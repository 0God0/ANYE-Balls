using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ANYE_Balls.API;

namespace ANYE_Balls
{

    public partial class honggongneng : Form
    {
        private System.Timers.Timer keyPressTimer;
        private bool isFirstKeyPress;
        private DateTime firstKeyPressTime; // 记录第一次按键的时间
        private const double timeInterval = 1000; // 时间间隔，设为1秒（1000毫秒）

        public static bool changan1, changan2, lianji1, lianji2;
        public static IntPtr handlew;
        public static bool erfenhong, sifenhong, bafenhong, gangganhong, shiliufenhong, yuandihong, changanhong1, changanhong2, lianjihong1, lianjihong2;
        public static int erfenhongwait, sifenhongwait, bafenhongwait, gangganhongwait, shiliufenhongwait, yuandihongwait, changanhong1wait, changanhong2wait, lianjihong1wait, lianjihong2wait;
        public static byte erfenhongjian, sifenhongjian, bafenhongjian, gangganhongjian, shiliufenhongjian, yuandihongjian, changanhong1jian, changanhong2jian, lianjihong1jian, lianjihong2jian;
        public static byte changanhongmnj1, changanhongmnj2, lianjihongmnj1, lianjihongmnj2;
        public honggongneng()
        {
            InitializeComponent();
            keyPressTimer = new System.Timers.Timer(timeInterval); // 初始化计时器，设置时间间隔为1秒
            isFirstKeyPress = false; // 初始化按键状态为 false，即未按键
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
        private void honggongneng_Load(object sender, EventArgs e)
        {
            if (Json.checkjson("erfenhong"))
            {
                if (Json.readjson("erfenhong") == "true")
                {
                    checkBoxerfenhong.Checked = true;
                }
                else
                {
                    checkBoxerfenhong.Checked = false;
                }
            }
            if (Json.checkjson("sifenhong"))
            {
                if (Json.readjson("sifenhong") == "true")
                {
                    checkBoxsifenhong.Checked = true;
                }
                else
                {
                    checkBoxsifenhong.Checked = false;
                }
            }
            if (Json.checkjson("bafenhong"))
            {
                if (Json.readjson("befenhong") == "true")
                {
                    checkBoxbafenhong.Checked = true;
                }
                else
                {
                    checkBoxbafenhong.Checked = false;
                }
            }
            if (Json.checkjson("gangganhong"))
            {
                if (Json.readjson("gangganhong") == "true")
                {
                    checkBoxgangganhong.Checked = true;
                }
                else
                {
                    checkBoxgangganhong.Checked = false;
                }
            }
            if (Json.checkjson("shiliufenhong"))
            {
                if (Json.readjson("shiliufenhong") == "true")
                {
                    checkBoxshiliufenhong.Checked = true;
                }
                else
                {
                    checkBoxshiliufenhong.Checked = false;
                }
            }
            if (Json.checkjson("yuandihong"))
            {
                if (Json.readjson("yuandihong") == "true")
                {
                    checkBoxyuandihong.Checked = true;
                }
                else
                {
                    checkBoxyuandihong.Checked = false;
                }
            }
            if (Json.checkjson("changanhong1"))
            {
                if (Json.readjson("changanhong1") == "true")
                {
                    checkBoxchanganhong1.Checked = true;
                }
                else
                {
                    checkBoxchanganhong1.Checked = false;
                }
            }
            if (Json.checkjson("changanhong2"))
            {
                if (Json.readjson("changanhong2") == "true")
                {
                    checkBoxchanganhong2.Checked = true;
                }
                else
                {
                    checkBoxchanganhong2.Checked = false;
                }
            }
            if (Json.checkjson("lianjihong1"))
            {
                if (Json.readjson("lianjihong1") == "true")
                {
                    checkBoxlianjihong1.Checked = true;
                }
                else
                {
                    checkBoxlianjihong1.Checked = false;
                }
            }
            if (Json.checkjson("lianjihong2"))
            {
                if (Json.readjson("lianjihong2") == "true")
                {
                    checkBoxlianjihong2.Checked = true;
                }
                else
                {
                    checkBoxlianjihong2.Checked = false;
                }
            }
            if (Json.checkjson("erfenhongjian"))
            {
                comboBoxerfenhong.SelectedItem = Json.readjson("erfenhongjian");
            }
            else
            {
                comboBoxerfenhong.SelectedItem = "A";
            }
            if (Json.checkjson("sifenhongjian"))
            {
                comboBoxsifenhong.SelectedItem = Json.readjson("sifenhongjian");
            }
            else
            {
                comboBoxsifenhong.SelectedItem = "A";
            }
            if (Json.checkjson("bafenhongjian"))
            {
                comboBoxbafenhong.SelectedItem = Json.readjson("bafenhongjian");
            }
            else
            {
                comboBoxbafenhong.SelectedItem = "A";
            }
            if (Json.checkjson("shiliufenhongjian"))
            {
                comboBoxshiliufenhong.SelectedItem = Json.readjson("shiliufenhongjian");
            }
            else
            {
                comboBoxshiliufenhong.SelectedItem = "A";
            }
            if (Json.checkjson("gangganhongjian"))
            {
                comboBoxgangganhong.SelectedItem = Json.readjson("gangganhongjian");
            }
            else
            {
                comboBoxgangganhong.SelectedItem = "A";
            }
            if (Json.checkjson("yuandihongjian"))
            {
                comboBoxyuandihong.SelectedItem = Json.readjson("yuandihongjian");
            }
            else
            {
                comboBoxyuandihong.SelectedItem = "A";
            }
            if (Json.checkjson("changanhong1jian"))
            {
                comboBoxchanganhong1.SelectedItem = Json.readjson("changanhong1jian");
            }
            else
            {
                comboBoxchanganhong1.SelectedItem = "A";
            }
            if (Json.checkjson("changanhongmnj1"))
            {
                comboBoxchanganhongmnj1.SelectedItem = Json.readjson("changanhongmnj1");
            }
            else
            {
                comboBoxchanganhongmnj1.SelectedItem = "A";
            }
            if (Json.checkjson("changanhong2jian"))
            {
                comboBoxchanganhong2.SelectedItem = Json.readjson("changanhong2jian");
            }
            else
            {
                comboBoxchanganhong2.SelectedItem = "A";
            }
            if (Json.checkjson("changanhongmnj2"))
            {
                comboBoxchanganhongmnj2.SelectedItem = Json.readjson("changanhongmnj2");
            }
            else
            {
                comboBoxchanganhongmnj2.SelectedItem = "A";
            }
            if (Json.checkjson("lianjihong1jian"))
            {
                comboBoxlianjihong1.SelectedItem = Json.readjson("lianjihong1jian");
            }
            else
            {
                comboBoxlianjihong1.SelectedItem = "A";
            }
            if (Json.checkjson("lianjihongmnj1"))
            {
                comboBoxlianjihongmnj1.SelectedItem = Json.readjson("lianjihongmnj1");
            }
            else
            {
                comboBoxlianjihongmnj1.SelectedItem = "A";
            }
            if (Json.checkjson("lianjihong2jian"))
            {
                comboBoxlianjihong2.SelectedItem = Json.readjson("lianjihong2jian");
            }
            else
            {
                comboBoxlianjihong2.SelectedItem = "A";
            }
            if (Json.checkjson("lianjihongmnj2"))
            {
                comboBoxlianjihongmnj2.SelectedItem = Json.readjson("lianjihongmnj2");
            }
            else
            {
                comboBoxlianjihongmnj2.SelectedItem = "A";
            }
            if (Json.checkjson("erfenhongwait"))
            {
                textboxerfenhong.Text = Json.readjson("erfenhongwait");
                try
                {
                    erfenhongwait = int.Parse(textboxerfenhong.Text);
                }
                catch (Exception ex)
                {
                    erfenhongwait = 0;
                }
            }
            else
            {
                erfenhongwait = 0;
                textboxerfenhong.Text = "0";
            }
            if (Json.checkjson("sifenhongwait"))
            {
                textboxsifenhong.Text = Json.readjson("sifenhongwait");
                try
                {
                    sifenhongwait = int.Parse(textboxsifenhong.Text);
                }
                catch (Exception ex)
                {
                    sifenhongwait = 50;
                }
            }
            else
            {
                sifenhongwait = 50;
                textboxsifenhong.Text = "50";
            }
            if (Json.checkjson("bafenhongwait"))
            {
                textboxbafenhong.Text = Json.readjson("bafenhongwait");
                try
                {
                    bafenhongwait = int.Parse(textboxbafenhong.Text);
                }
                catch (Exception ex)
                {
                    bafenhongwait = 50;
                }
            }
            else
            {
                bafenhongwait = 50;
                textboxbafenhong.Text = "50";
            }
            if (Json.checkjson("shiliufenhongwait"))
            {
                textboxshiliufenhong.Text = Json.readjson("shiliufenhongwait");
                try
                {
                    shiliufenhongwait = int.Parse(textboxshiliufenhong.Text);
                }
                catch (Exception ex)
                {
                    shiliufenhongwait = 50;
                }
            }
            else
            {
                shiliufenhongwait = 50;
                textboxshiliufenhong.Text = "50";
            }
            if (Json.checkjson("gangganhongwait"))
            {
                textboxgangganhong.Text = Json.readjson("gangganhongwait");
                try
                {
                    gangganhongwait = int.Parse(textboxgangganhong.Text);
                }
                catch (Exception ex)
                {
                    gangganhongwait = 50;
                }
            }
            else
            {
                gangganhongwait = 50;
                textboxgangganhong.Text = "50";
            }
            if (Json.checkjson("yuandihongwait"))
            {
                textboxyuandihong.Text = Json.readjson("yuandihongwait");
                try
                {
                    yuandihongwait = int.Parse(textboxyuandihong.Text);
                }
                catch (Exception ex)
                {
                    yuandihongwait = 50;
                }
            }
            else
            {
                yuandihongwait = 50;
                textboxyuandihong.Text = "50";
            }
            if (Json.checkjson("changanhong1wait"))
            {
                textboxchanganhong1.Text = Json.readjson("changanhong1wait");
                try
                {
                    changanhong1wait = int.Parse(textboxchanganhong1.Text);
                }
                catch (Exception ex)
                {
                    changanhong1wait = 50;
                }
            }
            else
            {
                changanhong1wait = 50;
                textboxchanganhong1.Text = "50";
            }
            if (Json.checkjson("changanhong2wait"))
            {
                textboxchanganhong2.Text = Json.readjson("changanhong2wait");
                try
                {
                    changanhong2wait = int.Parse(textboxchanganhong2.Text);
                }
                catch (Exception ex)
                {
                    changanhong2wait = 50;
                }
            }
            else
            {
                changanhong2wait = 50;
                textboxchanganhong2.Text = "50";
            }
            if (Json.checkjson("lianjihong1wait"))
            {
                textboxlianjihong1.Text = Json.readjson("lianjihong1wait");
                try
                {
                    lianjihong1wait = int.Parse(textboxlianjihong1.Text);
                }
                catch (Exception ex)
                {
                    lianjihong1wait = 50;
                }
            }
            else
            {
                lianjihong1wait = 50;
                textboxlianjihong1.Text = "50";
            }
            if (Json.checkjson("lianjihong2wait"))
            {
                textboxlianjihong2.Text = Json.readjson("lianjihong2wait");
                try
                {
                    lianjihong2wait = int.Parse(textboxlianjihong2.Text);
                }
                catch (Exception ex)
                {
                    lianjihong2wait = 50;
                }
            }
            else
            {
                lianjihong2wait = 50;
                textboxlianjihong2.Text = "50";
            }

            new Thread(() =>
            {
                while (true)
                {

                    if (API.GetForegroundWindow() == API.FindWindow(MainForm.lp, null) && MainForm.shifouzhanju == true)
                    {
                        //二分宏
                        if (GetAsyncKeyState(erfenhongjian) != 0 && checkBoxerfenhong.Checked)
                        {
                            Thread.Sleep(erfenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            while (GetAsyncKeyState(erfenhongjian) != 0)
                            {
                                Thread.Sleep(5);
                            }
                        }
                        //四分宏
                        if (GetAsyncKeyState(sifenhongjian) != 0 && checkBoxsifenhong.Checked)
                        {
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(sifenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            while (GetAsyncKeyState(sifenhongjian) != 0)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        //八分宏
                        if (GetAsyncKeyState(bafenhongjian) != 0 && checkBoxbafenhong.Checked)
                        {
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(bafenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(bafenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            while (GetAsyncKeyState(bafenhongjian) != 0)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        //十六分宏
                        if (GetAsyncKeyState(shiliufenhongjian) != 0 && checkBoxshiliufenhong.Checked)
                        {
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(shiliufenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(shiliufenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(shiliufenhongwait);
                            KeyDown(zidongheqiu.fenshenjian);
                            while (GetAsyncKeyState(shiliufenhongjian) != 0)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        //杠杆宏
                        if (GetAsyncKeyState(gangganhongjian) != 0 && checkBoxgangganhong.Checked)
                        {
                            isFirstKeyPress = true;
                            if (isFirstKeyPress && (DateTime.Now - firstKeyPressTime).TotalMilliseconds <= timeInterval)
                            {
                                Debug.WriteLine("1秒内第二次按下");
                                KeyDown(zidongheqiu.fenshenjian);
                                Thread.Sleep(gangganhongwait);
                                KeyDown(zidongheqiu.fenshenjian);
                                Thread.Sleep(gangganhongwait);
                                KeyDown(zidongheqiu.fenshenjian);
                                Thread.Sleep(gangganhongwait);
                                KeyDown(zidongheqiu.fenshenjian);
                                isFirstKeyPress = false;
                                keyPressTimer.Stop();
                            }
                            else
                            {
                                Debug.WriteLine("一次按下");
                                KeyDown(zidongheqiu.fenshenjian);
                                Thread.Sleep(gangganhongwait);
                                KeyDown(zidongheqiu.fenshenjian);
                                firstKeyPressTime = DateTime.Now;
                                isFirstKeyPress = true;
                                keyPressTimer.Start();
                            }

                            while (GetAsyncKeyState(gangganhongjian) != 0)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        //原地宏
                        if (GetAsyncKeyState(yuandihongjian) != 0 && checkBoxyuandihong.Checked)
                        {
                            KeyDown(zidongheqiu.fenshenjian);
                            Thread.Sleep(yuandihongwait);
                            neicunheqiu.writezhi(neicunheqiu.yaoganadr, 0, 0);
                            Thread.Sleep(50);
                            KeyDown(zidongheqiu.fenshenjian);
                            while (GetAsyncKeyState(yuandihongjian) != 0)
                            {
                                Thread.Sleep(10);
                            }
                        }
                        //长按宏1
                        if (GetAsyncKeyState(changanhong1jian) != 0 && checkBoxchanganhong1.Checked)
                        {
                            if (changan1 == false)
                            {
                                Thread th1 = new Thread(changan1th);
                                th1.Start();
                                changan1 = true;
                            }

                        }
                        //长按宏2
                        if (GetAsyncKeyState(changanhong2jian) != 0 && checkBoxchanganhong2.Checked)
                        {
                            if (changan2 == false)
                            {
                                Thread th1 = new Thread(changan2th);
                                th1.Start();
                                changan2 = true;
                            }

                        }
                        //连击宏1
                        if (GetAsyncKeyState(lianjihong1jian) != 0 && checkBoxlianjihong1.Checked)
                        {
                            if (lianji1 == false)
                            {
                                Thread th1 = new Thread(lianji1th);
                                th1.Start();
                                lianji1 = true;
                            }

                        }
                        //连击宏2
                        if (GetAsyncKeyState(lianjihong2jian) != 0 && checkBoxlianjihong2.Checked)
                        {
                            if (lianji2 == false)
                            {
                                Thread th1 = new Thread(lianji2th);
                                th1.Start();
                                lianji2 = true;
                            }

                        }
                    }

                    Thread.Sleep(10);
                }
            }).Start();

        }
        static void KeyDown(byte key)
        {
            uint scancode = MapVirtualKeyW(key, 0);

            keybd_event(key, (byte)scancode, 0, 0);
            keybd_event(key, (byte)scancode, 2, 0);
        }
        static void KeyDown2(byte key, int delay)
        {
            uint scancode = MapVirtualKeyW(key, 0);

            keybd_event(key, (byte)scancode, 0, 0);
            Thread.Sleep(delay);
            keybd_event(key, (byte)scancode, 2, 0);
        }
        void changan1th()
        {
            while (GetAsyncKeyState(changanhong1jian) != 0)
            {
                KeyDown(changanhongmnj1);
                Thread.Sleep(changanhong1wait);
            }
            changan1 = false;
        }

        void changan2th()
        {
            while (GetAsyncKeyState(changanhong2jian) != 0)
            {
                KeyDown(changanhongmnj2);
                Thread.Sleep(changanhong2wait);
            }
            changan2 = false;
        }

        void lianji1th()
        {
            while (GetAsyncKeyState(lianjihong1jian) != 0)
            {
                KeyDown2(lianjihongmnj1, 1000 / lianjihong1wait / 2);
                Thread.Sleep(1000 / lianjihong1wait / 2);
            }
            lianji1 = false;
        }

        void lianji2th()
        {
            while (GetAsyncKeyState(lianjihong2jian) != 0)
            {
                KeyDown2(lianjihongmnj2, 1000 / lianjihong2wait / 2);
                Thread.Sleep(1000 / lianjihong2wait / 2);
            }
            lianji1 = false;
        }

        private void checkBoxerfenhong_CheckedChanged(object sender, bool value)
        {
            if (checkBoxerfenhong.Checked)
            {
                erfenhong = true;
                Json.writejson("erfenhong", "true");
            }
            else
            {
                erfenhong = false;
                Json.writejson("erfenhong", "false");
            }
        }

        private void checkBoxsifenhong_CheckedChanged(object sender, bool value)
        {
            if (checkBoxsifenhong.Checked)
            {
                sifenhong = true;
                Json.writejson("sifenhong", "true");
            }
            else
            {
                sifenhong = false;
                Json.writejson("sifenhong", "false");
            }
        }

        private void checkBoxyuandihong_CheckedChanged(object sender, bool value)
        {
            if (checkBoxyuandihong.Checked)
            {
                yuandihong = true;
                Json.writejson("yuandihong", "true");
            }
            else
            {
                yuandihong = false;
                Json.writejson("yuandihong", "false");
            }
        }

        private void checkBoxbafenhong_CheckedChanged(object sender, bool value)
        {
            if (checkBoxbafenhong.Checked)
            {
                bafenhong = true;
                Json.writejson("bafenhong", "true");
            }
            else
            {
                bafenhong = false;
                Json.writejson("bafenhong", "false");
            }
        }

        private void checkBoxgangganhong_CheckedChanged(object sender, bool value)
        {
            if (checkBoxgangganhong.Checked)
            {
                gangganhong = true;
                Json.writejson("gangganhong", "true");
            }
            else
            {
                gangganhong = false;
                Json.writejson("gangganhong", "false");
            }
        }

        private void checkBoxshiliufenhong_CheckedChanged(object sender, bool value)
        {
            if (checkBoxshiliufenhong.Checked)
            {
                shiliufenhong = true;
                Json.writejson("shiliufenhong", "true");
            }
            else
            {
                shiliufenhong = false;
                Json.writejson("shiliufenhong", "false");
            }
        }

        private void checkBoxchanganhong1_CheckedChanged(object sender, bool value)
        {
            if (checkBoxchanganhong1.Checked)
            {
                changanhong1 = true;
                Json.writejson("changanhong1", "true");
            }
            else
            {
                changanhong1 = false;
                Json.writejson("changanhong1", "false");
            }
        }

        private void checkBoxchanganhong2_CheckedChanged(object sender, bool value)
        {
            if (checkBoxchanganhong2.Checked)
            {
                changanhong2 = true;
                Json.writejson("changanhong2", "true");
            }
            else
            {
                changanhong2 = false;
                Json.writejson("changanhong2", "false");
            }
        }

        private void checkBoxlianjihong1_CheckedChanged(object sender, bool value)
        {
            if (checkBoxlianjihong1.Checked)
            {
                lianjihong1 = true;
                Json.writejson("lianjihong1", "true");
            }
            else
            {
                lianjihong1 = false;
                Json.writejson("lianjihong1", "false");
            }
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxlianjihong2_CheckedChanged(object sender, bool value)
        {
            if (checkBoxlianjihong2.Checked)
            {
                lianjihong2 = true;
                Json.writejson("lianjihong2", "true");
            }
            else
            {
                lianjihong2 = false;
                Json.writejson("lianjihong2", "false");
            }
        }
        private void comboBoxerfenhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            erfenhongjian = (byte)GetVirtualKeyCode(comboBoxerfenhong.SelectedItem.ToString());
            Json.writejson("erfenhongjian", comboBoxerfenhong.SelectedItem.ToString());
        }

        private void comboBoxsifenhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            sifenhongjian = (byte)GetVirtualKeyCode(comboBoxsifenhong.SelectedItem.ToString());
            Json.writejson("sifenhongjian", comboBoxsifenhong.SelectedItem.ToString());
        }

        private void comboBoxbafenhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            bafenhongjian = (byte)GetVirtualKeyCode(comboBoxbafenhong.SelectedItem.ToString());
            Json.writejson("bafenhongjian", comboBoxbafenhong.SelectedItem.ToString());
        }

        private void comboBoxgangganhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            gangganhongjian = (byte)GetVirtualKeyCode(comboBoxgangganhong.SelectedItem.ToString());
            Json.writejson("gangganhongjian", comboBoxgangganhong.SelectedItem.ToString());
        }

        private void comboBoxshiliufenhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            shiliufenhongjian = (byte)GetVirtualKeyCode(comboBoxshiliufenhong.SelectedItem.ToString());
            Json.writejson("shiliufenhongjian", comboBoxshiliufenhong.SelectedItem.ToString());
        }

        private void comboBoxyuandihong_SelectedIndexChanged(object sender, EventArgs e)
        {
            yuandihongjian = (byte)GetVirtualKeyCode(comboBoxyuandihong.SelectedItem.ToString());
            Json.writejson("yuandihongjian", comboBoxyuandihong.SelectedItem.ToString());
        }

        private void comboBoxchanganhong1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changanhong1jian = (byte)GetVirtualKeyCode(comboBoxchanganhong1.SelectedItem.ToString());
            Json.writejson("changanhong1jian", comboBoxchanganhong1.SelectedItem.ToString());
        }

        private void comboBoxchanganhong2_SelectedIndexChanged(object sender, EventArgs e)
        {
            changanhong2jian = (byte)GetVirtualKeyCode(comboBoxchanganhong2.SelectedItem.ToString());
            Json.writejson("changanhong2jian", comboBoxchanganhong2.SelectedItem.ToString());
        }

        private void comboBoxlianjihong1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lianjihong1jian = (byte)GetVirtualKeyCode(comboBoxlianjihong1.SelectedItem.ToString());
            Json.writejson("lianjihong1jian", comboBoxlianjihong1.SelectedItem.ToString());
        }

        private void comboBoxlianjihong2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lianjihong2jian = (byte)GetVirtualKeyCode(comboBoxlianjihong2.SelectedItem.ToString());
            Json.writejson("lianjihong2jian", comboBoxlianjihong2.SelectedItem.ToString());
        }

        private void textBoxerfenhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                erfenhongwait = int.Parse(textboxerfenhong.Text);
            }
            catch (Exception ex)
            {
                erfenhongwait = 50;
            }
            Json.writejson("erfenhongwait", textboxerfenhong.Text);
        }

        private void textBoxsifenhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sifenhongwait = int.Parse(textboxsifenhong.Text);
            }
            catch (Exception ex)
            {
                sifenhongwait = 50;
            }
            Json.writejson("sifenhongwait", textboxsifenhong.Text);
        }

