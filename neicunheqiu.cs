using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ANYE_Balls.Struct;
using static ANYE_Balls.API;
using System.Diagnostics;

namespace ANYE_Balls
{
    public class neicunheqiu
    {
        public static long yaoganadr;
        public static long nctqadr;

        public static byte fenshenjian;
        public static byte tuqiujian;

        public static float yaogandaxiao;
        public static bool suoqiuflag;
        public static bool suoqiujiancha;
        public static int suoqiujian;

        public static bool ncsanjiaoflag, ncsanjiaojiantou, ncsanjiaotq;
        public static bool ncsanjiao2flag, ncsanjiao2jiantou, ncsanjiao2tq;
        public static bool ncsifenceheflag, ncsifencehetq;
        public static bool ncyuandiheqiuflag, ncyuandiheqiutq;
        public static bool nchouyangflag, nchouyangtq;
        public static bool ncbanxuanflag, ncbanxuantq;
        public static bool ncxuanzhuanflag, ncxuanzhuantq;
        public static bool ncsheshouflag, ncsheshoutq;

        public static int ncsanjiaojian;
        public static int ncsanjiao2jian;
        public static int ncsifencehejian;
        public static int ncyuandiheqiujian;
        public static int nchouyangjian;
        public static int ncbanxuanjian;
        public static int ncxuanzhuanjian;
        public static int ncsheshoujian;

        public static int ncsanjiaojd, ncsanjiaojcfd, ncsjyc1, ncsjyc2, ncsjyc3, ncsjyc4, ncsjyc5, ncsjyc6;
        public static int ncsanjiao2jd, ncsanjiao2jcfd, ncsj2yc1, ncsj2yc2, ncsj2yc3, ncsj2yc4, ncsj2yc5, ncsj2yc6;
        public static int ncyuandiheqiujcfd, ncydhqyc1, ncydhqyc2, ncydhqyc3, ncydhqyc4, ncydhqyc5, ncischuizhi;
        public static int ncsifencehejcfd, ncsfchyc1, ncsfchyc2, ncsfchyc3, ncsfchyc4;
        public static int nchouyangjcfd, nchouyangjd, nchyyc1, nchyyc2, nchyyc3, nchyyc4, nchyyc5;
        public static int ncbxjd1, ncbxjd2, ncbxjd3, ncbxjd4, ncbxjcfd1, ncbxjcfd2, ncbxjcfd3, ncbxjcfd4, ncbxyc1, ncbxyc2, ncbxyc3, ncbxyc4, ncbxyc5, ncbxyc6, ncbxyc7, ncbxyc8;
        public static int ncxzjd1, ncxzjd2, ncxzjd3, ncxzjd4, ncxzjcfd1, ncxzjcfd2, ncxzjcfd3, ncxzjcfd4, ncxzyc1, ncxzyc2, ncxzyc3, ncxzyc4, ncxzyc5, ncxzyc6, ncxzyc7, ncxzyc8;
        public static int ncssjd1, ncssjd2, ncssjd3, ncssjd4, ncssjcfd1, ncssjcfd2, ncssjcfd3, ncssjcfd4, ncssyc1, ncssyc2, ncssyc3, ncssyc4, ncssyc5, ncssyc6, ncssyc7, ncssyc8;

        const double PI = 3.14159265358979;
        static IntPtr Hwnd;
        static RECT mnqRect;
        static POINT mp, p1, p2;
        static double eqt_x, eqt_y, eqt_k, k, r = 100, dx, dy, sx1, sx2, sx3, sy1, sy2, sy3, sx3s, sy3s, mu, dwX, dwY, jiaodu, yygx, yygy, yaoGanX, yaoGanY, yaoGanR;

