using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vanara.PInvoke;
using static ANYE_Balls.Struct;
using static ANYE_Balls.API;

namespace ANYE_Balls
{
    public partial class fuzhugongneng : Form
    {
        static bool thkq = false;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Struct.POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        static Struct.RECT mnqRect;
        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int VK_RBUTTON = 0x02;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        IntPtr g_hook;
        private BackgroundWorker hookWorker;
        private readonly object lockObj = new object();
        static object lockObj2 = new object();
        public static float youjiankongqiu;
        public static long tiji;

        public static byte tbj1;
        public static byte tbj2;
        public static byte tbj3;
        public static byte mnjtbj1;
        public static byte mnjtbj2;
        public static byte mnjtbj3;
        public static bool tb1;
        public static bool tb2;
        public static bool tb3;
        private static Struct.POINT mp1, mp2;
        private static bool state;
        private static int yuzhi = 90;

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        static double length;
        static double unitX;
        static double unitY;
        public fuzhugongneng()
        {
            InitializeComponent();
        }
        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(null), 0);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (API.GetForegroundWindow() == API.FindWindow(MainForm.lp, null) && MainForm.shifouzhanju == true)
            {
                if (nCode >= 0 && wParam.ToInt32() == WM_MOUSEMOVE && state)
                {
                    unsafe
                    {
                        MSLLHOOKSTRUCT* pMouseStruct = (MSLLHOOKSTRUCT*)lParam;
                        mp2.X = pMouseStruct->pt.X;
                        mp2.Y = pMouseStruct->pt.Y;
                        int deltaX = mp2.X - mp1.X;
                        int deltaY = mp2.Y - mp1.Y;
                        int distanceSquared = deltaX * deltaX + deltaY * deltaY;
                        if (distanceSquared > yuzhi * yuzhi)
                        {
                            double length = Math.Sqrt(distanceSquared);
                            double unitX = deltaX / length;
                            double unitY = deltaY / length;

                            mp2.X = mp1.X + (int)(unitX * Math.Sqrt(yuzhi * yuzhi));
                            mp2.Y = mp1.Y + (int)(unitY * Math.Sqrt(yuzhi * yuzhi));
                            SetCursorPos(mp2.X, mp2.Y);

                            return (IntPtr)1;
                        }
                    }
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private void checkboxsuoqiu_CheckedChanged(object sender, bool value)
        {
            if (checkboxsuoqiu.Checked)
            {
                //zidongheqiu.suoqiuflag = true;
                neicunheqiu.suoqiuflag = true;
                Json.writejson("suoqiu", "true");
            }
            else
            {
                //zidongheqiu.suoqiuflag = false;
                neicunheqiu.suoqiuflag = false;
                Json.writejson("suoqiu", "false");
            }

        }

        private void checkboxkongqiu_CheckedChanged(object sender, bool value)
        {
            if (checkboxkongqiu.Checked)
            {
                Json.writejson("kongqiukq", "true");
                _hookID = SetHook(_proc);
                if (!thkq)
                {
                    thkq = true;
                    new Thread(() =>
                    {
                        while (true)
                        {
                            if (checkboxkongqiu.Checked && MainForm.shifouzhanju == true)
                            {
                                API.GetWindowRect(MainForm.hWnd, out mnqRect);
                                try
                                {
                                    yuzhi = int.Parse(textboxkongqiu.Text);
                                    yuzhi = (int)(yuzhi * ((float)(mnqRect.right - mnqRect.left) / 1920 * MainForm.ygdx / 1.6));

                                }
                                catch
                                {
                                    yuzhi = 100;
                                    yuzhi = (int)(yuzhi * ((float)(mnqRect.right - mnqRect.left) / 1920 * MainForm.ygdx / 1.6));

                                }
                                if ((GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0)
                                {
                                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                                    state = true;
                                    GetCursorPos(out mp1);

                                    while ((GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0)
                                    {
                                        Thread.Sleep(5);
                                    }
                                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                    state = false;
                                }
                            }

                            Thread.Sleep(1);
                        }
                    }).Start();
                }
            }
            else
            {
                Json.writejson("kongqiukq", "false");
                UnhookWindowsHookEx(_hookID);
            }
        }
        static float readzhitiji(long adr)
        {
            int bytesread;
            IntPtr hProcess = MainForm.hProcess;
            byte[] data = new byte[4];
            ReadProcessMemory(hProcess, adr, data, 4, out bytesread);
            float tiji = BitConverter.ToSingle(data, 0);
            return tiji;
        }
        private void fuzhugongneng_Load(object sender, EventArgs e)
        {
            if (Json.checkjson("youjiankongqiu"))
            {
                textboxkongqiu.Text = Json.readjson("youjiankongqiu");
            }
            else
            {
                textboxkongqiu.Text = "100";
            }
            if (Json.checkjson("kongqiukq"))
            {
                if (Json.readjson("kongqiukq") == "true")
                {
                    checkboxkongqiu.Checked = true;
                }
            }
            if (Json.checkjson("suoqiu"))
            {
                if (Json.readjson("suoqiu") == "true")
                {
                    checkboxsuoqiu.Checked = true;
                }
            }
            if (!Json.checkjson("suoqiujian"))
            {
                comboBoxtsuoqiu.SelectedItem = "A";
            }
            else
            {
                comboBoxtsuoqiu.SelectedItem = Json.readjson("suoqiujian");
            }
            if (!Json.checkjson("tb1kjj"))
            {
                comboBoxtb1.SelectedItem = "A";
            }
            else
            {
                comboBoxtb1.SelectedItem = Json.readjson("tb1kjj");
            }
            if (!Json.checkjson("tb2kjj"))
            {
                comboBoxtb2.SelectedItem = "A";
            }
            else
            {
                comboBoxtb2.SelectedItem = Json.readjson("tb2kjj");
            }
            if (!Json.checkjson("tb3kjj"))
            {
                comboBoxtb3.SelectedItem = "A";
            }
            else
            {
                comboBoxtb3.SelectedItem = Json.readjson("tb3kjj");
            }
            if (!Json.checkjson("mnj1"))
            {
                comboBoxmnj1.SelectedItem = "A";
            }
            else
            {
                comboBoxmnj1.SelectedItem = Json.readjson("mnj1");
            }
            if (!Json.checkjson("mnj2"))
            {
                comboBoxmnj2.SelectedItem = "A";
            }
            else
            {
                comboBoxmnj2.SelectedItem = Json.readjson("mnj2");
            }
            if (!Json.checkjson("mnj3"))
            {
                comboBoxmnj3.SelectedItem = "A";
            }
            else
            {
                comboBoxmnj3.SelectedItem = Json.readjson("mnj3");
            }

            if (Json.checkjson("tb1"))
            {
                if (Json.readjson("tb1") == "true")
                {
                    tb1 = true;
                    checkboxtb1.Checked = true;
                }
            }
            if (Json.checkjson("tb2"))
            {
                if (Json.readjson("tb2") == "true")
                {
                    tb2 = true;
                    checkboxtb2.Checked = true;
                }
            }
            if (Json.checkjson("tb3"))
            {
                if (Json.readjson("tb3") == "true")
                {
                    tb3 = true;
                    checkboxtb3.Checked = true;
                }
            }
            if (Json.checkjson("ygtm"))
            {
                if (Json.readjson("ygtm") == "true")
                {
                    checkboxygtm.Checked = true;
                }
            }
            bool syczj = true;
            new Thread(() =>
            {
                while (true)
                {
                    if (checkboxygtm.Checked)
                    {
                        if (MainForm.shifouzhanju == true && syczj == false)
                        {
                            new Thread(tmyg).Start();
                        }
                        syczj = MainForm.shifouzhanju;
                    }
                    if (GetForegroundWindow() == FindWindow(MainForm.lp, null))
                    {
                        //同步1
                        if (GetKeyState(tbj1) < 0 && tb1)
                        {
                            float tiji = readzhitiji(MainForm.tiji - 0x04);
                            float tijiyuanlai = readzhitiji(MainForm.tiji - 0x04);
                            while (GetKeyState(tbj1) < 0)
                            {
                                tiji = readzhitiji(MainForm.tiji - 0x04);
                                Debug.WriteLine($"体积值：{tiji}");
                                Debug.WriteLine($"上一次体积值：{tijiyuanlai}");
                                if (tiji - tijiyuanlai > tijiyuanlai * 0.15f)
                                {
                                    Debug.WriteLine($"检测到 {mnjtbj1}");
                                    uint scancode = MapVirtualKeyW(mnjtbj1, 0);
                                    keybd_event(mnjtbj1, (byte)scancode, 0, 0);
                                    Thread.Sleep(300);
                                    keybd_event(mnjtbj1, (byte)scancode, 2, 0);
                                    break;
                                }
                                else
                                {
                                    tijiyuanlai = tiji;
                                }
                                Thread.Sleep(1);
                            }
                        }
                        //同步2
                        if (GetKeyState(tbj2) < 0 && tb2)
                        {
                            float tiji = readzhitiji(MainForm.tiji - 0x04);
                            float tijiyuanlai = readzhitiji(MainForm.tiji - 0x04);
                            while (GetKeyState(tbj2) < 0)
                            {
                                tiji = readzhitiji(MainForm.tiji - 0x04);
                                if (tiji - tijiyuanlai > tijiyuanlai * 0.15f)
                                {
                                    uint scancode = MapVirtualKeyW(mnjtbj2, 0);
                                    keybd_event(mnjtbj2, (byte)scancode, 0, 0);
                                    Thread.Sleep(300);
                                    keybd_event(mnjtbj2, (byte)scancode, 2, 0);
                                    break;
                                }
                                else
                                {
                                    tijiyuanlai = tiji;
                                }
                                Thread.Sleep(1);
                            }
                        }
                        //同步3
                        if (GetKeyState(tbj3) < 0 && tb3)
                        {
                            float tiji = readzhitiji(MainForm.tiji - 0x04);
                            float tijiyuanlai = readzhitiji(MainForm.tiji - 0x04);
                            while (GetKeyState(tbj3) < 0)
                            {
                                tiji = readzhitiji(MainForm.tiji - 0x04);
                                if (tiji - tijiyuanlai > tijiyuanlai * 0.15f)
                                {
                                    uint scancode = MapVirtualKeyW(mnjtbj3, 0);
                                    keybd_event(mnjtbj3, (byte)scancode, 0, 0);
                                    Thread.Sleep(300);
                                    keybd_event(mnjtbj3, (byte)scancode, 2, 0);
                                    break;
                                }
                                else
                                {
                                    tijiyuanlai = tiji;
                                }
                                Thread.Sleep(1);
                            }
                        }
                    }
                    Thread.Sleep(1);
                }
            }).Start();
        }

        void tmyg()
        {
            List<long> addressygtm = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.ygtmaob, MainForm.ygtmaob.Length);
            if (addressygtm.Count > 0)
            {
                foreach (long addr in addressygtm)
                {
                    long ygtmadr = addr - 0x1B + 4;
                    Debug.WriteLine(ygtmadr.ToString("X"));
                    int byteswrite;
                    float value = 0.0f;
                    WriteProcessMemory(MainForm.hProcess, ygtmadr, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
            }
        }
        private void textboxkongqiu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                yuzhi = int.Parse(textboxkongqiu.Text);
            }
            catch
            {
                yuzhi = 100;
            }
            Json.writejson("youjiankongqiu", textboxkongqiu.Text);
        }

        private void textboxkongqiu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        static int GetVirtualKeyCode(string keyString)
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
        private void comboBoxtsuoqiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxtsuoqiu.SelectedItem != null)
            {
                neicunheqiu.suoqiujian = GetVirtualKeyCode(comboBoxtsuoqiu.SelectedItem.ToString());
                //zidongheqiu.suoqiujian = GetVirtualKeyCode(comboBoxsuoqiu.SelectedItem.ToString());
            }
            Json.writejson("suoqiujian", comboBoxtsuoqiu.SelectedItem.ToString());
        }

        private void checkboxtb1_CheckedChanged(object sender, bool value)
        {
            if (checkboxtb1.Checked)
            {
                tb1 = true;
                Json.writejson("tb1", "true");
            }
            else
            {
                tb1 = false;
                Json.writejson("tb1", "false");
            }
        }

        private void checkboxtb2_CheckedChanged(object sender, bool value)
        {
            if (checkboxtb2.Checked)
            {
                tb2 = true;
                Json.writejson("tb2", "true");
            }
            else
            {
                tb2 = false;
                Json.writejson("tb2", "false");
            }
        }

        private void checkboxtb3_CheckedChanged(object sender, bool value)
        {
            if (checkboxtb3.Checked)
            {
                tb3 = true;
                Json.writejson("tb3", "true");
            }
            else
            {
                tb3 = false;
                Json.writejson("tb3", "false");
            }
        }

        private void comboBoxtb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbj1 = (byte)GetVirtualKeyCode(comboBoxtb1.SelectedItem.ToString());
            }
            catch
            {
                tbj1 = (byte)GetVirtualKeyCode("A");
            }
            Json.writejson("tb1kjj", comboBoxtb1.SelectedItem.ToString());
        }

        private void comboBoxtb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbj2 = (byte)GetVirtualKeyCode(comboBoxtb2.SelectedItem.ToString());
            }
            catch
            {
                tbj2 = (byte)GetVirtualKeyCode("A");
            }
            Json.writejson("tb2kjj", comboBoxtb2.SelectedItem.ToString());
        }

        private void comboBoxtb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbj3 = (byte)GetVirtualKeyCode(comboBoxtb1.SelectedItem.ToString());
            }
            catch
            {
                tbj3 = (byte)GetVirtualKeyCode("A");
            }
            Json.writejson("tb3kjj", comboBoxtb1.SelectedItem.ToString());
        }

        private void comboBoxmnj1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mnjtbj1 = (byte)GetVirtualKeyCode(comboBoxmnj1.SelectedItem.ToString());
            }
            catch
            {
                mnjtbj1 = (byte)GetVirtualKeyCode("A");
            }
            Json.writejson("mnj1", comboBoxmnj1.SelectedItem.ToString());
        }

        private void comboBoxmnj2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mnjtbj2 = (byte)GetVirtualKeyCode(comboBoxmnj2.SelectedItem.ToString());
            }
            catch
            {
                mnjtbj2 = (byte)GetVirtualKeyCode("A");
            }
            Json.writejson("mnj2", comboBoxmnj2.SelectedItem.ToString());
        }

        private void comboBoxmnj3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mnjtbj3 = (byte)GetVirtualKeyCode(comboBoxmnj3.SelectedItem.ToString());
            }
            catch
            {
                mnjtbj3 = (byte)GetVirtualKeyCode("A");
            }
            Json.writejson("mnj3", comboBoxmnj3.SelectedItem.ToString());
        }

        private void checkbox1_CheckedChanged(object sender, bool value)
        {
            
            if (checkboxygtm.Checked)
            {
                new Thread(tmyg).Start();
                Json.writejson("ygtm", "true");
            }
            else
            {
                Json.writejson("ygtm", "false");
            }
        }
    }
}
