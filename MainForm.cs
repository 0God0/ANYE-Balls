using AntdUI;
using Newtonsoft.Json.Linq;
using System.CodeDom;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using Vanara.PInvoke;
using static ReaLTaiizor.Manager.MaterialSkinManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static ANYE_Balls.API;
using System;
using Sunny.UI;
using System.Net.Sockets;
using System.Net;
using System.Globalization;

namespace ANYE_Balls
{
    public partial class MainForm : Form
    {

        yanzhengck yz = new yanzhengck();
        public static bool gy = false;

        //特征码
        public static byte[] quanjuaob1 = { 0xD8, 0x00, 0x00, 0x00, 0x63, 0x04, 0x00, 0x00 };
        public static byte[] biansuaob = { 0x00, 0x00, 0x80, 0x3F, 0xAB, 0xAA, 0xAA, 0x3E, 0x8F, 0xC2, 0xF5 };
        public static byte[] nianheaob = { 0x03, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x02, 0x00, 0x9A, 0x99, 0xD9, 0x3F, 0x7B, 0x02, 0x01 };
        public static byte[] tuqiuaob = { 0xA6, 0x00, 0x03, 0x00, 0x03, 0x00, 0x04, 0x00, 0x7B, 0x02, 0x02, 0x00, 0x38, 0x04, 0x03, 0x00,
    0x30, 0x01, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    0x05, 0x00, 0x03, 0x00, 0x01, 0x00, 0x00, 0x00, 0x2F, 0x01, 0x02, 0x00, 0x05 };
        public static byte[] yaoganyanchiaob = { 0x0A, 0xD7, 0xA3, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x42 };
        public static byte[] yaoganjiexianaob = { 0x2C, 0x00, 0x04, 0x00, 0x04, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x05, 0x00, 0x0A, 0xD7, 0x23, 0x3C };
        public static byte[] yaoganhuitanaob = { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x40 };
        public static byte[] ncdxaob = { 0x22, 0x00, 0x00, 0x00, 0x21, 0x00, 0x00, 0x00, 0x24, 0x00, 0x00, 0x00, 0x29, 0x01 };
        public static byte[] yaogan10000aob = { 0x88, 0x56, 0x64, 0x20, 0xAF, 0xD5, 0x08 };
        public static byte[] ygtmaob = { 0xC3, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0xFD, 0x45 };
        //全局内存地址变量
        public static long kaishi;
        public static long jieshu;
        public static long shiye;
        public static long nianhe;
        public static long tuqiu;
        public static long yaoganyanchi;
        public static long yaoganrongcha;
        public static long yaoganjiexian;
        public static long biansu;
        public static long yaogan10000;
        public static long yaoganjiasu;
        public static long yaoganhuitan;
        public static long nichengdaxiao;
        public static long yaoganadr;
        public static long nctqadr;
        public static long tiji;
        public static float ygdx;

        //Json文件路径
        public static string filePath = @"C:\anyedata.json";

        //全局变量
        public static IntPtr pid;
        public static IntPtr hProcess;
        public static string choose = "";
        public static string ck = "";
        public static string lp = "";
        public static IntPtr hWnd;
        public static bool chushihuaflag = false;
        public static float DPI;
        public static bool shifouzhanju;
        public static string daoqishijian;
        public static string account;

        //子窗口对象
        List<Form> cks = new List<Form>();

