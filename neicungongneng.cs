using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ANYE_Balls.API;
using static ANYE_Balls.Struct;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ANYE_Balls
{

    public partial class neicungongneng : Form
    {
        //全局变量
        public static float gunlun;
        public const int WH_MOUSE_LL = 14;
        public const int WM_MOUSEWHEEL = 0x020A;
        public static IntPtr hookID;
        public LowLevelMouseProc mouseProc;

        //线程标识
        public static bool tuqiuthstatu = false;
        public static bool shiyethstatu = false;
        public static bool yaogan10000thstatu = false;
        public static bool yaoganjiasuthstatu = false;
        public static bool quanjubiansuthstatu = false;

        public neicungongneng()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }


        private void neicungongneng_Load(object sender, EventArgs e)
        {
            if (Json.checkjson("gunlunzuixiaozhi"))
            {
                textboxshiyemin.Text = Json.readjson("gunlunzuixiaozhi");
            }
            else
            {
                textboxshiyemin.Text = "1.0";
            }
            if (Json.checkjson("gunlunzuidazhi"))
            {
                textboxshiyemax.Text = Json.readjson("gunlunzuidazhi");
            }
            else
            {
                textboxshiyemax.Text = "10.0";
            }
            if (Json.checkjson("buchang"))
            {
                textboxshiyebuchang.Text = Json.readjson("buchang");
            }
            else
            {
                textboxshiyebuchang.Text = "0.5";
            }
        }

        private void buttonshiye_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonshiye.Loading = true;
                List<long> addresssy = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.quanjuaob1, MainForm.quanjuaob1.Length);
                if (addresssy.Count > 0)
                {
                    foreach (long addr in addresssy)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.shiye = addr + 0x424 + 8;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.shiye = addr + 0x300;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.shiye = addr + 0x300;
                        }
                        tishi("视野单独搜索成功\r\n");
                        int bytesRead;
                        byte[] data = new byte[sizeof(float)];
                        ReadProcessMemory(MainForm.hProcess, MainForm.shiye + 4, data, sizeof(float), out bytesRead);
                        if (Json.checkjson("shiye"))
                        {
                            textBoxshiyezhi.Text = Json.readjson("shiye");
                        }
                        else
                        {
                            textBoxshiyezhi.Text = BitConverter.ToSingle(data, 0).ToString("0.00");
                        }
                        if (!shiyethstatu)
                        {
                            new Thread(shiyethread).Start();
                            shiyethstatu = true;
                        }
                    }
                }
                else
                {
                    tishi("视野单独搜索失败\r\n");
                }
                buttonshiye.Loading = false;
            }).Start();
        }



        public void shiyethread()
        {
            while (true)
            {
                int byteswrite;
                float value;
                try
                {
                    value = float.Parse(textBoxshiyezhi.Text);
                    //Debug.WriteLine(value);
                    gunlun = value;
                }
                catch (FormatException)
                {
                    value = 1.0f;
                }
                WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                Thread.Sleep(10);
            }
        }

        void tishi(string str)
        {
            if (Application.OpenForms["MainForm"] is MainForm mainForm)
            {
                mainForm.tishi.Text += str;
            }
        }

        public void tuqiuthread()
        {
            while (true)
            {
                if (checkboxtuqiu.Checked)
                {
                    int byteswrite;
                    float value = 0;
                    API.WriteProcessMemory(MainForm.hProcess, (MainForm.tuqiu), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    API.WriteProcessMemory(MainForm.hProcess, (MainForm.tuqiu + 8), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(1);
            }
        }

        private void buttontuqiu_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttontuqiu.Loading = true;
                List<long> addresstq = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.quanjuaob1, MainForm.quanjuaob1.Length);
                if (addresstq.Count > 0)
                {
                    foreach (long addr in addresstq)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.tuqiu = addr + 0x90;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.tuqiu = addr + 0x7C;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.tuqiu = addr + 0x7C;
                        }
                        tishi("吐球双连点单独搜索成功\r\n");
                        checkboxtuqiu.Checked = true;
                        if (!tuqiuthstatu)
                        {
                            new Thread(tuqiuthread).Start();
                            tuqiuthstatu = true;
                        }
                    }
                }
                else
                {
                    tishi("吐球双连点单独搜索失败\r\n");
                }
                buttontuqiu.Loading = false;
            }).Start();
        }

        private void buttonyaogan10000_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaogan10000.Loading = true;
                List<long> addressyg10000 = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.yaogan10000aob, MainForm.yaogan10000aob.Length);
                if (addressyg10000.Count > 0)
                {
                    foreach (long addr in addressyg10000)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.yaogan10000 = addr - 0x51;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.yaogan10000 = addr - 0x3D;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.yaogan10000 = addr - 0x3D;
                        }
                        tishi("遥杆10000%单独搜索成功\r\n");
                        checkboxyaogan10000.Checked = true;
                        if (!yaogan10000thstatu)
                        {
                            new Thread(yg10000).Start();
                            yaogan10000thstatu = true;
                        }
                    }
                }
                else
                {
                    tishi("遥杆10000%单独搜索失败\r\n");
                }
                buttonyaogan10000.Loading = false;
            }).Start();
        }

        public void yg10000()
        {
            while (true)
            {
                if (checkboxyaogan10000.Checked)
                {
                    int byteswrite;
                    int value = 10000;
                    API.WriteProcessMemory(MainForm.hProcess, MainForm.yaogan10000, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(1);
            }
        }

        public void ygjiasu()
        {
            while (true)
            {
                byte[] data = new byte[sizeof(float)];
                int a;
                float zhuangtai;
                ReadProcessMemory(MainForm.hProcess, MainForm.yaoganjiasu, data, sizeof(float), out a);
                try
                {
                    zhuangtai = BitConverter.ToSingle(data, 0);
                    //Debug.WriteLine(zhuangtai);
                }
                catch
                {
                    zhuangtai = 0;
                }
                if (zhuangtai == 0)
                {
                    MainForm.shifouzhanju = false;
                }
                else
                {
                    MainForm.shifouzhanju = true;
                }
                if (checkboxygyh.Checked && zhuangtai != 0)
                {
                    int byteswrite;
                    float value = 100000000;
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiasu, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(100);
            }
        }

        private void buttonyaoganyouhua_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaoganyouhua.Loading = true;
                List<long> addressygjs = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.quanjuaob1, MainForm.quanjuaob1.Length);
                if (addressygjs.Count > 0)
                {
                    foreach (long addr in addressygjs)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.yaoganjiasu = addr + 0x48;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.yaoganjiasu = addr + 0x48;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.yaoganjiasu = addr + 0x48;
                        }
                        tishi("遥杆优化加速单独搜索成功\r\n");
                        checkboxygyh.Checked = true;
                        if (!yaoganjiasuthstatu)
                        {
                            new Thread(ygjiasu).Start();
                            yaoganjiasuthstatu = true;
                        }
                    }
                }
                else
                {
                    tishi("遥杆优化加速单独搜索失败\r\n");
                }
                buttonyaoganyouhua.Loading = false;
            }).Start();
        }

        private void buttonnianhe_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonnianhe.Loading = true;
                List<long> addressnh = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.nianheaob, MainForm.nianheaob.Length);
                if (addressnh.Count > 0)
                {
                    foreach (long addr in addressnh)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.nianhe = addr + 0x24;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.nianhe = addr + 0x24;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.nianhe = addr + 0x24;
                        }
                        tishi("粘合单独搜索成功\r\n");
                        int bytesRead;
                        byte[] data = new byte[sizeof(float)];
                        ReadProcessMemory(MainForm.hProcess, MainForm.nianhe, data, sizeof(float), out bytesRead);
                        if (Json.checkjson("nianhe"))
                        {
                            textboxnianhe.Text = Json.readjson("nianhe");
                        }
                        else
                        {
                            textboxnianhe.Text = BitConverter.ToSingle(data, 0).ToString("0.000");
                        }
                    }
                }
                else
                {
                    tishi("粘合单独搜索失败\r\n");
                }
                buttonnianhe.Loading = false;
            }).Start();
        }

        public void quanjubiansuthread()
        {
            while (true)
            {
                int byteswrite;
                float value;
                try
                {
                    value = float.Parse(textboxbiansu.Text);
                }
                catch (Exception ex)
                {
                    value = 1.0f;
                }
                WriteProcessMemory(MainForm.hProcess, MainForm.biansu, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                Thread.Sleep(1);
            }
        }

        private void buttonbiansu_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonbiansu.Loading = true;
                List<long> addressbs = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.biansuaob, MainForm.biansuaob.Length);
                if (addressbs.Count > 0)
                {
                    foreach (long addr in addressbs)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.biansu = addr;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.biansu = addr;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.biansu = addr;
                        }
                        tishi("全局变速单独搜索成功\r\n");
                        int bytesRead;
                        byte[] data = new byte[sizeof(float)];
                        ReadProcessMemory(MainForm.hProcess, MainForm.biansu, data, sizeof(float), out bytesRead);
                        if (Json.checkjson("biansu"))
                        {
                            textboxbiansu.Text = Json.readjson("biansu");
                        }
                        else
                        {
                            textboxbiansu.Text = BitConverter.ToSingle(data, 0).ToString("0.0");
                        }
                        if (!quanjubiansuthstatu)
                        {
                            new Thread(quanjubiansuthread).Start();
                            quanjubiansuthstatu = true;
                        }
                    }
                }
                else
                {
                    tishi("全局变速单独搜索失败\r\n");
                }
                buttonbiansu.Loading = false;
            }).Start();
        }

        private void buttonnichengdaxiao_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonnichengdaxiao.Loading = true;
                List<long> addressnc = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.ncdxaob, MainForm.ncdxaob.Length);
                if (addressnc.Count > 0)
                {
                    foreach (long addr in addressnc)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.nichengdaxiao = addr - 0x08;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.nichengdaxiao = addr - 0x08;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.nichengdaxiao = addr - 0x08;
                        }
                        tishi("昵称大小单独搜索成功\r\n");
                        int bytesRead;
                        byte[] data = new byte[sizeof(float)];
                        ReadProcessMemory(MainForm.hProcess, MainForm.nichengdaxiao, data, sizeof(float), out bytesRead);
                        if (Json.checkjson("nichengdaxiao"))
                        {
                            textboxnichengdaxiao.Text = Json.readjson("nichengdaxiao");
                        }
                        else
                        {
                            textboxnichengdaxiao.Text = BitConverter.ToSingle(data, 0).ToString("0.000");
                        }
                    }
                }
                else
                {
                    tishi("昵称大小单独搜索失败\r\n");
                }
                buttonnichengdaxiao.Loading = false;
            }).Start();
        }

        private void buttonyaoganyanchi_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaoganyanchi.Loading = true;
                List<long> addressygyc = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.biansuaob, MainForm.biansuaob.Length);
                if (addressygyc.Count > 0)
                {
                    foreach (long addr in addressygyc)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.yaoganyanchi = addr - 0xB4;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.yaoganyanchi = addr - 0xB4;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.yaoganyanchi = addr - 0xB4;
                        }
                        tishi("遥杆延迟单独搜索成功\r\n");
                        checkboxygyc.Checked = true;
                        int byteswrite;
                        float value = 0.005f;
                        WriteProcessMemory(MainForm.hProcess, MainForm.yaoganyanchi, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    }
                }
                else
                {
                    tishi("遥杆延迟单独搜索失败\r\n");
                }
                buttonyaoganyanchi.Loading = false;
            }).Start();
        }

        private void buttonyaoganjiexian_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaoganjiexian.Loading = true;
                List<long> addressygjx = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.yaoganjiexianaob, MainForm.yaoganjiexianaob.Length);
                if (addressygjx.Count > 0)
                {
                    foreach (long addr in addressygjx)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.yaoganjiexian = addr - 0x24;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.yaoganjiexian = addr - 0x24;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.yaoganjiexian = addr - 0x24;
                        }
                        tishi("遥杆/分身解限单独搜索成功\r\n");
                        checkboxygjx.Checked = true;
                        int byteswrite;
                        float value = 0.0f;
                        WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    }
                }
                else
                {
                    tishi("遥杆/分身解限单独搜索失败\r\n");
                }
                buttonyaoganjiexian.Loading = false;
            }).Start();
        }

        private void buttonyaoganrongcha_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaoganrongcha.Loading = true;
                List<long> addressygrc = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.yaoganhuitanaob, MainForm.yaoganhuitanaob.Length);
                if (addressygrc.Count > 0)
                {
                    foreach (long addr in addressygrc)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.yaoganrongcha = addr + 0x24;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.yaoganrongcha = addr + 0x24;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.yaoganrongcha = addr + 0x24;
                        }
                        tishi("遥杆容差单独搜索成功\r\n");
                        int bytesRead;
                        byte[] data = new byte[sizeof(float)];
                        ReadProcessMemory(MainForm.hProcess, MainForm.yaoganrongcha, data, sizeof(float), out bytesRead);
                        if (Json.checkjson("yaoganrongcha"))
                        {
                            textboxygrc.Text = Json.readjson("yaoganrongcha");
                        }
                        else
                        {
                            textboxygrc.Text = textboxygrc.Text = BitConverter.ToSingle(data, 0).ToString("0");
                        }
                    }
                }
                else
                {
                    tishi("遥杆容差单独搜索失败\r\n");
                }
                buttonyaoganrongcha.Loading = false;
            }).Start();
        }

        private void buttonyaoganhuitan_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaoganhuitan.Loading = true;
                List<long> addressyght = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.yaoganhuitanaob, MainForm.yaoganhuitanaob.Length);
                if (addressyght.Count > 0)
                {
                    foreach (long addr in addressyght)
                    {
                        if (MainForm.choose == "MuMu模拟器")
                        {
                            MainForm.yaoganrongcha = addr + 0x28;
                        }
                        else if (MainForm.choose == "雷电模拟器5")
                        {
                            MainForm.yaoganrongcha = addr + 0x28;
                        }
                        else if (MainForm.choose == "雷电模拟器9")
                        {
                            MainForm.yaoganrongcha = addr + 0x28;
                        }
                        tishi("遥杆回弹单独搜索成功\r\n");
                        int bytesRead;
                        byte[] data = new byte[sizeof(float)];
                        ReadProcessMemory(MainForm.hProcess, MainForm.yaoganhuitan, data, sizeof(float), out bytesRead);
                        if (Json.checkjson("yaoganhuitan"))
                        {
                            textboxyght.Text = Json.readjson("yaoganhuitan");
                        }
                        else
                        {
                            textboxyght.Text = BitConverter.ToSingle(data, 0).ToString("0");
                        }
                    }
                }
                else
                {
                    tishi("遥杆回弹单独搜索失败\r\n");
                }
                buttonyaoganhuitan.Loading = false;
            }).Start();
        }

        private void textBoxshiyezhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }

        }

        private void textboxshiyemin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxshiyemax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxshiyebuchang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxnianhe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxbiansu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxnichengdaxiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void uiTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void uiTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBoxshiyezhi_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textBoxshiyezhi.Text);
                gunlun = value;
            }
            catch (FormatException)
            {
                value = 1.0f;
            }
            API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("shiye", textBoxshiyezhi.Text);
        }

        private void checkboxgunlun_CheckedChanged(object sender, bool value)
        {
            if (checkboxgunlun.Checked)
            {
                mouseProc = HookCallback;
                hookID = SetHook(mouseProc);
            }
            else
            {
                UnhookWindowsHookEx(hookID);
            }
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (GetForegroundWindow() == FindWindow(MainForm.lp, null))
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_MOUSEWHEEL)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    IntPtr windowHandle = API.WindowFromPoint(hookStruct.pt);
                    int delta = (short)((hookStruct.mouseData >> 16) & 0xffff);
                    try
                    {
                        if (delta > 0)
                        {
                            if (gunlun < float.Parse(textboxshiyemax.Text))
                            {
                                int byteswrite;
                                gunlun = gunlun + float.Parse(textboxshiyebuchang.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }
                            else
                            {
                                int byteswrite;
                                gunlun = float.Parse(textboxshiyemax.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }
                        }
                        else
                        {
                            if (gunlun > float.Parse(textboxshiyemin.Text))
                            {
                                int byteswrite;
                                gunlun = gunlun - float.Parse(textboxshiyebuchang.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }
                            else
                            {
                                int byteswrite;
                                gunlun = float.Parse(textboxshiyemin.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }

                        }
                    }
                    catch (Exception ex)
                    {

                    }


                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private void textboxnianhe_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxnianhe.Text);
            }
            catch (FormatException)
            {
                value = 0.588f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.nianhe, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("nianhe", textboxnianhe.Text);
        }

        private void textboxnichengdaxiao_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxnichengdaxiao.Text);
            }
            catch (FormatException)
            {
                value = 1.875f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.nichengdaxiao, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("nichengdaxiao", textboxnichengdaxiao.Text);
        }

        private void checkboxygyc_CheckedChanged(object sender, bool value1)
        {
            if (checkboxygyc.Checked)
            {
                int byteswrite;
                float value = 0.005f;
                WriteProcessMemory(MainForm.hProcess, MainForm.yaoganyanchi, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            }
            else
            {
                int byteswrite;
                float value = 0.02f;
                WriteProcessMemory(MainForm.hProcess, MainForm.yaoganyanchi, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            }
        }

        private void checkboxygjx_CheckedChanged(object sender, bool value1)
        {
            if (checkboxygjx.Checked)
            {
                int byteswrite;
                float value = 0.0f;
                API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            }
            else
            {
                int byteswrite;
                float value = 0.789f;
                API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            }
        }

        private void textboxygrc_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value = 0;
            try
            {
                value = float.Parse(textboxygrc.Text);
            }
            catch (FormatException)
            {
                value = 1.0f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.yaoganrongcha, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("yaoganrongcha", textboxygrc.Text);
        }

        private void textboxyght_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value = 0;
            try
            {
                value = float.Parse(textboxyght.Text);
            }
            catch (FormatException)
            {
                value = 40f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.yaoganhuitan, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("yaoganhuitan", textboxyght.Text);
        }

        private void textboxshiyemin_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("gunlunzuixiaozhi", textboxshiyemin.Text);
        }

        private void textboxshiyemax_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("gunlunzuidazhi", textboxshiyemax.Text);
        }

        private void textboxshiyebuchang_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("buchang", textboxshiyebuchang.Text);
        }

        private void textboxbiansu_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxbiansu.Text);
            }
            catch (FormatException)
            {
                value = 1.0f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.biansu, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("biansu", textboxbiansu.Text);
        }

        private void checkboxygyh_CheckedChanged(object sender, bool value)
        {

        }
    }
}