        private void textBoxbafenhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bafenhongwait = int.Parse(textboxbafenhong.Text);
            }
            catch (Exception ex)
            {
                bafenhongwait = 50;
            }
            Json.writejson("bafenhongwait", textboxbafenhong.Text);
        }

        private void textBoxgangganhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gangganhongwait = int.Parse(textboxgangganhong.Text);
            }
            catch (Exception ex)
            {
                gangganhongwait = 50;
            }
            Json.writejson("gangganhongwait", textboxgangganhong.Text);
        }

        private void textBoxshiliufenhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                shiliufenhongwait = int.Parse(textboxshiliufenhong.Text);
            }
            catch (Exception ex)
            {
                shiliufenhongwait = 50;
            }
            Json.writejson("shiliufenhongwait", textboxshiliufenhong.Text);
        }

        private void textBoxyuandihong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                yuandihongwait = int.Parse(textboxyuandihong.Text);
            }
            catch (Exception ex)
            {
                yuandihongwait = 50;
            }
            Json.writejson("yuandihongwait", textboxyuandihong.Text);
        }

        private void textBoxchanganhong1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                changanhong1wait = int.Parse(textboxchanganhong1.Text);
            }
            catch (Exception ex)
            {
                changanhong1wait = 50;
            }
            Json.writejson("changanhong1wait", textboxchanganhong1.Text);
        }

        private void textBoxchanganhong2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                changanhong2wait = int.Parse(textboxchanganhong2.Text);
            }
            catch (Exception ex)
            {
                changanhong2wait = 50;
            }
            Json.writejson("changanhong2wait", textboxchanganhong2.Text);
        }

        private void textBoxlianjihong1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lianjihong1wait = int.Parse(textboxlianjihong1.Text);
            }
            catch (Exception ex)
            {
                lianjihong1wait = 50;
            }
            Json.writejson("lianjihong1wait", textboxlianjihong1.Text);
        }

        private void textBoxlianjihong2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lianjihong2wait = int.Parse(textboxlianjihong2.Text);
            }
            catch (Exception ex)
            {
                lianjihong2wait = 50;
            }
            Json.writejson("lianjihong2wait", textboxlianjihong2.Text);
        }
        private void comboBoxchanganhongmnj1_SelectedIndexChanged(object sender, EventArgs e)
        {
            changanhongmnj1 = (byte)GetVirtualKeyCode(comboBoxchanganhongmnj1.SelectedItem.ToString());
            Json.writejson("changanhongmnj1", comboBoxchanganhongmnj1.SelectedItem.ToString());
        }

        private void comboBoxchanganhongmnj2_SelectedIndexChanged(object sender, EventArgs e)
        {
            changanhongmnj2 = (byte)GetVirtualKeyCode(comboBoxchanganhongmnj2.SelectedItem.ToString());
            Json.writejson("changanhongmnj2", comboBoxchanganhongmnj2.SelectedItem.ToString());
        }

        private void comboBoxlianjihongmnj1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lianjihongmnj1 = (byte)GetVirtualKeyCode(comboBoxlianjihongmnj1.SelectedItem.ToString());
            Json.writejson("lianjihongmnj1", comboBoxlianjihongmnj1.SelectedItem.ToString());
        }

        private void comboBoxlianjihongmnj2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lianjihongmnj2 = (byte)GetVirtualKeyCode(comboBoxlianjihongmnj2.SelectedItem.ToString());
            Json.writejson("lianjihongmnj2", comboBoxlianjihongmnj2.SelectedItem.ToString());
        }
    }
}