        private void ScaleFonts(Control.ControlCollection controls, float scalingFactor)
        {
            foreach (Control control in controls)
            {


                if (control is UITextBox)
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * (1.0f / scalingFactor) * scalingFactor, control.Font.Style);
                }
                else
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * (1.0f / scalingFactor), control.Font.Style);
                }
                // 递归处理子控件
                if (control.Controls.Count > 0)
                {
                    ScaleFonts(control.Controls, scalingFactor);
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            cks.Add(new neicungongneng());
            cks.Add(new fuzhugongneng());
            cks.Add(new sanjiao1());
            cks.Add(new sanjiao2());
            cks.Add(new sifencehe());
            cks.Add(new zhongfencehe());
            cks.Add(new houyangcehe());
            cks.Add(new banxuan());
            cks.Add(new xuanzhuan());
            cks.Add(new sheshou());
            cks.Add(new ncsanjiao1());
            cks.Add(new ncsanjiao2());
            cks.Add(new ncsifencehe());
            cks.Add(new nczhongfencehe());
            cks.Add(new nchouyangcehe());
            cks.Add(new ncbanxuan());
            cks.Add(new ncxuanzhuan());
            cks.Add(new ncsheshou());
            cks.Add(new heipingkadian());
            cks.Add(new honggongneng());
            cks.Add(new pifugongneng());
            cks.Add(new qitagongneng());
            Control.CheckForIllegalCrossThreadCalls = false;
            buttondiyibu.Enabled = false;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            // 获取当前显示器的 DPI
            float dpi = GetDpiForCurrentWindow();
            // 计算缩放百分比
            float scalingFactor = dpi / 96.0f;
            DPI = scalingFactor;
            ScaleFonts(this.Controls, scalingFactor);

        }

        private void windowBar1_Click(object sender, EventArgs e)
        {

        }
        private void jihuo()
        {
            foreach (Form form in cks)
            {
                form.Show();
            }
            foreach (Form form in cks)
            {
                form.Hide();
            }
            foreach (Form form in cks)
            {
                form.AutoScaleMode = AutoScaleMode.None;
                form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                ScaleFonts(form.Controls, DPI);

            }
        }


        public float GetDpiForCurrentWindow()
        {
            // 检查操作系统版本
            if (Environment.OSVersion.Version.Major >= 10)
            {
                // 使用 GetDpiForWindow 获取 DPI
                return GetDpiForWindow(this.Handle);
            }
            else
            {
                // 使用 GetDeviceCaps 获取 DPI
                using (Graphics graphics = this.CreateGraphics())
                {
                    IntPtr hdc = graphics.GetHdc();
                    int dpi = GetDeviceCaps(hdc, 88); // 88 是 LOGPIXELSX
                    graphics.ReleaseHdc(hdc);
                    return dpi;
                }
            }
        }



        public static int GetVirtualKeyCode(string keyString)
        {
            if (int.TryParse(keyString, out int keyCode))
            {
                return char.Parse(keyString);
            }
            if (keyString == "空格")
            {
                return 0x20;
            }
            Keys key;
            if (Enum.TryParse(keyString, out key))
            {
                return (int)key;
            }
            else
            {
                return 0;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

            windowBar.Text += "    " + daoqishijian;
            if (!File.Exists(MainForm.filePath))
            {
                using (FileStream fs = File.Create(MainForm.filePath)) { }
                string jsonf = File.ReadAllText(MainForm.filePath);
                JObject root = new JObject();
                jsonf = root.ToString();
                File.WriteAllText(MainForm.filePath, jsonf);
            }

            //-----------连接服务器
            yz.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            yz.ipAddress = IPAddress.Parse("27.25.156.233");
            //yz.ipAddress = IPAddress.Parse("127.0.0.1");
            yz.port = 25101;
            yz.remoteEndPoint = new IPEndPoint(yz.ipAddress, yz.port);
            yz.clientSocket.Connect(yz.remoteEndPoint);
            //--------------------



            //判断是否存在配置，不存在配置文件则创建一个新的Json配置文件
            if (!File.Exists(MainForm.filePath))
            {
                using (FileStream fs = File.Create(MainForm.filePath)) { }
                string jsonf = File.ReadAllText(MainForm.filePath);
                JObject root = new JObject();
                jsonf = root.ToString();
                File.WriteAllText(MainForm.filePath, jsonf);
            }
            //读取配置
            if (Json.readjson2("zidongdenglu") == "true")
            {
                checkboxlwblk.Checked = true;
            }
            if (!Json.checkjson("ismoniqi"))
            {
                moniqi.SelectedItem = "MuMu模拟器";
            }
            else
            {
                moniqi.SelectedItem = Json.readjson("ismoniqi");
            }
            if (!Json.checkjson("tuqiujian"))
            {
                comboBoxtuqiu.SelectedItem = "A";
            }
            else
            {
                comboBoxtuqiu.SelectedItem = Json.readjson("tuqiujian");
            }
            if (!Json.checkjson("fenshenjian"))
            {
                comboBoxfenshen.SelectedItem = "A";
            }
            else
            {
                comboBoxfenshen.SelectedItem = Json.readjson("fenshenjian");
            }
            if (!Json.checkjson("yaogandaxiao"))
            {
                textBoxyaogandaxiao.Text = "1.6";
                try
                {
                    ygdx = float.Parse(textBoxyaogandaxiao.Text);
                }
                catch (Exception ex)
                {
                    ygdx = 1.6f;
                }
            }
            else
            {
                textBoxyaogandaxiao.Text = Json.readjson("yaogandaxiao");
                try
                {
                    ygdx = float.Parse(textBoxyaogandaxiao.Text);
                }
                catch (Exception ex)
                {
                    ygdx = 1.6f;
                }
            }
            if (!Json.checkjson("qjyc"))
            {
                comboBoxhqyc.SelectedItem = "技战室延迟[稳定]";
            }
            else
            {
                comboBoxhqyc.SelectedItem = Json.readjson("qjyc");
            }
            //展开树-基本功能
            treeView.Items[0].Expand = true;
            //添加所有窗口至容器
            Addck();
            //激活容器中所有窗口
            jihuo();
            //显示内存功能窗口
            Showck(cks[0]);

            new Thread(heart).Start();
        }
        void exit()
        {
            Thread.Sleep(3000);
            System.Environment.Exit(0);
        }
        DateTime toTime(string dateTimeStr)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeStr, "yyyy年MM月dd日 HH:mm:ss", CultureInfo.GetCultureInfo("zh-CN")); ;
            return dateTime;
        }
        string gettime()
        {
            TimeZoneInfo beijingTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            DateTime beijingTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, beijingTimeZone);
            return beijingTime.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
        void heart()
        {
            while (true)
            {
                Debug.WriteLine(gy);
                string resultgg = yz.Send(yz.Encrypt("获取公告"));
                if (yz.Decrypt(resultgg).Length > 2)
                {
                    if (yz.Decrypt(resultgg).Substring(0, "公告".Length) == "公告")
                    {
                        uiTextBox1.Text = yz.Decrypt(resultgg).Split("|")[1];
                    }
                }
                if (gy)
                {
                    Process[] processes = Process.GetProcessesByName("Fiddler");
                    if (processes.Length > 0)
                    {
                        //zhuangtaixinxi.Text = "检测到代理，即将退出";
                        Thread.Sleep(2000);
                        //System.Environment.Exit(0);
                    }
                    try
                    {
                        WebRequest request2 = WebRequest.Create("http://anyezwc.com/yanzheng/c.html");
                        WebResponse response = request2.GetResponse();
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string html = reader.ReadToEnd();
                            if (html == "ok")
                            {
                                //zhuangtaixinxi.Text = "公益已关闭，将在5秒后退出";
                                Thread.Sleep(5000);
                                //System.Environment.Exit(0);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else
                {
                    string result = yz.Send(yz.Encrypt("心跳|" + account + "|" + toTime(gettime()).AddSeconds(60).ToString("yyyy年MM月dd日 HH:mm:ss")));
                    if (yz.Decrypt(result) == "卡密到期")
                    {
                        Thread t = new Thread(exit);
                        t.Start();
                        MessageBox.Show("卡密到期。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(0);
                    }
                    else if (yz.Decrypt(result) == "连接丢失")
                    {
                        //Thread t = new Thread(exit);
                        //t.Start();
                        //MessageBox.Show("与服务器的连接丢失1。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (yz.Decrypt(result).Length > "正常".Length && yz.Decrypt(result).Substring(0, "正常".Length) == "正常")
                    {
                        string[] fenge = yz.Decrypt(result).Split("|");
                        string timejiance = fenge[1];
                        if (toTime(timejiance).AddSeconds(60) > toTime(gettime()))
                        {

                        }
                        else
                        {
                            //Thread t = new Thread(exit);
                            //t.Start();
                            //MessageBox.Show("与服务器的连接丢失2。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //System.Environment.Exit(0);
                        }
                    }


                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        //result = yz.Send(yz.Encrypt("调试|" + yz.clientSocket.RemoteEndPoint.ToString() + "|" + yz.getjiqima()));
                        //System.Environment.Exit(0);
                    }
                    Process[] processes = Process.GetProcessesByName("Fiddler");
                    if (processes.Length > 0)
                    {
                        System.Environment.Exit(0);
                    }

                }

                Thread.Sleep(5000);
            }
        }
        private void Addck()
        {
            foreach (Form form in cks)
            {
                form.TopLevel = false;
                panel.Controls.Add(form);
            }
        }
        private void Showck(Form form)
        {
            new Thread(shows).Start(form);
        }
        void shows(object obj)
        {
            Form form = (Form)obj;
            foreach (var forms in cks)
            {
                if (forms.Name == form.Name)
                {
                    forms.Show();
                }
                else
                {
                    if (forms.Name != this.Name)
                    {
                        forms.Hide();
                    }
                }
            }
        }
        private void treeView_NodeMouseClick(object sender, AntdUI.TreeItem item, Rectangle rect)
        {

            switch (item.Text)
            {
                case "内存功能":
                    Showck(new neicungongneng());
                    break;
                case "辅助功能":
                    Showck(new fuzhugongneng());
                    break;
                case "三角-模式1":
                    Showck(new sanjiao1());
                    break;
                case "三角-模式2":
                    Showck(new sanjiao2());
                    break;
                case "四分侧合":
                    Showck(new sifencehe());
                    break;
                case "中分侧合":
                    Showck(new zhongfencehe());
                    break;
                case "后仰侧合":
                    Showck(new houyangcehe());
                    break;
                case "半旋":
                    Showck(new banxuan());
                    break;
                case "旋转":
                    Showck(new xuanzhuan());
                    break;
                case "蛇手":
                    Showck(new sheshou());
                    break;
                case "内存三角-模式1":
                    Showck(new ncsanjiao1());
                    break;
                case "内存三角-模式2":
                    Showck(new ncsanjiao2());
                    break;
                case "内存四分侧合":
                    Showck(new ncsifencehe());
                    break;
                case "内存中分侧合":
                    Showck(new nczhongfencehe());
                    break;
                case "内存后仰侧合":
                    Showck(new nchouyangcehe());
                    break;
                case "内存半旋":
                    Showck(new ncbanxuan());
                    break;
                case "内存旋转":
                    Showck(new ncxuanzhuan());
                    break;
                case "内存蛇手":
                    Showck(new ncsheshou());
                    break;
                case "黑屏图色":
                    Showck(new heipingkadian());
                    break;
                case "宏功能":
                    Showck(new honggongneng());
                    break;
                case "皮肤功能":
                    Showck(new pifugongneng());
                    break;
                case "其他功能":
                    Showck(new qitagongneng());
                    break;
            }
        }

        private void buttonhuoqujincheng_Click(object sender, EventArgs e)
        {
            Process[] processes;
            //赋值选择的全局模拟器
            try
            {
                choose = (string)moniqi.SelectedItem;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                processes = null;
            }

            //获取进程、窗口名、窗口句柄、窗口类名
            if (choose == "MuMu模拟器")
            {
                processes = Process.GetProcessesByName("MuMuVMMHeadless");
                ck = "MuMu模拟器12";
                lp = "Qt5156QWindowIcon";
                IntPtr h1, h2;
                h1 = FindWindowEx((IntPtr)null, (IntPtr)null, "Qt5156QWindowIcon", null);
                h2 = FindWindowEx(h1, (IntPtr)null, "Qt5156QWindowIcon", null);
                hWnd = FindWindowEx(h2, (IntPtr)null, "nemuwin", null);
            }
            else if (choose == "雷电模拟器5")
            {
                processes = Process.GetProcessesByName("LdVBoxHeadless");
                ck = "雷电模拟器";
                lp = "LDPlayerMainFrame";
                IntPtr h1, h2;
                h1 = FindWindowEx((IntPtr)null, (IntPtr)null, "LDPlayerMainFrame", null);
                h2 = FindWindowEx(h1, (IntPtr)null, "RenderWindow", null);
                hWnd = FindWindowEx(h2, (IntPtr)null, "subWin", null);
            }
            else if (choose == "雷电模拟器9")
            {
                processes = Process.GetProcessesByName("Ld9BoxHeadless");
                ck = "雷电模拟器";
                lp = "LDPlayerMainFrame";
                IntPtr h1, h2;
                h1 = FindWindowEx((IntPtr)null, (IntPtr)null, "LDPlayerMainFrame", null);
                h2 = FindWindowEx(h1, (IntPtr)null, "RenderWindow", null);
                hWnd = FindWindowEx(h2, (IntPtr)null, "subWin", null);
            }
            else
            {
                processes = null;
            }
            if (processes != null)
            {
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        pid = (IntPtr)process.Id;
                    }
                    hProcess = OpenProcess(Struct.ProcessAccessFlags.All, false, pid);
                    buttondiyibu.Enabled = true;

                }
                else
                {
                    MessageBox.Show("未找到" + choose + "的进程");
                }
            }
            else
            {
                MessageBox.Show("未找到" + choose + "的进程");
            }
        }

        private void buttondiyibu_Click(object sender, EventArgs e)
        {
            new Thread(diyibu).Start();


        }







        void diyibu()
        {
            buttondiyibu.Loading = true;
            buttondiyibu.Text = "搜索中";
            tishi.Text += "[全部搜索中...]\r\n";
            buttondiyibu.Enabled = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<long> addresssy = Memory.ScanPatternParallel(hProcess, quanjuaob1, quanjuaob1.Length);

            if (addresssy.Count > 0)
            {

                foreach (long addr in addresssy)
                {
                    if (choose == "MuMu模拟器")
                    {
                        shiye = addr + 0x424 + 8;
                        tuqiu = addr + 0x90;
                        yaoganjiasu = addr + 0x48;
                        yaoganadr = addr + 0x30;
                        nctqadr = addr + 0xB8;
                        tiji = addr + 0x3B4 + 8;
                    }
                    else if (choose == "雷电模拟器5")
                    {
                        shiye = addr + 0x300;
                        tuqiu = addr + 0x7C;
                        yaoganjiasu = addr + 0x40;
                        yaoganadr = addr + 0x30;
                        nctqadr = addr + 0x9C;
                        tiji = addr + 0x29C;
                    }
                    else if (choose == "雷电模拟器9")
                    {
                        shiye = addr + 0x300;
                        tuqiu = addr + 0x7C;
                        yaoganjiasu = addr + 0x40;
                        yaoganadr = addr + 0x30;
                        nctqadr = addr + 0x9C;
                        tiji = addr + 0x29C;
                    }
                    tishi.Text += "视野搜索成功\r\n";
                    Thread.Sleep(300);
                    tishi.Text += "吐球双连点搜索成功\r\n";
                    Thread.Sleep(300);
                    tishi.Text += "遥杆优化加速搜索成功\r\n";
                    buttonchushihua.Enabled = true;
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(MainForm.hProcess, MainForm.shiye + 4, data, sizeof(float), out bytesRead);
                    if (Json.checkjson("shiye"))
                    {
                        if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                        {
                            ncck1.textBoxshiyezhi.Text = Json.readjson("shiye");
                            if (!neicungongneng.shiyethstatu)
                            {
                                new Thread(ncck1.shiyethread).Start();
                                neicungongneng.shiyethstatu = true;
                            }
                        }
                    }
                    else
                    {
                        if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                        {
                            ncck1.textBoxshiyezhi.Text = BitConverter.ToSingle(data, 0).ToString("0.00");
                            if (!neicungongneng.shiyethstatu)
                            {
                                new Thread(ncck1.shiyethread).Start();
                                neicungongneng.shiyethstatu = true;
                            }
                        }
                    }
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck2)
                    {
                        ncck2.checkboxtuqiu.Checked = true;
                        if (!neicungongneng.tuqiuthstatu)
                        {
                            new Thread(ncck2.tuqiuthread).Start();
                            neicungongneng.tuqiuthstatu = true;
                        }

                        ncck2.checkboxygyh.Checked = true;
                        if (!neicungongneng.yaoganjiasuthstatu)
                        {
                            new Thread(ncck2.ygjiasu).Start();
                            neicungongneng.yaoganjiasuthstatu = true;
                        }
                    }


                }
            }
            else
            {
                tishi.Text += "视野搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "吐球双连点搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "遥杆优化加速搜索失败\r\n";
            }

            List<long> addressnh = Memory.ScanPatternParallel(hProcess, nianheaob, nianheaob.Length);


            if (addressnh.Count > 0)
            {
                foreach (long addr in addressnh)
                {
                    nianhe = addr + 0x24;
                }
                tishi.Text += "粘合搜索成功\r\n";

                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.nianhe, data, sizeof(float), out bytesRead);
                if (Json.checkjson("nianhe"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnianhe.Text = Json.readjson("nianhe");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnianhe.Text = BitConverter.ToSingle(data, 0).ToString("0.000");
                    }
                }
            }
            else
            {
                tishi.Text += "粘合搜索失败\r\n";
            }


            List<long> addressyg10000 = Memory.ScanPatternParallel(hProcess, yaogan10000aob, yaogan10000aob.Length);

            if (addressyg10000.Count > 0)
            {
                foreach (long addr in addressyg10000)
                {
                    if (choose == "MuMu模拟器")
                    {
                        yaogan10000 = addr - 0x51;
                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        yaogan10000 = addr - 0x3D;
                    }
                }
                tishi.Text += "摇杆10000%搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxyaogan10000.Checked = true;
                    if (!neicungongneng.yaogan10000thstatu)
                    {
                        new Thread(ncck1.yg10000).Start();
                        neicungongneng.yaogan10000thstatu = true;
                    }
                }

            }
            else
            {
                tishi.Text += "摇杆10000%搜索失败\r\n";
            }

            List<long> addressqjbs = Memory.ScanPatternParallel(hProcess, biansuaob, biansuaob.Length);

            if (addressqjbs.Count > 0)
            {
                foreach (long addr in addressqjbs)
                {
                    biansu = addr;
                }
                yaoganyanchi = biansu - 0xB4;
                tishi.Text += "全局变速搜索成功\r\n";
                Thread.Sleep(300);
                tishi.Text += "摇杆延迟搜索成功\r\n";
                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.biansu, data, sizeof(float), out bytesRead);
                if (Json.checkjson("biansu"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxbiansu.Text = Json.readjson("biansu");
                        if (!neicungongneng.quanjubiansuthstatu)
                        {
                            new Thread(ncck1.quanjubiansuthread).Start();
                            neicungongneng.quanjubiansuthstatu = true;
                        }
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxbiansu.Text = BitConverter.ToSingle(data, 0).ToString("0.0");
                        if (!neicungongneng.quanjubiansuthstatu)
                        {
                            new Thread(ncck1.quanjubiansuthread).Start();
                            neicungongneng.quanjubiansuthstatu = true;
                        }
                    }
                }
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck2)
                {
                    ncck2.checkboxygyc.Checked = true;
                    int byteswrite;
                    float value = 0.005f;
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganyanchi, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }

            }
            else
            {
                tishi.Text += "全局变速搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "摇杆延迟搜索失败\r\n";
            }

            List<long> addressygjx = Memory.ScanPatternParallel(hProcess, yaoganjiexianaob, yaoganjiexianaob.Length);

            if (addressygjx.Count > 0)
            {
                foreach (long addr in addressygjx)
                {
                    yaoganjiexian = addr - 0x24;
                }
                tishi.Text += "遥杆/分身解限搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxygjx.Checked = true;
                    int byteswrite;
                    float value = 0.0f;
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }

            }
            else
            {
                tishi.Text += "遥杆/分身解限搜索失败\r\n";
            }

            List<long> addressyght = Memory.ScanPatternParallel(hProcess, yaoganhuitanaob, yaoganhuitanaob.Length);


            if (addressyght.Count > 0)
            {
                for (int i = 0; i < addressyght.Count; i++)
                {
                    yaoganhuitan = addressyght[i] + 0x28;
                }
                yaoganrongcha = yaoganhuitan - 0x04;
                tishi.Text += "遥杆回弹搜索成功\r\n";
                Thread.Sleep(300);
                tishi.Text += "遥杆容差搜索成功\r\n";
                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.yaoganrongcha, data, sizeof(float), out bytesRead);
                if (Json.checkjson("yaoganrongcha"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxygrc.Text = Json.readjson("yaoganrongcha");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxygrc.Text = BitConverter.ToSingle(data, 0).ToString("0");
                    }
                }

                ReadProcessMemory(MainForm.hProcess, MainForm.yaoganhuitan, data, sizeof(float), out bytesRead);
                if (Json.checkjson("yaoganhuitan"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxyght.Text = Json.readjson("yaoganhuitan");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxyght.Text = BitConverter.ToSingle(data, 0).ToString("0");
                    }
                }
            }
            else
            {
                tishi.Text += "遥杆回弹搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "遥杆容差搜索失败\r\n";
            }

            List<long> addressncdx = Memory.ScanPatternParallel(hProcess, ncdxaob, ncdxaob.Length);


            if (addressncdx.Count > 0)
            {
                foreach (long addr in addressncdx)
                {
                    nichengdaxiao = addr - 0x08;
                }
                tishi.Text += "昵称大小搜索成功\r\n";
                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.nichengdaxiao, data, sizeof(float), out bytesRead);
                if (Json.checkjson("nichengdaxiao"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnichengdaxiao.Text = Json.readjson("nichengdaxiao");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnichengdaxiao.Text = BitConverter.ToSingle(data, 0).ToString("0.000");
                    }
                }
            }
            else
            {
                tishi.Text += "昵称大小搜索失败\r\n";
            }
            stopwatch.Stop();
            string elapsedTime = String.Format("{0} s {1} ms", (stopwatch.Elapsed - new TimeSpan(0)).Seconds, (stopwatch.Elapsed - new TimeSpan()).Milliseconds);
            tishi.Text += $"[全部搜索完成...总共用时:{elapsedTime}]\r\n";
            buttondiyibu.Text = "全部搜索";
            buttondiyibu.Loading = false;
            buttondiyibu.Enabled = true;
        }

        private void tishi_TextChanged(object sender, EventArgs e)
        {
            tishi.SelectionStart = tishi.Text.Length;
            tishi.ScrollToCaret();
        }
        void heqiuchushihua()
        {
            zidongheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
            zidongheqiu.tuqiujian = (byte)GetVirtualKeyCode(comboBoxtuqiu.SelectedItem.ToString());
            //quanjufenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
            //honggongneng.handlew = hWnd;
            try
            {
                zidongheqiu.yaogandaxiao = float.Parse(textBoxyaogandaxiao.Text);
                ygdx = float.Parse(textBoxyaogandaxiao.Text);
            }
            catch (Exception ex)
            {
                zidongheqiu.yaogandaxiao = 1.6f;
                ygdx = 1.6f;
                textBoxyaogandaxiao.Text = "1.6";
            }
            buttonchushihua.Enabled = false;
        }



        private void MainForm_Resize(object sender, EventArgs e)
        {
            double bili = this.ClientSize.Width / 1284;
            Debug.WriteLine(bili);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void buttonchushihua_Click(object sender, EventArgs e)
        {
            if (comboBoxfenshen.SelectedItem != null && comboBoxtuqiu.SelectedItem != null)
            {
                bool neiCunYaoGanZhuangTai = true;
                if (neiCunYaoGanZhuangTai)
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        if (!neicungongneng.yaoganjiasuthstatu)
                        {
                            new Thread(ncck.ygjiasu).Start();
                            neicungongneng.yaoganjiasuthstatu = true;
                        }
                    }

                    zidongheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
                    zidongheqiu.tuqiujian = (byte)GetVirtualKeyCode(comboBoxtuqiu.SelectedItem.ToString());
                    neicunheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
                    neicunheqiu.tuqiujian = (byte)GetVirtualKeyCode(comboBoxtuqiu.SelectedItem.ToString());
                    neicunheqiu.yaoganadr = yaoganadr;
                    heqiuchushihua();
                    if (!chushihuaflag)
                    {
                        new Thread(zidongheqiu.heqiu).Start();
                        new Thread(neicunheqiu.ncheqiu).Start();
                        chushihuaflag = true;
                    }
                    tishi.Text += "合球初始化成功\r\n";
                }
                else
                {
                    heqiuchushihua();
                    if (!chushihuaflag)
                    {
                        new Thread(zidongheqiu.heqiu).Start();
                        chushihuaflag = true;
                    }
                    tishi.Text += "内存合球初始化失败，请勿使用内存合球!\r\n";
                    //锁定内存合球启用键
                }
            }
            else
            {
                MessageBox.Show("初始化失败，请设置吐球键和分身键！");
            }
        }

        private void windowBar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBoxhqyc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Json.writejson("qjyc", comboBoxhqyc.SelectedItem.ToString());
            if (comboBoxhqyc.SelectedItem.ToString() == "实战通用延迟-慢速[稳定]")
            {
                if (Application.OpenForms["sanjiao1"] is sanjiao1 sj)
                {
                    sj.datagridviewsj1.Rows[0].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[1].Cells[1].Value = 30;
                    sj.datagridviewsj1.Rows[2].Cells[1].Value = 55;
                    sj.datagridviewsj1.Rows[3].Cells[1].Value = 30;
                    sj.datagridviewsj1.Rows[4].Cells[1].Value = 55;
                    sj.datagridviewsj1.Rows[5].Cells[1].Value = 30;
                    sj.datagridviewsj1.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sanjiao2"] is sanjiao2 sj2)
                {
                    sj2.datagridviewsj2.Rows[0].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[1].Cells[1].Value = 30;
                    sj2.datagridviewsj2.Rows[2].Cells[1].Value = 55;
                    sj2.datagridviewsj2.Rows[3].Cells[1].Value = 30;
                    sj2.datagridviewsj2.Rows[4].Cells[1].Value = 55;
                    sj2.datagridviewsj2.Rows[5].Cells[1].Value = 30;
                    sj2.datagridviewsj2.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 55;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 55;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 55;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 55;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sifencehe"] is sifencehe sfch)
                {
                    sfch.datagridviewsfch.Rows[0].Cells[1].Value = 55;
                    sfch.datagridviewsfch.Rows[1].Cells[1].Value = 55;
                    sfch.datagridviewsfch.Rows[2].Cells[1].Value = 30;
                    sfch.datagridviewsfch.Rows[3].Cells[1].Value = 30;
                    sfch.datagridviewsfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 55;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 55;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 30;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["zhongfencehe"] is zhongfencehe zfch)
                {
                    zfch.datagridviewzfch.Rows[0].Cells[1].Value = 30;
                    zfch.datagridviewzfch.Rows[1].Cells[1].Value = 55;
                    zfch.datagridviewzfch.Rows[2].Cells[1].Value = 30;
                    zfch.datagridviewzfch.Rows[3].Cells[1].Value = 55;
                    zfch.datagridviewzfch.Rows[4].Cells[1].Value = 30;
                    zfch.datagridviewzfch.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 55;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 55;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["houyangcehe"] is houyangcehe hych)
                {
                    hych.datagridviewhych.Rows[0].Cells[1].Value = 55;
                    hych.datagridviewhych.Rows[1].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[2].Cells[1].Value = 30;
                    hych.datagridviewhych.Rows[3].Cells[1].Value = 55;
                    hych.datagridviewhych.Rows[4].Cells[1].Value = 30;
                    hych.datagridviewhych.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 55;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 55;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["banxuan"] is banxuan bx)
                {
                    bx.datagridviewbx.Rows[0].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[1].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[2].Cells[1].Value = 55;
                    bx.datagridviewbx.Rows[3].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[4].Cells[1].Value = 55;
                    bx.datagridviewbx.Rows[5].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[6].Cells[1].Value = 55;
                    bx.datagridviewbx.Rows[7].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["xuanzhuan"] is xuanzhuan xz)
                {
                    xz.datagridviewxz.Rows[0].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[1].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[2].Cells[1].Value = 55;
                    xz.datagridviewxz.Rows[3].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[4].Cells[1].Value = 55;
                    xz.datagridviewxz.Rows[5].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[6].Cells[1].Value = 55;
                    xz.datagridviewxz.Rows[7].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sheshou"] is sheshou ss)
                {
                    ss.datagridviewss.Rows[0].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[1].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[2].Cells[1].Value = 55;
                    ss.datagridviewss.Rows[3].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[4].Cells[1].Value = 55;
                    ss.datagridviewss.Rows[5].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[6].Cells[1].Value = 55;
                    ss.datagridviewss.Rows[7].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "实战通用延迟-快速[激进]")
            {
                if (Application.OpenForms["sanjiao1"] is sanjiao1 sj)
                {
                    sj.datagridviewsj1.Rows[0].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[1].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[2].Cells[1].Value = 45;
                    sj.datagridviewsj1.Rows[3].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[4].Cells[1].Value = 45;
                    sj.datagridviewsj1.Rows[5].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sanjiao2"] is sanjiao2 sj2)
                {
                    sj2.datagridviewsj2.Rows[0].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[1].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[2].Cells[1].Value = 45;
                    sj2.datagridviewsj2.Rows[3].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[4].Cells[1].Value = 45;
                    sj2.datagridviewsj2.Rows[5].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 45;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 45;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 45;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 45;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sifencehe"] is sifencehe sfch)
                {
                    sfch.datagridviewsfch.Rows[0].Cells[1].Value = 45;
                    sfch.datagridviewsfch.Rows[1].Cells[1].Value = 45;
                    sfch.datagridviewsfch.Rows[2].Cells[1].Value = 20;
                    sfch.datagridviewsfch.Rows[3].Cells[1].Value = 20;
                    sfch.datagridviewsfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 45;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 45;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 20;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["zhongfencehe"] is zhongfencehe zfch)
                {
                    zfch.datagridviewzfch.Rows[0].Cells[1].Value = 20;
                    zfch.datagridviewzfch.Rows[1].Cells[1].Value = 45;
                    zfch.datagridviewzfch.Rows[2].Cells[1].Value = 20;
                    zfch.datagridviewzfch.Rows[3].Cells[1].Value = 45;
                    zfch.datagridviewzfch.Rows[4].Cells[1].Value = 20;
                    zfch.datagridviewzfch.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 45;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 45;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["houyangcehe"] is houyangcehe hych)
                {
                    hych.datagridviewhych.Rows[0].Cells[1].Value = 45;
                    hych.datagridviewhych.Rows[1].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[2].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[3].Cells[1].Value = 45;
                    hych.datagridviewhych.Rows[4].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 45;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 45;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["banxuan"] is banxuan bx)
                {
                    bx.datagridviewbx.Rows[0].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[1].Cells[1].Value = 25;
                    bx.datagridviewbx.Rows[2].Cells[1].Value = 55;
                    bx.datagridviewbx.Rows[3].Cells[1].Value = 25;
                    bx.datagridviewbx.Rows[4].Cells[1].Value = 55;
                    bx.datagridviewbx.Rows[5].Cells[1].Value = 25;
                    bx.datagridviewbx.Rows[6].Cells[1].Value = 55;
                    bx.datagridviewbx.Rows[7].Cells[1].Value = 25;
                    bx.datagridviewbx.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["xuanzhuan"] is xuanzhuan xz)
                {
                    xz.datagridviewxz.Rows[0].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[1].Cells[1].Value = 25;
                    xz.datagridviewxz.Rows[2].Cells[1].Value = 55;
                    xz.datagridviewxz.Rows[3].Cells[1].Value = 25;
                    xz.datagridviewxz.Rows[4].Cells[1].Value = 55;
                    xz.datagridviewxz.Rows[5].Cells[1].Value = 25;
                    xz.datagridviewxz.Rows[6].Cells[1].Value = 55;
                    xz.datagridviewxz.Rows[7].Cells[1].Value = 25;
                    xz.datagridviewxz.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sheshou"] is sheshou ss)
                {
                    ss.datagridviewss.Rows[0].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[1].Cells[1].Value = 25;
                    ss.datagridviewss.Rows[2].Cells[1].Value = 55;
                    ss.datagridviewss.Rows[3].Cells[1].Value = 25;
                    ss.datagridviewss.Rows[4].Cells[1].Value = 55;
                    ss.datagridviewss.Rows[5].Cells[1].Value = 25;
                    ss.datagridviewss.Rows[6].Cells[1].Value = 55;
                    ss.datagridviewss.Rows[7].Cells[1].Value = 25;
                    ss.datagridviewss.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "技战室延迟[稳定]")
            {
                if (Application.OpenForms["sanjiao1"] is sanjiao1 sj)
                {
                    sj.datagridviewsj1.Rows[0].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[1].Cells[1].Value = 50;
                    sj.datagridviewsj1.Rows[2].Cells[1].Value = 10;
                    sj.datagridviewsj1.Rows[3].Cells[1].Value = 50;
                    sj.datagridviewsj1.Rows[4].Cells[1].Value = 10;
                    sj.datagridviewsj1.Rows[5].Cells[1].Value = 50;
                    sj.datagridviewsj1.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sanjiao2"] is sanjiao2 sj2)
                {
                    sj2.datagridviewsj2.Rows[0].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[1].Cells[1].Value = 50;
                    sj2.datagridviewsj2.Rows[2].Cells[1].Value = 10;
                    sj2.datagridviewsj2.Rows[3].Cells[1].Value = 50;
                    sj2.datagridviewsj2.Rows[4].Cells[1].Value = 10;
                    sj2.datagridviewsj2.Rows[5].Cells[1].Value = 50;
                    sj2.datagridviewsj2.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 10;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 10;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 10;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 10;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sifencehe"] is sifencehe sfch)
                {
                    sfch.datagridviewsfch.Rows[0].Cells[1].Value = 10;
                    sfch.datagridviewsfch.Rows[1].Cells[1].Value = 10;
                    sfch.datagridviewsfch.Rows[2].Cells[1].Value = 50;
                    sfch.datagridviewsfch.Rows[3].Cells[1].Value = 50;
                    sfch.datagridviewsfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 10;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 10;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 50;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["zhongfencehe"] is zhongfencehe zfch)
                {
                    zfch.datagridviewzfch.Rows[0].Cells[1].Value = 50;
                    zfch.datagridviewzfch.Rows[1].Cells[1].Value = 10;
                    zfch.datagridviewzfch.Rows[2].Cells[1].Value = 50;
                    zfch.datagridviewzfch.Rows[3].Cells[1].Value = 10;
                    zfch.datagridviewzfch.Rows[4].Cells[1].Value = 50;
                    zfch.datagridviewzfch.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 10;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 10;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["houyangcehe"] is houyangcehe hych)
                {
                    hych.datagridviewhych.Rows[0].Cells[1].Value = 10;
                    hych.datagridviewhych.Rows[1].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[2].Cells[1].Value = 50;
                    hych.datagridviewhych.Rows[3].Cells[1].Value = 10;
                    hych.datagridviewhych.Rows[4].Cells[1].Value = 50;
                    hych.datagridviewhych.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 10;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 10;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["banxuan"] is banxuan bx)
                {
                    bx.datagridviewbx.Rows[0].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[1].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[2].Cells[1].Value = 10;
                    bx.datagridviewbx.Rows[3].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[4].Cells[1].Value = 10;
                    bx.datagridviewbx.Rows[5].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[6].Cells[1].Value = 10;
                    bx.datagridviewbx.Rows[7].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 10;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 10;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 10;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["xuanzhuan"] is xuanzhuan xz)
                {
                    xz.datagridviewxz.Rows[0].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[1].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[2].Cells[1].Value = 10;
                    xz.datagridviewxz.Rows[3].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[4].Cells[1].Value = 10;
                    xz.datagridviewxz.Rows[5].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[6].Cells[1].Value = 10;
                    xz.datagridviewxz.Rows[7].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 10;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 10;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 10;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sheshou"] is sheshou ss)
                {
                    ss.datagridviewss.Rows[0].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[1].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[2].Cells[1].Value = 10;
                    ss.datagridviewss.Rows[3].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[4].Cells[1].Value = 10;
                    ss.datagridviewss.Rows[5].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[6].Cells[1].Value = 10;
                    ss.datagridviewss.Rows[7].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 10;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 10;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 10;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "自建房通用延迟-慢速[稳定]")
            {
                if (Application.OpenForms["sanjiao1"] is sanjiao1 sj)
                {
                    sj.datagridviewsj1.Rows[0].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[1].Cells[1].Value = 50;
                    sj.datagridviewsj1.Rows[2].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[3].Cells[1].Value = 50;
                    sj.datagridviewsj1.Rows[4].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[5].Cells[1].Value = 50;
                    sj.datagridviewsj1.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sanjiao2"] is sanjiao2 sj2)
                {
                    sj2.datagridviewsj2.Rows[0].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[1].Cells[1].Value = 50;
                    sj2.datagridviewsj2.Rows[2].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[3].Cells[1].Value = 50;
                    sj2.datagridviewsj2.Rows[4].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[5].Cells[1].Value = 50;
                    sj2.datagridviewsj2.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sifencehe"] is sifencehe sfch)
                {
                    sfch.datagridviewsfch.Rows[0].Cells[1].Value = 20;
                    sfch.datagridviewsfch.Rows[1].Cells[1].Value = 20;
                    sfch.datagridviewsfch.Rows[2].Cells[1].Value = 50;
                    sfch.datagridviewsfch.Rows[3].Cells[1].Value = 50;
                    sfch.datagridviewsfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 20;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 20;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 50;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["zhongfencehe"] is zhongfencehe zfch)
                {
                    zfch.datagridviewzfch.Rows[0].Cells[1].Value = 50;
                    zfch.datagridviewzfch.Rows[1].Cells[1].Value = 20;
                    zfch.datagridviewzfch.Rows[2].Cells[1].Value = 50;
                    zfch.datagridviewzfch.Rows[3].Cells[1].Value = 20;
                    zfch.datagridviewzfch.Rows[4].Cells[1].Value = 50;
                    zfch.datagridviewzfch.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["houyangcehe"] is houyangcehe hych)
                {
                    hych.datagridviewhych.Rows[0].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[1].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[2].Cells[1].Value = 50;
                    hych.datagridviewhych.Rows[3].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[4].Cells[1].Value = 50;
                    hych.datagridviewhych.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["banxuan"] is banxuan bx)
                {
                    bx.datagridviewbx.Rows[0].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[1].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[2].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[3].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[4].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[5].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[6].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[7].Cells[1].Value = 50;
                    bx.datagridviewbx.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 20;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 20;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 20;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["xuanzhuan"] is xuanzhuan xz)
                {
                    xz.datagridviewxz.Rows[0].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[1].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[2].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[3].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[4].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[5].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[6].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[7].Cells[1].Value = 50;
                    xz.datagridviewxz.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 20;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 20;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 20;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sheshou"] is sheshou ss)
                {
                    ss.datagridviewss.Rows[0].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[1].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[2].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[3].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[4].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[5].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[6].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[7].Cells[1].Value = 50;
                    ss.datagridviewss.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 20;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 20;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 20;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "自建房通用延迟-快速[激进]")
            {
                if (Application.OpenForms["sanjiao1"] is sanjiao1 sj)
                {
                    sj.datagridviewsj1.Rows[0].Cells[1].Value = 20;
                    sj.datagridviewsj1.Rows[1].Cells[1].Value = 30;
                    sj.datagridviewsj1.Rows[2].Cells[1].Value = 15;
                    sj.datagridviewsj1.Rows[3].Cells[1].Value = 30;
                    sj.datagridviewsj1.Rows[4].Cells[1].Value = 15;
                    sj.datagridviewsj1.Rows[5].Cells[1].Value = 30;
                    sj.datagridviewsj1.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sanjiao2"] is sanjiao2 sj2)
                {
                    sj2.datagridviewsj2.Rows[0].Cells[1].Value = 20;
                    sj2.datagridviewsj2.Rows[1].Cells[1].Value = 30;
                    sj2.datagridviewsj2.Rows[2].Cells[1].Value = 15;
                    sj2.datagridviewsj2.Rows[3].Cells[1].Value = 30;
                    sj2.datagridviewsj2.Rows[4].Cells[1].Value = 15;
                    sj2.datagridviewsj2.Rows[5].Cells[1].Value = 30;
                    sj2.datagridviewsj2.Rows[6].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 15;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 15;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 15;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 15;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sifencehe"] is sifencehe sfch)
                {
                    sfch.datagridviewsfch.Rows[0].Cells[1].Value = 15;
                    sfch.datagridviewsfch.Rows[1].Cells[1].Value = 15;
                    sfch.datagridviewsfch.Rows[2].Cells[1].Value = 30;
                    sfch.datagridviewsfch.Rows[3].Cells[1].Value = 30;
                    sfch.datagridviewsfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 15;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 15;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 30;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["zhongfencehe"] is zhongfencehe zfch)
                {
                    zfch.datagridviewzfch.Rows[0].Cells[1].Value = 30;
                    zfch.datagridviewzfch.Rows[1].Cells[1].Value = 15;
                    zfch.datagridviewzfch.Rows[2].Cells[1].Value = 30;
                    zfch.datagridviewzfch.Rows[3].Cells[1].Value = 15;
                    zfch.datagridviewzfch.Rows[4].Cells[1].Value = 30;
                    zfch.datagridviewzfch.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 15;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 15;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["houyangcehe"] is houyangcehe hych)
                {
                    hych.datagridviewhych.Rows[0].Cells[1].Value = 15;
                    hych.datagridviewhych.Rows[1].Cells[1].Value = 20;
                    hych.datagridviewhych.Rows[2].Cells[1].Value = 30;
                    hych.datagridviewhych.Rows[3].Cells[1].Value = 15;
                    hych.datagridviewhych.Rows[4].Cells[1].Value = 30;
                    hych.datagridviewhych.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 15;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 15;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["banxuan"] is banxuan bx)
                {
                    bx.datagridviewbx.Rows[0].Cells[1].Value = 20;
                    bx.datagridviewbx.Rows[1].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[2].Cells[1].Value = 15;
                    bx.datagridviewbx.Rows[3].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[4].Cells[1].Value = 15;
                    bx.datagridviewbx.Rows[5].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[6].Cells[1].Value = 15;
                    bx.datagridviewbx.Rows[7].Cells[1].Value = 30;
                    bx.datagridviewbx.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 15;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 15;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 15;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["xuanzhuan"] is xuanzhuan xz)
                {
                    xz.datagridviewxz.Rows[0].Cells[1].Value = 20;
                    xz.datagridviewxz.Rows[1].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[2].Cells[1].Value = 15;
                    xz.datagridviewxz.Rows[3].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[4].Cells[1].Value = 15;
                    xz.datagridviewxz.Rows[5].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[6].Cells[1].Value = 15;
                    xz.datagridviewxz.Rows[7].Cells[1].Value = 30;
                    xz.datagridviewxz.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 15;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 15;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 15;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["sheshou"] is sheshou ss)
                {
                    ss.datagridviewss.Rows[0].Cells[1].Value = 20;
                    ss.datagridviewss.Rows[1].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[2].Cells[1].Value = 15;
                    ss.datagridviewss.Rows[3].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[4].Cells[1].Value = 15;
                    ss.datagridviewss.Rows[5].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[6].Cells[1].Value = 15;
                    ss.datagridviewss.Rows[7].Cells[1].Value = 30;
                    ss.datagridviewss.Rows[8].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 15;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 15;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 15;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
        }

        private void textBoxyaogandaxiao_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("yaogandaxiao", textBoxyaogandaxiao.Text);
            try
            {
                ygdx = float.Parse(textBoxyaogandaxiao.Text);
            }
            catch (Exception ex)
            {
                ygdx = 1.6f;
            }
            zidongheqiu.yaogandaxiao = ygdx;
        }

        private void textBoxyaogandaxiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void comboBoxfenshen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxfenshen.SelectedItem != null)
            {
                zidongheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
                neicunheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
                //quanjufenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
            }
            Json.writejson("fenshenjian", comboBoxfenshen.SelectedItem.ToString());
        }

        private void buttondaorupz_Click(object sender, EventArgs e)
        {
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                MainForm.filePath = openFileDialog1.FileName;
            }
            daorupeizhi();
        }

        private void buttondaochupz_Click(object sender, EventArgs e)
        {
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog1.FileName))
                {
                    try
                    {
                        using (FileStream fs = File.Create(saveFileDialog1.FileName)) { };
                        File.WriteAllBytes(saveFileDialog1.FileName, File.ReadAllBytes(MainForm.filePath));
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        void daorupeizhi()
        {
            if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
            {
                if (Json.checkjson("gunlunzuixiaozhi"))
                {
                    ncck.textboxshiyemin.Text = Json.readjson("gunlunzuixiaozhi");
                }
                else
                {
                    ncck.textboxshiyemin.Text = "1.0";
                }
                if (Json.checkjson("gunlunzuidazhi"))
                {
                    ncck.textboxshiyemax.Text = Json.readjson("gunlunzuidazhi");
                }
                else
                {
                    ncck.textboxshiyemax.Text = "10.0";
                }
                if (Json.checkjson("buchang"))
                {
                    ncck.textboxshiyebuchang.Text = Json.readjson("buchang");
                }
                else
                {
                    ncck.textboxshiyebuchang.Text = "0.5";
                }
            }
            if (Application.OpenForms["banxuan"] is banxuan bx)
            {
                if (!Json.checkjson("banxuanjian"))
                {
                    bx.comboboxbanxuan.SelectedItem = "A";
                }
                else
                {
                    bx.comboboxbanxuan.SelectedItem = Json.readjson("banxuanjian");
                }
                if (!Json.checkjson("bxjcfd1"))
                {
                    bx.textboxbxjcfd1.Text = "100";
                }
                else
                {
                    bx.textboxbxjcfd1.Text = Json.readjson("bxjcfd1");
                }
                if (!Json.checkjson("bxjcfd2"))
                {
                    bx.textboxbxjcfd2.Text = "100";
                }
                else
                {
                    bx.textboxbxjcfd2.Text = Json.readjson("bxjcfd2");
                }
                if (!Json.checkjson("bxjcfd3"))
                {
                    bx.textboxbxjcfd3.Text = "120";
                }
                else
                {
                    bx.textboxbxjcfd3.Text = Json.readjson("bxjcfd3");
                }
                if (!Json.checkjson("bxjcfd4"))
                {
                    bx.textboxbxjcfd4.Text = "120";
                }
                else
                {
                    bx.textboxbxjcfd4.Text = Json.readjson("bxjcfd4");
                }
                if (!Json.checkjson("bxjd1"))
                {
                    bx.textboxbxjd1.Text = "5";
                }
                else
                {
                    bx.textboxbxjd1.Text = Json.readjson("bxjd1");
                }
                if (!Json.checkjson("bxjd2"))
                {
                    bx.textboxbxjd2.Text = "20";
                }
                else
                {
                    bx.textboxbxjd2.Text = Json.readjson("bxjd2");
                }
                if (!Json.checkjson("bxjd3"))
                {
                    bx.textboxbxjd3.Text = "25";
                }
                else
                {
                    bx.textboxbxjd3.Text = Json.readjson("bxjd3");
                }
                if (!Json.checkjson("bxjd4"))
                {
                    bx.textboxbxjd4.Text = "25";
                }
                else
                {
                    bx.textboxbxjd4.Text = Json.readjson("bxjd4");
                }
                if (!Json.checkjson("bxyc1"))
                {
                    bx.datagridviewbx.Rows.Add("鼠标左键按下", 20);
                    bx.datagridviewbx.Rows.Add("第一次拖动鼠标", 50);
                    bx.datagridviewbx.Rows.Add("分身", 10);
                    bx.datagridviewbx.Rows.Add("第二次拖动鼠标", 50);
                    bx.datagridviewbx.Rows.Add("分身", 10);
                    bx.datagridviewbx.Rows.Add("第三次拖动鼠标", 50);
                    bx.datagridviewbx.Rows.Add("分身", 10);
                    bx.datagridviewbx.Rows.Add("第四次拖动鼠标", 50);
                    bx.datagridviewbx.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    bx.datagridviewbx.Rows.Add("鼠标左键按下", Json.readjson("bxyc1"));
                    bx.datagridviewbx.Rows.Add("第一次拖动鼠标", Json.readjson("bxyc2"));
                    bx.datagridviewbx.Rows.Add("分身", Json.readjson("bxyc3"));
                    bx.datagridviewbx.Rows.Add("第二次拖动鼠标", Json.readjson("bxyc4"));
                    bx.datagridviewbx.Rows.Add("分身", Json.readjson("bxyc5"));
                    bx.datagridviewbx.Rows.Add("第三次拖动鼠标", Json.readjson("bxyc6"));
                    bx.datagridviewbx.Rows.Add("分身", Json.readjson("bxyc7"));
                    bx.datagridviewbx.Rows.Add("第四次拖动鼠标", Json.readjson("bxyc8"));
                    bx.datagridviewbx.Rows.Add("最后分身延迟", Json.readjson("bxyc9"));
                }
                zidongheqiu.banxuanjian = MainForm.GetVirtualKeyCode(bx.comboboxbanxuan.SelectedItem.ToString());
                try
                {
                    zidongheqiu.bxjcfd1 = Convert.ToInt32(bx.textboxbxjcfd1.Text);
                    zidongheqiu.bxjcfd2 = Convert.ToInt32(bx.textboxbxjcfd2.Text);
                    zidongheqiu.bxjcfd3 = Convert.ToInt32(bx.textboxbxjcfd3.Text);
                    zidongheqiu.bxjcfd4 = Convert.ToInt32(bx.textboxbxjcfd4.Text);
                    zidongheqiu.bxjd1 = Convert.ToInt32(bx.textboxbxjd1.Text);
                    zidongheqiu.bxjd2 = Convert.ToInt32(bx.textboxbxjd2.Text);
                    zidongheqiu.bxjd3 = Convert.ToInt32(bx.textboxbxjd3.Text);
                    zidongheqiu.bxjd4 = Convert.ToInt32(bx.textboxbxjd4.Text);
                    zidongheqiu.bxyc1 = int.Parse(bx.datagridviewbx.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.bxyc2 = int.Parse(bx.datagridviewbx.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.bxyc3 = int.Parse(bx.datagridviewbx.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.bxyc4 = int.Parse(bx.datagridviewbx.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.bxyc5 = int.Parse(bx.datagridviewbx.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.bxyc6 = int.Parse(bx.datagridviewbx.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.bxyc7 = int.Parse(bx.datagridviewbx.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.bxyc8 = int.Parse(bx.datagridviewbx.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.bxyc9 = int.Parse(bx.datagridviewbx.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("banxuan"))
                {
                    if (Json.readjson("banxuan") == "true")
                    {
                        bx.checkboxbanxuan.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["xuanzhuan"] is xuanzhuan xz)
            {
                if (!Json.checkjson("xuanzhuanjian"))
                {
                    xz.comboboxxuanzhuan.SelectedItem = "A";
                }
                else
                {
                    xz.comboboxxuanzhuan.SelectedItem = Json.readjson("xuanzhuanjian");
                }
                if (!Json.checkjson("xzjcfd1"))
                {
                    xz.textboxxzjcfd1.Text = "90";
                }
                else
                {
                    xz.textboxxzjcfd1.Text = Json.readjson("xzjcfd1");
                }
                if (!Json.checkjson("xzjcfd2"))
                {
                    xz.textboxxzjcfd2.Text = "85";
                }
                else
                {
                    xz.textboxxzjcfd2.Text = Json.readjson("xzjcfd2");
                }
                if (!Json.checkjson("xzjcfd3"))
                {
                    xz.textboxxzjcfd3.Text = "75";
                }
                else
                {
                    xz.textboxxzjcfd3.Text = Json.readjson("xzjcfd3");
                }
                if (!Json.checkjson("xzjcfd4"))
                {
                    xz.textboxxzjcfd4.Text = "70";
                }
                else
                {
                    xz.textboxxzjcfd4.Text = Json.readjson("xzjcfd4");
                }
                if (!Json.checkjson("xzjd1"))
                {
                    xz.textboxxzjd1.Text = "20";
                }
                else
                {
                    xz.textboxxzjd1.Text = Json.readjson("xzjd1");
                }
                if (!Json.checkjson("xzjd2"))
                {
                    xz.textboxxzjd2.Text = "25";
                }
                else
                {
                    xz.textboxxzjd2.Text = Json.readjson("xzjd2");
                }
                if (!Json.checkjson("xzjd3"))
                {
                    xz.textboxxzjd3.Text = "25";
                }
                else
                {
                    xz.textboxxzjd3.Text = Json.readjson("xzjd3");
                }
                if (!Json.checkjson("xzjd4"))
                {
                    xz.textboxxzjd4.Text = "40";
                }
                else
                {
                    xz.textboxxzjd4.Text = Json.readjson("xzjd4");
                }
                if (!Json.checkjson("xzyc1"))
                {
                    xz.datagridviewxz.Rows.Add("鼠标左键按下", 20);
                    xz.datagridviewxz.Rows.Add("第一次拖动鼠标", 50);
                    xz.datagridviewxz.Rows.Add("分身", 10);
                    xz.datagridviewxz.Rows.Add("第二次拖动鼠标", 50);
                    xz.datagridviewxz.Rows.Add("分身", 10);
                    xz.datagridviewxz.Rows.Add("第三次拖动鼠标", 50);
                    xz.datagridviewxz.Rows.Add("分身", 10);
                    xz.datagridviewxz.Rows.Add("第四次拖动鼠标", 50);
                    xz.datagridviewxz.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    xz.datagridviewxz.Rows.Add("鼠标左键按下", Json.readjson("xzyc1"));
                    xz.datagridviewxz.Rows.Add("第一次拖动鼠标", Json.readjson("xzyc2"));
                    xz.datagridviewxz.Rows.Add("分身", Json.readjson("xzyc3"));
                    xz.datagridviewxz.Rows.Add("第二次拖动鼠标", Json.readjson("xzyc4"));
                    xz.datagridviewxz.Rows.Add("分身", Json.readjson("xzyc5"));
                    xz.datagridviewxz.Rows.Add("第三次拖动鼠标", Json.readjson("xzyc6"));
                    xz.datagridviewxz.Rows.Add("分身", Json.readjson("xzyc7"));
                    xz.datagridviewxz.Rows.Add("第四次拖动鼠标", Json.readjson("xzyc8"));
                    xz.datagridviewxz.Rows.Add("最后分身延迟", Json.readjson("xzyc9"));
                }
                zidongheqiu.xuanzhuanjian = MainForm.GetVirtualKeyCode(xz.comboboxxuanzhuan.SelectedItem.ToString());
                try
                {
                    zidongheqiu.xzjcfd1 = Convert.ToInt32(xz.textboxxzjcfd1.Text);
                    zidongheqiu.xzjcfd2 = Convert.ToInt32(xz.textboxxzjcfd2.Text);
                    zidongheqiu.xzjcfd3 = Convert.ToInt32(xz.textboxxzjcfd3.Text);
                    zidongheqiu.xzjcfd4 = Convert.ToInt32(xz.textboxxzjcfd4.Text);
                    zidongheqiu.xzjd1 = Convert.ToInt32(xz.textboxxzjd1.Text);
                    zidongheqiu.xzjd2 = Convert.ToInt32(xz.textboxxzjd2.Text);
                    zidongheqiu.xzjd3 = Convert.ToInt32(xz.textboxxzjd3.Text);
                    zidongheqiu.xzjd4 = Convert.ToInt32(xz.textboxxzjd4.Text);
                    zidongheqiu.xzyc1 = int.Parse(xz.datagridviewxz.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.xzyc2 = int.Parse(xz.datagridviewxz.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.xzyc3 = int.Parse(xz.datagridviewxz.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.xzyc4 = int.Parse(xz.datagridviewxz.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.xzyc5 = int.Parse(xz.datagridviewxz.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.xzyc6 = int.Parse(xz.datagridviewxz.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.xzyc7 = int.Parse(xz.datagridviewxz.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.xzyc8 = int.Parse(xz.datagridviewxz.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.xzyc9 = int.Parse(xz.datagridviewxz.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("xuanzhuan"))
                {
                    if (Json.readjson("xuanzhuan") == "true")
                    {
                        xz.checkboxxuanzhuan.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["sheshou"] is sheshou ss)
            {
                if (!Json.checkjson("sheshoujian"))
                {
                    ss.comboboxsheshou.SelectedItem = "A";
                }
                else
                {
                    ss.comboboxsheshou.SelectedItem = Json.readjson("sheshoujian");
                }
                if (!Json.checkjson("ssjcfd1"))
                {
                    ss.textboxssjcfd1.Text = "135";
                }
                else
                {
                    ss.textboxssjcfd1.Text = Json.readjson("ssjcfd1");
                }
                if (!Json.checkjson("ssjcfd2"))
                {
                    ss.textboxssjcfd2.Text = "135";
                }
                else
                {
                    ss.textboxssjcfd2.Text = Json.readjson("ssjcfd2");
                }
                if (!Json.checkjson("ssjcfd3"))
                {
                    ss.textboxssjcfd3.Text = "100";
                }
                else
                {
                    ss.textboxssjcfd3.Text = Json.readjson("ssjcfd3");
                }
                if (!Json.checkjson("ssjcfd4"))
                {
                    ss.textboxssjcfd4.Text = "150";
                }
                else
                {
                    ss.textboxssjcfd4.Text = Json.readjson("ssjcfd4");
                }
                if (!Json.checkjson("ssjd1"))
                {
                    ss.textboxssjd1.Text = "0";
                }
                else
                {
                    ss.textboxssjd1.Text = Json.readjson("ssjd1");
                }
                if (!Json.checkjson("ssjd2"))
                {
                    ss.textboxssjd2.Text = "60";
                }
                else
                {
                    ss.textboxssjd2.Text = Json.readjson("ssjd2");
                }
                if (!Json.checkjson("ssjd3"))
                {
                    ss.textboxssjd3.Text = "-50";
                }
                else
                {
                    ss.textboxssjd3.Text = Json.readjson("ssjd3");
                }
                if (!Json.checkjson("ssjd4"))
                {
                    ss.textboxssjd4.Text = "0";
                }
                else
                {
                    ss.textboxssjd4.Text = Json.readjson("ssjd4");
                }
                if (!Json.checkjson("ssyc1"))
                {
                    ss.datagridviewss.Rows.Add("鼠标左键按下", 20);
                    ss.datagridviewss.Rows.Add("第一次拖动鼠标", 50);
                    ss.datagridviewss.Rows.Add("分身", 10);
                    ss.datagridviewss.Rows.Add("第二次拖动鼠标", 50);
                    ss.datagridviewss.Rows.Add("分身", 10);
                    ss.datagridviewss.Rows.Add("第三次拖动鼠标", 50);
                    ss.datagridviewss.Rows.Add("分身", 10);
                    ss.datagridviewss.Rows.Add("第四次拖动鼠标", 50);
                    ss.datagridviewss.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ss.datagridviewss.Rows.Add("鼠标左键按下", Json.readjson("ssyc1"));
                    ss.datagridviewss.Rows.Add("第一次拖动鼠标", Json.readjson("ssyc2"));
                    ss.datagridviewss.Rows.Add("分身", Json.readjson("ssyc3"));
                    ss.datagridviewss.Rows.Add("第二次拖动鼠标", Json.readjson("ssyc4"));
                    ss.datagridviewss.Rows.Add("分身", Json.readjson("ssyc5"));
                    ss.datagridviewss.Rows.Add("第三次拖动鼠标", Json.readjson("ssyc6"));
                    ss.datagridviewss.Rows.Add("分身", Json.readjson("ssyc7"));
                    ss.datagridviewss.Rows.Add("第四次拖动鼠标", Json.readjson("ssyc8"));
                    ss.datagridviewss.Rows.Add("最后分身延迟", Json.readjson("ssyc9"));
                }
                zidongheqiu.sheshoujian = MainForm.GetVirtualKeyCode(ss.comboboxsheshou.SelectedItem.ToString());
                try
                {
                    zidongheqiu.ssjcfd1 = Convert.ToInt32(ss.textboxssjcfd1.Text);
                    zidongheqiu.ssjcfd2 = Convert.ToInt32(ss.textboxssjcfd2.Text);
                    zidongheqiu.ssjcfd3 = Convert.ToInt32(ss.textboxssjcfd3.Text);
                    zidongheqiu.ssjcfd4 = Convert.ToInt32(ss.textboxssjcfd4.Text);
                    zidongheqiu.ssjd1 = Convert.ToInt32(ss.textboxssjd1.Text);
                    zidongheqiu.ssjd2 = Convert.ToInt32(ss.textboxssjd2.Text);
                    zidongheqiu.ssjd3 = Convert.ToInt32(ss.textboxssjd3.Text);
                    zidongheqiu.ssjd4 = Convert.ToInt32(ss.textboxssjd4.Text);
                    zidongheqiu.ssyc1 = int.Parse(ss.datagridviewss.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.ssyc2 = int.Parse(ss.datagridviewss.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.ssyc3 = int.Parse(ss.datagridviewss.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.ssyc4 = int.Parse(ss.datagridviewss.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.ssyc5 = int.Parse(ss.datagridviewss.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.ssyc6 = int.Parse(ss.datagridviewss.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.ssyc7 = int.Parse(ss.datagridviewss.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.ssyc8 = int.Parse(ss.datagridviewss.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.ssyc9 = int.Parse(ss.datagridviewss.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("sheshou"))
                {
                    if (Json.readjson("sheshou") == "true")
                    {
                        ss.checkboxsheshou.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
            {
                if (!Json.checkjson("ncbanxuanjian"))
                {
                    ncbx.comboboxncbanxuan.SelectedItem = "A";
                }
                else
                {
                    ncbx.comboboxncbanxuan.SelectedItem = Json.readjson("ncbanxuanjian");
                }
                if (!Json.checkjson("ncbxjcfd1"))
                {
                    ncbx.textboxncbxjcfd1.Text = "100";
                }
                else
                {
                    ncbx.textboxncbxjcfd1.Text = Json.readjson("ncbxjcfd1");
                }
                if (!Json.checkjson("ncbxjcfd2"))
                {
                    ncbx.textboxncbxjcfd2.Text = "100";
                }
                else
                {
                    ncbx.textboxncbxjcfd2.Text = Json.readjson("ncbxjcfd2");
                }
                if (!Json.checkjson("ncbxjcfd3"))
                {
                    ncbx.textboxncbxjcfd3.Text = "120";
                }
                else
                {
                    ncbx.textboxncbxjcfd3.Text = Json.readjson("ncbxjcfd3");
                }
                if (!Json.checkjson("ncbxjcfd4"))
                {
                    ncbx.textboxncbxjcfd4.Text = "120";
                }
                else
                {
                    ncbx.textboxncbxjcfd4.Text = Json.readjson("ncbxjcfd4");
                }
                if (!Json.checkjson("ncbxjd1"))
                {
                    ncbx.textboxncbxjd1.Text = "5";
                }
                else
                {
                    ncbx.textboxncbxjd1.Text = Json.readjson("ncbxjd1");
                }
                if (!Json.checkjson("ncbxjd2"))
                {
                    ncbx.textboxncbxjd2.Text = "20";
                }
                else
                {
                    ncbx.textboxncbxjd2.Text = Json.readjson("ncbxjd2");
                }
                if (!Json.checkjson("ncbxjd3"))
                {
                    ncbx.textboxncbxjd3.Text = "25";
                }
                else
                {
                    ncbx.textboxncbxjd3.Text = Json.readjson("ncbxjd3");
                }
                if (!Json.checkjson("ncbxjd4"))
                {
                    ncbx.textboxncbxjd4.Text = "25";
                }
                else
                {
                    ncbx.textboxncbxjd4.Text = Json.readjson("ncbxjd4");
                }
                if (!Json.checkjson("ncbxyc1"))
                {
                    ncbx.datagridviewncbx.Rows.Add("第一次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("分身", 10);
                    ncbx.datagridviewncbx.Rows.Add("第二次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("分身", 10);
                    ncbx.datagridviewncbx.Rows.Add("第三次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("分身", 10);
                    ncbx.datagridviewncbx.Rows.Add("第四次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncbx.datagridviewncbx.Rows.Add("第一次拖动鼠标", Json.readjson("ncbxyc1"));
                    ncbx.datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc2"));
                    ncbx.datagridviewncbx.Rows.Add("第二次拖动鼠标", Json.readjson("ncbxyc3"));
                    ncbx.datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc4"));
                    ncbx.datagridviewncbx.Rows.Add("第三次拖动鼠标", Json.readjson("ncbxyc5"));
                    ncbx.datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc6"));
                    ncbx.datagridviewncbx.Rows.Add("第四次拖动鼠标", Json.readjson("ncbxyc7"));
                    ncbx.datagridviewncbx.Rows.Add("最后分身延迟", Json.readjson("ncbxyc8"));
                }
                neicunheqiu.ncbanxuanjian = MainForm.GetVirtualKeyCode(ncbx.comboboxncbanxuan.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncbxjcfd1 = Convert.ToInt32(ncbx.textboxncbxjcfd1.Text);
                    neicunheqiu.ncbxjcfd2 = Convert.ToInt32(ncbx.textboxncbxjcfd2.Text);
                    neicunheqiu.ncbxjcfd3 = Convert.ToInt32(ncbx.textboxncbxjcfd3.Text);
                    neicunheqiu.ncbxjcfd4 = Convert.ToInt32(ncbx.textboxncbxjcfd4.Text);
                    neicunheqiu.ncbxjd1 = Convert.ToInt32(ncbx.textboxncbxjd1.Text);
                    neicunheqiu.ncbxjd2 = Convert.ToInt32(ncbx.textboxncbxjd2.Text);
                    neicunheqiu.ncbxjd3 = Convert.ToInt32(ncbx.textboxncbxjd3.Text);
                    neicunheqiu.ncbxjd4 = Convert.ToInt32(ncbx.textboxncbxjd4.Text);
                    neicunheqiu.ncbxyc1 = int.Parse(ncbx.datagridviewncbx.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc2 = int.Parse(ncbx.datagridviewncbx.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc3 = int.Parse(ncbx.datagridviewncbx.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc4 = int.Parse(ncbx.datagridviewncbx.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc5 = int.Parse(ncbx.datagridviewncbx.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc6 = int.Parse(ncbx.datagridviewncbx.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc7 = int.Parse(ncbx.datagridviewncbx.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc8 = int.Parse(ncbx.datagridviewncbx.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncbanxuan"))
                {
                    if (Json.readjson("ncbanxuan") == "true")
                    {
                        ncbx.checkboxncbanxuan.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
            {
                if (!Json.checkjson("ncxuanzhuanjian"))
                {
                    ncxz.comboboxncxuanzhuan.SelectedItem = "A";
                }
                else
                {
                    ncxz.comboboxncxuanzhuan.SelectedItem = Json.readjson("ncxuanzhuanjian");
                }
                if (!Json.checkjson("ncxzjcfd1"))
                {
                    ncxz.textboxncxzjcfd1.Text = "90";
                }
                else
                {
                    ncxz.textboxncxzjcfd1.Text = Json.readjson("ncxzjcfd1");
                }
                if (!Json.checkjson("ncxzjcfd2"))
                {
                    ncxz.textboxncxzjcfd2.Text = "85";
                }
                else
                {
                    ncxz.textboxncxzjcfd2.Text = Json.readjson("ncxzjcfd2");
                }
                if (!Json.checkjson("ncxzjcfd3"))
                {
                    ncxz.textboxncxzjcfd3.Text = "75";
                }
                else
                {
                    ncxz.textboxncxzjcfd3.Text = Json.readjson("ncxzjcfd3");
                }
                if (!Json.checkjson("ncxzjcfd4"))
                {
                    ncxz.textboxncxzjcfd4.Text = "70";
                }
                else
                {
                    ncxz.textboxncxzjcfd4.Text = Json.readjson("ncxzjcfd4");
                }
                if (!Json.checkjson("ncxzjd1"))
                {
                    ncxz.textboxncxzjd1.Text = "20";
                }
                else
                {
                    ncxz.textboxncxzjd1.Text = Json.readjson("ncxzjd1");
                }
                if (!Json.checkjson("ncxzjd2"))
                {
                    ncxz.textboxncxzjd2.Text = "25";
                }
                else
                {
                    ncxz.textboxncxzjd2.Text = Json.readjson("ncxzjd2");
                }
                if (!Json.checkjson("ncxzjd3"))
                {
                    ncxz.textboxncxzjd3.Text = "25";
                }
                else
                {
                    ncxz.textboxncxzjd3.Text = Json.readjson("ncxzjd3");
                }
                if (!Json.checkjson("ncxzjd4"))
                {
                    ncxz.textboxncxzjd4.Text = "40";
                }
                else
                {
                    ncxz.textboxncxzjd4.Text = Json.readjson("ncxzjd4");
                }
                if (!Json.checkjson("ncxzyc1"))
                {
                    ncxz.datagridviewncxz.Rows.Add("第一次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("分身", 10);
                    ncxz.datagridviewncxz.Rows.Add("第二次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("分身", 10);
                    ncxz.datagridviewncxz.Rows.Add("第三次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("分身", 10);
                    ncxz.datagridviewncxz.Rows.Add("第四次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncxz.datagridviewncxz.Rows.Add("第一次拖动鼠标", Json.readjson("ncxzyc1"));
                    ncxz.datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc2"));
                    ncxz.datagridviewncxz.Rows.Add("第二次拖动鼠标", Json.readjson("ncxzyc3"));
                    ncxz.datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc4"));
                    ncxz.datagridviewncxz.Rows.Add("第三次拖动鼠标", Json.readjson("ncxzyc5"));
                    ncxz.datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc6"));
                    ncxz.datagridviewncxz.Rows.Add("第四次拖动鼠标", Json.readjson("ncxzyc7"));
                    ncxz.datagridviewncxz.Rows.Add("最后分身延迟", Json.readjson("ncxzyc8"));
                }
                neicunheqiu.ncxuanzhuanjian = MainForm.GetVirtualKeyCode(ncxz.comboboxncxuanzhuan.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncxzjcfd1 = Convert.ToInt32(ncxz.textboxncxzjcfd1.Text);
                    neicunheqiu.ncxzjcfd2 = Convert.ToInt32(ncxz.textboxncxzjcfd2.Text);
                    neicunheqiu.ncxzjcfd3 = Convert.ToInt32(ncxz.textboxncxzjcfd3.Text);
                    neicunheqiu.ncxzjcfd4 = Convert.ToInt32(ncxz.textboxncxzjcfd4.Text);
                    neicunheqiu.ncxzjd1 = Convert.ToInt32(ncxz.textboxncxzjd1.Text);
                    neicunheqiu.ncxzjd2 = Convert.ToInt32(ncxz.textboxncxzjd2.Text);
                    neicunheqiu.ncxzjd3 = Convert.ToInt32(ncxz.textboxncxzjd3.Text);
                    neicunheqiu.ncxzjd4 = Convert.ToInt32(ncxz.textboxncxzjd4.Text);
                    neicunheqiu.ncxzyc1 = int.Parse(ncxz.datagridviewncxz.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc2 = int.Parse(ncxz.datagridviewncxz.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc3 = int.Parse(ncxz.datagridviewncxz.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc4 = int.Parse(ncxz.datagridviewncxz.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc5 = int.Parse(ncxz.datagridviewncxz.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc6 = int.Parse(ncxz.datagridviewncxz.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc7 = int.Parse(ncxz.datagridviewncxz.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc8 = int.Parse(ncxz.datagridviewncxz.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncxuanzhuan"))
                {
                    if (Json.readjson("ncxuanzhuan") == "true")
                    {
                        ncxz.checkboxncxuanzhuan.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
            {
                if (!Json.checkjson("ncsheshoujian"))
                {
                    ncss.comboboxncsheshou.SelectedItem = "A";
                }
                else
                {
                    ncss.comboboxncsheshou.SelectedItem = Json.readjson("ncsheshoujian");
                }
                if (!Json.checkjson("ncssjcfd1"))
                {
                    ncss.textboxncssjcfd1.Text = "135";
                }
                else
                {
                    ncss.textboxncssjcfd1.Text = Json.readjson("ncssjcfd1");
                }
                if (!Json.checkjson("ncssjcfd2"))
                {
                    ncss.textboxncssjcfd2.Text = "135";
                }
                else
                {
                    ncss.textboxncssjcfd2.Text = Json.readjson("ncssjcfd2");
                }
                if (!Json.checkjson("ncssjcfd3"))
                {
                    ncss.textboxncssjcfd3.Text = "100";
                }
                else
                {
                    ncss.textboxncssjcfd3.Text = Json.readjson("ncssjcfd3");
                }
                if (!Json.checkjson("ncssjcfd4"))
                {
                    ncss.textboxncssjcfd4.Text = "150";
                }
                else
                {
                    ncss.textboxncssjcfd4.Text = Json.readjson("ncssjcfd4");
                }
                if (!Json.checkjson("ncssjd1"))
                {
                    ncss.textboxncssjd1.Text = "0";
                }
                else
                {
                    ncss.textboxncssjd1.Text = Json.readjson("ncssjd1");
                }
                if (!Json.checkjson("ncssjd2"))
                {
                    ncss.textboxncssjd2.Text = "60";
                }
                else
                {
                    ncss.textboxncssjd2.Text = Json.readjson("ncssjd2");
                }
                if (!Json.checkjson("ncssjd3"))
                {
                    ncss.textboxncssjd3.Text = "-50";
                }
                else
                {
                    ncss.textboxncssjd3.Text = Json.readjson("ncssjd3");
                }
                if (!Json.checkjson("ncssjd4"))
                {
                    ncss.textboxncssjd4.Text = "0";
                }
                else
                {
                    ncss.textboxncssjd4.Text = Json.readjson("ncssjd4");
                }
                if (!Json.checkjson("ncssyc1"))
                {
                    ncss.datagridviewncss.Rows.Add("第一次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("分身", 10);
                    ncss.datagridviewncss.Rows.Add("第二次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("分身", 10);
                    ncss.datagridviewncss.Rows.Add("第三次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("分身", 10);
                    ncss.datagridviewncss.Rows.Add("第四次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncss.datagridviewncss.Rows.Add("第一次拖动鼠标", Json.readjson("ncssyc1"));
                    ncss.datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc2"));
                    ncss.datagridviewncss.Rows.Add("第二次拖动鼠标", Json.readjson("ncssyc3"));
                    ncss.datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc4"));
                    ncss.datagridviewncss.Rows.Add("第三次拖动鼠标", Json.readjson("ncssyc5"));
                    ncss.datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc6"));
                    ncss.datagridviewncss.Rows.Add("第四次拖动鼠标", Json.readjson("ncssyc7"));
                    ncss.datagridviewncss.Rows.Add("最后分身延迟", Json.readjson("ncssyc8"));
                }
                neicunheqiu.ncsheshoujian = MainForm.GetVirtualKeyCode(ncss.comboboxncsheshou.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncssjcfd1 = Convert.ToInt32(ncss.textboxncssjcfd1.Text);
                    neicunheqiu.ncssjcfd2 = Convert.ToInt32(ncss.textboxncssjcfd2.Text);
                    neicunheqiu.ncssjcfd3 = Convert.ToInt32(ncss.textboxncssjcfd3.Text);
                    neicunheqiu.ncssjcfd4 = Convert.ToInt32(ncss.textboxncssjcfd4.Text);
                    neicunheqiu.ncssjd1 = Convert.ToInt32(ncss.textboxncssjd1.Text);
                    neicunheqiu.ncssjd2 = Convert.ToInt32(ncss.textboxncssjd2.Text);
                    neicunheqiu.ncssjd3 = Convert.ToInt32(ncss.textboxncssjd3.Text);
                    neicunheqiu.ncssjd4 = Convert.ToInt32(ncss.textboxncssjd4.Text);
                    neicunheqiu.ncssyc1 = int.Parse(ncss.datagridviewncss.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc2 = int.Parse(ncss.datagridviewncss.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc3 = int.Parse(ncss.datagridviewncss.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc4 = int.Parse(ncss.datagridviewncss.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc5 = int.Parse(ncss.datagridviewncss.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc6 = int.Parse(ncss.datagridviewncss.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc7 = int.Parse(ncss.datagridviewncss.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc8 = int.Parse(ncss.datagridviewncss.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncsheshou"))
                {
                    if (Json.readjson("ncsheshou") == "true")
                    {
                        ncss.checkboxncsheshou.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["sanjiao1"] is sanjiao1 sj1)
            {
                if (!Json.checkjson("sanjiaojian"))
                {
                    sj1.comboboxsanjiao1.SelectedItem = "A";
                }
                else
                {
                    sj1.comboboxsanjiao1.SelectedItem = Json.readjson("sanjiaojian");
                }
                if (!Json.checkjson("sjjcfd"))
                {
                    sj1.textboxsj1jcfd.Text = "100";
                }
                else
                {
                    sj1.textboxsj1jcfd.Text = Json.readjson("sjjcfd");
                }
                if (!Json.checkjson("sjjd"))
                {
                    sj1.textboxsj1jd.Text = "180";
                }
                else
                {
                    sj1.textboxsj1jd.Text = Json.readjson("sjjd");
                }
                if (!Json.checkjson("sjyc1"))
                {
                    sj1.datagridviewsj1.Rows.Add("鼠标左键按下", 20);
                    sj1.datagridviewsj1.Rows.Add("第一次拖动鼠标", 50);
                    sj1.datagridviewsj1.Rows.Add("分身", 10);
                    sj1.datagridviewsj1.Rows.Add("第二次拖动鼠标", 50);
                    sj1.datagridviewsj1.Rows.Add("分身", 10);
                    sj1.datagridviewsj1.Rows.Add("第三次拖动鼠标", 50);
                    sj1.datagridviewsj1.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    sj1.datagridviewsj1.Rows.Add("鼠标左键按下", Json.readjson("sjyc1"));
                    sj1.datagridviewsj1.Rows.Add("第一次拖动鼠标", Json.readjson("sjyc2"));
                    sj1.datagridviewsj1.Rows.Add("分身", Json.readjson("sjyc3"));
                    sj1.datagridviewsj1.Rows.Add("第二次拖动鼠标", Json.readjson("sjyc4"));
                    sj1.datagridviewsj1.Rows.Add("分身", Json.readjson("sjyc5"));
                    sj1.datagridviewsj1.Rows.Add("第三次拖动鼠标", Json.readjson("sjyc6"));
                    sj1.datagridviewsj1.Rows.Add("最后分身延迟", Json.readjson("sjyc7"));
                }
                try
                {
                    zidongheqiu.sanjiaojcfd = Convert.ToInt32(sj1.textboxsj1jcfd.Text);
                    zidongheqiu.sanjiaojd = Convert.ToInt32(sj1.textboxsj1jd.Text);
                    zidongheqiu.sanjiaojian = MainForm.GetVirtualKeyCode(sj1.comboboxsanjiao1.SelectedItem.ToString());
                }
                catch
                {

                }
                try
                {
                    zidongheqiu.sjyc1 = int.Parse(sj1.datagridviewsj1.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sjyc2 = int.Parse(sj1.datagridviewsj1.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sjyc3 = int.Parse(sj1.datagridviewsj1.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sjyc4 = int.Parse(sj1.datagridviewsj1.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sjyc5 = int.Parse(sj1.datagridviewsj1.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.sjyc6 = int.Parse(sj1.datagridviewsj1.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.sjyc7 = int.Parse(sj1.datagridviewsj1.Rows[6].Cells[1].Value.ToString());

                }
                catch
                {

                }

                if (Json.checkjson("sanjiao"))
                {
                    if (Json.readjson("sanjiao") == "true")
                    {
                        sj1.checkboxsanjiao1.Checked = true;
                    }
                }
                if (Json.checkjson("sanjiaojiantou"))
                {
                    if (Json.readjson("sanjiaojiantou") == "true")
                    {
                        sj1.checkboxsanjiao1.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["sanjiao2"] is sanjiao2 sj2)
            {
                if (!Json.checkjson("sanjiao2jian"))
                {
                    sj2.comboboxsanjiao2.SelectedItem = "A";
                }
                else
                {
                    sj2.comboboxsanjiao2.SelectedItem = Json.readjson("sanjiao2jian");
                }
                if (!Json.checkjson("sj2jcfd"))
                {
                    sj2.textboxsj2jcfd.Text = "100";
                }
                else
                {
                    sj2.textboxsj2jcfd.Text = Json.readjson("sj2jcfd");
                }
                if (!Json.checkjson("sj2jd"))
                {
                    sj2.textboxsj2jd.Text = "160";
                }
                else
                {
                    sj2.textboxsj2jd.Text = Json.readjson("sj2jd");
                }
                if (!Json.checkjson("sj2yc1"))
                {
                    sj2.datagridviewsj2.Rows.Add("鼠标左键按下", 20);
                    sj2.datagridviewsj2.Rows.Add("第一次拖动鼠标", 50);
                    sj2.datagridviewsj2.Rows.Add("分身", 10);
                    sj2.datagridviewsj2.Rows.Add("第二次拖动鼠标", 50);
                    sj2.datagridviewsj2.Rows.Add("分身", 10);
                    sj2.datagridviewsj2.Rows.Add("第三次拖动鼠标", 50);
                    sj2.datagridviewsj2.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    sj2.datagridviewsj2.Rows.Add("鼠标左键按下", Json.readjson("sj2yc1"));
                    sj2.datagridviewsj2.Rows.Add("第一次拖动鼠标", Json.readjson("sj2yc2"));
                    sj2.datagridviewsj2.Rows.Add("分身", Json.readjson("sj2yc3"));
                    sj2.datagridviewsj2.Rows.Add("第二次拖动鼠标", Json.readjson("sj2yc4"));
                    sj2.datagridviewsj2.Rows.Add("分身", Json.readjson("sj2yc5"));
                    sj2.datagridviewsj2.Rows.Add("第三次拖动鼠标", Json.readjson("sj2yc6"));
                    sj2.datagridviewsj2.Rows.Add("最后分身延迟", Json.readjson("sj2yc7"));
                }
                try
                {
                    zidongheqiu.sanjiao2jcfd = Convert.ToInt32(sj2.textboxsj2jcfd.Text);
                    zidongheqiu.sanjiao2jd = Convert.ToInt32(sj2.textboxsj2jd.Text);
                    zidongheqiu.sanjiao2jian = MainForm.GetVirtualKeyCode(sj2.comboboxsanjiao2.SelectedItem.ToString());
                }
                catch
                {

                }
                try
                {
                    zidongheqiu.sj2yc1 = int.Parse(sj2.datagridviewsj2.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc2 = int.Parse(sj2.datagridviewsj2.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc3 = int.Parse(sj2.datagridviewsj2.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc4 = int.Parse(sj2.datagridviewsj2.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc5 = int.Parse(sj2.datagridviewsj2.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc6 = int.Parse(sj2.datagridviewsj2.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc7 = int.Parse(sj2.datagridviewsj2.Rows[6].Cells[1].Value.ToString());

                }
                catch
                {

                }

                if (Json.checkjson("sanjiao2"))
                {
                    if (Json.readjson("sanjiao2") == "true")
                    {
                        sj2.checkboxsanjiao2.Checked = true;
                    }
                }
                if (Json.checkjson("sanjiao2jiantou"))
                {
                    if (Json.readjson("sanjiao2jiantou") == "true")
                    {
                        sj2.checkboxsanjiao2.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj1)
            {
                if (!Json.checkjson("ncsanjiaojian"))
                {
                    ncsj1.comboboxncsanjiao1.SelectedItem = "A";
                }
                else
                {
                    ncsj1.comboboxncsanjiao1.SelectedItem = Json.readjson("ncsanjiaojian");
                }
                if (!Json.checkjson("ncsjjcfd"))
                {
                    ncsj1.textboxncsj1jcfd.Text = "100";
                }
                else
                {
                    ncsj1.textboxncsj1jcfd.Text = Json.readjson("ncsjjcfd");
                }
                if (!Json.checkjson("ncsjjd"))
                {
                    ncsj1.textboxncsj1jd.Text = "180";
                }
                else
                {
                    ncsj1.textboxncsj1jd.Text = Json.readjson("ncsjjd");
                }
                if (!Json.checkjson("ncsjyc1"))
                {
                    ncsj1.datagridviewncsj1.Rows.Add("第一次拖动鼠标", 50);
                    ncsj1.datagridviewncsj1.Rows.Add("分身", 10);
                    ncsj1.datagridviewncsj1.Rows.Add("第二次拖动鼠标", 50);
                    ncsj1.datagridviewncsj1.Rows.Add("分身", 10);
                    ncsj1.datagridviewncsj1.Rows.Add("第三次拖动鼠标", 50);
                    ncsj1.datagridviewncsj1.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncsj1.datagridviewncsj1.Rows.Add("第一次拖动鼠标", Json.readjson("ncsjyc1"));
                    ncsj1.datagridviewncsj1.Rows.Add("分身", Json.readjson("ncsjyc2"));
                    ncsj1.datagridviewncsj1.Rows.Add("第二次拖动鼠标", Json.readjson("ncsjyc3"));
                    ncsj1.datagridviewncsj1.Rows.Add("分身", Json.readjson("ncsjyc4"));
                    ncsj1.datagridviewncsj1.Rows.Add("第三次拖动鼠标", Json.readjson("ncsjyc5"));
                    ncsj1.datagridviewncsj1.Rows.Add("最后分身延迟", Json.readjson("ncsjyc6"));
                }
                try
                {
                    neicunheqiu.ncsanjiaojcfd = Convert.ToInt32(ncsj1.textboxncsj1jcfd.Text);
                    neicunheqiu.ncsanjiaojd = Convert.ToInt32(ncsj1.textboxncsj1jd.Text);
                    neicunheqiu.ncsanjiaojian = MainForm.GetVirtualKeyCode(ncsj1.comboboxncsanjiao1.SelectedItem.ToString());
                }
                catch
                {

                }
                try
                {
                    neicunheqiu.ncsjyc1 = int.Parse(ncsj1.datagridviewncsj1.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc2 = int.Parse(ncsj1.datagridviewncsj1.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc3 = int.Parse(ncsj1.datagridviewncsj1.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc4 = int.Parse(ncsj1.datagridviewncsj1.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc5 = int.Parse(ncsj1.datagridviewncsj1.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc6 = int.Parse(ncsj1.datagridviewncsj1.Rows[5].Cells[1].Value.ToString());

                }
                catch
                {

                }

                if (Json.checkjson("ncsanjiao"))
                {
                    if (Json.readjson("ncsanjiao") == "true")
                    {
                        ncsj1.checkboxncsanjiao1.Checked = true;
                    }
                }
                if (Json.checkjson("ncsanjiaojiantou"))
                {
                    if (Json.readjson("ncsanjiaojiantou") == "true")
                    {
                        ncsj1.checkboxncsanjiao1.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
            {
                if (!Json.checkjson("ncsanjiao2jian"))
                {
                    ncsj2.comboboxncsanjiao2.SelectedItem = "A";
                }
                else
                {
                    ncsj2.comboboxncsanjiao2.SelectedItem = Json.readjson("ncsanjiao2jian");
                }
                if (!Json.checkjson("ncsj2jcfd"))
                {
                    ncsj2.textboxncsj2jcfd.Text = "100";
                }
                else
                {
                    ncsj2.textboxncsj2jcfd.Text = Json.readjson("ncsj2jcfd");
                }
                if (!Json.checkjson("ncsj2jd"))
                {
                    ncsj2.textboxncsj2jd.Text = "160";
                }
                else
                {
                    ncsj2.textboxncsj2jd.Text = Json.readjson("ncsj2jd");
                }
                if (!Json.checkjson("ncsj2yc1"))
                {
                    ncsj2.datagridviewncsj2.Rows.Add("第一次拖动鼠标", 50);
                    ncsj2.datagridviewncsj2.Rows.Add("分身", 10);
                    ncsj2.datagridviewncsj2.Rows.Add("第二次拖动鼠标", 50);
                    ncsj2.datagridviewncsj2.Rows.Add("分身", 10);
                    ncsj2.datagridviewncsj2.Rows.Add("第三次拖动鼠标", 50);
                    ncsj2.datagridviewncsj2.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncsj2.datagridviewncsj2.Rows.Add("第一次拖动鼠标", Json.readjson("ncsj2yc1"));
                    ncsj2.datagridviewncsj2.Rows.Add("分身", Json.readjson("ncsj2yc2"));
                    ncsj2.datagridviewncsj2.Rows.Add("第二次拖动鼠标", Json.readjson("ncsj2yc3"));
                    ncsj2.datagridviewncsj2.Rows.Add("分身", Json.readjson("ncsj2yc4"));
                    ncsj2.datagridviewncsj2.Rows.Add("第三次拖动鼠标", Json.readjson("ncsj2yc5"));
                    ncsj2.datagridviewncsj2.Rows.Add("最后分身延迟", Json.readjson("ncsj2yc6"));
                }
                try
                {
                    neicunheqiu.ncsanjiao2jcfd = Convert.ToInt32(ncsj2.textboxncsj2jcfd.Text);
                    neicunheqiu.ncsanjiao2jd = Convert.ToInt32(ncsj2.textboxncsj2jd.Text);
                    neicunheqiu.ncsanjiao2jian = MainForm.GetVirtualKeyCode(ncsj2.comboboxncsanjiao2.SelectedItem.ToString());
                }
                catch
                {

                }
                try
                {
                    neicunheqiu.ncsj2yc1 = int.Parse(ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc2 = int.Parse(ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc3 = int.Parse(ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc4 = int.Parse(ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc5 = int.Parse(ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc6 = int.Parse(ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value.ToString());

                }
                catch
                {

                }

                if (Json.checkjson("ncsanjiao2"))
                {
                    if (Json.readjson("ncsanjiao2") == "true")
                    {
                        ncsj2.checkboxncsanjiao2.Checked = true;
                    }
                }
                if (Json.checkjson("ncsanjiao2jiantou"))
                {
                    if (Json.readjson("ncsanjiao2jiantou") == "true")
                    {
                        ncsj2.checkboxncsanjiao2.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["sifencehe"] is sifencehe sfch)
            {
                if (!Json.checkjson("sifencehejian"))
                {
                    sfch.comboboxsifencehe.SelectedItem = "A";
                }
                else
                {
                    sfch.comboboxsifencehe.SelectedItem = Json.readjson("sifencehejian");
                }
                if (!Json.checkjson("sfchjcfd"))
                {
                    sfch.textboxsfchjcfd.Text = "100";
                }
                else
                {
                    sfch.textboxsfchjcfd.Text = Json.readjson("sfchjcfd");
                }
                if (!Json.checkjson("sfchyc1"))
                {
                    sfch.datagridviewsfch.Rows.Add("分身", 10);
                    sfch.datagridviewsfch.Rows.Add("分身", 10);
                    sfch.datagridviewsfch.Rows.Add("第一次拖动鼠标", 50);
                    sfch.datagridviewsfch.Rows.Add("第二次拖动鼠标", 50);
                    sfch.datagridviewsfch.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    sfch.datagridviewsfch.Rows.Add("分身", Json.readjson("sfchyc1"));
                    sfch.datagridviewsfch.Rows.Add("分身", Json.readjson("sfchyc2"));
                    sfch.datagridviewsfch.Rows.Add("第一次拖动鼠标", Json.readjson("sfchyc3"));
                    sfch.datagridviewsfch.Rows.Add("第二次拖动鼠标", Json.readjson("sfchyc4"));
                    sfch.datagridviewsfch.Rows.Add("最后分身延迟", Json.readjson("sfchyc5"));
                }
                zidongheqiu.sifencehejian = MainForm.GetVirtualKeyCode(sfch.comboboxsifencehe.SelectedItem.ToString());
                try
                {
                    zidongheqiu.sifencehejcfd = Convert.ToInt32(sfch.textboxsfchjcfd.Text);
                    zidongheqiu.sfchyc1 = int.Parse(sfch.datagridviewsfch.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc2 = int.Parse(sfch.datagridviewsfch.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc3 = int.Parse(sfch.datagridviewsfch.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc4 = int.Parse(sfch.datagridviewsfch.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc5 = int.Parse(sfch.datagridviewsfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("sifencehe"))
                {
                    if (Json.readjson("sifencehe") == "true")
                    {
                        sfch.checkboxsifencehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
            {
                if (!Json.checkjson("ncsifencehejian"))
                {
                    ncsfch.comboboxncsifencehe.SelectedItem = "A";
                }
                else
                {
                    ncsfch.comboboxncsifencehe.SelectedItem = Json.readjson("ncsifencehejian");
                }
                if (!Json.checkjson("ncsfchjcfd"))
                {
                    ncsfch.textboxncsfchjcfd.Text = "100";
                }
                else
                {
                    ncsfch.textboxncsfchjcfd.Text = Json.readjson("ncsfchjcfd");
                }
                if (!Json.checkjson("ncsfchyc1"))
                {
                    ncsfch.datagridviewncsfch.Rows.Add("分身", 10);
                    ncsfch.datagridviewncsfch.Rows.Add("分身", 10);
                    ncsfch.datagridviewncsfch.Rows.Add("第一次拖动鼠标", 50);
                    ncsfch.datagridviewncsfch.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncsfch.datagridviewncsfch.Rows.Add("分身", Json.readjson("ncsfchyc1"));
                    ncsfch.datagridviewncsfch.Rows.Add("分身", Json.readjson("ncsfchyc2"));
                    ncsfch.datagridviewncsfch.Rows.Add("第一次拖动鼠标", Json.readjson("ncsfchyc3"));
                    ncsfch.datagridviewncsfch.Rows.Add("最后分身延迟", Json.readjson("ncsfchyc4"));
                }
                neicunheqiu.ncsifencehejian = MainForm.GetVirtualKeyCode(ncsfch.comboboxncsifencehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncsifencehejcfd = Convert.ToInt32(ncsfch.textboxncsfchjcfd.Text);
                    neicunheqiu.ncsfchyc1 = int.Parse(ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc2 = int.Parse(ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc3 = int.Parse(ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc4 = int.Parse(ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncsifencehe"))
                {
                    if (Json.readjson("ncsifencehe") == "true")
                    {
                        ncsfch.checkboxncsifencehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["zhongfencehe"] is zhongfencehe zfch)
            {
                if (!Json.checkjson("yuandijian"))
                {
                    zfch.comboboxzhongfencehe.SelectedItem = "A";
                }
                else
                {
                    zfch.comboboxzhongfencehe.SelectedItem = Json.readjson("yuandijian");
                }
                if (!Json.checkjson("ydjcfd"))
                {
                    zfch.textboxzfchjcfd.Text = "100";
                }
                else
                {
                    zfch.textboxzfchjcfd.Text = Json.readjson("ydjcfd");
                }
                if (!Json.checkjson("ydhqyc1"))
                {
                    zfch.datagridviewzfch.Rows.Add("第一次拖动鼠标", 50);
                    zfch.datagridviewzfch.Rows.Add("分身", 10);
                    zfch.datagridviewzfch.Rows.Add("第二次拖动鼠标", 50);
                    zfch.datagridviewzfch.Rows.Add("分身", 10);
                    zfch.datagridviewzfch.Rows.Add("第三次拖动鼠标", 50);
                    zfch.datagridviewzfch.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    zfch.datagridviewzfch.Rows.Add("第一次拖动鼠标", Json.readjson("ydhqyc1"));
                    zfch.datagridviewzfch.Rows.Add("分身", Json.readjson("ydhqyc2"));
                    zfch.datagridviewzfch.Rows.Add("第二次拖动鼠标", Json.readjson("ydhqyc3"));
                    zfch.datagridviewzfch.Rows.Add("分身", Json.readjson("ydhqyc4"));
                    zfch.datagridviewzfch.Rows.Add("第三次拖动鼠标", Json.readjson("ydhqyc5"));
                    zfch.datagridviewzfch.Rows.Add("最后分身延迟", Json.readjson("ydhqyc6"));
                }
                zidongheqiu.yuandiheqiujian = MainForm.GetVirtualKeyCode(zfch.comboboxzhongfencehe.SelectedItem.ToString());
                try
                {
                    zidongheqiu.yuandiheqiujcfd = Convert.ToInt32(zfch.textboxzfchjcfd.Text);
                    zidongheqiu.ydhqyc1 = int.Parse(zfch.datagridviewzfch.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc2 = int.Parse(zfch.datagridviewzfch.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc3 = int.Parse(zfch.datagridviewzfch.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc4 = int.Parse(zfch.datagridviewzfch.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc5 = int.Parse(zfch.datagridviewzfch.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc6 = int.Parse(zfch.datagridviewzfch.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("yuandi"))
                {
                    if (Json.readjson("yuandi") == "true")
                    {
                        zfch.checkboxzhongfencehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
            {
                if (!Json.checkjson("ncyuandijian"))
                {
                    nczfch.comboboxnczhongfencehe.SelectedItem = "A";
                }
                else
                {
                    nczfch.comboboxnczhongfencehe.SelectedItem = Json.readjson("ncyuandijian");
                }
                if (!Json.checkjson("ncydjcfd"))
                {
                    nczfch.textboxnczfchjcfd.Text = "100";
                }
                else
                {
                    nczfch.textboxnczfchjcfd.Text = Json.readjson("ncydjcfd");
                }
                if (!Json.checkjson("ncydhqyc1"))
                {
                    nczfch.datagridviewnczfch.Rows.Add("分身", 10);
                    nczfch.datagridviewnczfch.Rows.Add("第二次拖动鼠标", 50);
                    nczfch.datagridviewnczfch.Rows.Add("分身", 10);
                    nczfch.datagridviewnczfch.Rows.Add("第三次拖动鼠标", 50);
                    nczfch.datagridviewnczfch.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    nczfch.datagridviewnczfch.Rows.Add("分身", Json.readjson("ncydhqyc1"));
                    nczfch.datagridviewnczfch.Rows.Add("第二次拖动鼠标", Json.readjson("ncydhqyc2"));
                    nczfch.datagridviewnczfch.Rows.Add("分身", Json.readjson("ncydhqyc3"));
                    nczfch.datagridviewnczfch.Rows.Add("第三次拖动鼠标", Json.readjson("ncydhqyc4"));
                    nczfch.datagridviewnczfch.Rows.Add("最后分身延迟", Json.readjson("ncydhqyc5"));
                }
                neicunheqiu.ncyuandiheqiujian = MainForm.GetVirtualKeyCode(nczfch.comboboxnczhongfencehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncyuandiheqiujcfd = Convert.ToInt32(nczfch.textboxnczfchjcfd.Text);
                    neicunheqiu.ncydhqyc1 = int.Parse(nczfch.datagridviewnczfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc2 = int.Parse(nczfch.datagridviewnczfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc3 = int.Parse(nczfch.datagridviewnczfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc4 = int.Parse(nczfch.datagridviewnczfch.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc5 = int.Parse(nczfch.datagridviewnczfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncyuandi"))
                {
                    if (Json.readjson("ncyuandi") == "true")
                    {
                        nczfch.checkboxnczhongfencehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["houyangcehe"] is houyangcehe hych)
            {
                if (!Json.checkjson("houyangjian"))
                {
                    hych.comboboxhouyangcehe.SelectedItem = "A";
                }
                else
                {
                    hych.comboboxhouyangcehe.SelectedItem = Json.readjson("houyangjian");
                }
                if (!Json.checkjson("hyjcfd"))
                {
                    hych.textboxhychjcfd.Text = "120";
                }
                else
                {
                    hych.textboxhychjcfd.Text = Json.readjson("hyjcfd");
                }
                if (!Json.checkjson("hyjd"))
                {
                    hych.textboxhychjd.Text = "40";
                }
                else
                {
                    hych.textboxhychjd.Text = Json.readjson("hyjd");
                }

                if (!Json.checkjson("hyyc1"))
                {
                    hych.datagridviewhych.Rows.Add("分身", 10);
                    hych.datagridviewhych.Rows.Add("鼠标左键按下", 20);
                    hych.datagridviewhych.Rows.Add("第一次拖动鼠标", 50);
                    hych.datagridviewhych.Rows.Add("分身", 10);
                    hych.datagridviewhych.Rows.Add("第二次拖动鼠标", 50);
                    hych.datagridviewhych.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    hych.datagridviewhych.Rows.Add("分身", Json.readjson("hyyc1"));
                    hych.datagridviewhych.Rows.Add("鼠标左键按下", Json.readjson("hyyc2"));
                    hych.datagridviewhych.Rows.Add("第一次拖动鼠标", Json.readjson("hyyc3"));
                    hych.datagridviewhych.Rows.Add("分身", Json.readjson("hyyc4"));
                    hych.datagridviewhych.Rows.Add("第二次拖动鼠标", Json.readjson("hyyc5"));
                    hych.datagridviewhych.Rows.Add("最后分身延迟", Json.readjson("hyyc6"));
                }
                zidongheqiu.houyangjian = MainForm.GetVirtualKeyCode(hych.comboboxhouyangcehe.SelectedItem.ToString());
                try
                {
                    zidongheqiu.houyangjcfd = Convert.ToInt32(hych.textboxhychjcfd.Text);
                    zidongheqiu.houyangjd = Convert.ToInt32(hych.textboxhychjd.Text);
                    zidongheqiu.hyyc1 = int.Parse(hych.datagridviewhych.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.hyyc2 = int.Parse(hych.datagridviewhych.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.hyyc3 = int.Parse(hych.datagridviewhych.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.hyyc4 = int.Parse(hych.datagridviewhych.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.hyyc5 = int.Parse(hych.datagridviewhych.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.hyyc6 = int.Parse(hych.datagridviewhych.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("houyang"))
                {
                    if (Json.readjson("houyang") == "true")
                    {
                        hych.checkboxhouyangcehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
            {
                if (!Json.checkjson("nchouyangjian"))
                {
                    nchych.comboboxnchouyangcehe.SelectedItem = "A";
                }
                else
                {
                    nchych.comboboxnchouyangcehe.SelectedItem = Json.readjson("nchouyangjian");
                }
                if (!Json.checkjson("nchyjcfd"))
                {
                    nchych.textboxnchychjcfd.Text = "120";
                }
                else
                {
                    nchych.textboxnchychjcfd.Text = Json.readjson("nchyjcfd");
                }
                if (!Json.checkjson("nchyjd"))
                {
                    nchych.textboxnchychjd.Text = "40";
                }
                else
                {
                    nchych.textboxnchychjd.Text = Json.readjson("nchyjd");
                }

                if (!Json.checkjson("nchyyc1"))
                {
                    nchych.datagridviewnchych.Rows.Add("分身", 10);
                    nchych.datagridviewnchych.Rows.Add("第一次拖动鼠标", 50);
                    nchych.datagridviewnchych.Rows.Add("分身", 10);
                    nchych.datagridviewnchych.Rows.Add("第二次拖动鼠标", 50);
                    nchych.datagridviewnchych.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    nchych.datagridviewnchych.Rows.Add("分身", Json.readjson("nchyyc1"));
                    nchych.datagridviewnchych.Rows.Add("第一次拖动鼠标", Json.readjson("nchyyc2"));
                    nchych.datagridviewnchych.Rows.Add("分身", Json.readjson("nchyyc3"));
                    nchych.datagridviewnchych.Rows.Add("第二次拖动鼠标", Json.readjson("nchyyc4"));
                    nchych.datagridviewnchych.Rows.Add("最后分身延迟", Json.readjson("nchyyc5"));
                }
                neicunheqiu.nchouyangjian = MainForm.GetVirtualKeyCode(nchych.comboboxnchouyangcehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.nchouyangjcfd = Convert.ToInt32(nchych.textboxnchychjcfd.Text);
                    neicunheqiu.nchouyangjd = Convert.ToInt32(nchych.textboxnchychjd.Text);
                    neicunheqiu.nchyyc1 = int.Parse(nchych.datagridviewnchych.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc2 = int.Parse(nchych.datagridviewnchych.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc3 = int.Parse(nchych.datagridviewnchych.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc4 = int.Parse(nchych.datagridviewnchych.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc5 = int.Parse(nchych.datagridviewnchych.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("nchouyang"))
                {
                    if (Json.readjson("nchouyang") == "true")
                    {
                        nchych.checkboxnchouyangcehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["fuzhugongneng"] is fuzhugongneng fzgn)
            {
                if (Json.checkjson("youjiankongqiu"))
                {
                    fzgn.textboxkongqiu.Text = Json.readjson("youjiankongqiu");
                }
                else
                {
                    fzgn.textboxkongqiu.Text = "100";
                }
                if (Json.checkjson("kongqiukq"))
                {
                    if (Json.readjson("kongqiukq") == "true")
                    {
                        fzgn.checkboxkongqiu.Checked = true;
                    }
                }
                if (Json.checkjson("suoqiu"))
                {
                    if (Json.readjson("suoqiu") == "true")
                    {
                        fzgn.checkboxsuoqiu.Checked = true;
                    }
                }
                if (!Json.checkjson("suoqiujian"))
                {
                    fzgn.comboBoxtsuoqiu.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxtsuoqiu.SelectedItem = Json.readjson("suoqiujian");
                }
                if (!Json.checkjson("tb1kjj"))
                {
                    fzgn.comboBoxtb1.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxtb1.SelectedItem = Json.readjson("tb1kjj");
                }
                if (!Json.checkjson("tb2kjj"))
                {
                    fzgn.comboBoxtb2.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxtb2.SelectedItem = Json.readjson("tb2kjj");
                }
                if (!Json.checkjson("tb3kjj"))
                {
                    fzgn.comboBoxtb3.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxtb3.SelectedItem = Json.readjson("tb3kjj");
                }
                if (!Json.checkjson("mnj1"))
                {
                    fzgn.comboBoxmnj1.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxmnj1.SelectedItem = Json.readjson("mnj1");
                }
                if (!Json.checkjson("mnj2"))
                {
                    fzgn.comboBoxmnj2.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxmnj2.SelectedItem = Json.readjson("mnj2");
                }
                if (!Json.checkjson("mnj3"))
                {
                    fzgn.comboBoxmnj3.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxmnj3.SelectedItem = Json.readjson("mnj3");
                }

                if (Json.checkjson("tb1"))
                {
                    if (Json.readjson("tb1") == "true")
                    {
                        fuzhugongneng.tb1 = true;
                        fzgn.checkboxtb1.Checked = true;
                    }
                }
                if (Json.checkjson("tb2"))
                {
                    if (Json.readjson("tb2") == "true")
                    {
                        fuzhugongneng.tb2 = true;
                        fzgn.checkboxtb2.Checked = true;
                    }
                }
                if (Json.checkjson("tb3"))
                {
                    if (Json.readjson("tb3") == "true")
                    {
                        fuzhugongneng.tb3 = true;
                        fzgn.checkboxtb3.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["honggongneng"] is honggongneng hgn)
            {
                if (Json.checkjson("erfenhong"))
                {
                    if (Json.readjson("erfenhong") == "true")
                    {
                        hgn.checkBoxerfenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxerfenhong.Checked = false;
                    }
                }
                if (Json.checkjson("sifenhong"))
                {
                    if (Json.readjson("sifenhong") == "true")
                    {
                        hgn.checkBoxsifenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxsifenhong.Checked = false;
                    }
                }
                if (Json.checkjson("bafenhong"))
                {
                    if (Json.readjson("befenhong") == "true")
                    {
                        hgn.checkBoxbafenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxbafenhong.Checked = false;
                    }
                }
                if (Json.checkjson("gangganhong"))
                {
                    if (Json.readjson("gangganhong") == "true")
                    {
                        hgn.checkBoxgangganhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxgangganhong.Checked = false;
                    }
                }
                if (Json.checkjson("shiliufenhong"))
                {
                    if (Json.readjson("shiliufenhong") == "true")
                    {
                        hgn.checkBoxshiliufenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxshiliufenhong.Checked = false;
                    }
                }
                if (Json.checkjson("yuandihong"))
                {
                    if (Json.readjson("yuandihong") == "true")
                    {
                        hgn.checkBoxyuandihong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxyuandihong.Checked = false;
                    }
                }
                if (Json.checkjson("changanhong1"))
                {
                    if (Json.readjson("changanhong1") == "true")
                    {
                        hgn.checkBoxchanganhong1.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxchanganhong1.Checked = false;
                    }
                }
                if (Json.checkjson("changanhong2"))
                {
                    if (Json.readjson("changanhong2") == "true")
                    {
                        hgn.checkBoxchanganhong2.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxchanganhong2.Checked = false;
                    }
                }
                if (Json.checkjson("lianjihong1"))
                {
                    if (Json.readjson("lianjihong1") == "true")
                    {
                        hgn.checkBoxlianjihong1.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxlianjihong1.Checked = false;
                    }
                }
                if (Json.checkjson("lianjihong2"))
                {
                    if (Json.readjson("lianjihong2") == "true")
                    {
                        hgn.checkBoxlianjihong2.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxlianjihong2.Checked = false;
                    }
                }
                if (Json.checkjson("erfenhongjian"))
                {
                    hgn.comboBoxerfenhong.SelectedItem = Json.readjson("erfenhongjian");
                }
                else
                {
                    hgn.comboBoxerfenhong.SelectedItem = "A";
                }
                if (Json.checkjson("sifenhongjian"))
                {
                    hgn.comboBoxsifenhong.SelectedItem = Json.readjson("sifenhongjian");
                }
                else
                {
                    hgn.comboBoxsifenhong.SelectedItem = "A";
                }
                if (Json.checkjson("bafenhongjian"))
                {
                    hgn.comboBoxbafenhong.SelectedItem = Json.readjson("bafenhongjian");
                }
                else
                {
                    hgn.comboBoxbafenhong.SelectedItem = "A";
                }
                if (Json.checkjson("shiliufenhongjian"))
                {
                    hgn.comboBoxshiliufenhong.SelectedItem = Json.readjson("shiliufenhongjian");
                }
                else
                {
                    hgn.comboBoxshiliufenhong.SelectedItem = "A";
                }
                if (Json.checkjson("gangganhongjian"))
                {
                    hgn.comboBoxgangganhong.SelectedItem = Json.readjson("gangganhongjian");
                }
                else
                {
                    hgn.comboBoxgangganhong.SelectedItem = "A";
                }
                if (Json.checkjson("yuandihongjian"))
                {
                    hgn.comboBoxyuandihong.SelectedItem = Json.readjson("yuandihongjian");
                }
                else
                {
                    hgn.comboBoxyuandihong.SelectedItem = "A";
                }
                if (Json.checkjson("changanhong1jian"))
                {
                    hgn.comboBoxchanganhong1.SelectedItem = Json.readjson("changanhong1jian");
                }
                else
                {
                    hgn.comboBoxchanganhong1.SelectedItem = "A";
                }
                if (Json.checkjson("changanhongmnj1"))
                {
                    hgn.comboBoxchanganhongmnj1.SelectedItem = Json.readjson("changanhongmnj1");
                }
                else
                {
                    hgn.comboBoxchanganhongmnj1.SelectedItem = "A";
                }
                if (Json.checkjson("changanhong2jian"))
                {
                    hgn.comboBoxchanganhong2.SelectedItem = Json.readjson("changanhong2jian");
                }
                else
                {
                    hgn.comboBoxchanganhong2.SelectedItem = "A";
                }
                if (Json.checkjson("changanhongmnj2"))
                {
                    hgn.comboBoxchanganhongmnj2.SelectedItem = Json.readjson("changanhongmnj2");
                }
                else
                {
                    hgn.comboBoxchanganhongmnj2.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihong1jian"))
                {
                    hgn.comboBoxlianjihong1.SelectedItem = Json.readjson("lianjihong1jian");
                }
                else
                {
                    hgn.comboBoxlianjihong1.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihongmnj1"))
                {
                    hgn.comboBoxlianjihongmnj1.SelectedItem = Json.readjson("lianjihongmnj1");
                }
                else
                {
                    hgn.comboBoxlianjihongmnj1.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihong2jian"))
                {
                    hgn.comboBoxlianjihong2.SelectedItem = Json.readjson("lianjihong2jian");
                }
                else
                {
                    hgn.comboBoxlianjihong2.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihongmnj2"))
                {
                    hgn.comboBoxlianjihongmnj2.SelectedItem = Json.readjson("lianjihongmnj2");
                }
                else
                {
                    hgn.comboBoxlianjihongmnj2.SelectedItem = "A";
                }
                if (Json.checkjson("erfenhongwait"))
                {
                    hgn.textboxerfenhong.Text = Json.readjson("erfenhongwait");
                    try
                    {
                        honggongneng.erfenhongwait = int.Parse(hgn.textboxerfenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.erfenhongwait = 0;
                    }
                }
                else
                {
                    honggongneng.erfenhongwait = 0;
                    hgn.textboxerfenhong.Text = "0";
                }
                if (Json.checkjson("sifenhongwait"))
                {
                    hgn.textboxsifenhong.Text = Json.readjson("sifenhongwait");
                    try
                    {
                        honggongneng.sifenhongwait = int.Parse(hgn.textboxsifenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.sifenhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.sifenhongwait = 50;
                    hgn.textboxsifenhong.Text = "50";
                }
                if (Json.checkjson("bafenhongwait"))
                {
                    hgn.textboxbafenhong.Text = Json.readjson("bafenhongwait");
                    try
                    {
                        honggongneng.bafenhongwait = int.Parse(hgn.textboxbafenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.bafenhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.bafenhongwait = 50;
                    hgn.textboxbafenhong.Text = "50";
                }
                if (Json.checkjson("shiliufenhongwait"))
                {
                    hgn.textboxshiliufenhong.Text = Json.readjson("shiliufenhongwait");
                    try
                    {
                        honggongneng.shiliufenhongwait = int.Parse(hgn.textboxshiliufenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.shiliufenhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.shiliufenhongwait = 50;
                    hgn.textboxshiliufenhong.Text = "50";
                }
                if (Json.checkjson("gangganhongwait"))
                {
                    hgn.textboxgangganhong.Text = Json.readjson("gangganhongwait");
                    try
                    {
                        honggongneng.gangganhongwait = int.Parse(hgn.textboxgangganhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.gangganhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.gangganhongwait = 50;
                    hgn.textboxgangganhong.Text = "50";
                }
                if (Json.checkjson("yuandihongwait"))
                {
                    hgn.textboxyuandihong.Text = Json.readjson("yuandihongwait");
                    try
                    {
                        honggongneng.yuandihongwait = int.Parse(hgn.textboxyuandihong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.yuandihongwait = 50;
                    }
                }
                else
                {
                    honggongneng.yuandihongwait = 50;
                    hgn.textboxyuandihong.Text = "50";
                }
                if (Json.checkjson("changanhong1wait"))
                {
                    hgn.textboxchanganhong1.Text = Json.readjson("changanhong1wait");
                    try
                    {
                        honggongneng.changanhong1wait = int.Parse(hgn.textboxchanganhong1.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.changanhong1wait = 50;
                    }
                }
                else
                {
                    honggongneng.changanhong1wait = 50;
                    hgn.textboxchanganhong1.Text = "50";
                }
                if (Json.checkjson("changanhong2wait"))
                {
                    hgn.textboxchanganhong2.Text = Json.readjson("changanhong2wait");
                    try
                    {
                        honggongneng.changanhong2wait = int.Parse(hgn.textboxchanganhong2.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.changanhong2wait = 50;
                    }
                }
                else
                {
                    honggongneng.changanhong2wait = 50;
                    hgn.textboxchanganhong2.Text = "50";
                }
                if (Json.checkjson("lianjihong1wait"))
                {
                    hgn.textboxlianjihong1.Text = Json.readjson("lianjihong1wait");
                    try
                    {
                        honggongneng.lianjihong1wait = int.Parse(hgn.textboxlianjihong1.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.lianjihong1wait = 50;
                    }
                }
                else
                {
                    honggongneng.lianjihong1wait = 50;
                    hgn.textboxlianjihong1.Text = "50";
                }
                if (Json.checkjson("lianjihong2wait"))
                {
                    hgn.textboxlianjihong2.Text = Json.readjson("lianjihong2wait");
                    try
                    {
                        honggongneng.lianjihong2wait = int.Parse(hgn.textboxlianjihong2.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.lianjihong2wait = 50;
                    }
                }
                else
                {
                    honggongneng.lianjihong2wait = 50;
                    hgn.textboxlianjihong2.Text = "50";
                }
            }
            if (Application.OpenForms["heipingkadian"] is heipingkadian hpkd)
            {
                if (Json.checkjson("heipingkjj"))
                {
                    hpkd.comboBoxheipingkjj.SelectedItem = Json.readjson("heipingkjj");
                }
                else
                {
                    hpkd.comboBoxheipingkjj.SelectedItem = "A";
                }
                if (Json.checkjson("hpfscs"))
                {
                    hpkd.textboxhpfscs.Text = Json.readjson("hpfscs");
                }
                else
                {
                    hpkd.textboxhpfscs.Text = "1";
                }
                if (Json.checkjson("hpcsbl"))
                {
                    hpkd.textboxhpcsbl.Text = Json.readjson("hpcsbl");
                }
                else
                {
                    hpkd.textboxhpcsbl.Text = "0.5";
                }
                if (Json.checkjson("hpfsyc"))
                {
                    hpkd.textboxhpfsyc.Text = Json.readjson("hpfsyc");
                }
                else
                {
                    hpkd.textboxhpfsyc.Text = "50";
                }
                if (Json.checkjson("hptzbc"))
                {
                    hpkd.textboxhpglbc.Text = Json.readjson("hptzbc");
                }
                else
                {
                    hpkd.textboxhpglbc.Text = "10";
                }
            }
        }

        private void checkboxlwblk_CheckedChanged(object sender, bool value)
        {
            if (checkboxlwblk.Checked)
            {
                Json.writejson2("zidongdenglu", "true");
            }
            else
            {
                Json.writejson2("zidongdenglu", "false");
            }
        }

        private void moniqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Json.writejson("ismoniqi", moniqi.SelectedItem.ToString());
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
            kaishi = int.Parse(uiTextBox2.Text);

        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
            jieshu = int.Parse(uiTextBox3.Text);
        }
    }
}