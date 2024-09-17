using Newtonsoft.Json.Linq;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANYE_Balls
{
    public partial class qitagongneng : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CreateProcess(
        string lpApplicationName,
        string lpCommandLine,
        IntPtr lpProcessAttributes,
        IntPtr lpThreadAttributes,
        bool bInheritHandles,
        uint dwCreationFlags,
        IntPtr lpEnvironment,
        string lpCurrentDirectory,
        ref STARTUPINFO lpStartupInfo,
        out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr CreateWindowEx(
        uint dwExStyle,
        string lpClassName,
        string lpWindowName,
        uint dwStyle,
        int x, int y, int nWidth, int nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DestroyWindow(IntPtr hWnd);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct STARTUPINFO
        {
            public int cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        const uint CREATE_NO_WINDOW = 0x08000000;
        const uint STARTF_USESHOWWINDOW = 0x00000001;
        const short SW_HIDE = 0;
        const uint STARTF_USESTDHANDLES = 0x00000100;
        const uint WS_POPUP = 0x80000000;
        const uint WS_VISIBLE = 0x10000000;
        const uint WS_EX_TOOLWINDOW = 0x00000080;
        public qitagongneng()
        {
            InitializeComponent();
        }

        private void buttonshiye_Click(object sender, EventArgs e)
        {

            string tempFilePath = Path.Combine(Path.GetTempPath(), "System32.dll");
            string tempFilePath2 = Path.Combine(Path.GetTempPath(), "ExuiKrnln_Win32.lib");
            if (Process.GetProcessesByName("System32.dll").Length > 0)
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName("System32.dll");
                    foreach (Process process in processes)
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {

                }
                File.WriteAllBytes(tempFilePath, Properties.Resources.ANYE解断);
                File.WriteAllBytes(tempFilePath2, Properties.Resources.ExuiKrnln_Win32);

                new Thread(new ParameterizedThreadStart(RunEmbeddedExe)).Start(tempFilePath);
            }
            else
            {
                File.WriteAllBytes(tempFilePath, Properties.Resources.ANYE解断);
                File.WriteAllBytes(tempFilePath2, Properties.Resources.ExuiKrnln_Win32);

                new Thread(new ParameterizedThreadStart(RunEmbeddedExe)).Start(tempFilePath);
            }
            //// 加载二进制数据为程序集
            //Assembly assembly = Assembly.Load(Properties.Resources.ANYE解断);

            //// 获取入口点方法
            //MethodInfo entryPoint = assembly.EntryPoint;
            //if (entryPoint != null)
            //{
            //    // 执行入口点方法
            //    entryPoint.Invoke(null, new object[] { new string[] { } });
            //}
            //else
            //{

            //}


        }
        static void RunEmbeddedExe(object obj)
        {
            string exePath = obj.ToString();
            PROCESS_INFORMATION procInfo = new PROCESS_INFORMATION();
            STARTUPINFO startInfo = new STARTUPINFO();
            startInfo.cb = Marshal.SizeOf(startInfo);

            bool success = CreateProcess(
                exePath,
                null,
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                0,
                IntPtr.Zero,
                null,
                ref startInfo,
                out procInfo);

            if (!success)
            {
                Debug.WriteLine("失败");
            }

            WaitForSingleObject(procInfo.hProcess, 0xFFFFFFFF);

            CloseHandle(procInfo.hProcess);
            CloseHandle(procInfo.hThread);
            try
            {
                File.Delete(exePath);
            }
            catch { }
        }

        private void qitagongneng_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string URL = "https://webpay-api.battleofballs.com/api/player/" + textboxid.Text;
            using (WebClient client = new WebClient())
            {
                try
                {
                    string response = client.DownloadString(URL);
                    Debug.WriteLine(response);
                    JObject jsonObject = JObject.Parse(response);
                    if (jsonObject["code"].ToString() == "0")
                    {
                        int uid = (int)jsonObject["data"]["uid"];
                        string name = (string)jsonObject["data"]["name"];
                        textboxpaiming.Text = uid.ToString();
                        textboxmingcheng.Text = name;
                    }
                    else
                    {
                        MessageBox.Show("查询失败，请输入正确的游戏ID");
                    }

                }
                catch (WebException ex)
                {
                    MessageBox.Show("查询失败，请输入ID，若已输入ID，请检查网络连接");
                }
            }
        }
    }
}