        static void tuqiu(int zhuangtai)
        {
            int a;
            WriteProcessMemory(MainForm.hProcess, nctqadr, BitConverter.GetBytes(zhuangtai), sizeof(int), out a);
        }
        static float readzhiX(long adr)
        {
            int bytesread;
            IntPtr hProcess = MainForm.hProcess;
            byte[] data = new byte[4];
            ReadProcessMemory(hProcess, adr, data, 4, out bytesread);
            float X = BitConverter.ToSingle(data, 0);
            return X;
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

        static float readzhiY(long adr)
        {
            int bytesread;
            IntPtr hProcess = MainForm.hProcess;
            byte[] data = new byte[4];
            ReadProcessMemory(hProcess, adr + 0x4, data, 4, out bytesread);
            float Y = BitConverter.ToSingle(data, 0);
            return Y;
        }

        public static void writezhi(long adr, float XZ, float YZ)
        {
            int byteswrite;
            IntPtr hProcess = MainForm.hProcess;
            WriteProcessMemory(hProcess, adr, BitConverter.GetBytes(XZ), 4, out byteswrite);
            WriteProcessMemory(hProcess, adr + 0x4, BitConverter.GetBytes(YZ), 4, out byteswrite);
        }

        public static void KeyDown(byte key, int delay)
        {
            uint scancode = MapVirtualKeyW(key, 0);

            keybd_event(key, (byte)scancode, 0, 0);
            keybd_event(key, (byte)scancode, 2, 0);
            Thread.Sleep(delay);
        }

        static void jiSuanCanShu()
        {
            sx3 = Math.Sqrt((r * r) / (1 + k * k)) * dx / Math.Abs(dx);
            sy3 = sx3 * k;
        }

        static void jiSuanShuBiaoZhiXiang()
        {
            dx = mp.X - (mnqRect.left + mnqRect.right) / 2;
            dy = -(mp.Y - (mnqRect.top + mnqRect.bottom) / 2);
            k = (double)dy / dx;
            Debug.WriteLine(k);
            jiSuanCanShu();
        }

        static void huoQuShuBiaoWeiZhi()
        {
            GetCursorPos(out mp);
            GetWindowRect(Hwnd, out mnqRect);
        }

        static void huoQuYaoGanFangXiang()
        {
            float X;
            float Y;
            while (true)
            {
                X = readzhiX(yaoganadr);
                Y = readzhiY(yaoganadr);
                if (X == 0) continue;
                eqt_k = Y / X;
                if (X != 0) break;
                Thread.Sleep(10);
            }
            yygx = X;
            yygy = Y;
            
        }
        static void jiSuanYaoGanLiang(float nk, float nx)
        {
            mu = Math.Sqrt(1 + nk * nk);
            yaoGanX = Math.Abs(nx) / nx / mu;
            yaoGanY = Math.Abs(nx) / nx * nk / mu;
        }



        static void yaoGanJiaoDu(int jiao)
        {
            jiaodu += jiao;
            yaoGanX = Math.Cos(jiaodu * PI / 180);
            yaoGanY = Math.Sin(jiaodu * PI / 180);
        }

        public static void ncheqiu()
        {
            SetProcessDpiAwareness(PROCESS_DPI_AWARENESS.Process_Per_Monitor_DPI_Aware);
            Hwnd = MainForm.hWnd;
            while (true)
            {
                
                if (GetForegroundWindow() == FindWindow(MainForm.lp, null) && MainForm.shifouzhanju == true)
                {
                    
                    uint scancode = API.MapVirtualKeyW(tuqiujian, 0);


                    //自动锁球
                    if (GetKeyState(suoqiujian) < 0 && suoqiuflag)
                    {
                        float caoZuoZhi;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        jiSuanYaoGanLiang((float)k, (float)dx);
                        int px = (mnqRect.left - mnqRect.right) / 2, py = (mnqRect.bottom - mnqRect.top) / 2;
                        caoZuoZhi = (float)Math.Abs(dx * dx + dy * dy) / Math.Abs(px * px + py * py) * 10f;
                        writezhi(yaoganadr, (float)yaoGanX * caoZuoZhi, (float)yaoGanY * caoZuoZhi);
                        keybd_event((byte)tuqiujian, (byte)scancode, 0, 0);
                        //keybd_event((byte)tuqiujian, (byte)scancode, 2, 0);
                        suoqiujiancha = true;
                    }
                    if (GetKeyState(suoqiujian) >= 0 && suoqiuflag && suoqiujiancha)
                    {
                        keybd_event((byte)tuqiujian, (byte)scancode, 2, 0);
                        suoqiujiancha = false;
                    }
                    
                    //三角
                    if (GetKeyState(ncsanjiaojian) < 0 && ncsanjiaoflag)
                    {
                        yaoGanR = (float)ncsanjiaojcfd / 250;
                        float yaoGanR1 = 10;
                        huoQuShuBiaoWeiZhi();
                        if (ncsanjiaojiantou)
                        {
                            huoQuYaoGanFangXiang();

                            k = eqt_k;
                            dx = yygx;
                            jiSuanCanShu();
                        }
                        else
                        {
                            jiSuanShuBiaoZhiXiang();
                        }
                        sx1 = (sx3 * Math.Cos(ncsanjiaojd * PI / 360) - sy3 * Math.Sin(ncsanjiaojd * PI / 360));
                        sy1 = (sy3 * Math.Cos(ncsanjiaojd * PI / 360) + sx3 * Math.Sin(ncsanjiaojd * PI / 360));
                        sx2 = (sx3 * Math.Cos(ncsanjiaojd * PI / 360) + sy3 * Math.Sin(ncsanjiaojd * PI / 360));
                        sy2 = (sy3 * Math.Cos(ncsanjiaojd * PI / 360) - sx3 * Math.Sin(ncsanjiaojd * PI / 360));

                        jiSuanYaoGanLiang((float)(sy1 / sx1), (float)sx1);
                        writezhi(yaoganadr, (float)(yaoGanX * yaoGanR1), (float)(yaoGanY * yaoGanR1));
                        Debug.WriteLine(yaoganadr.ToString("X"));
                        Thread.Sleep(ncsjyc1);
                        KeyDown((byte)fenshenjian, ncsjyc2);
                        jiSuanYaoGanLiang((float)(sy2 / sx2), (float)sx2);
                        writezhi(yaoganadr, (float)(yaoGanX * yaoGanR1), (float)(yaoGanY * yaoGanR1));
                        Thread.Sleep(ncsjyc3);
                        KeyDown((byte)fenshenjian, ncsjyc4);
                        jiSuanYaoGanLiang((float)k, (float)dx);
                        writezhi(yaoganadr, (float)(yaoGanX * yaoGanR), (float)(yaoGanY * yaoGanR));
                        Thread.Sleep(ncsjyc5);
                        if (ncsanjiaotq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown((byte)fenshenjian, ncsjyc6);
                        }
                        if (ncsanjiaotq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }
                    //三角2
                    if (GetKeyState(ncsanjiao2jian) < 0 && ncsanjiao2flag)
                    {
                        yaoGanR = (float)ncsanjiao2jcfd / 250;
                        float yaoGanR1 = 10;
                        huoQuShuBiaoWeiZhi();
                        if (ncsanjiao2jiantou)
                        {
                            huoQuYaoGanFangXiang();
                            k = eqt_k;
                            dx = yygx;
                            jiSuanCanShu();
                        }
                        else
                        {
                            jiSuanShuBiaoZhiXiang();
                        }
                        sx1 = (sx3 * Math.Cos(ncsanjiao2jd * PI / 360) - sy3 * Math.Sin(ncsanjiao2jd * PI / 360));
                        sy1 = (sy3 * Math.Cos(ncsanjiao2jd * PI / 360) + sx3 * Math.Sin(ncsanjiao2jd * PI / 360));
                        sx2 = (sx3 * Math.Cos(ncsanjiao2jd * PI / 360) + sy3 * Math.Sin(ncsanjiao2jd * PI / 360));
                        sy2 = (sy3 * Math.Cos(ncsanjiao2jd * PI / 360) - sx3 * Math.Sin(ncsanjiao2jd * PI / 360));

                        jiSuanYaoGanLiang((float)(sy1 / sx1), (float)sx1);
                        writezhi(yaoganadr, (float)(yaoGanX * yaoGanR1), (float)(yaoGanY * yaoGanR1));
                        Thread.Sleep(ncsj2yc1);
                        KeyDown((byte)fenshenjian, ncsj2yc2);
                        jiSuanYaoGanLiang((float)(sy2 / sx2), (float)sx2);
                        writezhi(yaoganadr, (float)(yaoGanX * yaoGanR1), (float)(yaoGanY * yaoGanR1));
                        Thread.Sleep(ncsj2yc3);
                        KeyDown((byte)fenshenjian, ncsj2yc4);
                        jiSuanYaoGanLiang((float)k, (float)dx);
                        writezhi(yaoganadr, (float)(yaoGanX * yaoGanR), (float)(yaoGanY * yaoGanR));
                        Thread.Sleep(ncsj2yc5);
                        if (ncsanjiaotq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown((byte)fenshenjian, ncsj2yc6);
                        }
                        if (ncsanjiao2tq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }
                    //原地
                    if (GetKeyState(ncyuandiheqiujian) < 0 && ncyuandiheqiuflag)
                    {
                        int chuizhi = ncischuizhi;
                        yaoGanR = (float)ncyuandiheqiujcfd / 250;
                        float xiuZhenZhi = 0.55f;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        huoQuYaoGanFangXiang();
                        KeyDown(fenshenjian, ncydhqyc1);
                        writezhi(yaoganadr, 0, 0);
                        Thread.Sleep(ncydhqyc2);
                        KeyDown(fenshenjian, ncydhqyc3);
                        if (chuizhi == 1)
                        {
                            jiSuanYaoGanLiang((float)(-1 / (yygy / yygx)), (float)yygx);
                            writezhi(yaoganadr, (float)(Math.Abs(yaoGanX * yaoGanR) * Math.Abs(dx) / dx), (float)(Math.Abs(yaoGanY * yaoGanR) * Math.Abs(dy) / dy));
                        }
                        else
                        {
                            jiSuanYaoGanLiang((float)k, (float)dx);
                            writezhi(yaoganadr, (float)((yaoGanX - yygx * xiuZhenZhi) * yaoGanR), (float)((yaoGanY - yygy * xiuZhenZhi) * yaoGanR));
                        }
                        Thread.Sleep(ncydhqyc4);
                        if (ncyuandiheqiutq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, ncydhqyc5);
                        }
                        if (ncyuandiheqiutq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }
                    //后仰
                    if (GetKeyState(nchouyangjian) < 0 && nchouyangflag)
                    {
                        yaoGanR = (float)nchouyangjcfd / 250;
                        float xiuZhenZhi = 0.6f, houYangFuDu = 0.15f;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        huoQuYaoGanFangXiang();
                        KeyDown(fenshenjian, nchyyc1);
                        jiSuanYaoGanLiang((float)(-1 / k), (float)dx);
                        writezhi(yaoganadr, (float)(-Math.Abs(yaoGanX * houYangFuDu) * Math.Abs(dx) / dx), (float)(-Math.Abs(yaoGanY * houYangFuDu) * Math.Abs(dy) / dy));
                        Thread.Sleep(nchyyc2);
                        KeyDown(fenshenjian, nchyyc3);
                        jiSuanYaoGanLiang((float)k, (float)dx);
                        writezhi(yaoganadr, (float)((yaoGanX - yygx * xiuZhenZhi) * yaoGanR), (float)((yaoGanY - yygy * xiuZhenZhi) * yaoGanR));
                        Thread.Sleep(nchyyc4);
                        if (nchouyangtq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, nchyyc5);
                        }
                        if (nchouyangtq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }
                    //四分侧合
                    if (GetKeyState(ncsifencehejian) < 0 && ncsifenceheflag)
                    {
                        yaoGanR = (float)ncsifencehejcfd / 250;
                        float xiuZhenZhi = 0.6f;
                        KeyDown(fenshenjian, ncsfchyc1);
                        KeyDown(fenshenjian, ncsfchyc2);
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        huoQuYaoGanFangXiang();
                        jiSuanYaoGanLiang((float)k, (float)dx);
                        writezhi(yaoganadr, (float)((yaoGanX - yygx * xiuZhenZhi) * yaoGanR), (float)((yaoGanY - yygy * xiuZhenZhi) * yaoGanR));
                        Thread.Sleep(ncsfchyc3);
                        if (ncsifencehetq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, ncsfchyc4);
                        }
                        if (ncsifencehetq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }
                    //半旋
                    if (GetKeyState(ncbanxuanjian) < 0 && ncbanxuanflag)
                    {
                        jiaodu = 0;
                        float jiao1 = ncbxjd1, jiao2 = ncbxjd2, jiao3 = ncbxjd3, jiao4 = ncbxjd4, fudu1 = ncbxjcfd1, fudu2 = ncbxjcfd2, fudu3 = ncbxjcfd3, fudu4 = ncbxjcfd4, xishu = 250;
                        fudu1 /= xishu; fudu2 /= xishu; fudu3 /= xishu; fudu4 /= xishu;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        huoQuYaoGanFangXiang();
                        eqt_k = yygy / yygx;
                        jiSuanYaoGanLiang((float)eqt_k, (float)yygx);
                        jiaodu += Math.Atan(eqt_k) * 180 / PI;
                        int fangXiang = (int)(Math.Abs(yygx) / yygx);
                        if ((float)dx * eqt_k > (float)dy && yygx > 0 || (float)dx * eqt_k < (float)dy && yygx < 0)
                        {
                            yaoGanJiaoDu((int)jiao1);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu1 * fangXiang), (float)(yaoGanY * fudu1 * fangXiang));
                            Thread.Sleep(ncbxyc1);
                            KeyDown(fenshenjian, ncbxyc2);
                            yaoGanJiaoDu(-(int)jiao2);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu2 * fangXiang), (float)(yaoGanY * fudu2 * fangXiang));
                            Thread.Sleep(ncbxyc3);
                            KeyDown(fenshenjian, ncbxyc4);
                            yaoGanJiaoDu(-(int)jiao3);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu3 * fangXiang), (float)(yaoGanY * fudu3 * fangXiang));
                            Thread.Sleep(ncbxyc5);
                            KeyDown(fenshenjian, ncbxyc6);
                            yaoGanJiaoDu(-(int)jiao4);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu4 * fangXiang), (float)(yaoGanY * fudu4 * fangXiang));
                            Thread.Sleep(ncbxyc7);
                        }
                        else
                        {
                            yaoGanJiaoDu(-(int)jiao1);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu1 * fangXiang), (float)(yaoGanY * fudu1 * fangXiang));
                            Thread.Sleep(ncbxyc1);
                            KeyDown(fenshenjian, ncbxyc2);
                            yaoGanJiaoDu((int)jiao2);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu2 * fangXiang), (float)(yaoGanY * fudu2 * fangXiang));
                            Thread.Sleep(ncbxyc3);
                            KeyDown(fenshenjian, ncbxyc4);
                            yaoGanJiaoDu((int)jiao3);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu3 * fangXiang), (float)(yaoGanY * fudu3 * fangXiang));
                            Thread.Sleep(ncbxyc5);
                            KeyDown(fenshenjian, ncbxyc6);
                            yaoGanJiaoDu((int)jiao4);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu4 * fangXiang), (float)(yaoGanY * fudu4 * fangXiang));
                            Thread.Sleep(ncbxyc7);
                        }
                        if (ncbanxuantq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, ncbxyc8);
                        }
                        if (ncbanxuantq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }

                    //旋转
                    if (GetKeyState(ncxuanzhuanjian) < 0 && ncxuanzhuanflag)
                    {
                        jiaodu = 0;
                        float jiao1 = ncxzjd1, jiao2 = ncxzjd2, jiao3 = ncxzjd3, jiao4 = ncxzjd4, fudu1 = ncxzjcfd1, fudu2 = ncxzjcfd2, fudu3 = ncxzjcfd3, fudu4 = ncxzjcfd4, xishu = 250;
                        fudu1 /= xishu; fudu2 /= xishu; fudu3 /= xishu; fudu4 /= xishu;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        huoQuYaoGanFangXiang();
                        eqt_k = yygy / yygx;
                        jiSuanYaoGanLiang((float)eqt_k, (float)yygx);
                        jiaodu += Math.Atan(eqt_k) * 180 / PI;
                        int fangXiang = (int)(Math.Abs(yygx) / yygx);
                        if ((float)dx * eqt_k > (float)dy && yygx > 0 || (float)dx * eqt_k < (float)dy && yygx < 0)
                        {
                            yaoGanJiaoDu((int)jiao1);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu1 * fangXiang), (float)(yaoGanY * fudu1 * fangXiang));
                            Thread.Sleep(ncxzyc1);
                            KeyDown(fenshenjian, ncxzyc2);
                            yaoGanJiaoDu(-(int)jiao2);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu2 * fangXiang), (float)(yaoGanY * fudu2 * fangXiang));
                            Thread.Sleep(ncxzyc3);
                            KeyDown(fenshenjian, ncxzyc4);
                            yaoGanJiaoDu(-(int)jiao3);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu3 * fangXiang), (float)(yaoGanY * fudu3 * fangXiang));
                            Thread.Sleep(ncxzyc5);
                            KeyDown(fenshenjian, ncxzyc6);
                            yaoGanJiaoDu(-(int)jiao4);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu4 * fangXiang), (float)(yaoGanY * fudu4 * fangXiang));
                            Thread.Sleep(ncxzyc7);
                        }
                        else
                        {
                            yaoGanJiaoDu(-(int)jiao1);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu1 * fangXiang), (float)(yaoGanY * fudu1 * fangXiang));
                            Thread.Sleep(ncxzyc1);
                            KeyDown(fenshenjian, ncxzyc2);
                            yaoGanJiaoDu((int)jiao2);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu2 * fangXiang), (float)(yaoGanY * fudu2 * fangXiang));
                            Thread.Sleep(ncxzyc3);
                            KeyDown(fenshenjian, ncxzyc4);
                            yaoGanJiaoDu((int)jiao3);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu3 * fangXiang), (float)(yaoGanY * fudu3 * fangXiang));
                            Thread.Sleep(ncxzyc5);
                            KeyDown(fenshenjian, ncxzyc6);
                            yaoGanJiaoDu((int)jiao4);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu4 * fangXiang), (float)(yaoGanY * fudu4 * fangXiang));
                            Thread.Sleep(ncxzyc7);
                        }
                        if (ncxuanzhuantq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, ncxzyc8);
                        }
                        if (ncxuanzhuantq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }

                    //蛇手
                    if (GetKeyState(ncsheshoujian) < 0 && ncsheshouflag)
                    {
                        jiaodu = 0;
                        float jiao1 = ncssjd1, jiao2 = ncssjd2, jiao3 = ncssjd3, jiao4 = ncssjd4, fudu1 = ncssjcfd1, fudu2 = ncssjcfd2, fudu3 = ncssjcfd3, fudu4 = ncssjcfd4, xishu = 250;
                        fudu1 /= xishu; fudu2 /= xishu; fudu3 /= xishu; fudu4 /= xishu;
                        huoQuShuBiaoWeiZhi();
                        jiSuanShuBiaoZhiXiang();
                        huoQuYaoGanFangXiang();
                        eqt_k = yygy / yygx;
                        jiSuanYaoGanLiang((float)eqt_k, (float)yygx);
                        jiaodu += Math.Atan(eqt_k) * 180 / PI;
                        int fangXiang = (int)(Math.Abs(yygx) / yygx);
                        if ((float)dx * eqt_k > (float)dy && yygx > 0 || (float)dx * eqt_k < (float)dy && yygx < 0)
                        {
                            yaoGanJiaoDu((int)jiao1);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu1 * fangXiang), (float)(yaoGanY * fudu1 * fangXiang));
                            Thread.Sleep(ncssyc1);
                            KeyDown(fenshenjian, ncssyc2);
                            yaoGanJiaoDu(-(int)jiao2);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu2 * fangXiang), (float)(yaoGanY * fudu2 * fangXiang));
                            Thread.Sleep(ncssyc3);
                            KeyDown(fenshenjian, ncssyc4);
                            yaoGanJiaoDu(-(int)jiao3);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu3 * fangXiang), (float)(yaoGanY * fudu3 * fangXiang));
                            Thread.Sleep(ncssyc5);
                            KeyDown(fenshenjian, ncssyc6);
                            yaoGanJiaoDu(-(int)jiao4);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu4 * fangXiang), (float)(yaoGanY * fudu4 * fangXiang));
                            Thread.Sleep(ncssyc7);
                        }
                        else
                        {
                            yaoGanJiaoDu(-(int)jiao1);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu1 * fangXiang), (float)(yaoGanY * fudu1 * fangXiang));
                            Thread.Sleep(ncssyc1);
                            KeyDown(fenshenjian, ncssyc2);
                            yaoGanJiaoDu((int)jiao2);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu2 * fangXiang), (float)(yaoGanY * fudu2 * fangXiang));
                            Thread.Sleep(ncssyc3);
                            KeyDown(fenshenjian, ncssyc4);
                            yaoGanJiaoDu((int)jiao3);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu3 * fangXiang), (float)(yaoGanY * fudu3 * fangXiang));
                            Thread.Sleep(ncssyc5);
                            KeyDown(fenshenjian, ncssyc6);
                            yaoGanJiaoDu((int)jiao4);
                            writezhi(yaoganadr, (float)(yaoGanX * fudu4 * fangXiang), (float)(yaoGanY * fudu4 * fangXiang));
                            Thread.Sleep(ncssyc7);
                        }
                        if (ncsheshoutq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 0, 0);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            KeyDown(fenshenjian, ncssyc8);
                        }
                        if (ncsheshoutq)
                        {
                            keybd_event(tuqiujian, (byte)scancode, 2, 0);
                        }
                    }
                }
                Thread.Sleep(10);

            }

        }
    }
}