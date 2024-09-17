namespace ANYE_Balls
{
    partial class qitagongneng
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Groupshiye = new Sunny.UI.UIGroupBox();
            label1 = new AntdUI.Label();
            label6 = new AntdUI.Label();
            buttonshiye = new AntdUI.Button();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            label4 = new AntdUI.Label();
            textboxmingcheng = new Sunny.UI.UITextBox();
            label2 = new AntdUI.Label();
            textboxpaiming = new Sunny.UI.UITextBox();
            label11 = new AntdUI.Label();
            textboxid = new Sunny.UI.UITextBox();
            label3 = new AntdUI.Label();
            button1 = new AntdUI.Button();
            Groupshiye.SuspendLayout();
            uiGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Groupshiye
            // 
            Groupshiye.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Groupshiye.Controls.Add(label1);
            Groupshiye.Controls.Add(label6);
            Groupshiye.Controls.Add(buttonshiye);
            Groupshiye.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Groupshiye.Location = new Point(14, 5);
            Groupshiye.Margin = new Padding(5, 6, 5, 6);
            Groupshiye.MinimumSize = new Size(1, 1);
            Groupshiye.Name = "Groupshiye";
            Groupshiye.Padding = new Padding(0, 38, 0, 0);
            Groupshiye.Radius = 20;
            Groupshiye.RectColor = SystemColors.ActiveCaption;
            Groupshiye.Size = new Size(753, 92);
            Groupshiye.TabIndex = 1;
            Groupshiye.Text = "吐球双连点解断吐";
            Groupshiye.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(523, 58);
            label1.Name = "label1";
            label1.Size = new Size(213, 22);
            label1.TabIndex = 17;
            label1.Text = "注：解断功能需要另行购买";
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Green;
            label6.Location = new Point(155, 39);
            label6.Name = "label6";
            label6.Size = new Size(595, 41);
            label6.TabIndex = 16;
            label6.Text = "打开脚本,打开模拟器,点此开启按钮,输入解断卡密,登录解断后点击启动,提示成功即可打开幷进入游戏    务必按要求操作！！！";
            // 
            // buttonshiye
            // 
            buttonshiye.BackHover = Color.Aquamarine;
            buttonshiye.DefaultBack = Color.Azure;
            buttonshiye.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonshiye.JoinRight = true;
            buttonshiye.Location = new Point(14, 35);
            buttonshiye.Name = "buttonshiye";
            buttonshiye.Radius = 0;
            buttonshiye.Size = new Size(135, 47);
            buttonshiye.TabIndex = 15;
            buttonshiye.Text = "开启";
            buttonshiye.Click += buttonshiye_Click;
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uiGroupBox1.Controls.Add(label4);
            uiGroupBox1.Controls.Add(textboxmingcheng);
            uiGroupBox1.Controls.Add(label2);
            uiGroupBox1.Controls.Add(textboxpaiming);
            uiGroupBox1.Controls.Add(label11);
            uiGroupBox1.Controls.Add(textboxid);
            uiGroupBox1.Controls.Add(label3);
            uiGroupBox1.Controls.Add(button1);
            uiGroupBox1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox1.Location = new Point(14, 97);
            uiGroupBox1.Margin = new Padding(5, 6, 5, 6);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 38, 0, 0);
            uiGroupBox1.Radius = 20;
            uiGroupBox1.RectColor = SystemColors.ActiveCaption;
            uiGroupBox1.Size = new Size(753, 140);
            uiGroupBox1.TabIndex = 18;
            uiGroupBox1.Text = "ID查排名";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(470, 93);
            label4.Name = "label4";
            label4.Size = new Size(80, 23);
            label4.TabIndex = 24;
            label4.Text = "名称ID";
            // 
            // textboxmingcheng
            // 
            textboxmingcheng.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxmingcheng.Location = new Point(551, 89);
            textboxmingcheng.Margin = new Padding(4, 5, 4, 5);
            textboxmingcheng.MaxLength = 999;
            textboxmingcheng.MinimumSize = new Size(1, 16);
            textboxmingcheng.Name = "textboxmingcheng";
            textboxmingcheng.Padding = new Padding(5);
            textboxmingcheng.ReadOnly = true;
            textboxmingcheng.RectColor = Color.FromArgb(255, 255, 192);
            textboxmingcheng.ShowText = false;
            textboxmingcheng.Size = new Size(167, 30);
            textboxmingcheng.TabIndex = 23;
            textboxmingcheng.TextAlignment = ContentAlignment.MiddleCenter;
            textboxmingcheng.Watermark = "";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(226, 93);
            label2.Name = "label2";
            label2.Size = new Size(57, 23);
            label2.TabIndex = 22;
            label2.Text = "排名";
            // 
            // textboxpaiming
            // 
            textboxpaiming.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxpaiming.Location = new Point(288, 89);
            textboxpaiming.Margin = new Padding(4, 5, 4, 5);
            textboxpaiming.MaxLength = 999;
            textboxpaiming.MinimumSize = new Size(1, 16);
            textboxpaiming.Name = "textboxpaiming";
            textboxpaiming.Padding = new Padding(5);
            textboxpaiming.ReadOnly = true;
            textboxpaiming.RectColor = Color.FromArgb(255, 255, 192);
            textboxpaiming.ShowText = false;
            textboxpaiming.Size = new Size(167, 30);
            textboxpaiming.TabIndex = 21;
            textboxpaiming.TextAlignment = ContentAlignment.MiddleCenter;
            textboxpaiming.Watermark = "";
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(14, 42);
            label11.Name = "label11";
            label11.Size = new Size(37, 23);
            label11.TabIndex = 20;
            label11.Text = "ID";
            // 
            // textboxid
            // 
            textboxid.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxid.Location = new Point(52, 36);
            textboxid.Margin = new Padding(4, 5, 4, 5);
            textboxid.MaxLength = 999;
            textboxid.MinimumSize = new Size(1, 16);
            textboxid.Name = "textboxid";
            textboxid.Padding = new Padding(5);
            textboxid.RectColor = Color.FromArgb(255, 255, 192);
            textboxid.ShowText = false;
            textboxid.Size = new Size(158, 30);
            textboxid.TabIndex = 18;
            textboxid.TextAlignment = ContentAlignment.MiddleCenter;
            textboxid.Watermark = "";
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.Green;
            label3.Location = new Point(217, 36);
            label3.Name = "label3";
            label3.Size = new Size(229, 29);
            label3.TabIndex = 16;
            label3.Text = "输入游戏中数字ID即可查排名";
            // 
            // button1
            // 
            button1.BackHover = Color.Aquamarine;
            button1.DefaultBack = Color.Azure;
            button1.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.JoinRight = true;
            button1.Location = new Point(14, 71);
            button1.Name = "button1";
            button1.Radius = 0;
            button1.Size = new Size(196, 60);
            button1.TabIndex = 15;
            button1.Text = "查询";
            button1.Click += button1_Click;
            // 
            // qitagongneng
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(779, 815);
            Controls.Add(uiGroupBox1);
            Controls.Add(Groupshiye);
            FormBorderStyle = FormBorderStyle.None;
            Name = "qitagongneng";
            Text = "qitagongneng";
            Load += qitagongneng_Load;
            Groupshiye.ResumeLayout(false);
            uiGroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIGroupBox Groupshiye;
        private AntdUI.Button buttonshiye;
        private AntdUI.Label label6;
        private AntdUI.Label label1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private AntdUI.Label label3;
        private AntdUI.Button button1;
        public Sunny.UI.UITextBox textboxid;
        private AntdUI.Label label11;
        private AntdUI.Label label2;
        public Sunny.UI.UITextBox textboxpaiming;
        private AntdUI.Label label4;
        public Sunny.UI.UITextBox textboxmingcheng;
    }
}