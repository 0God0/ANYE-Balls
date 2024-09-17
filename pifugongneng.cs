using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ANYE_Balls
{
    public partial class pifugongneng : Form
    {
        public static string adbPath = "";
        string xmlpath = "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/ver.xml";
        //string localpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string localpath = @"C:\ver.xml";
        public pifugongneng()
        {
            InitializeComponent();
        }

        private void pifugongneng_Load(object sender, EventArgs e)
        {

        }
        void ModifyXmlFile(string xmlFilePath)
        {
            string fileAttributeStart = "common/data/shopconfig.unity3d";
            try
            {
                // 加载XML文件
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFilePath);

                // 查找所有file属性值以指定字符串开头的item标签
                XmlNodeList itemList = doc.SelectNodes($"//item[starts-with(@file, '{fileAttributeStart}')]");

                // 输出找到的item数量
                Debug.WriteLine($"找到 {itemList.Count} 个 file 属性以 \"{fileAttributeStart}\" 开头的 item 标签。");

                // 移除找到的所有item标签
                foreach (XmlNode itemNode in itemList)
                {
                    Debug.WriteLine($"正在移除 item 标签：{itemNode.OuterXml}");
                    itemNode.ParentNode.RemoveChild(itemNode);
                }

                // 保存修改后的XML文件
                doc.Save(xmlFilePath);

                Debug.WriteLine($"已成功从 XML 文件中删除所有 file 属性以 \"{fileAttributeStart}\" 开头的 item 标签。");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"修改 XML 文件时出错：{ex.Message}");
            }
        }
        private void buttonqupi_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }

                if (!File.Exists(@"C:\ver.xml"))
                {
                    try
                    {
                        using (StreamWriter sw = File.CreateText(@"C:\ver.xml"))
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (!File.Exists(@"C:\push.bat"))
                {
                    try
                    {
                        using (FileStream fs = File.Create(@"C:\push.bat")) { };
                        File.WriteAllBytes(@"C:\push.bat", Properties.Resources.push);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                if (!File.Exists(@"C:\pull.bat"))
                {
                    try
                    {
                        using (FileStream fs = File.Create(@"C:\pull.bat")) { };
                        File.WriteAllBytes(@"C:\pull.bat", Properties.Resources.pull);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                var adbServer = new AdbServer();
                var result = adbServer.StartServer(@adbPath + "\\adb.exe", restartServerIfNewer: false);

                // 创建 AdbClient 实例
                var adbClient = new AdbClient();
                if (MainForm.choose == "MuMu模拟器")
                {
                    var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                    adbClient.Connect(endpoint);
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                    adbClient.Connect(endpoint);
                }
                var devices = adbClient.GetDevices();
                foreach (var device in devices)
                {
                    if (MainForm.choose == "MuMu模拟器")
                    {
                        if (device.ToString() == "127.0.0.1:16384")
                        {
                            var receiver = new ConsoleOutputReceiver();


                            try
                            {
                                Debug.WriteLine(adbPath);
                                // 修改本地的 XML 文件
                                adb("C:\\pull.bat", adbPath);
                                Thread.Sleep(2000);
                                ModifyXmlFile(localpath);
                                adb("C:\\push.bat", adbPath);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Error: {ex.Message}");
                            }
                            MessageBox.Show("去皮成功，若要恢复，点击恢复重上游戏或卸载游戏重装");
                        }
                        //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                    }
                    else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                    {
                        if (device.ToString() == "emulator-5554")
                        {

                            try
                            {
                                Debug.WriteLine(adbPath);
                                // 修改本地的 XML 文件
                                adb("C:\\pull.bat", adbPath);
                                Thread.Sleep(2000);
                                ModifyXmlFile(localpath);
                                adb("C:\\push.bat", adbPath);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Error: {ex.Message}");
                            }



                            MessageBox.Show("去皮成功，若要恢复，点击恢复重上游戏或卸载游戏重装");
                        }
                    }
                }



            }
            else
            {
                MessageBox.Show("请先获取模拟器！");
            }
        }
        void adb(string path, string adbpath)
        {
            // 创建一个新的进程启动信息
            ProcessStartInfo startInfo = new ProcessStartInfo();

            // 设置文件名为你的批处理文件路径
            startInfo.FileName = path;

            // 设置是否使用操作系统shell启动进程
            startInfo.UseShellExecute = false;

            // 设置重定向标准输出和错误输出
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            // 设置创建无窗口进程
            startInfo.CreateNoWindow = true;

            // 启动进程
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            // 等待进程完成
            process.WaitForExit();

            //Process.Start(path);
        }

        private void buttonqupihf_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }


                if (!File.Exists(@"C:\qphf.bat"))
                {
                    try
                    {
                        using (FileStream fs = File.Create(@"C:\qphf.bat")) { };
                        File.WriteAllBytes(@"C:\qphf.bat", Properties.Resources.qphf);
                    }
                    catch (Exception ex)
                    {
                    }
                }

                var adbServer = new AdbServer();
                var result = adbServer.StartServer(@adbPath + "\\adb.exe", restartServerIfNewer: false);

                // 创建 AdbClient 实例
                var adbClient = new AdbClient();
                if (MainForm.choose == "MuMu模拟器")
                {
                    var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                    adbClient.Connect(endpoint);
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                    adbClient.Connect(endpoint);
                }
                var devices = adbClient.GetDevices();
                foreach (var device in devices)
                {
                    if (MainForm.choose == "MuMu模拟器")
                    {
                        if (device.ToString() == "127.0.0.1:16384")
                        {
                            var receiver = new ConsoleOutputReceiver();


                            try
                            {
                                // 修改本地的 XML 文件
                                adb("C:\\qphf.bat", adbPath);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Error: {ex.Message}");
                            }
                            MessageBox.Show("去皮恢复成功，重上游戏或卸载游戏重装");
                        }
                        //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                    }
                    else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                    {
                        if (device.ToString() == "emulator-5554")
                        {

                            try
                            {
                                Debug.WriteLine(adbPath);
                                // 修改本地的 XML 文件
                                adb("C:\\qphf.bat", adbPath);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Error: {ex.Message}");
                            }



                            MessageBox.Show("去皮恢复成功，重上游戏或卸载游戏重装");
                        }
                    }
                }



            }
            else
            {
                MessageBox.Show("请先获取模拟器！");
            }
        }

        private void buttontmc_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }


            }
            if (!File.Exists(@"C:\jdcq.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\jdcq.bat")) { };
                    File.WriteAllBytes(@"C:\jdcq.bat", Properties.Resources.jdcq);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\lgwcq.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\lgwcq.bat")) { };
                    File.WriteAllBytes(@"C:\lgwcq.bat", Properties.Resources.lgwcq);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\wcq.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\wcq.bat")) { };
                    File.WriteAllBytes(@"C:\wcq.bat", Properties.Resources.wcq);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\dhlqcq.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\dhlqcq.bat")) { };
                    File.WriteAllBytes(@"C:\dhlqcq.bat", Properties.Resources.dhlqcq);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\jdtz"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\jdtz")) { };
                    File.WriteAllBytes(@"C:\jdtz", Properties.Resources.jdtz);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\jdts"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\jdts")) { };
                    File.WriteAllBytes(@"C:\jdts", Properties.Resources.jdts);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\jdsg"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\jdsg")) { };
                    File.WriteAllBytes(@"C:\jdsg", Properties.Resources.jdsg);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\lgwtz"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\lgwtz")) { };
                    File.WriteAllBytes(@"C:\lgwtz", Properties.Resources.lgwtz);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\lgwts"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\lgwts")) { };
                    File.WriteAllBytes(@"C:\lgwts", Properties.Resources.lgwts);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\lgwsg"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\lgwsg")) { };
                    File.WriteAllBytes(@"C:\lgwsg", Properties.Resources.lgwsg);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\wtz"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\wtz")) { };
                    File.WriteAllBytes(@"C:\wtz", Properties.Resources.wtz);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\wts"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\wts")) { };
                    File.WriteAllBytes(@"C:\wts", Properties.Resources.wts);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\wsg"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\lgwsg")) { };
                    File.WriteAllBytes(@"C:\lgwsg", Properties.Resources.lgwsg);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\dhlqtz"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\dhlqtz")) { };
                    File.WriteAllBytes(@"C:\dhlqtz", Properties.Resources.dhlqtz);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\dhlqts"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\dhlqts")) { };
                    File.WriteAllBytes(@"C:\dhlqts", Properties.Resources.dhlqts);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\dhlqsg"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\dhlqsg")) { };
                    File.WriteAllBytes(@"C:\dhlqsg", Properties.Resources.dhlqsg);
                }
                catch (Exception ex)
                {
                }
            }


            // 创建 AdbClient 实例
            var adbClient = new AdbClient();
            if (MainForm.choose == "MuMu模拟器")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                adbClient.Connect(endpoint);
            }
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                adbClient.Connect(endpoint);
            }
            var devices = adbClient.GetDevices();
            foreach (var device in devices)
            {
                if (MainForm.choose == "MuMu模拟器")
                {
                    if (device.ToString() == "127.0.0.1:16384")
                    {
                        var receiver = new ConsoleOutputReceiver();


                        try
                        {
                            Debug.WriteLine(adbPath);
                            if (comboBoxtmc.SelectedItem.ToString() == "经典透明刺")
                            {
                                adb(@"C:\jdcq.bat", adbPath);
                            }
                            else if (comboBoxtmc.SelectedItem.ToString() == "蓝光无")
                            {
                                adb(@"C:\lgwcq.bat", adbPath);
                            }
                            else if (comboBoxtmc.SelectedItem.ToString() == "无")
                            {
                                adb(@"C:\wcq.bat", adbPath);
                            }
                            else if (comboBoxtmc.SelectedItem.ToString() == "多环蓝圈")
                            {
                                adb(@"C:\dhlqcq.bat", adbPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }
                        MessageBox.Show("透明刺启用成功，请大退重新进入游戏");
                    }
                    //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    if (device.ToString() == "emulator-5554")
                    {

                        try
                        {
                            Debug.WriteLine(adbPath);
                            if (comboBoxtmc.SelectedItem.ToString() == "经典透明刺")
                            {
                                adb(@"C:\jdcq.bat", adbPath);
                            }
                            else if (comboBoxtmc.SelectedItem.ToString() == "蓝光无")
                            {
                                adb(@"C:\lgwcq.bat", adbPath);
                            }
                            else if (comboBoxtmc.SelectedItem.ToString() == "无")
                            {
                                adb(@"C:\wcq.bat", adbPath);
                            }
                            else if (comboBoxtmc.SelectedItem.ToString() == "多环蓝圈")
                            {
                                adb(@"C:\dhlqcq.bat", adbPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }



                        MessageBox.Show("透明刺启用成功，请大退重新进入游戏");
                    }
                }

            }
        }

        private void buttontmchf_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }


            }

            if (!File.Exists(@"C:\hycq.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\hycq.bat")) { };
                    File.WriteAllBytes(@"C:\hycq.bat", Properties.Resources.hycq);
                }
                catch (Exception ex)
                {
                }
            }

            // 创建 AdbClient 实例
            var adbClient = new AdbClient();
            if (MainForm.choose == "MuMu模拟器")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                adbClient.Connect(endpoint);
            }
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                adbClient.Connect(endpoint);
            }
            var devices = adbClient.GetDevices();
            foreach (var device in devices)
            {
                if (MainForm.choose == "MuMu模拟器")
                {
                    if (device.ToString() == "127.0.0.1:16384")
                    {
                        var receiver = new ConsoleOutputReceiver();


                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\hycq.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }
                        MessageBox.Show("透明刺还原成功，请大退重新进入游戏");
                    }
                    //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    if (device.ToString() == "emulator-5554")
                    {

                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\hycq.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }



                        MessageBox.Show("透明刺还原成功，请大退重新进入游戏");
                    }
                }

            }
        }

        private void buttonqlw_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }
            }

            if (!File.Exists(@"C:\qlw.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\qlw.bat")) { };
                    File.WriteAllBytes(@"C:\qlw.bat", Properties.Resources.qlw);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\qlw"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\qlw")) { };
                    File.WriteAllBytes(@"C:\qlw", Properties.Resources.qlwwj);
                }
                catch (Exception ex)
                {
                }
            }

            // 创建 AdbClient 实例
            var adbClient = new AdbClient();
            if (MainForm.choose == "MuMu模拟器")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                adbClient.Connect(endpoint);
            }
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                adbClient.Connect(endpoint);
            }
            var devices = adbClient.GetDevices();
            foreach (var device in devices)
            {
                if (MainForm.choose == "MuMu模拟器")
                {
                    if (device.ToString() == "127.0.0.1:16384")
                    {
                        var receiver = new ConsoleOutputReceiver();


                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\qlw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }
                        MessageBox.Show("去蓝雾成功，请大退重新进入游戏");
                    }
                    //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    if (device.ToString() == "emulator-5554")
                    {

                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\qlw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }



                        MessageBox.Show("去蓝雾成功，请大退重新进入游戏");
                    }
                }

            }
        }

        private void buttonqlwhf_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }
            }

            if (!File.Exists(@"C:\hylw.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\hylw.bat")) { };
                    File.WriteAllBytes(@"C:\hylw.bat", Properties.Resources.hylw);
                }
                catch (Exception ex)
                {
                }
            }


            // 创建 AdbClient 实例
            var adbClient = new AdbClient();
            if (MainForm.choose == "MuMu模拟器")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                adbClient.Connect(endpoint);
            }
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                adbClient.Connect(endpoint);
            }
            var devices = adbClient.GetDevices();
            foreach (var device in devices)
            {
                if (MainForm.choose == "MuMu模拟器")
                {
                    if (device.ToString() == "127.0.0.1:16384")
                    {
                        var receiver = new ConsoleOutputReceiver();


                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\hylw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }
                        MessageBox.Show("还原蓝雾成功，请大退重新进入游戏");
                    }
                    //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    if (device.ToString() == "emulator-5554")
                    {

                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\hylw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }



                        MessageBox.Show("还原蓝雾成功，请大退重新进入游戏");
                    }
                }

            }
        }

        private void buttonqhw_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }
            }

            if (!File.Exists(@"C:\qhw.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\qhw.bat")) { };
                    File.WriteAllBytes(@"C:\qhw.bat", Properties.Resources.qhw);
                }
                catch (Exception ex)
                {
                }
            }
            if (!File.Exists(@"C:\qhw"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\qhw")) { };
                    File.WriteAllBytes(@"C:\qhw", Properties.Resources.qhwwj);
                }
                catch (Exception ex)
                {
                }
            }

            // 创建 AdbClient 实例
            var adbClient = new AdbClient();
            if (MainForm.choose == "MuMu模拟器")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                adbClient.Connect(endpoint);
            }
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                adbClient.Connect(endpoint);
            }
            var devices = adbClient.GetDevices();
            foreach (var device in devices)
            {
                if (MainForm.choose == "MuMu模拟器")
                {
                    if (device.ToString() == "127.0.0.1:16384")
                    {
                        var receiver = new ConsoleOutputReceiver();


                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\qhw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }
                        MessageBox.Show("去红雾成功，请大退重新进入游戏");
                    }
                    //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    if (device.ToString() == "emulator-5554")
                    {

                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\qhw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }



                        MessageBox.Show("去红雾成功，请大退重新进入游戏");
                    }
                }

            }
        }

        private void buttonqhwhf_Click(object sender, EventArgs e)
        {
            string processName = "MuMuPlayer";
            if (MainForm.choose == "MuMu模拟器")
            {
                processName = "MuMuPlayer";
            }
            else if (MainForm.choose == "雷电模拟器5")
            {
                processName = "dnplayer";
            }
            else if (MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
            }
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                Process targetProcess = processes[0];
                string processFilePath = targetProcess.MainModule.FileName;
                string processDirectory = Path.GetDirectoryName(processFilePath);
                adbPath = processDirectory;

                string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                string currentPath2 = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
                if (!currentPath.Contains(adbPath))
                {
                    string newPath = currentPath + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.Machine);
                    Debug.WriteLine("ADB路径已成功添加到系统环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于系统环境变量中。");
                }
                if (!currentPath2.Contains(adbPath))
                {
                    string newPath = currentPath2 + ";" + adbPath;
                    Environment.SetEnvironmentVariable("PATH", newPath, EnvironmentVariableTarget.User);
                    Debug.WriteLine("ADB路径已成功添加到用户环境变量。");
                }
                else
                {
                    Debug.WriteLine("ADB路径已经存在于用户环境变量中。");
                }
            }

            if (!File.Exists(@"C:\hyhw.bat"))
            {
                try
                {
                    using (FileStream fs = File.Create(@"C:\hyhw.bat")) { };
                    File.WriteAllBytes(@"C:\hyhw.bat", Properties.Resources.hylw);
                }
                catch (Exception ex)
                {
                }
            }


            // 创建 AdbClient 实例
            var adbClient = new AdbClient();
            if (MainForm.choose == "MuMu模拟器")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16384);
                adbClient.Connect(endpoint);
            }
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
                adbClient.Connect(endpoint);
            }
            var devices = adbClient.GetDevices();
            foreach (var device in devices)
            {
                if (MainForm.choose == "MuMu模拟器")
                {
                    if (device.ToString() == "127.0.0.1:16384")
                    {
                        var receiver = new ConsoleOutputReceiver();


                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\hyhw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }
                        MessageBox.Show("还原红雾成功，请大退重新进入游戏");
                    }
                    //adbClient.Disconnect(new DnsEndPoint("127.0.0.1", 16384));
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    if (device.ToString() == "emulator-5554")
                    {

                        try
                        {
                            Debug.WriteLine(adbPath);
                            adb(@"C:\hyhw.bat", adbPath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Error: {ex.Message}");
                        }



                        MessageBox.Show("还原红雾成功，请大退重新进入游戏");
                    }
                }

            }
        }
    }
}
