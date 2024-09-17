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
using static ANYE_Balls.Struct;
using static ANYE_Balls.API;
using System.Drawing.Printing;
using ReaLTaiizor.Controls;

namespace ANYE_Balls
{
    public partial class heipingkadian : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "SetWindowsHookEx")]
        public static extern IntPtr SetWindowsHookEx2(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        public static int fsyc;
        public static int fscs;
        public static bool hzxcth;
        public static bool hzxcth2 = false;
        public static float csbl;
        public static int tzbc;

        public static byte[] heipingaob1 = { 0x00, 0x80, 0x3B, 0xC4 };
        public static byte[] heipingaob2 = { 0x00, 0x00, 0x48, 0x44 };

        public static long heiping;
        public static long tiji;
        static heipinghuizhi hzck;
        static heipinghuizhi2 hzck2;

        static string kjj;
        static string kjj2;
        static float tijizhi = 0;
        static float shiyezhi = 1;
        public static float hongquanbanjing = 100, jisuanbanjing, hqjsbj, lqjsbj, bili, ckkd, ckgd, ckbl;
        public static IntPtr hdc;
        public static IntPtr hdc2;
        public static RECT mnqRect;
        public static bool kqflag = false;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        public const int WH_MOUSE_LL = 14;
        public const int WM_MOUSEWHEEL = 0x020A;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static bool shifouqiyong;
        public static bool tsshifouqiyong;
        public static bool heipingcg;
        public static string tuseyanse;
        public static bool tusecg;
        public static float heipingx;//黑屏值
        public static float heipingy;//体积半径
        public static IntPtr hookID;
        public static LowLevelMouseProc mouseProc;
        static Graphics g;
        static Graphics g2;
        static Pen pen;
        static Pen pen1;
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        private const int WM_PAINT = 0x000F;
        public heipingkadian()
        {
            InitializeComponent();
        }
        public static void DrawCircle(Graphics g, Pen pen, float centerX, float centerY, float radius)
        {
            // 计算圆的外接矩形的左上角坐标
            float x = centerX - radius;
            float y = centerY - radius;

            try
            {
                if (g != null)
                {
                    // 绘制圆形
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // 使用抗锯齿模式
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality; // 设置像素偏移模式为高质量
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // 设置插值模式为高质量双三次插值

                    g.DrawEllipse(pen, x, y, radius * 2, radius * 2);
                }
                else
                {
                    //MessageBox.Show("请先初始化");
                }
            }
            catch
            {
                //MessageBox.Show("请先初始化");
            }
        }
        private void buttonfeipingcsh_Click(object sender, EventArgs e)
        {
            hzck = new heipinghuizhi();
            hzck2 = new heipinghuizhi2();
            hzck.Show();
            hzck.Hide();
            hzck2.Show();
            hzck2.Hide();

            new Thread(() =>
            {
                buttonheipingcsh.Loading = true;
                List<long> address = Memory.ScanPatternParallel(MainForm.hProcess, heipingaob1, heipingaob1.Length);
                int bytesread2;
                bool shuzhiduibi = false;



                if (address.Count > 0)
                {
                    shuzhiduibi = false;
                    int NUM_THREADS;
                    NUM_THREADS = Environment.ProcessorCount;
                    Task[] tasks = new Task[NUM_THREADS];
                    int addressesPerThread = address.Count / NUM_THREADS;
                    for (int i = 0; i < NUM_THREADS; i++)
                    {
                        int startIndex = i * addressesPerThread;
                        int endIndex = (i == NUM_THREADS - 1) ? address.Count : (i + 1) * addressesPerThread;

                        tasks[i] = Task.Run(() =>
                        {
                            for (int j = startIndex; j < endIndex; j++)
                            {
                                if (shuzhiduibi == true)
                                {
                                    break;
                                }
                                long addr = address[j];
                                byte[] aaa = new byte[4];
                                API.ReadProcessMemory(MainForm.hProcess, addr + 12, aaa, 12, out bytesread2);
                                if (aaa.SequenceEqual(heipingaob2))
                                {
                                    heiping = addr + 0x0C;
                                    Debug.WriteLine("黑屏地址：" + heiping.ToString("X"));
                                    int bytesRead;
                                    byte[] data3 = new byte[sizeof(float)];
                                    shuzhiduibi = true;
                                    break;
                                }
                            }
                        });
                    }
                    Task.WaitAll(tasks);

                    tiji = MainForm.tiji;
                }
                else
                {
                    MessageBox.Show("黑屏初始化失败:Error1");
                }
                buttonheipingcsh.Loading = false;
            }).Start();

            // 获取窗口的设备上下文
            hdc = GetDC(hzck.Handle);
            hdc2 = GetDC(hzck2.Handle);
            if (hzck.Handle != IntPtr.Zero)
            {
                g = Graphics.FromHdc(hdc);
                g2 = Graphics.FromHdc(hdc2);

                if (hzxcth == false)
                {
                    new Thread(() =>
                    {
                        GetWindowRect(MainForm.hWnd, out mnqRect);

                        ckbl = (float)Math.Sqrt((mnqRect.right - mnqRect.left) * (mnqRect.right - mnqRect.left) + (mnqRect.bottom - mnqRect.top) * (mnqRect.bottom - mnqRect.top)) / (float)Math.Sqrt(1920 * 1920 + 1080 * 1080);
                        pen = new Pen(Color.GreenYellow, 2 * ckbl);
                        pen1 = new Pen(Color.Red, 2 * ckbl);

                        pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round; // 设置线连接为圆角
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round; // 设置起点为圆角
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round; // 设置终点为圆角

                        pen1.LineJoin = System.Drawing.Drawing2D.LineJoin.Round; // 设置线连接为圆角
                        pen1.StartCap = System.Drawing.Drawing2D.LineCap.Round; // 设置起点为圆角
                        pen1.EndCap = System.Drawing.Drawing2D.LineCap.Round; // 设置终点为圆角

                        float x = 0, y = 0;
                        float shiyezhi2;
                        POINT weizhi;
                        weizhi.X = 0;
                        weizhi.Y = 0;
                        float hqbj2 = 0;
                        while (true)
                        {
                            int b;
                            byte[] a = new byte[4];

                            try
                            {
                                if (comboBoxheipingkjj.SelectedItem != null)
                                {
                                    kjj = comboBoxheipingkjj.SelectedItem.ToString();
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            ReadProcessMemory(MainForm.hProcess, MainForm.shiye, a, 4, out b);
                            shiyezhi2 = BitConverter.ToSingle(a);
                            GetWindowRect(MainForm.hWnd, out mnqRect);
                            ckkd = (mnqRect.right - mnqRect.left) / 1920.0f;
                            ckgd = (mnqRect.bottom - mnqRect.top) / 1080.0f;
                            if (x != (mnqRect.left + mnqRect.right) / 2 || y != (mnqRect.top + mnqRect.bottom) / 2 || Math.Abs(tijizhi - readtiji()) > 5 || shiyezhi != shiyezhi2)
                            {
                                InvalidateRect(hzck.Handle, IntPtr.Zero, true);
                                SendMessage(hzck.Handle, WM_PAINT, IntPtr.Zero, IntPtr.Zero);
                            }
                            x = (mnqRect.left + mnqRect.right) / 2;
                            y = (mnqRect.top + mnqRect.bottom) / 2;
                            tijizhi = readtiji();


                            ReadProcessMemory(MainForm.hProcess, MainForm.shiye, a, 4, out b);
                            shiyezhi = BitConverter.ToSingle(a);
                            if (shiyezhi != 0)
                            {
                                DrawCircle(g, pen, x, y, (float)Math.Sqrt(Math.Sqrt(tijizhi / Math.PI) * (1.0f / shiyezhi)) * 40f * (ckkd / ckgd > 16f / 9 ? 1 : ckgd));
                            }
                            else
                            {
                                shiyezhi = 1.0f;
                                DrawCircle(g, pen, x, y, (float)Math.Sqrt(Math.Sqrt(tijizhi / Math.PI) * (1.0f / shiyezhi)) * 40f * (ckkd / ckgd > 16f / 9 ? 1 : ckgd));
                            }
                            POINT weizhi2;
                            GetCursorPos(out weizhi2);
                            Point weizhi3 = new Point();
                            weizhi3.X = weizhi2.X;
                            weizhi3.Y = weizhi2.Y;
                            Color pixelColor = GetColorAt(weizhi3);
                            if (ColorTranslator.ToHtml(pixelColor) == "#000000" && kqflag && heipingcg == false)
                            {

                                try
                                {
                                    fsyc = int.Parse(textboxhpfsyc.Text);
                                }
                                catch (Exception ex)
                                {
                                    fsyc = 50;
                                }
                                try
                                {
                                    fscs = int.Parse(textboxhpfscs.Text);
                                }
                                catch (Exception ex)
                                {
                                    fscs = 1;
                                }
                                for (int i = 0; i < fscs; i++)
                                {
                                    if (Application.OpenForms["MainForm"] is MainForm mf)
                                    {
                                        KeyDown((byte)GetVirtualKeyCode(mf.comboBoxfenshen.SelectedItem.ToString()), fsyc);
                                    }

                                }
                                heipingcg = true;
                                kqflag = false;
                                UnhookWindowsHookEx(hookID);
                                writeheiping(800);
                                hzck.Hide();
                                hzck2.Hide();
                            }
                            if (weizhi.X != weizhi2.X || weizhi.Y != weizhi2.Y || hongquanbanjing != hqbj2)
                            {
                                weizhi.X = weizhi2.X;
                                weizhi.Y = weizhi2.Y;
                                InvalidateRect(hzck2.Handle, IntPtr.Zero, true);
                                SendMessage(hzck2.Handle, WM_PAINT, IntPtr.Zero, IntPtr.Zero);
                            }
                            //InvalidateRect(hzck2.Handle, IntPtr.Zero, true);
                            //SendMessage(hzck2.Handle, WM_PAINT, IntPtr.Zero, IntPtr.Zero);
                            DrawCircle(g2, pen1, weizhi.X, weizhi.Y, hongquanbanjing);
                            hqbj2 = hongquanbanjing;
                            try
                            {
                                csbl = float.Parse(textboxhpcsbl.Text);
                            }
                            catch (Exception ex)
                            {
                                csbl = 0.5f;
                            }
                            try
                            {
                                tzbc = int.Parse(textboxhpglbc.Text);
                            }
                            catch (Exception ex)
                            {
                                tzbc = 10;
                            }
                            Thread.Sleep(1);
                        }
                    }).Start();
                    hzxcth = true;
                }

            }
        }

        private static Color GetColorAt2(Point location)
        {
            using (Bitmap bitmap = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(location, Point.Empty, new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }
        private Color GetColorAt(Point location)
        {
            using (Bitmap bitmap = new Bitmap(1, 1))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(location, Point.Empty, new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }
        static void KeyDown(byte key, int delay)
        {
            uint scancode = API.MapVirtualKeyW(key, 0);
            keybd_event(key, (byte)scancode, 0, 0);
            keybd_event(key, (byte)scancode, 0x02, 0);
            Thread.Sleep(delay);
        }
        static float readtiji()
        {
            int b;
            byte[] a = new byte[sizeof(float)];
            ReadProcessMemory(MainForm.hProcess, tiji, a, sizeof(float), out b);
            return BitConverter.ToSingle(a);
        }

        static void writeheiping(float value)
        {
            int b;
            byte[] a = BitConverter.GetBytes(value);
            WriteProcessMemory(MainForm.hProcess, heiping, a, sizeof(float), out b);
        }

        private static IntPtr HookCallback2(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (hzck != null && hzck2 != null)
            {
                if (GetForegroundWindow() == FindWindow(MainForm.lp, null) || GetForegroundWindow() == hzck.Handle || GetForegroundWindow() == hzck2.Handle)
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
                                bili = tzbc / hongquanbanjing;
                                hongquanbanjing += tzbc;
                                hqjsbj *= (1 + bili);
                                heipingx = (float)(20 / Math.PI * hqjsbj * shiyezhi) + 53;
                                writeheiping(800 - heipingx);
                                return new IntPtr(1);
                            }
                            else
                            {
                                bili = tzbc / hongquanbanjing;
                                if (hqjsbj * hqjsbj * Math.PI >= 10)
                                {
                                    hongquanbanjing -= tzbc;
                                    hqjsbj *= (1 - bili);
                                }

                                heipingx = (float)(20 / Math.PI * hqjsbj * shiyezhi) + 53;
                                writeheiping(800 - heipingx);
                                return new IntPtr(1);
                            }
                        }
                        catch (Exception ex)
                        {

                        }


                    }
                }
            }



            return API.CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (hzck != null && hzck2 != null)
            {
                if ((GetForegroundWindow() == FindWindow(MainForm.lp, null) || GetForegroundWindow() == hzck.Handle || GetForegroundWindow() == hzck2.Handle))
                {
                    if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                    {
                        int vkCode = Marshal.ReadInt32(lParam);
                        Debug.WriteLine(kjj2);
                        if (vkCode == GetVirtualKeyCode(kjj) && shifouqiyong)
                        {
                            kqflag = !kqflag;
                            if (kqflag)
                            {
                                heipingcg = false;
                                mouseProc = HookCallback2;
                                hookID = SetHook2(mouseProc);
                                jisuanbanjing = (float)Math.Sqrt(tijizhi / Math.PI) / shiyezhi;
                                hqjsbj = jisuanbanjing;
                                hongquanbanjing = (float)Math.Sqrt(hqjsbj) * 40f * (ckkd / ckgd > 16f / 9 ? 1 : ckgd);
                                float luquanbanjing = (float)Math.Sqrt(Math.Sqrt(tijizhi / Math.PI) * (1.0f / shiyezhi)) * 40f * (ckkd / ckgd > 16f / 9 ? 1 : ckgd);
                                luquanbanjing *= (1 - csbl);
                                //bili = 10 / hongquanbanjing;
                                bili = luquanbanjing / hongquanbanjing;
                                //hongquanbanjing -= 10;
                                hongquanbanjing -= luquanbanjing;

                                hqjsbj *= (1 - bili);
                                heipingx = (float)(20 / Math.PI * hqjsbj * shiyezhi) + 53;
                                writeheiping(800 - heipingx);
                                hzck.Show();
                                hzck2.Show();
                            }
                            else
                            {
                                heipingcg = true;
                                UnhookWindowsHookEx(hookID);
                                writeheiping(800);
                                hzck.Hide();
                                hzck2.Hide();

                                //g.Clear(Color.FromArgb(0, 0, 0, 0));
                                //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
                                //SendMessage(IntPtr.Zero, WM_PAINT, IntPtr.Zero, IntPtr.Zero);
                                //Debug.WriteLine("111");
                            }
                        }
                        
                        else if (vkCode == GetVirtualKeyCode(kjj2) && tsshifouqiyong)
                        {
                            Debug.WriteLine("1");
                            kqflag = !kqflag;
                            if (kqflag)
                            {
                                
                                writeheiping(749);
                                Thread.Sleep(500);
                                tuseyanse = quse();
                                tusecg = false;
                            }
                            else
                            {
                                tusecg = true;
                                writeheiping(800);
                            }
                        }
                    }
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private void heipingkadian_Load(object sender, EventArgs e)
        {
            if (Json.checkjson("tusekjj"))
            {
                uiComboBox1.SelectedItem = Json.readjson("tusekjj");
            }
            else
            {
                uiComboBox1.SelectedItem = "A";
            }
            if (Json.checkjson("tsfscs"))
            {
                uiTextBox6.Text = Json.readjson("tsfscs");
            }
            else
            {
                uiTextBox6.Text = "1";
            }

            if (Json.checkjson("tsfsyc"))
            {
                uiTextBox5.Text = Json.readjson("tsfsyc");
            }
            else
            {
                uiTextBox5.Text = "50";
            }
            if (Json.checkjson("heipingkjj"))
            {
                comboBoxheipingkjj.SelectedItem = Json.readjson("heipingkjj");
            }
            else
            {
                comboBoxheipingkjj.SelectedItem = "A";
            }
            if (Json.checkjson("hpfscs"))
            {
                textboxhpfscs.Text = Json.readjson("hpfscs");
            }
            else
            {
                textboxhpfscs.Text = "1";
            }
            if (Json.checkjson("hpcsbl"))
            {
                textboxhpcsbl.Text = Json.readjson("hpcsbl");
            }
            else
            {
                textboxhpcsbl.Text = "0.5";
            }
            if (Json.checkjson("hpfsyc"))
            {
                textboxhpfsyc.Text = Json.readjson("hpfsyc");
            }
            else
            {
                textboxhpfsyc.Text = "50";
            }
            if (Json.checkjson("hptzbc"))
            {
                textboxhpglbc.Text = Json.readjson("hptzbc");
            }
            else
            {
                textboxhpglbc.Text = "10";
            }
            _hookID = SetHook(_proc);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx2(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private static IntPtr SetHook2(LowLevelMouseProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, API.GetModuleHandle(curModule.ModuleName), 0);
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

        private void checkboxheiping_CheckedChanged(object sender, bool value)
        {
            if (checkboxheiping.Checked)
            {
                shifouqiyong = true;
            }
            else
            {
                shifouqiyong = false;
            }
        }

        private void comboBoxheipingkjj_SelectedIndexChanged(object sender, EventArgs e)
        {
            Json.writejson("heipingkjj", comboBoxheipingkjj.SelectedItem.ToString());
        }

        private void textboxhpfscs_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("hpfscs", textboxhpfscs.Text);
        }

        private void textboxhpcsbl_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("hpcsbl", textboxhpcsbl.Text);
        }

        private void textboxhpglbc_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("hptzbc", textboxhpglbc.Text);
        }

        private void textboxhpfsyc_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("hpfsyc", textboxhpfsyc.Text);
        }

        private void textboxhpcsbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') == -1)
            {
                e.Handled = false;
            }
        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            writeheiping(749);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeheiping(800);
        }


        static string quse()
        {
            POINT weizhi1 = new POINT();
            Point weizhi2 = new Point();
            GetCursorPos(out weizhi1);
            weizhi2.X = weizhi1.X;
            weizhi2.Y = weizhi1.Y;
            Color pixelColor = GetColorAt2(weizhi2);
            return ColorTranslator.ToHtml(pixelColor);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            hzck = new heipinghuizhi();
            hzck2 = new heipinghuizhi2();
            Debug.WriteLine("22");
            try
            {
                if (uiComboBox1.SelectedItem != null)
                {
                    kjj2 = uiComboBox1.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            
            new Thread(() =>
            {
                button5.Loading = true;
                List<long> address = Memory.ScanPatternParallel(MainForm.hProcess, heipingaob1, heipingaob1.Length);
                int bytesread2;
                bool shuzhiduibi = false;



                if (address.Count > 0)
                {
                    shuzhiduibi = false;
                    int NUM_THREADS;
                    NUM_THREADS = Environment.ProcessorCount;
                    Task[] tasks = new Task[NUM_THREADS];
                    int addressesPerThread = address.Count / NUM_THREADS;
                    for (int i = 0; i < NUM_THREADS; i++)
                    {
                        int startIndex = i * addressesPerThread;
                        int endIndex = (i == NUM_THREADS - 1) ? address.Count : (i + 1) * addressesPerThread;

                        tasks[i] = Task.Run(() =>
                        {
                            for (int j = startIndex; j < endIndex; j++)
                            {
                                if (shuzhiduibi == true)
                                {
                                    break;
                                }
                                long addr = address[j];
                                byte[] aaa = new byte[4];
                                API.ReadProcessMemory(MainForm.hProcess, addr + 12, aaa, 12, out bytesread2);
                                if (aaa.SequenceEqual(heipingaob2))
                                {
                                    heiping = addr + 0x0C;
                                    Debug.WriteLine("黑屏地址：" + heiping.ToString("X"));
                                    int bytesRead;
                                    byte[] data3 = new byte[sizeof(float)];
                                    shuzhiduibi = true;
                                    break;
                                }
                            }
                        });
                    }
                    Task.WaitAll(tasks);

                    tiji = MainForm.tiji;
                }
                else
                {
                    MessageBox.Show("图色初始化失败:Error1");
                }
                button5.Loading = false;
            }).Start();
            
            if (true)
            {
                
                if (hzxcth2 == false)
                {
                    
                    hzxcth2 = true;
                    new Thread(() =>
                    {
                        
                        while (true)
                        {

                            
                            try
                            {
                                if (uiComboBox1.SelectedItem != null)
                                {
                                    kjj2 = uiComboBox1.SelectedItem.ToString();
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                            POINT weizhi1 = new POINT();
                            Point weizhi2 = new Point();
                            GetCursorPos(out weizhi1);
                            weizhi2.X = weizhi1.X;
                            weizhi2.Y = weizhi1.Y;
                            Color pixelColor = GetColorAt(weizhi2);
                            Debug.WriteLine(ColorTranslator.ToHtml(pixelColor));
                            if (ColorTranslator.ToHtml(pixelColor) != tuseyanse && kqflag && tusecg == false)
                            {

                                try
                                {
                                    fsyc = int.Parse(uiTextBox5.Text);
                                }
                                catch (Exception ex)
                                {
                                    fsyc = 50;
                                }
                                try
                                {
                                    fscs = int.Parse(uiTextBox6.Text);
                                }
                                catch (Exception ex)
                                {
                                    fscs = 1;
                                }
                                for (int i = 0; i < fscs; i++)
                                {
                                    if (Application.OpenForms["MainForm"] is MainForm mf)
                                    {
                                        KeyDown((byte)GetVirtualKeyCode(mf.comboBoxfenshen.SelectedItem.ToString()), fsyc);
                                    }

                                }
                                tusecg = true;
                                kqflag = false;
                                UnhookWindowsHookEx(hookID);
                                writeheiping(800);
                                
                            }
                        }

                    }).Start();
                }
            }
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Json.writejson("tusekjj", uiComboBox1.SelectedItem.ToString());
        }

        private void uiTextBox6_TipsClick(object sender, EventArgs e)
        {

        }

        private void uiTextBox6_TextAlignmentChange(object sender, ContentAlignment alignment)
        {

        }

        private void uiTextBox6_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("tsfscs", uiTextBox6.Text);
        }

        private void uiTextBox5_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("tsfsyc", uiTextBox5.Text);
        }

        private void checkbox2_CheckedChanged(object sender, bool value)
        {
            if (checkbox2.Checked)
            {
                tsshifouqiyong = true;
            }
            else
            {
                tsshifouqiyong = false;
            }
        }
    }
}
