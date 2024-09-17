using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANYE_Balls
{
    public partial class heipinghuizhi2 : Form
    {
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        public const int GWL_EXSTYLE = -20;
        // 设置窗口样式
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // 获取窗口样式
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        // 设置窗口透明度
        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte bAlpha, int dwFlags);

        // 获取桌面窗口句柄
        [DllImport("user32.dll", SetLastError = false)]
        static extern IntPtr GetDesktopWindow();
        public heipinghuizhi2()
        {
            InitializeComponent();
            // 设置窗体为无边框、透明
            this.FormBorderStyle = FormBorderStyle.None;
            SetWindowLong(this.Handle, -20, GetWindowLong(this.Handle, -20) | WS_EX_TRANSPARENT | WS_EX_LAYERED);

            // 设置窗体透明度（0-255）
            //SetLayeredWindowAttributes(this.Handle, 0, 50, 0x2);
            //this.BackColor = Color.Transparent;
            // 将窗体置于桌面之上
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Black; // 将窗体上所有颜色的部分设为透明
            this.TopMost = true;
            int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            exStyle |= WS_EX_LAYERED | WS_EX_TRANSPARENT;
            SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle);
        }

        private void heipinghuizhi2_Load(object sender, EventArgs e)
        {
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
    }
}
