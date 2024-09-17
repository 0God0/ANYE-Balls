using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ANYE_Balls
{
    public partial class yanzhengck : Form
    {

        public Socket clientSocket;
        public IPAddress ipAddress;
        public int port;
        public IPEndPoint remoteEndPoint;
        public static string filePath = "C:\\anye.json";
        bool flag = false;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int WS_EX_LAYERED = 0x80000;
        public const int LWA_COLORKEY = 0x1;
        public const int LWA_ALPHA = 0x2;
        public yanzhengck()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
            tabPage1.BackColor = Color.Transparent;
            SetWindowTransparent(tabControl1);
            // 初始化 TabControl

            //SetWindowTransparent(tabPage5);
        }
        private void SetWindowTransparent(Control control)
        {
            int exStyle = GetWindowLong(control.Handle, GWL_EXSTYLE);
            SetWindowLong(control.Handle, GWL_EXSTYLE, exStyle | WS_EX_TRANSPARENT | WS_EX_LAYERED);
            SetLayeredWindowAttributes(control.Handle, 0, 128, LWA_ALPHA);
        }
        private void yanzhengck_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Fiddler");
            if (processes.Length > 0)
            {
                System.Environment.Exit(0);
            }
            try
            {
                WebRequest request = WebRequest.Create("http://www.baidu.com");

                IWebProxy proxy = request.Proxy;
                if (proxy != null)
                {
                    if (proxy.GetProxy(request.RequestUri) != null)
                    {
                        MessageBox.Show("请关闭vpn或fiddler等代理网络工具。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(0);
                    }
                    //result = Send(Encrypt("代理|" + clientSocket.RemoteEndPoint.ToString() + "|" + getjiqima()));

                }

            }
            catch (Exception ex)
            {

            }
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath)) { }
                string jsonf = File.ReadAllText(filePath);
                JObject root = new JObject();
                jsonf = root.ToString();
                File.WriteAllText(filePath, jsonf);
            }
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipAddress = IPAddress.Parse("27.25.156.233");
            //ipAddress = IPAddress.Parse("127.0.0.1");
            port = 25101;
            remoteEndPoint = new IPEndPoint(ipAddress, port);
            try
            {
                Debug.WriteLine("开始 {0}", clientSocket.RemoteEndPoint);
                clientSocket.Connect(remoteEndPoint);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    //string result = Send(Encrypt("调试|" + clientSocket.RemoteEndPoint.ToString() + "|" + getjiqima()));
                    //System.Environment.Exit(0);
                }
                Debug.WriteLine("已连接到服务器 {0}", clientSocket.RemoteEndPoint);
                string res = Decrypt(Send(Encrypt("获取信息")));
                if (res == "正常")
                {

                }
                if (res == "")
                {
                    MessageBox.Show("服务器关闭。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(0);
                }
                if (res == "禁止使用")
                {
                    buttondenglu.Text = "禁 止 登 录";
                    buttondenglu.Enabled = false;
                    buttonzhuce.Enabled = false;
                    buttonchongzhi.Enabled = false;
                }
                if (res == "强制更新")
                {
                    MessageBox.Show("该版本需要更新，本版本已经禁止登录，点击确定，看公告获取最新版本。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttondenglu.Enabled = false;
                    buttonzhuce.Enabled = false;
                    buttonchongzhi.Enabled = false;
                }
                if (res == "维护")
                {
                    MessageBox.Show("服务器维护中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Environment.Exit(0);
                }
                if (res == "拉黑")
                {
                    MessageBox.Show("您已被拉黑。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(0);
                }
                if (Json.checkjson2("zhanghao") && Json.checkjson2("mima") && Json.checkjson2("jizhumima"))
                {
                    if (Json.readjson2("jizhumima") == "true")
                    {
                        textBoxzhanghao.Text = Json.readjson2("zhanghao");
                        textBoxmima.Text = Json.readjson2("mima");
                        checkBoxjizhumima.Checked = true;
                    }
                }
                if (Json.checkjson2("zhanghao") && Json.checkjson2("mima") && Json.checkjson2("zidongdenglu"))
                {
                    if (Json.readjson2("zidongdenglu") == "true")
                    {
                        textBoxzhanghao.Text = Json.readjson2("zhanghao");
                        textBoxmima.Text = Json.readjson2("mima");
                        checkBoxjizhumima.Checked = true;
                        string result = Send(Encrypt("登录|" + textBoxzhanghao.Text + "|" + textBoxmima.Text + "|" + getjiqima() + "|" + getjiqima2()));
                        if (Decrypt(result) == "账号不存在")
                        {
                            MessageBox.Show("账号不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Decrypt(result) == "密码错误")
                        {
                            MessageBox.Show("密码错误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Decrypt(result) == "卡密到期")
                        {
                            MessageBox.Show("卡密已到期。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Decrypt(result) == "信息不一致")
                        {
                            MessageBox.Show("当前设备与本账号使用卡密绑定设备信息不一致。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (Decrypt(result).Length > 4)
                        {
                            if (Decrypt(result).Substring(0, "登录成功".Length) == "登录成功")
                            {
                                if (checkBoxjizhumima.Checked)
                                {
                                    Json.writejson2("zhanghao", textBoxzhanghao.Text);
                                    Json.writejson2("mima", textBoxmima.Text);
                                }
                                MessageBox.Show("登录成功！" + Decrypt(result).Split("|")[1]);
                                flag = true;
                                MainForm mf = new MainForm();
                                MainForm.daoqishijian = Decrypt(result).Split("|")[1];
                                MainForm.account = textBoxzhanghao.Text;
                                mf.Show();
                                this.Hide();
                            }
                        }

                    }
                }

            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
                string error = "由于目标计算机积极拒绝，无法连接。";
                string error2 = "远程主机强迫关闭了一个现有的连接。";
                if (ex.Message.Substring(0, error.Length) == error)
                {
                    MessageBox.Show("服务器关闭。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(0);
                }
                else if (ex.Message.Substring(0, error2.Length) == error2)
                {
                    MessageBox.Show("服务器关闭。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(0);
                }
            }
            new Thread(chuli).Start();

        }
        void chuli()
        {
            while (true)
            {
                string result;
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    //result = Send(Encrypt("调试|" + clientSocket.RemoteEndPoint.ToString() + "|" + getjiqima()));
                    //System.Environment.Exit(0);
                }

                result = Send(Encrypt("机器码|" + getjiqima));
                if (Decrypt(result) == "***")
                {
                    //System.Environment.Exit(0);
                }
                result = Send(Encrypt("获取公告"));
                if (Decrypt(result).Length > 2)
                {
                    if (Decrypt(result).Substring(0, "公告".Length) == "公告")
                    {
                        textBoxgonggao.Text = Decrypt(result).Split("|")[1];
                    }
                }
                Process[] processes;
                processes = Process.GetProcessesByName("Fiddler");
                if (processes.Length > 0)
                {
                    System.Environment.Exit(0);
                }

                Thread.Sleep(2000);
            }
        }
        public string Encrypt(string plainText)
        {
            byte[] encryptedBytes;
            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = {  0x6E, 0x36, 0xF8, 0xA1, 0x2D, 0x8F, 0xE2, 0x5D,
                                0x87, 0x1F, 0x64, 0x23, 0x5F, 0xF7, 0x97, 0xD5,
                                0x4B, 0x8E, 0x16, 0x51, 0x4D, 0x3A, 0x1C, 0xC7,
                                0xB8, 0xA9, 0x8E, 0x53, 0x2D, 0x7B, 0x28, 0xFF };
                aesAlg.Key = key;
                aesAlg.IV = new byte[16];

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string cipherText)
        {
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                byte[] key = {  0x6E, 0x36, 0xF8, 0xA1, 0x2D, 0x8F, 0xE2, 0x5D,
                                0x87, 0x1F, 0x64, 0x23, 0x5F, 0xF7, 0x97, 0xD5,
                                0x4B, 0x8E, 0x16, 0x51, 0x4D, 0x3A, 0x1C, 0xC7,
                                0xB8, 0xA9, 0x8E, 0x53, 0x2D, 0x7B, 0x28, 0xFF };
                aesAlg.Key = key;
                aesAlg.IV = new byte[16];

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public string Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            try
            {
                clientSocket.Send(data);
                byte[] buffer = new byte[1024];
                int bytesRead = clientSocket.Receive(buffer);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                //Debug.WriteLine("服务器响应: {0}", Decrypt(response));
                return response;
            }
            catch (Exception ex)
            {

                System.Environment.Exit(0);
            }
            return " ";
        }
        private void windowBar1_Click(object sender, EventArgs e)
        {

        }
        private string CleanText(string input)
        {
            var lines = input
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line));

            return string.Join(Environment.NewLine, lines);
        }
        public string getjiqima2()
        {
            // 获取 CPU 序列号
            string cpuSerial = "";
            cpuSerial = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");

            // 获取硬盘特征字
            string diskFeature = "";
            // 获取硬盘卷标
            string volumeLabel = DriveInfo.GetDrives()[0].VolumeLabel;

            // 获取硬盘文件系统类型
            string fileSystem = DriveInfo.GetDrives()[0].DriveFormat;

            // 合成硬盘特征字
            diskFeature = $"{volumeLabel}_{fileSystem}";



            // 合成机器码
            string machineCode = $"{cpuSerial}_{diskFeature}";

            // 计算机器码的哈希值
            string machineCodeHash = ComputeHash(machineCode);

            return machineCodeHash;
        }
        public string getjiqima()
        {
            // 获取 CPU 序列号
            string cpuSerial = "";
            cpuSerial = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");

            // 获取硬盘特征字
            string diskFeature = "";
            // 获取硬盘卷标
            string volumeLabel = DriveInfo.GetDrives()[0].VolumeLabel;

            // 获取硬盘文件系统类型
            string fileSystem = DriveInfo.GetDrives()[0].DriveFormat;

            // 合成硬盘特征字
            diskFeature = $"{volumeLabel}_{fileSystem}";

            // 获取 MAC 地址
            string macAddress = "";
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    PhysicalAddress mac = networkInterface.GetPhysicalAddress();
                    macAddress = mac.ToString();
                    break;
                }
            }

            // 合成机器码
            string machineCode = $"{cpuSerial}_{diskFeature}_{macAddress}";

            // 计算机器码的哈希值
            string machineCodeHash = ComputeHash(machineCode);

            return machineCodeHash;
        }

        string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void buttonzhuce_Click(object sender, EventArgs e)
        {
            if (textBoxzhanghao2.Text != "" && textBoxmima2.Text != "" && textBoxchongzhikami.Text != "")
            {
                string result = Send(Encrypt("注册|" + textBoxzhanghao2.Text + "|" + textBoxmima2.Text + "|" + CleanText(textBoxchongzhikami.Text) + "|" + getjiqima2()));
                if (Decrypt(result) == "卡密不存在")
                {
                    MessageBox.Show("卡密不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "卡密已到期")
                {
                    MessageBox.Show("该充值卡密无效，充值卡密已到期。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "卡密未到期")
                {
                    MessageBox.Show("该账号卡密还未到期，请到期后再充值。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "注册成功")
                {
                    MessageBox.Show("注册成功。");
                }
                else if (Decrypt(result) == "账号已存在")
                {
                    MessageBox.Show("账号已存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("账号和密码和充值卡密均不得为空。");
            }
        }

        private void buttondenglu_Click(object sender, EventArgs e)
        {
            if (textBoxzhanghao.Text != "" && textBoxmima.Text != "")
            {
                string result = Send(Encrypt("登录|" + textBoxzhanghao.Text + "|" + textBoxmima.Text + "|" + getjiqima() + "|" + getjiqima2()));
                if (Decrypt(result) == "账号不存在")
                {
                    MessageBox.Show("账号不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "密码错误")
                {
                    MessageBox.Show("密码错误。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "卡密到期")
                {
                    MessageBox.Show("卡密已到期。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "信息不一致")
                {
                    MessageBox.Show("当前设备与本账号使用卡密绑定设备信息不一致。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result).Length > 4)
                {
                    if (Decrypt(result).Substring(0, "登录成功".Length) == "登录成功")
                    {
                        if (checkBoxjizhumima.Checked)
                        {
                            Json.writejson2("zhanghao", textBoxzhanghao.Text);
                            Json.writejson2("mima", textBoxmima.Text);
                        }
                        MessageBox.Show("登录成功！" + Decrypt(result).Split("|")[1]);
                        flag = true;
                        MainForm mf = new MainForm();
                        MainForm.daoqishijian = Decrypt(result).Split("|")[1];
                        MainForm.account = textBoxzhanghao.Text;
                        mf.Show();
                        this.Hide();
                    }

                }
            }
            else
            {
                MessageBox.Show("账号和密码不得为空。");
            }
        }

        private void checkBoxjizhumima_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxjizhumima.Checked)
            {
                Json.writejson2("jizhumima", "true");
            }
            else
            {
                Json.writejson2("jizhumima", "false");
            }
        }

        private void checkBoxzidongdenglu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxzidongdenglu.Checked)
            {
                Json.writejson2("zidongdenglu", "true");
            }
            else
            {
                Json.writejson2("zidongdenglu", "false");
            }
        }

        private void buttonchongzhi_Click(object sender, EventArgs e)
        {
            if (textBoxzhanghao3.Text != "" && textBoxchongzhikami2.Text != "")
            {
                string result = Send(Encrypt("充值|" + textBoxzhanghao3.Text + "|" + CleanText(textBoxchongzhikami2.Text) + "|" + getjiqima2()));
                if (Decrypt(result) == "账号不存在")
                {
                    MessageBox.Show("账号不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "卡密不存在")
                {
                    MessageBox.Show("卡密不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "卡密已到期")
                {
                    MessageBox.Show("卡密已到期。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "卡密未到期")
                {
                    MessageBox.Show("该账号卡密还未到期，请到期后再充值。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Decrypt(result) == "充值成功")
                {
                    MessageBox.Show("充值成功。");
                }
            }
        }

        private void buttonhuanbang_Click(object sender, EventArgs e)
        {
            string result = Send(Encrypt("换绑|" + textBoxzhanghao.Text + "|" + getjiqima2()));
            if (Decrypt(result) == "换绑账号不存在")
            {
                MessageBox.Show("要换绑的账号不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Decrypt(result) == "无法换绑")
            {
                MessageBox.Show("作者暂未开放自助换绑权限，若需换绑请咨询作者。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Decrypt(result).Length > 4)
            {
                if (Decrypt(result).Substring(0, "换绑成功".Length) == "换绑成功")
                {
                    MessageBox.Show("账号：【" + Decrypt(result).Split("|")[1] + "】换绑新设备成功！到期时间" + Decrypt(result).Split("|")[2]);
                }

            }
        }

        private void yanzhengck_Shown(object sender, EventArgs e)
        {
            if (Json.checkjson2("zidongdenglu"))
            {
                if (Json.readjson2("zidongdenglu") == "true" && flag)
                {
                    this.Hide();
                }
            }
        }

        private void yanzhengck_FormClosing(object sender, FormClosingEventArgs e)
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
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }
    }
}
