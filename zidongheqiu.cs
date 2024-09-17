using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanara.PInvoke;

namespace ANYE_Balls
{
    public class zidongheqiu
    {
        const int VK_LBUTTON = 0x01;
        const uint KEYEVENTF_KEYUP = 0x02;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;

        public static byte fenshenjian;
        public static byte tuqiujian;
        public static float yaogandaxiao;

        public static bool sanjiaoflag, sanjiaojiantou, sanjiaotqflag;
        public static bool sanjiao2flag, sanjiao2jiantou, sanjiao2tqflag;
        public static bool sheshouflag, sheshoutqflag;
        public static bool sifenceheflag, sifencehetqflag;
        public static bool yuandiheqiuflag, yuandiheqiutqflag;
        public static bool houyangflag, houyangtqflag;
        public static bool xuanzhuanflag, xuanzhuantqflag;
        public static bool banxuanflag, banxuantqflag;



        public static int sanjiaojian;
        public static int sanjiao2jian;
        public static int sheshoujian;
        public static int sifencehejian;
        public static int yuandiheqiujian;
        public static int houyangjian;
        public static int xuanzhuanjian;
        public static int banxuanjian;


        public static int sanjiaojd, sanjiaojcfd, sjyc1, sjyc2, sjyc3, sjyc4, sjyc5, sjyc6, sjyc7, isshubiao;
        public static int sanjiao2jd, sanjiao2jcfd, sj2yc1, sj2yc2, sj2yc3, sj2yc4, sj2yc5, sj2yc6, sj2yc7, isshubiao2;
        public static int sifencehejcfd, sfchyc1, sfchyc2, sfchyc3, sfchyc4, sfchyc5;
        public static int yuandiheqiujcfd, ydhqyc1, ydhqyc2, ydhqyc3, ydhqyc4, ydhqyc5, ydhqyc6, ischuizhi;
        public static int houyangjcfd, houyangjd, hyyc1, hyyc2, hyyc3, hyyc4, hyyc5, hyyc6;
        public static int bxjd1, bxjd2, bxjd3, bxjd4, bxjcfd1, bxjcfd2, bxjcfd3, bxjcfd4, bxyc1, bxyc2, bxyc3, bxyc4, bxyc5, bxyc6, bxyc7, bxyc8, bxyc9;
        public static int xzjd1, xzjd2, xzjd3, xzjd4, xzjcfd1, xzjcfd2, xzjcfd3, xzjcfd4, xzyc1, xzyc2, xzyc3, xzyc4, xzyc5, xzyc6, xzyc7, xzyc8, xzyc9;
        public static int ssjd1, ssjd2, ssjd3, ssjd4, ssjcfd1, ssjcfd2, ssjcfd3, ssjcfd4, ssyc1, ssyc2, ssyc3, ssyc4, ssyc5, ssyc6, ssyc7, ssyc8, ssyc9;


