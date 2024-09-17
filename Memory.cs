using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ANYE_Balls
{
    public class Memory
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll")]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);
        static bool find = false;
        //const int MEM_SIZE = 0x4096;
        
        //private static List<long> ScanPatternInRange(IntPtr hProcess, byte[] pattern, int pLen, long startAddress, long endAddress)
        //{
        //    List<long> foundAddresses = new List<long>();
        //    const int MEM_SIZE = 131072;

        //    byte[] mem = new byte[MEM_SIZE];
        //    MEMORY_BASIC_INFORMATION mbi;
        //    long currentAddress = startAddress;

        //    try
        //    {
        //        while (currentAddress < endAddress)
        //        {
        //            VirtualQueryEx(hProcess, (IntPtr)currentAddress, out mbi, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

        //            if (mbi.RegionSize.ToInt64() <= 0) break;
        //            if (mbi.State != 0x1000 || mbi.RegionSize.ToInt64() <= 0)
        //            {
        //                currentAddress += MEM_SIZE; // Move to the next address
        //                continue;
        //            }

        //            long regionStart = (long)mbi.BaseAddress;
        //            long regionEnd = regionStart + mbi.RegionSize.ToInt64();

        //            // Ensure that the current region is within the specified range
        //            if (regionStart < startAddress)
        //            {
        //                currentAddress = regionEnd;
        //                continue;
        //            }

        //            // Adjust the region end if it exceeds the specified end address
        //            if (regionEnd > endAddress)
        //            {
        //                regionEnd = endAddress;
        //            }

        //            //Debug.WriteLine("Searching in region: " + regionStart.ToString("X") + " - " + regionEnd.ToString("X"));

        //            for (long memIndex = regionStart; memIndex < regionEnd; memIndex += MEM_SIZE)
        //            {
        //                long beginAddress = memIndex;
        //                ReadProcessMemory(hProcess, ((IntPtr)beginAddress), mem, MEM_SIZE, out _);
        //                List<int> offsets = SundaySearch(mem, MEM_SIZE, pattern, pLen);
        //                foreach (int offset in offsets)
        //                {
        //                    lock (foundAddresses)
        //                    {
        //                        foundAddresses.Add(beginAddress + offset);
        //                    }
        //                    //Debug.WriteLine("Address: " + (beginAddress + offset).ToString("X"));
        //                }
        //            }

        //            currentAddress = regionEnd;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Exception occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        Array.Clear(mem, 0, mem.Length);
        //        GC.Collect();
        //    }

        //    return foundAddresses;
        //}
        

        
        
        private static List<long> ScanPatternInRange(IntPtr hProcess, byte[] pattern, int pLen, long startAddress, long endAddress)
        {
            List<long> foundAddresses = new List<long>();
            const int MEM_SIZE = 65536;
            int MAX_THREADS = Environment.ProcessorCount; // 定义最大并发线程数
            SemaphoreSlim semaphore = new SemaphoreSlim(MAX_THREADS);


            MEMORY_BASIC_INFORMATION mbi;
            long currentAddress = startAddress;

            try
            {
                List<Task> tasks = new List<Task>();

                while (currentAddress < endAddress)
                {
                    VirtualQueryEx(hProcess, (IntPtr)currentAddress, out mbi, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

                    if (mbi.RegionSize.ToInt64() <= 0) break;
                    if (mbi.State != 0x1000 || mbi.RegionSize.ToInt64() <= 0)
                    {
                        currentAddress += mbi.RegionSize.ToInt64(); // 移动到下一个区域
                        continue;
                    }

                    long regionStart = (long)mbi.BaseAddress;
                    long regionEnd = regionStart + mbi.RegionSize.ToInt64();

                    // 确保当前区域在指定范围内
                    if (regionStart < startAddress)
                    {
                        currentAddress = regionEnd;
                        continue;
                    }

                    // 如果区域结束地址超过指定的结束地址，则调整区域结束地址
                    if (regionEnd > endAddress)
                    {
                        regionEnd = endAddress;
                    }

                    // 创建一个任务来搜索这个内存区域
                    long regionStartCopy = regionStart;
                    long regionEndCopy = regionEnd;
                    //tasks.Add(Task.Run(() =>
                    //{
                    //    byte[] localMem = new byte[MEM_SIZE]; // 每个任务使用局部内存缓冲区
                    //    for (long memIndex = regionStartCopy; memIndex < regionEndCopy; memIndex += MEM_SIZE)
                    //    {
                    //        long beginAddress = memIndex;
                    //        ReadProcessMemory(hProcess, (IntPtr)beginAddress, localMem, MEM_SIZE, out _);
                    //        List<int> offsets = SundaySearch(localMem, MEM_SIZE, pattern, pLen);
                    //        foreach (int offset in offsets)
                    //        {
                    //            lock (foundAddresses)
                    //            {
                    //                foundAddresses.Add(beginAddress + offset);
                    //            }
                    //        }
                    //    }
                    //}));

                    tasks.Add(Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            byte[] localMem = new byte[MEM_SIZE]; 
                            for (long memIndex = regionStartCopy; memIndex < regionEndCopy; memIndex += MEM_SIZE)
                            {
                                long beginAddress = memIndex;
                                ReadProcessMemory(hProcess, (IntPtr)beginAddress, localMem, MEM_SIZE, out _);
                                List<int> offsets = SundaySearch(localMem, MEM_SIZE, pattern, pLen);
                                foreach (int offset in offsets)
                                {
                                    lock (foundAddresses)
                                    {
                                        foundAddresses.Add(beginAddress + offset);
                                    }
                                }
                            }
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    }));


                    currentAddress = regionEnd;
                }

                // 等待所有任务完成
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception occurred: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }

            return foundAddresses;
        }

        

        //原
        //private static List<long> ScanPatternInRange(IntPtr hProcess, byte[] pattern, int pLen, long startAddress, long endAddress)
        //{
        //    bool find = false;
        //    List<long> foundAddresses = new List<long>();
        //    const int MEM_SIZE = 4096 * 16;

        //    MEMORY_BASIC_INFORMATION mbi;
        //    long currentAddress = startAddress;

        //    try
        //    {
        //        List<Task> tasks = new List<Task>();

        //        while (currentAddress < endAddress)
        //        {
        //            VirtualQueryEx(hProcess, (IntPtr)currentAddress, out mbi, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

        //            if (mbi.RegionSize.ToInt64() <= 0) break;
        //            if (mbi.State != 0x1000 || mbi.RegionSize.ToInt64() <= 0)
        //            {
        //                currentAddress += mbi.RegionSize.ToInt64();
        //                continue;
        //            }

        //            long regionStart = (long)mbi.BaseAddress;
        //            long regionEnd = regionStart + mbi.RegionSize.ToInt64();

        //            // 确保当前区域在指定范围内
        //            if (regionStart < startAddress)
        //            {
        //                currentAddress = regionEnd;
        //                continue;
        //            }

        //            // 如果区域结束地址超过指定的结束地址，则调整区域结束地址
        //            if (regionEnd > endAddress)
        //            {
        //                regionEnd = endAddress;
        //            }

        //            // 创建一个任务来搜索这个内存区域
        //            long regionStartCopy = regionStart;
        //            long regionEndCopy = regionEnd;
        //            tasks.Add(Task.Run(() =>
        //            {
        //                byte[] localMem = new byte[MEM_SIZE]; // 每个任务使用局部内存缓冲区
        //                for (long memIndex = regionStartCopy; memIndex < regionEndCopy; memIndex += MEM_SIZE)
        //                {
        //                    long beginAddress = memIndex;
        //                    ReadProcessMemory(hProcess, (IntPtr)beginAddress, localMem, MEM_SIZE, out _);
        //                    List<int> offsets = SundaySearch(localMem, MEM_SIZE, pattern, pLen);
        //                    foreach (int offset in offsets)
        //                    {
        //                        lock (foundAddresses)
        //                        {
        //                            foundAddresses.Add(beginAddress + offset);

        //                        }


        //                        //foundAddresses.Add(beginAddress + offset);
        //                    }

        //                }
        //            }));

        //            currentAddress = regionEnd;
        //        }

        //        // 等待所有任务完成
        //        Task.WaitAll(tasks.ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Exception occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }

        //    return foundAddresses;
        //}


        //private static List<long> ScanPatternInRange(IntPtr hProcess, byte[] pattern, int pLen, long startAddress, long endAddress)
        //{
        //    List<long> foundAddresses = new List<long>();
        //    const int MEM_SIZE = 4096 * 6;

        //    MEMORY_BASIC_INFORMATION mbi;
        //    long currentAddress = startAddress;

        //    try
        //    {
        //        int MAX_CONCURRENT_TASKS = Environment.ProcessorCount / 2 + 3;
        //        //int MAX_CONCURRENT_TASKS = 6;
        //        SemaphoreSlim semaphore = new SemaphoreSlim(MAX_CONCURRENT_TASKS);

        //        List<Task> tasks = new List<Task>();
        //        List<bool> flag = new List<bool>();
        //        int i = 0;

        //        while (currentAddress < endAddress)
        //        {
        //            //Debug.WriteLine(currentAddress.ToString("X"));
        //            VirtualQueryEx(hProcess, (IntPtr)currentAddress, out mbi, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));
        //            if (mbi.RegionSize.ToInt64() <= 0) break;
        //            if (mbi.State != 0x1000 || mbi.RegionSize.ToInt64() <= 0)
        //            {
        //                currentAddress += mbi.RegionSize.ToInt64();
        //                continue;
        //            }

        //            long regionStart = (long)mbi.BaseAddress;
        //            long regionEnd = regionStart + mbi.RegionSize.ToInt64();

        //            if (regionStart < startAddress)
        //            {
        //                currentAddress = regionEnd;
        //                continue;
        //            }

        //            if (regionEnd > endAddress)
        //            {
        //                regionEnd = endAddress;
        //            }

        //            long regionStartCopy = regionStart;
        //            long regionEndCopy = regionEnd;
        //            tasks.Add(Task.Run(async () =>
        //            {
        //                long start = regionStartCopy;
        //                long end = regionEndCopy;
        //                flag.Add(false);
        //                await semaphore.WaitAsync();
        //                try
        //                {
        //                    byte[] localMem = new byte[MEM_SIZE];
        //                    for (long memIndex = start; memIndex < end; memIndex += MEM_SIZE)
        //                    {
        //                        if (flag[i] == true)
        //                        {
        //                            break;
        //                        }
        //                        long beginAddress = memIndex;
        //                        ReadProcessMemory(hProcess, (IntPtr)beginAddress, localMem, MEM_SIZE, out _);
        //                        List<int> offsets = SundaySearch(localMem, MEM_SIZE, pattern, pLen);
        //                        foreach (int offset in offsets)
        //                        {
        //                            //foundAddresses.Add(beginAddress + offset);
        //                            //flag[i] = true;
        //                            lock (foundAddresses)
        //                            {
        //                                foundAddresses.Add(beginAddress + offset);
        //                                flag[i] = true;
        //                            }
        //                        }

        //                    }

        //                }
        //                finally
        //                {
        //                    semaphore.Release();
        //                }
        //                i++;
        //            }));

        //            currentAddress = regionEnd;
        //        }
        //        Task.WaitAll(tasks.ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Exception occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }

        //    return foundAddresses;
        //}


        //private static List<long> ScanPatternInRange2(IntPtr hProcess, byte[] pattern, int pLen, long startAddress, long endAddress)
        //{
        //    List<long> foundAddresses = new List<long>();
        //    const int MEM_SIZE = 4096 * 8;

        //    MEMORY_BASIC_INFORMATION mbi;
        //    long currentAddress = startAddress;

        //    try
        //    {
        //        //int MAX_CONCURRENT_TASKS = Environment.ProcessorCount / 3 + 1;
        //        int MAX_CONCURRENT_TASKS = 10;
        //        SemaphoreSlim semaphore = new SemaphoreSlim(MAX_CONCURRENT_TASKS);

        //        List<Task> tasks = new List<Task>();
        //        List<bool> flag = new List<bool>();
        //        int i = 0;

        //        while (currentAddress < endAddress)
        //        {
        //            VirtualQueryEx(hProcess, (IntPtr)currentAddress, out mbi, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

        //            if (mbi.RegionSize.ToInt64() <= 0) break;
        //            if (mbi.State != 0x1000 || mbi.RegionSize.ToInt64() <= 0)
        //            {
        //                currentAddress += mbi.RegionSize.ToInt64();
        //                continue;
        //            }

        //            long regionStart = (long)mbi.BaseAddress;
        //            long regionEnd = regionStart + mbi.RegionSize.ToInt64();

        //            if (regionStart < startAddress)
        //            {
        //                currentAddress = regionEnd;
        //                continue;
        //            }

        //            if (regionEnd > endAddress)
        //            {
        //                regionEnd = endAddress;
        //            }

        //            long regionStartCopy = regionStart;
        //            long regionEndCopy = regionEnd;
        //            tasks.Add(Task.Run(async () =>
        //            {
        //                flag.Add(false);
        //                await semaphore.WaitAsync();
        //                try
        //                {
        //                    byte[] localMem = new byte[MEM_SIZE];
        //                    for (long memIndex = regionStartCopy; memIndex < regionEndCopy; memIndex += MEM_SIZE)
        //                    {
        //                        if (flag[i] == true)
        //                        {
        //                            break;
        //                        }
        //                        long beginAddress = memIndex;
        //                        ReadProcessMemory(hProcess, (IntPtr)beginAddress, localMem, MEM_SIZE, out _);
        //                        List<int> offsets = SundaySearch(localMem, MEM_SIZE, pattern, pLen);
        //                        foreach (int offset in offsets)
        //                        {
        //                            //foundAddresses.Add(beginAddress + offset);
        //                            //flag[i] = true;
        //                            lock (foundAddresses)
        //                            {
        //                                foundAddresses.Add(beginAddress + offset);
        //                                flag[i] = true;
        //                            }
        //                        }

        //                    }

        //                }
        //                finally
        //                {
        //                    semaphore.Release();
        //                }
        //                i++;
        //            }));

        //            currentAddress = regionEnd;
        //        }
        //        Task.WaitAll(tasks.ToArray());
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Exception occurred: " + ex.Message);
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }

        //    return foundAddresses;
        //}

        private static List<long> GetMemoryIndices(long start, long end, int blockSize)
        {
            List<long> indices = new List<long>();
            for (long index = start; index < end; index += blockSize)
            {
                indices.Add(index);
            }
            return indices;
        }
        public static List<int> SundaySearch(byte[] target, int tLen, byte[] pattern, int pLen)
        {
            int[] shift = new int[256];
            for (int i = 0; i < 256; i++)
            {
                shift[i] = pLen + 1;
            }
            for (int i = 0; i < pLen; i++)
            {
                shift[pattern[i]] = pLen - i;
            }

            List<int> indexes = new List<int>();
            int index = 0;
            while (index <= tLen - pLen)
            {
                int j = 0;
                while (j < pLen && target[index + j] == pattern[j])
                {
                    j++;
                }

                if (j == pLen)
                {
                    indexes.Add(index);
                }

                if (index + pLen >= tLen)
                {
                    break;
                }

                index += shift[target[index + pLen]];
            }

            return indexes;
        }







        //原
        public static List<long> ScanPatternParallel(IntPtr hProcess, byte[] pattern, int pLen)
        {
            find = false;
            List<long> foundAddresses = new List<long>();
            double totalPhysicalMemoryGB = 16;

            long bgadd, endadd;
            try
            {
                Microsoft.VisualBasic.Devices.ComputerInfo computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
                totalPhysicalMemoryGB = computerInfo.TotalPhysicalMemory / 1024 / 1024 / 1024; 
            }
            catch (Exception e)
            {
                
            }
            bgadd = 0x00000000;
            endadd = 0xffffffff;
            
            //if (totalPhysicalMemoryGB <= 30)
            //{
            //    bgadd = 0x00401000;
            //    endadd = 0x1000000000;
            //}
            //else if (totalPhysicalMemoryGB > 30)
            //{
            //    bgadd = 0x0;
            //    endadd = 0x5000000000;
            //}

            //int NUM_THREADS = Environment.ProcessorCount;

            //Task[] tasks = new Task[NUM_THREADS];

            //for (int i = 0; i < NUM_THREADS; i++)
            //{
            //    int threadId = i;
            //    tasks[i] = Task.Run(() =>
            //    {
            //        if (find)
            //        {

            //        }
            //        else
            //        {
            //            long startAddress = (bgadd + (endadd - bgadd) / NUM_THREADS * threadId);
            //            long endAddress = (bgadd + (endadd - bgadd) / NUM_THREADS * (threadId + 1));


            //            List<long> addresses = ScanPatternInRange(hProcess, pattern, pLen, startAddress, endAddress);


            //            lock (foundAddresses)
            //            {
            //                foundAddresses.AddRange(addresses);

            //            }
            //        }

            //    });
            //}


            //Task.WaitAll(tasks);

            //return foundAddresses;

            return ScanPatternInRange(hProcess, pattern, pLen, bgadd, endadd);
        }


        //public static List<long> ScanPatternParallel2(IntPtr hProcess, byte[] pattern, int pLen)
        //{
        //    find = false;
        //    List<long> foundAddresses = new List<long>();
        //    double totalPhysicalMemoryGB = 16;

        //    long bgadd, endadd;
        //    try
        //    {
        //        Microsoft.VisualBasic.Devices.ComputerInfo computerInfo = new Microsoft.VisualBasic.Devices.ComputerInfo();
        //        totalPhysicalMemoryGB = computerInfo.TotalPhysicalMemory / 1024 / 1024 / 1024;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    MessageBox.Show(totalPhysicalMemoryGB.ToString());
        //    bgadd = 0x00401000;
        //    endadd = 0x1000000000;
        //    bgadd = MainForm.kaishi;
        //    endadd = MainForm.jieshu;
        //    //if (totalPhysicalMemoryGB <= 30)
        //    //{
        //    //    bgadd = 0x00401000;
        //    //    endadd = 0x1000000000;
        //    //}
        //    //else if (totalPhysicalMemoryGB > 30)
        //    //{
        //    //    bgadd = 0x0;
        //    //    endadd = 0x3000000000;
        //    //}

        //    //int NUM_THREADS = Environment.ProcessorCount;

        //    //Task[] tasks = new Task[NUM_THREADS];

        //    //for (int i = 0; i < NUM_THREADS; i++)
        //    //{
        //    //    int threadId = i;
        //    //    tasks[i] = Task.Run(() =>
        //    //    {
        //    //        if (find)
        //    //        {

        //    //        }
        //    //        else
        //    //        {
        //    //            long startAddress = (bgadd + (endadd - bgadd) / NUM_THREADS * threadId);
        //    //            long endAddress = (bgadd + (endadd - bgadd) / NUM_THREADS * (threadId + 1));


        //    //            List<long> addresses = ScanPatternInRange(hProcess, pattern, pLen, startAddress, endAddress);


        //    //            lock (foundAddresses)
        //    //            {
        //    //                foundAddresses.AddRange(addresses);

        //    //            }
        //    //        }

        //    //    });
        //    //}


        //    //Task.WaitAll(tasks);

        //    //return foundAddresses;

        //    return ScanPatternInRange2(hProcess, pattern, pLen, bgadd, endadd);
        //}


    }
}