        const double PI = 3.14159265358979;
        static IntPtr Hwnd;
        static Struct.RECT mnqRect;
        static Struct.POINT mp, p1, p2;
        static double eqt_x, eqt_y, eqt_k, k, r, dx, dy, sx1, sx2, sx3, sy1, sy2, sy3, sx3s, sy3s, mu, dwX, dwY, jiaodu;
        static void KeyDown(byte key, int delay)
        {
            uint scancode = API.MapVirtualKeyW(key, 0);
            API.keybd_event(key, (byte)scancode, 0, 0);
            API.keybd_event(key, (byte)scancode, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(delay);
        }

        static void jiSuanXiangLiang()
        {
            mu = Math.Sqrt(1 + eqt_k * eqt_k);
            dwX = Math.Abs(eqt_x) / eqt_x / mu;
            dwY = Math.Abs(eqt_x) / eqt_x * eqt_k / mu;
        }

        static void jiSuanCanShu()
        {
            sx3 = Math.Sqrt((r * r) / (1 + k * k)) * dx / Math.Abs(dx);
            sy3 = sx3 * k;
        }

        static void jiSuanShuBiaoZhiXiang()
        {
            dx = mp.X - (mnqRect.left + mnqRect.right) / 2;
            dy = mp.Y - (mnqRect.top + mnqRect.bottom) / 2;
            k = (double)dy / dx;
            jiSuanCanShu();
            sx3s = sx3;
            sy3s = sy3;
        }

        static void jiaoDuCaoZuo(bool zhenFu/*[1:+] [0:-]*/, int jiao)
        {
            jiaodu = zhenFu == true ? jiaodu + jiao : jiaodu - jiao;
            dwX = Math.Cos(jiaodu * PI / 180);
            dwY = Math.Sin(jiaodu * PI / 180);
        }

        static void huoQuShuBiaoWeiZhi()
        {
            API.GetCursorPos(out mp);
            API.GetWindowRect(Hwnd, out mnqRect);
        }

        public static void heqiu()
        {
            API.SetProcessDpiAwareness(Struct.PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
            Hwnd = MainForm.hWnd;
            while (true)
            {
                if (API.GetForegroundWindow() == API.FindWindow(MainForm.lp, null) && MainForm.shifouzhanju == true)
                {
                    
                    uint scancode = API.MapVirtualKeyW(tuqiujian, 0);
                    //遥杆方向
                    if (API.GetKeyState(VK_LBUTTON) < 0)
                    {
                        API.GetCursorPos(out p1);
                        API.GetWindowRect(Hwnd, out mnqRect);
                        while (true)
                        {
                            if (API.GetKeyState(VK_LBUTTON) >= 0) break;
                            if (API.GetKeyState(sanjiaojian) < 0 && sanjiaoflag) break;
                            if (API.GetKeyState(yuandiheqiujian) < 0 && yuandiheqiuflag) break;
                            if (API.GetKeyState(houyangjian) < 0 && houyangflag) break;
                            if (API.GetKeyState(xuanzhuanjian) < 0 && xuanzhuanflag) break;
                            if (API.GetKeyState(sifencehejian) < 0 && sifenceheflag) break;
                            Thread.Sleep(5);
                        }
                        API.GetCursorPos(out p2);
                        if ((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y) > 64)
                        {
                            eqt_x = p2.X - p1.X;
                            eqt_y = p2.Y - p1.Y;
                            if (eqt_x == 0) eqt_x = 0.1;
                            eqt_k = eqt_y / eqt_x;
                        }
                    }
                    //三角
                    if (API.GetKeyState(sanjiaojian) < 0 && sanjiaoflag)
                    {
                        
                        r = sanjiaojcfd;
                        r = (int)(r * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        huoQuShuBiaoWeiZhi();
                        if (sanjiaojiantou)
                        {
                            k = eqt_k;
                            dx = eqt_x;
                            jiSuanCanShu();
                        }
                        else
                        {
                            jiSuanShuBiaoZhiXiang();
                        }

                        sx1 = (sx3 * Math.Cos(sanjiaojd * PI / 360) - sy3 * Math.Sin(sanjiaojd * PI / 360));
                        sy1 = (sy3 * Math.Cos(sanjiaojd * PI / 360) + sx3 * Math.Sin(sanjiaojd * PI / 360));
                        sx2 = (sx3 * Math.Cos(sanjiaojd * PI / 360) + sy3 * Math.Sin(sanjiaojd * PI / 360));
                        sy2 = (sy3 * Math.Cos(sanjiaojd * PI / 360) - sx3 * Math.Sin(sanjiaojd * PI / 360));

                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(20);
                        API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(sjyc1);
                        API.SetCursorPos(mp.X + (int)sx1, mp.Y + (int)sy1);
                        Thread.Sleep(sjyc2);
                        KeyDown(fenshenjian, sjyc3);
                        API.SetCursorPos(mp.X + (int)sx2, mp.Y + (int)sy2);
                        Thread.Sleep(sjyc4);
                        KeyDown(fenshenjian, sjyc5);
                        API.SetCursorPos(mp.X + (int)sx3, mp.Y + (int)sy3);
                        Thread.Sleep(sjyc6);
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        if (sanjiaotqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, sjyc7);
                        }
                        if (sanjiaotqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                        }
                    }
                    //三角2
                    if (API.GetKeyState(sanjiao2jian) < 0 && sanjiao2flag)
                    {
                        r = sanjiao2jcfd;
                        r = (int)(r * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        huoQuShuBiaoWeiZhi();
                        if (sanjiao2jiantou)
                        {
                            k = eqt_k;
                            dx = eqt_x;
                            jiSuanCanShu();
                        }
                        else
                        {
                            jiSuanShuBiaoZhiXiang();
                        }

                        sx1 = (sx3 * Math.Cos(sanjiao2jd * PI / 360) - sy3 * Math.Sin(sanjiao2jd * PI / 360));
                        sy1 = (sy3 * Math.Cos(sanjiao2jd * PI / 360) + sx3 * Math.Sin(sanjiao2jd * PI / 360));
                        sx2 = (sx3 * Math.Cos(sanjiao2jd * PI / 360) + sy3 * Math.Sin(sanjiao2jd * PI / 360));
                        sy2 = (sy3 * Math.Cos(sanjiao2jd * PI / 360) - sx3 * Math.Sin(sanjiao2jd * PI / 360));

                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(20);
                        API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(sj2yc1);
                        API.SetCursorPos(mp.X + (int)sx1, mp.Y + (int)sy1);
                        Thread.Sleep(sj2yc2);
                        KeyDown(fenshenjian, sj2yc3);
                        API.SetCursorPos(mp.X + (int)sx2, mp.Y + (int)sy2);
                        Thread.Sleep(sjyc4);
                        KeyDown(fenshenjian, sj2yc5);
                        API.SetCursorPos(mp.X + (int)sx3, mp.Y + (int)sy3);
                        Thread.Sleep(sj2yc6);
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        if (sanjiao2tqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, sj2yc7);
                        }
                        if (sanjiao2tqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                        }
                    }

                    //原地
                    if (API.GetKeyState(yuandiheqiujian) < 0 && yuandiheqiuflag)
                    {

                        r = yuandiheqiujcfd;
                        r = (int)(r * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        int xiuZhengZhi = (int)(50 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6)), chuiZhi = 0;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(20);
                        API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(20);
                        API.SetCursorPos(mp.X, mp.Y);
                        Thread.Sleep(ydhqyc1);
                        KeyDown(fenshenjian, ydhqyc2);
                        jiSuanXiangLiang();
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(ydhqyc3);
                        KeyDown(fenshenjian, ydhqyc4);
                        if (chuiZhi == 1)
                        {
                            k = -1 / eqt_k;
                            jiSuanCanShu();
                            API.SetCursorPos((int)(mp.X + Math.Abs(sx3) * Math.Abs(sx3s) / sx3s), (int)(mp.Y + Math.Abs(sy3) * Math.Abs(sy3s) / sy3s));
                        }
                        else
                        {
                            API.SetCursorPos((int)(mp.X + sx3s - dwX * xiuZhengZhi), (int)(mp.Y + sy3s - dwY * xiuZhengZhi));
                        }
                        Thread.Sleep(ydhqyc5);
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        if (yuandiheqiutqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, ydhqyc6);
                        }
                        if (yuandiheqiutqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                        }

                    }
                    //后仰
                    if (API.GetKeyState(houyangjian) < 0 && houyangflag)
                    {
                        r = houyangjcfd;
                        r = (int)(r * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        int xiuZhengZhi = (int)(56 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        int houYangJiaoDu = (int)(houyangjd * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        jiSuanXiangLiang();
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(20);
                        API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(hyyc1);
                        KeyDown(fenshenjian, hyyc2);
                        API.SetCursorPos((int)(mp.X - sx3s / Math.Abs(sx3s) * Math.Abs(dwY) * houYangJiaoDu), (int)(mp.Y - sy3s / Math.Abs(sy3s) * Math.Abs(dwX) * houYangJiaoDu));
                        Thread.Sleep(hyyc3);
                        KeyDown(fenshenjian, hyyc4);
                        //r = 100;
                        API.SetCursorPos((int)(mp.X + sx3s - dwX * xiuZhengZhi), (int)(mp.Y + sy3s - dwY * xiuZhengZhi));
                        Thread.Sleep(hyyc5);
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        if (houyangtqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, hyyc6);
                        }
                        if (houyangtqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                        }
                    }
                    //四分侧合
                    if (API.GetKeyState(sifencehejian) < 0 && sifenceheflag)
                    {
                        r = sifencehejcfd;
                        r = (int)(r * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        int xiuZhengZhi = (int)(70 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        KeyDown(fenshenjian, sfchyc1);
                        KeyDown(fenshenjian, sfchyc2);
                        API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(20);
                        API.SetCursorPos(mp.X, mp.Y);
                        Thread.Sleep(sfchyc3);
                        jiSuanXiangLiang();
                        API.SetCursorPos((int)(mp.X + sx3s - dwX * xiuZhengZhi), (int)(mp.Y + sy3s - dwY * xiuZhengZhi));
                        Thread.Sleep(sfchyc4);
                        API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        if (sifencehetqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, sfchyc5);
                        }
                        if (sifencehetqflag)
                        {
                            API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                        }

                    }
                    //半旋
                    if (API.GetKeyState(banxuanjian) < 0 && banxuanflag)
                    {
                        r = 80; jiaodu = 0;
                        int jiao1 = bxjd1, jiao2 = bxjd2, jiao3 = bxjd3, jiao4 = bxjd4, fudu1 = bxjcfd1, fudu2 = bxjcfd2, fudu3 = bxjcfd3, fudu4 = bxjcfd4;
                        fudu1 = (int)(fudu1 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu2 = (int)(fudu2 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu3 = (int)(fudu3 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu4 = (int)(fudu4 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        Debug.WriteLine(fudu1 + " " + fudu2 + " " + fudu3 + " " + fudu4);
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        jiSuanXiangLiang();
                        int fangXiang = (int)(Math.Abs(eqt_x) / eqt_x);
                        if ((((float)dx * -1 * eqt_k > (float)-dy) && eqt_x > 0) || (((float)dx * -1 * eqt_k < (float)-dy) && eqt_x < 0))
                        {
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            Thread.Sleep(20);
                            API.SetCursorPos(mp.X, mp.Y);
                            Thread.Sleep(bxyc1);
                            jiaodu += Math.Atan(dwY / dwX) * 180 / PI;
                            jiaoDuCaoZuo(false, jiao1);
                            API.SetCursorPos((int)(mp.X + fudu1 * dwX * fangXiang), (int)(mp.Y + fudu1 * dwY * fangXiang));
                            Thread.Sleep(bxyc2);
                            KeyDown(fenshenjian, bxyc3);
                            jiaoDuCaoZuo(true, jiao2);
                            API.SetCursorPos((int)(mp.X + fudu2 * dwX * fangXiang), (int)(mp.Y + fudu2 * dwY * fangXiang));
                            Thread.Sleep(bxyc4);
                            KeyDown(fenshenjian, bxyc5);
                            jiaoDuCaoZuo(true, jiao3);
                            API.SetCursorPos((int)(mp.X + fudu3 * dwX * fangXiang), (int)(mp.Y + fudu3 * dwY * fangXiang));
                            Thread.Sleep(bxyc6);
                            KeyDown(fenshenjian, bxyc7);
                            jiaoDuCaoZuo(true, jiao4);
                            API.SetCursorPos((int)(mp.X + fudu4 * dwX * fangXiang), (int)(mp.Y + fudu4 * dwY * fangXiang));
                            Thread.Sleep(bxyc8);
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            if (xuanzhuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                            }
                            KeyDown(fenshenjian, bxyc9);
                            //API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            //API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            //Thread.Sleep(bxyc9);
                            for (int i = 0; i < 20; i++)
                            {
                                KeyDown(fenshenjian, bxyc9);
                            }
                            if (xuanzhuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                            }
                        }
                        else
                        {
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            Thread.Sleep(20);
                            API.SetCursorPos(mp.X, mp.Y);
                            Thread.Sleep(bxyc1);
                            jiaodu += Math.Atan(dwY / dwX) * 180 / PI;
                            jiaoDuCaoZuo(true, jiao1);
                            API.SetCursorPos((int)(mp.X + fudu1 * dwX * fangXiang), (int)(mp.Y + fudu1 * dwY * fangXiang));
                            Thread.Sleep(bxyc2);
                            KeyDown(fenshenjian, bxyc3);
                            jiaoDuCaoZuo(false, jiao2);
                            API.SetCursorPos((int)(mp.X + fudu2 * dwX * fangXiang), (int)(mp.Y + fudu2 * dwY * fangXiang));
                            Thread.Sleep(bxyc4);
                            KeyDown(fenshenjian, bxyc5);
                            jiaoDuCaoZuo(false, jiao3);
                            API.SetCursorPos((int)(mp.X + fudu3 * dwX * fangXiang), (int)(mp.Y + fudu3 * dwY * fangXiang));
                            Thread.Sleep(bxyc6);
                            KeyDown(fenshenjian, bxyc7);
                            jiaoDuCaoZuo(false, jiao4);
                            API.SetCursorPos((int)(mp.X + fudu4 * dwX * fangXiang), (int)(mp.Y + fudu4 * dwY * fangXiang));
                            Thread.Sleep(bxyc8);
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            if (banxuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                            }
                            KeyDown(fenshenjian, bxyc9);
                            //API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            //API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            //Thread.Sleep(bxyc9);
                            for (int i = 0; i < 20; i++)
                            {
                                KeyDown(fenshenjian, bxyc9);
                            }
                            if (banxuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                            }

                        }
                    }

                    //旋转
                    if (API.GetKeyState(xuanzhuanjian) < 0 && xuanzhuanflag)
                    {
                        r = 80; jiaodu = 0;
                        int jiao1 = xzjd1, jiao2 = xzjd2, jiao3 = xzjd3, jiao4 = xzjd4, fudu1 = xzjcfd1, fudu2 = xzjcfd2, fudu3 = xzjcfd3, fudu4 = xzjcfd4;
                        fudu1 = (int)(fudu1 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu2 = (int)(fudu2 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu3 = (int)(fudu3 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu4 = (int)(fudu4 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        Debug.WriteLine(fudu1 + " " + fudu2 + " " + fudu3 + " " + fudu4);
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        jiSuanXiangLiang();
                        int fangXiang = (int)(Math.Abs(eqt_x) / eqt_x);
                        if ((((float)dx * -1 * eqt_k > (float)-dy) && eqt_x > 0) || (((float)dx * -1 * eqt_k < (float)-dy) && eqt_x < 0))
                        {
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            Thread.Sleep(20);
                            API.SetCursorPos(mp.X, mp.Y);
                            Thread.Sleep(xzyc1);
                            jiaodu += Math.Atan(dwY / dwX) * 180 / PI;
                            jiaoDuCaoZuo(false, jiao1);
                            API.SetCursorPos((int)(mp.X + fudu1 * dwX * fangXiang), (int)(mp.Y + fudu1 * dwY * fangXiang));
                            Thread.Sleep(xzyc2);
                            KeyDown(fenshenjian, xzyc3);
                            jiaoDuCaoZuo(true, jiao2);
                            API.SetCursorPos((int)(mp.X + fudu2 * dwX * fangXiang), (int)(mp.Y + fudu2 * dwY * fangXiang));
                            Thread.Sleep(xzyc4);
                            KeyDown(fenshenjian, xzyc5);
                            jiaoDuCaoZuo(true, jiao3);
                            API.SetCursorPos((int)(mp.X + fudu3 * dwX * fangXiang), (int)(mp.Y + fudu3 * dwY * fangXiang));
                            Thread.Sleep(xzyc6);
                            KeyDown(fenshenjian, xzyc7);
                            jiaoDuCaoZuo(true, jiao4);
                            API.SetCursorPos((int)(mp.X + fudu4 * dwX * fangXiang), (int)(mp.Y + fudu4 * dwY * fangXiang));
                            Thread.Sleep(xzyc8);
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            
                            if (xuanzhuantqflag)
                            {
                                
                                API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                            }

                            KeyDown(fenshenjian, xzyc9);
                            //API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            //API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            //Thread.Sleep(xzyc9);
                            for (int i = 0; i < 20; i++)
                            {
                                KeyDown(fenshenjian, xzyc9);
                            }
                            if (xuanzhuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                            }
                        }
                        else
                        {
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            Thread.Sleep(20);
                            API.SetCursorPos(mp.X, mp.Y);
                            Thread.Sleep(xzyc1);
                            jiaodu += Math.Atan(dwY / dwX) * 180 / PI;
                            jiaoDuCaoZuo(true, jiao1);
                            API.SetCursorPos((int)(mp.X + fudu1 * dwX * fangXiang), (int)(mp.Y + fudu1 * dwY * fangXiang));
                            Thread.Sleep(xzyc2);
                            KeyDown(fenshenjian, xzyc3);
                            jiaoDuCaoZuo(false, jiao2);
                            API.SetCursorPos((int)(mp.X + fudu2 * dwX * fangXiang), (int)(mp.Y + fudu2 * dwY * fangXiang));
                            Thread.Sleep(xzyc4);
                            KeyDown(fenshenjian, xzyc5);
                            jiaoDuCaoZuo(false, jiao3);
                            API.SetCursorPos((int)(mp.X + fudu3 * dwX * fangXiang), (int)(mp.Y + fudu3 * dwY * fangXiang));
                            Thread.Sleep(xzyc6);
                            KeyDown(fenshenjian, xzyc7);
                            jiaoDuCaoZuo(false, jiao4);
                            API.SetCursorPos((int)(mp.X + fudu4 * dwX * fangXiang), (int)(mp.Y + fudu4 * dwY * fangXiang));
                            Thread.Sleep(xzyc8);
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            if (xuanzhuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                            }
                            KeyDown(fenshenjian, xzyc9);
                            //API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            //API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            //Thread.Sleep(xzyc9);
                            for (int i = 0; i < 20; i++)
                            {
                                KeyDown(fenshenjian, xzyc9);
                            }
                            if (xuanzhuantqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                            }

                        }
                    }
                    //蛇手
                    if (API.GetKeyState(sheshoujian) < 0 && sheshouflag)
                    {
                        r = 80; jiaodu = 0;
                        int jiao1 = ssjd1, jiao2 = ssjd2, jiao3 = ssjd3, jiao4 = ssjd4, fudu1 = ssjcfd1, fudu2 = ssjcfd2, fudu3 = ssjcfd3, fudu4 = ssjcfd4;
                        fudu1 = (int)(fudu1 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu2 = (int)(fudu2 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu3 = (int)(fudu3 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        fudu4 = (int)(fudu4 * ((float)(mnqRect.right - mnqRect.left) / 1920 * yaogandaxiao / 1.6));
                        Debug.WriteLine(fudu1 + " " + fudu2 + " " + fudu3 + " " + fudu4);
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        jiSuanXiangLiang();
                        int fangXiang = (int)(Math.Abs(eqt_x) / eqt_x);
                        if ((((float)dx * -1 * eqt_k > (float)-dy) && eqt_x > 0) || (((float)dx * -1 * eqt_k < (float)-dy) && eqt_x < 0))
                        {
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            Thread.Sleep(20);
                            API.SetCursorPos(mp.X, mp.Y);
                            Thread.Sleep(ssyc1);
                            jiaodu += Math.Atan(dwY / dwX) * 180 / PI;
                            jiaoDuCaoZuo(false, jiao1);
                            API.SetCursorPos((int)(mp.X + fudu1 * dwX * fangXiang), (int)(mp.Y + fudu1 * dwY * fangXiang));
                            Thread.Sleep(ssyc2);
                            KeyDown(fenshenjian, ssyc3);
                            jiaoDuCaoZuo(true, jiao2);
                            API.SetCursorPos((int)(mp.X + fudu2 * dwX * fangXiang), (int)(mp.Y + fudu2 * dwY * fangXiang));
                            Thread.Sleep(ssyc4);
                            KeyDown(fenshenjian, ssyc5);
                            jiaoDuCaoZuo(true, jiao3);
                            API.SetCursorPos((int)(mp.X + fudu3 * dwX * fangXiang), (int)(mp.Y + fudu3 * dwY * fangXiang));
                            Thread.Sleep(ssyc6);
                            KeyDown(fenshenjian, ssyc7);
                            jiaoDuCaoZuo(true, jiao4);
                            API.SetCursorPos((int)(mp.X + fudu4 * dwX * fangXiang), (int)(mp.Y + fudu4 * dwY * fangXiang));
                            Thread.Sleep(ssyc8);
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            if (sheshoutqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                            }
                            for (int i = 0; i < 20; i++)
                            {
                                KeyDown(fenshenjian, ssyc9);
                            }
                            if (sheshoutqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                            }
                        }
                        else
                        {
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            API.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                            Thread.Sleep(20);
                            API.SetCursorPos(mp.X, mp.Y);
                            Thread.Sleep(ssyc1);
                            jiaodu += Math.Atan(dwY / dwX) * 180 / PI;
                            jiaoDuCaoZuo(true, jiao1);
                            API.SetCursorPos((int)(mp.X + fudu1 * dwX * fangXiang), (int)(mp.Y + fudu1 * dwY * fangXiang));
                            Thread.Sleep(ssyc2);
                            KeyDown(fenshenjian, ssyc3);
                            jiaoDuCaoZuo(false, jiao2);
                            API.SetCursorPos((int)(mp.X + fudu2 * dwX * fangXiang), (int)(mp.Y + fudu2 * dwY * fangXiang));
                            Thread.Sleep(ssyc4);
                            KeyDown(fenshenjian, ssyc5);
                            jiaoDuCaoZuo(false, jiao3);
                            API.SetCursorPos((int)(mp.X + fudu3 * dwX * fangXiang), (int)(mp.Y + fudu3 * dwY * fangXiang));
                            Thread.Sleep(ssyc6);
                            KeyDown(fenshenjian, ssyc7);
                            jiaoDuCaoZuo(false, jiao4);
                            API.SetCursorPos((int)(mp.X + fudu4 * dwX * fangXiang), (int)(mp.Y + fudu4 * dwY * fangXiang));
                            Thread.Sleep(ssyc8);
                            API.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                            if (sheshoutqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, 0, 0);
                            }
                            for (int i = 0; i < 20; i++)
                            {
                                KeyDown(fenshenjian, ssyc9);
                            }
                            if (sheshoutqflag)
                            {
                                API.keybd_event(tuqiujian, (byte)scancode, KEYEVENTF_KEYUP, 0);
                            }

                        }
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
