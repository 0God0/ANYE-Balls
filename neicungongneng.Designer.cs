namespace ANYE_Balls
{
    partial class neicungongneng
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
            label14 = new AntdUI.Label();
            buttonshiye = new AntdUI.Button();
            textboxshiyebuchang = new Sunny.UI.UITextBox();
            label3 = new AntdUI.Label();
            textboxshiyemax = new Sunny.UI.UITextBox();
            label2 = new AntdUI.Label();
            textboxshiyemin = new Sunny.UI.UITextBox();
            checkboxgunlun = new AntdUI.Checkbox();
            textBoxshiyezhi = new Sunny.UI.UITextBox();
            label1 = new AntdUI.Label();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            label18 = new AntdUI.Label();
            label17 = new AntdUI.Label();
            label15 = new AntdUI.Label();
            label16 = new AntdUI.Label();
            buttonnichengdaxiao = new AntdUI.Button();
            buttonbiansu = new AntdUI.Button();
            buttonnianhe = new AntdUI.Button();
            buttontuqiu = new AntdUI.Button();
            label7 = new AntdUI.Label();
            textboxnichengdaxiao = new Sunny.UI.UITextBox();
            label5 = new AntdUI.Label();
            textboxbiansu = new Sunny.UI.UITextBox();
            label4 = new AntdUI.Label();
            checkboxtuqiu = new AntdUI.Checkbox();
            textboxnianhe = new Sunny.UI.UITextBox();
            label6 = new AntdUI.Label();
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            label24 = new AntdUI.Label();
            label23 = new AntdUI.Label();
            label22 = new AntdUI.Label();
            label21 = new AntdUI.Label();
            label20 = new AntdUI.Label();
            label19 = new AntdUI.Label();
            checkboxygyh = new AntdUI.Checkbox();
            label13 = new AntdUI.Label();
            buttonyaoganyouhua = new AntdUI.Button();
            checkboxygjx = new AntdUI.Checkbox();
            label12 = new AntdUI.Label();
            buttonyaoganjiexian = new AntdUI.Button();
            checkboxygyc = new AntdUI.Checkbox();
            label10 = new AntdUI.Label();
            buttonyaoganhuitan = new AntdUI.Button();
            buttonyaoganrongcha = new AntdUI.Button();
            buttonyaoganyanchi = new AntdUI.Button();
            buttonyaogan10000 = new AntdUI.Button();
            label8 = new AntdUI.Label();
            textboxyght = new Sunny.UI.UITextBox();
            label9 = new AntdUI.Label();
            textboxygrc = new Sunny.UI.UITextBox();
            checkboxyaogan10000 = new AntdUI.Checkbox();
            label11 = new AntdUI.Label();
            Groupshiye.SuspendLayout();
            uiGroupBox1.SuspendLayout();
            uiGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Groupshiye
            // 
            Groupshiye.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Groupshiye.Controls.Add(label14);
            Groupshiye.Controls.Add(buttonshiye);
            Groupshiye.Controls.Add(textboxshiyebuchang);
            Groupshiye.Controls.Add(label3);
            Groupshiye.Controls.Add(textboxshiyemax);
            Groupshiye.Controls.Add(label2);
            Groupshiye.Controls.Add(textboxshiyemin);
            Groupshiye.Controls.Add(checkboxgunlun);
            Groupshiye.Controls.Add(textBoxshiyezhi);
            Groupshiye.Controls.Add(label1);
            Groupshiye.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            Groupshiye.Location = new Point(14, 5);
            Groupshiye.Margin = new Padding(5, 6, 5, 6);
            Groupshiye.MinimumSize = new Size(1, 1);
            Groupshiye.Name = "Groupshiye";
            Groupshiye.Padding = new Padding(0, 38, 0, 0);
            Groupshiye.Radius = 20;
            Groupshiye.RectColor = SystemColors.ActiveCaption;
            Groupshiye.Size = new Size(753, 123);
            Groupshiye.TabIndex = 0;
            Groupshiye.Text = "视野功能";
            Groupshiye.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.Green;
            label14.Location = new Point(154, 35);
            label14.Name = "label14";
            label14.Size = new Size(574, 42);
            label14.TabIndex = 17;
            label14.Text = "视野功能：不开启滚轮则为固定当前视野值,开启滚轮可以鼠标滚轮动态调节   若需开启滚轮,请填写好范围与步长,视野最大值为10,超出10无效";
            // 
            // buttonshiye
            // 
            buttonshiye.BackHover = Color.Aquamarine;
            buttonshiye.DefaultBack = Color.Azure;
            buttonshiye.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonshiye.JoinRight = true;
            buttonshiye.Location = new Point(14, 35);
            buttonshiye.Name = "buttonshiye";
            buttonshiye.Size = new Size(135, 40);
            buttonshiye.TabIndex = 15;
            buttonshiye.Text = "单独搜索";
            buttonshiye.Click += buttonshiye_Click;
            // 
            // textboxshiyebuchang
            // 
            textboxshiyebuchang.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxshiyebuchang.Location = new Point(627, 80);
            textboxshiyebuchang.Margin = new Padding(4, 5, 4, 5);
            textboxshiyebuchang.MaxLength = 4;
            textboxshiyebuchang.MinimumSize = new Size(1, 16);
            textboxshiyebuchang.Name = "textboxshiyebuchang";
            textboxshiyebuchang.Padding = new Padding(5);
            textboxshiyebuchang.RectColor = Color.FromArgb(255, 255, 192);
            textboxshiyebuchang.ShowText = false;
            textboxshiyebuchang.Size = new Size(77, 30);
            textboxshiyebuchang.TabIndex = 14;
            textboxshiyebuchang.Text = "0.0";
            textboxshiyebuchang.TextAlignment = ContentAlignment.MiddleCenter;
            textboxshiyebuchang.Watermark = "";
            textboxshiyebuchang.TextChanged += textboxshiyebuchang_TextChanged;
            textboxshiyebuchang.KeyPress += textboxshiyebuchang_KeyPress;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(577, 83);
            label3.Name = "label3";
            label3.Size = new Size(55, 23);
            label3.TabIndex = 14;
            label3.Text = "步长";
            // 
            // textboxshiyemax
            // 
            textboxshiyemax.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxshiyemax.Location = new Point(467, 80);
            textboxshiyemax.Margin = new Padding(4, 5, 4, 5);
            textboxshiyemax.MaxLength = 4;
            textboxshiyemax.MinimumSize = new Size(1, 16);
            textboxshiyemax.Name = "textboxshiyemax";
            textboxshiyemax.Padding = new Padding(5);
            textboxshiyemax.RectColor = Color.FromArgb(255, 255, 192);
            textboxshiyemax.ShowText = false;
            textboxshiyemax.Size = new Size(77, 30);
            textboxshiyemax.TabIndex = 13;
            textboxshiyemax.Text = "0.0";
            textboxshiyemax.TextAlignment = ContentAlignment.MiddleCenter;
            textboxshiyemax.Watermark = "";
            textboxshiyemax.TextChanged += textboxshiyemax_TextChanged;
            textboxshiyemax.KeyPress += textboxshiyemax_KeyPress;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(437, 83);
            label2.Name = "label2";
            label2.Size = new Size(23, 23);
            label2.TabIndex = 13;
            label2.Text = "~";
            // 
            // textboxshiyemin
            // 
            textboxshiyemin.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxshiyemin.Location = new Point(353, 80);
            textboxshiyemin.Margin = new Padding(4, 5, 4, 5);
            textboxshiyemin.MaxLength = 4;
            textboxshiyemin.MinimumSize = new Size(1, 16);
            textboxshiyemin.Name = "textboxshiyemin";
            textboxshiyemin.Padding = new Padding(5);
            textboxshiyemin.RectColor = Color.FromArgb(255, 255, 192);
            textboxshiyemin.ShowText = false;
            textboxshiyemin.Size = new Size(77, 30);
            textboxshiyemin.TabIndex = 12;
            textboxshiyemin.Text = "0.0";
            textboxshiyemin.TextAlignment = ContentAlignment.MiddleCenter;
            textboxshiyemin.Watermark = "";
            textboxshiyemin.TextChanged += textboxshiyemin_TextChanged;
            textboxshiyemin.KeyPress += textboxshiyemin_KeyPress;
            // 
            // checkboxgunlun
            // 
            checkboxgunlun.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxgunlun.Location = new Point(223, 83);
            checkboxgunlun.Name = "checkboxgunlun";
            checkboxgunlun.Size = new Size(135, 23);
            checkboxgunlun.TabIndex = 12;
            checkboxgunlun.Text = "滚轮调整";
            checkboxgunlun.CheckedChanged += checkboxgunlun_CheckedChanged;
            // 
            // textBoxshiyezhi
            // 
            textBoxshiyezhi.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxshiyezhi.Location = new Point(128, 80);
            textBoxshiyezhi.Margin = new Padding(4, 5, 4, 5);
            textBoxshiyezhi.MaxLength = 4;
            textBoxshiyezhi.MinimumSize = new Size(1, 16);
            textBoxshiyezhi.Name = "textBoxshiyezhi";
            textBoxshiyezhi.Padding = new Padding(5);
            textBoxshiyezhi.RectColor = Color.FromArgb(255, 255, 192);
            textBoxshiyezhi.ShowText = false;
            textBoxshiyezhi.Size = new Size(77, 30);
            textBoxshiyezhi.TabIndex = 11;
            textBoxshiyezhi.Text = "0.0";
            textBoxshiyezhi.TextAlignment = ContentAlignment.MiddleCenter;
            textBoxshiyezhi.Watermark = "";
            textBoxshiyezhi.TextChanged += textBoxshiyezhi_TextChanged;
            textBoxshiyezhi.KeyPress += textBoxshiyezhi_KeyPress;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 83);
            label1.Name = "label1";
            label1.Size = new Size(116, 23);
            label1.TabIndex = 0;
            label1.Text = "当前视野值";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(label18);
            uiGroupBox1.Controls.Add(label17);
            uiGroupBox1.Controls.Add(label15);
            uiGroupBox1.Controls.Add(label16);
            uiGroupBox1.Controls.Add(buttonnichengdaxiao);
            uiGroupBox1.Controls.Add(buttonbiansu);
            uiGroupBox1.Controls.Add(buttonnianhe);
            uiGroupBox1.Controls.Add(buttontuqiu);
            uiGroupBox1.Controls.Add(label7);
            uiGroupBox1.Controls.Add(textboxnichengdaxiao);
            uiGroupBox1.Controls.Add(label5);
            uiGroupBox1.Controls.Add(textboxbiansu);
            uiGroupBox1.Controls.Add(label4);
            uiGroupBox1.Controls.Add(checkboxtuqiu);
            uiGroupBox1.Controls.Add(textboxnianhe);
            uiGroupBox1.Controls.Add(label6);
            uiGroupBox1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox1.Location = new Point(14, 128);
            uiGroupBox1.Margin = new Padding(5, 6, 5, 6);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 38, 0, 0);
            uiGroupBox1.Radius = 20;
            uiGroupBox1.RectColor = SystemColors.ActiveCaption;
            uiGroupBox1.Size = new Size(753, 190);
            uiGroupBox1.TabIndex = 15;
            uiGroupBox1.Text = "基本内存";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            label18.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label18.ForeColor = Color.Green;
            label18.Location = new Point(337, 144);
            label18.Name = "label18";
            label18.Size = new Size(411, 29);
            label18.TabIndex = 23;
            label18.Text = "修改游戏中昵称大小,原始值为1.875,改0则所有昵称消失";
            // 
            // label17
            // 
            label17.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.Green;
            label17.Location = new Point(337, 109);
            label17.Name = "label17";
            label17.Size = new Size(295, 29);
            label17.TabIndex = 22;
            label17.Text = "适合用于开宝箱时使用，原始值为1.0";
            // 
            // label15
            // 
            label15.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label15.ForeColor = Color.Green;
            label15.Location = new Point(397, 74);
            label15.Name = "label15";
            label15.Size = new Size(295, 29);
            label15.TabIndex = 21;
            label15.Text = "合球动画,初始值为0.588,越小动画越快";
            // 
            // label16
            // 
            label16.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.Green;
            label16.Location = new Point(353, 38);
            label16.Name = "label16";
            label16.Size = new Size(388, 29);
            label16.TabIndex = 19;
            label16.Text = "开启设置中长按连点吐球,模拟器连击调7~12即可";
            // 
            // buttonnichengdaxiao
            // 
            buttonnichengdaxiao.BackHover = Color.Aquamarine;
            buttonnichengdaxiao.DefaultBack = Color.Azure;
            buttonnichengdaxiao.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonnichengdaxiao.Location = new Point(14, 137);
            buttonnichengdaxiao.Name = "buttonnichengdaxiao";
            buttonnichengdaxiao.Size = new Size(135, 40);
            buttonnichengdaxiao.TabIndex = 20;
            buttonnichengdaxiao.Text = "单独搜索";
            buttonnichengdaxiao.Click += buttonnichengdaxiao_Click;
            // 
            // buttonbiansu
            // 
            buttonbiansu.BackHover = Color.Aquamarine;
            buttonbiansu.DefaultBack = Color.Azure;
            buttonbiansu.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonbiansu.Location = new Point(14, 102);
            buttonbiansu.Name = "buttonbiansu";
            buttonbiansu.Size = new Size(135, 40);
            buttonbiansu.TabIndex = 19;
            buttonbiansu.Text = "单独搜索";
            buttonbiansu.Click += buttonbiansu_Click;
            // 
            // buttonnianhe
            // 
            buttonnianhe.BackHover = Color.Aquamarine;
            buttonnianhe.DefaultBack = Color.Azure;
            buttonnianhe.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonnianhe.Location = new Point(14, 66);
            buttonnianhe.Name = "buttonnianhe";
            buttonnianhe.Size = new Size(135, 40);
            buttonnianhe.TabIndex = 18;
            buttonnianhe.Text = "单独搜索";
            buttonnianhe.Click += buttonnianhe_Click;
            // 
            // buttontuqiu
            // 
            buttontuqiu.BackHover = Color.Aquamarine;
            buttontuqiu.DefaultBack = Color.Azure;
            buttontuqiu.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttontuqiu.Location = new Point(14, 30);
            buttontuqiu.Name = "buttontuqiu";
            buttontuqiu.Size = new Size(135, 40);
            buttontuqiu.TabIndex = 16;
            buttontuqiu.Text = "单独搜索";
            buttontuqiu.Click += buttontuqiu_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(153, 148);
            label7.Name = "label7";
            label7.Size = new Size(95, 23);
            label7.TabIndex = 17;
            label7.Text = "昵称大小";
            // 
            // textboxnichengdaxiao
            // 
            textboxnichengdaxiao.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxnichengdaxiao.Location = new Point(255, 143);
            textboxnichengdaxiao.Margin = new Padding(4, 5, 4, 5);
            textboxnichengdaxiao.MaxLength = 5;
            textboxnichengdaxiao.MinimumSize = new Size(1, 16);
            textboxnichengdaxiao.Name = "textboxnichengdaxiao";
            textboxnichengdaxiao.Padding = new Padding(5);
            textboxnichengdaxiao.RectColor = Color.FromArgb(255, 255, 192);
            textboxnichengdaxiao.ShowText = false;
            textboxnichengdaxiao.Size = new Size(77, 30);
            textboxnichengdaxiao.TabIndex = 16;
            textboxnichengdaxiao.Text = "0.000";
            textboxnichengdaxiao.TextAlignment = ContentAlignment.MiddleCenter;
            textboxnichengdaxiao.Watermark = "";
            textboxnichengdaxiao.TextChanged += textboxnichengdaxiao_TextChanged;
            textboxnichengdaxiao.KeyPress += textboxnichengdaxiao_KeyPress;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(153, 112);
            label5.Name = "label5";
            label5.Size = new Size(95, 23);
            label5.TabIndex = 15;
            label5.Text = "全局变速";
            // 
            // textboxbiansu
            // 
            textboxbiansu.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxbiansu.Location = new Point(255, 107);
            textboxbiansu.Margin = new Padding(4, 5, 4, 5);
            textboxbiansu.MaxLength = 3;
            textboxbiansu.MinimumSize = new Size(1, 16);
            textboxbiansu.Name = "textboxbiansu";
            textboxbiansu.Padding = new Padding(5);
            textboxbiansu.RectColor = Color.FromArgb(255, 255, 192);
            textboxbiansu.ShowText = false;
            textboxbiansu.Size = new Size(77, 30);
            textboxbiansu.TabIndex = 14;
            textboxbiansu.Text = "0.0";
            textboxbiansu.TextAlignment = ContentAlignment.MiddleCenter;
            textboxbiansu.Watermark = "";
            textboxbiansu.TextChanged += textboxbiansu_TextChanged;
            textboxbiansu.KeyPress += textboxbiansu_KeyPress;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(153, 76);
            label4.Name = "label4";
            label4.Size = new Size(153, 23);
            label4.TabIndex = 13;
            label4.Text = "粘合(合球动画)";
            // 
            // checkboxtuqiu
            // 
            checkboxtuqiu.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxtuqiu.Location = new Point(266, 40);
            checkboxtuqiu.Name = "checkboxtuqiu";
            checkboxtuqiu.Size = new Size(135, 23);
            checkboxtuqiu.TabIndex = 12;
            checkboxtuqiu.Text = "开启";
            // 
            // textboxnianhe
            // 
            textboxnianhe.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxnianhe.Location = new Point(313, 73);
            textboxnianhe.Margin = new Padding(4, 5, 4, 5);
            textboxnianhe.MaxLength = 5;
            textboxnianhe.MinimumSize = new Size(1, 16);
            textboxnianhe.Name = "textboxnianhe";
            textboxnianhe.Padding = new Padding(5);
            textboxnianhe.RectColor = Color.FromArgb(255, 255, 192);
            textboxnianhe.ShowText = false;
            textboxnianhe.Size = new Size(77, 30);
            textboxnianhe.TabIndex = 11;
            textboxnianhe.Text = "0.000";
            textboxnianhe.TextAlignment = ContentAlignment.MiddleCenter;
            textboxnianhe.Watermark = "";
            textboxnianhe.TextChanged += textboxnianhe_TextChanged;
            textboxnianhe.KeyPress += textboxnianhe_KeyPress;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(153, 40);
            label6.Name = "label6";
            label6.Size = new Size(116, 23);
            label6.TabIndex = 0;
            label6.Text = "吐球双连点";
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(label24);
            uiGroupBox2.Controls.Add(label23);
            uiGroupBox2.Controls.Add(label22);
            uiGroupBox2.Controls.Add(label21);
            uiGroupBox2.Controls.Add(label20);
            uiGroupBox2.Controls.Add(label19);
            uiGroupBox2.Controls.Add(checkboxygyh);
            uiGroupBox2.Controls.Add(label13);
            uiGroupBox2.Controls.Add(buttonyaoganyouhua);
            uiGroupBox2.Controls.Add(checkboxygjx);
            uiGroupBox2.Controls.Add(label12);
            uiGroupBox2.Controls.Add(buttonyaoganjiexian);
            uiGroupBox2.Controls.Add(checkboxygyc);
            uiGroupBox2.Controls.Add(label10);
            uiGroupBox2.Controls.Add(buttonyaoganhuitan);
            uiGroupBox2.Controls.Add(buttonyaoganrongcha);
            uiGroupBox2.Controls.Add(buttonyaoganyanchi);
            uiGroupBox2.Controls.Add(buttonyaogan10000);
            uiGroupBox2.Controls.Add(label8);
            uiGroupBox2.Controls.Add(textboxyght);
            uiGroupBox2.Controls.Add(label9);
            uiGroupBox2.Controls.Add(textboxygrc);
            uiGroupBox2.Controls.Add(checkboxyaogan10000);
            uiGroupBox2.Controls.Add(label11);
            uiGroupBox2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox2.Location = new Point(14, 318);
            uiGroupBox2.Margin = new Padding(5, 6, 5, 6);
            uiGroupBox2.MinimumSize = new Size(1, 1);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new Padding(0, 38, 0, 0);
            uiGroupBox2.Radius = 20;
            uiGroupBox2.RectColor = SystemColors.ActiveCaption;
            uiGroupBox2.Size = new Size(753, 260);
            uiGroupBox2.TabIndex = 21;
            uiGroupBox2.Text = "遥杆类";
            uiGroupBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiGroupBox2.Click += uiGroupBox2_Click;
            // 
            // label24
            // 
            label24.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label24.ForeColor = Color.Green;
            label24.Location = new Point(339, 215);
            label24.Name = "label24";
            label24.Size = new Size(409, 36);
            label24.TabIndex = 34;
            label24.Text = "原始值为40,由于游戏更新后,修改后需要重启游戏才可生效";
            // 
            // label23
            // 
            label23.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label23.ForeColor = Color.Green;
            label23.Location = new Point(339, 178);
            label23.Name = "label23";
            label23.Size = new Size(409, 36);
            label23.TabIndex = 33;
            label23.Text = "原始值为1,遥杆从中心突然偏离一定距离移动,由于游戏更新后,修改后需要重启游戏才可生效";
            // 
            // label22
            // 
            label22.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label22.ForeColor = Color.Green;
            label22.Location = new Point(380, 145);
            label22.Name = "label22";
            label22.Size = new Size(370, 29);
            label22.TabIndex = 32;
            label22.Text = "遥杆解限速,分身加速";
            // 
            // label21
            // 
            label21.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label21.ForeColor = Color.Green;
            label21.Location = new Point(371, 110);
            label21.Name = "label21";
            label21.Size = new Size(370, 29);
            label21.TabIndex = 31;
            label21.Text = "优化遥杆,若觉得不舒服可关闭此项";
            // 
            // label20
            // 
            label20.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label20.ForeColor = Color.Green;
            label20.Location = new Point(353, 72);
            label20.Name = "label20";
            label20.Size = new Size(395, 40);
            label20.TabIndex = 30;
            label20.Text = "解除遥杆延迟,但会导致精彩时刻加速,若需要观看精彩时刻,先将此功能关闭即可";
            // 
            // label19
            // 
            label19.Font = new Font("Microsoft YaHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label19.ForeColor = Color.Green;
            label19.Location = new Point(370, 34);
            label19.Name = "label19";
            label19.Size = new Size(371, 36);
            label19.TabIndex = 29;
            label19.Text = "遥杆延迟锁10000%,不一定每次都能显示10000%,若拖动遥杆延迟重进设置还是100%即为成功";
            // 
            // checkboxygyh
            // 
            checkboxygyh.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxygyh.Location = new Point(287, 112);
            checkboxygyh.Name = "checkboxygyh";
            checkboxygyh.Size = new Size(135, 23);
            checkboxygyh.TabIndex = 28;
            checkboxygyh.Text = "开启";
            checkboxygyh.CheckedChanged += checkboxygyh_CheckedChanged;
            // 
            // label13
            // 
            label13.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(153, 112);
            label13.Name = "label13";
            label13.Size = new Size(153, 23);
            label13.TabIndex = 27;
            label13.Text = "遥杆优化加速";
            // 
            // buttonyaoganyouhua
            // 
            buttonyaoganyouhua.BackHover = Color.Aquamarine;
            buttonyaoganyouhua.DefaultBack = Color.Azure;
            buttonyaoganyouhua.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaoganyouhua.Location = new Point(14, 102);
            buttonyaoganyouhua.Name = "buttonyaoganyouhua";
            buttonyaoganyouhua.Size = new Size(135, 40);
            buttonyaoganyouhua.TabIndex = 26;
            buttonyaoganyouhua.Text = "单独搜索";
            buttonyaoganyouhua.Click += buttonyaoganyouhua_Click;
            // 
            // checkboxygjx
            // 
            checkboxygjx.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxygjx.Location = new Point(296, 148);
            checkboxygjx.Name = "checkboxygjx";
            checkboxygjx.Size = new Size(135, 23);
            checkboxygjx.TabIndex = 25;
            checkboxygjx.Text = "开启";
            checkboxygjx.CheckedChanged += checkboxygjx_CheckedChanged;
            // 
            // label12
            // 
            label12.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(153, 148);
            label12.Name = "label12";
            label12.Size = new Size(153, 23);
            label12.TabIndex = 24;
            label12.Text = "遥杆/分身解限";
            // 
            // buttonyaoganjiexian
            // 
            buttonyaoganjiexian.BackHover = Color.Aquamarine;
            buttonyaoganjiexian.DefaultBack = Color.Azure;
            buttonyaoganjiexian.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaoganjiexian.Location = new Point(14, 138);
            buttonyaoganjiexian.Name = "buttonyaoganjiexian";
            buttonyaoganjiexian.Size = new Size(135, 40);
            buttonyaoganjiexian.TabIndex = 23;
            buttonyaoganjiexian.Text = "单独搜索";
            buttonyaoganjiexian.Click += buttonyaoganjiexian_Click;
            // 
            // checkboxygyc
            // 
            checkboxygyc.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxygyc.Location = new Point(266, 76);
            checkboxygyc.Name = "checkboxygyc";
            checkboxygyc.Size = new Size(135, 23);
            checkboxygyc.TabIndex = 22;
            checkboxygyc.Text = "开启";
            checkboxygyc.CheckedChanged += checkboxygyc_CheckedChanged;
            // 
            // label10
            // 
            label10.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(153, 76);
            label10.Name = "label10";
            label10.Size = new Size(116, 23);
            label10.TabIndex = 21;
            label10.Text = "解遥杆延迟";
            // 
            // buttonyaoganhuitan
            // 
            buttonyaoganhuitan.BackHover = Color.Aquamarine;
            buttonyaoganhuitan.DefaultBack = Color.Azure;
            buttonyaoganhuitan.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaoganhuitan.Location = new Point(14, 209);
            buttonyaoganhuitan.Name = "buttonyaoganhuitan";
            buttonyaoganhuitan.Size = new Size(135, 40);
            buttonyaoganhuitan.TabIndex = 20;
            buttonyaoganhuitan.Text = "单独搜索";
            buttonyaoganhuitan.Click += buttonyaoganhuitan_Click;
            // 
            // buttonyaoganrongcha
            // 
            buttonyaoganrongcha.BackHover = Color.Aquamarine;
            buttonyaoganrongcha.DefaultBack = Color.Azure;
            buttonyaoganrongcha.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaoganrongcha.Location = new Point(14, 174);
            buttonyaoganrongcha.Name = "buttonyaoganrongcha";
            buttonyaoganrongcha.Size = new Size(135, 40);
            buttonyaoganrongcha.TabIndex = 19;
            buttonyaoganrongcha.Text = "单独搜索";
            buttonyaoganrongcha.Click += buttonyaoganrongcha_Click;
            // 
            // buttonyaoganyanchi
            // 
            buttonyaoganyanchi.BackHover = Color.Aquamarine;
            buttonyaoganyanchi.DefaultBack = Color.Azure;
            buttonyaoganyanchi.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaoganyanchi.Location = new Point(14, 66);
            buttonyaoganyanchi.Name = "buttonyaoganyanchi";
            buttonyaoganyanchi.Size = new Size(135, 40);
            buttonyaoganyanchi.TabIndex = 18;
            buttonyaoganyanchi.Text = "单独搜索";
            buttonyaoganyanchi.Click += buttonyaoganyanchi_Click;
            // 
            // buttonyaogan10000
            // 
            buttonyaogan10000.BackHover = Color.Aquamarine;
            buttonyaogan10000.DefaultBack = Color.Azure;
            buttonyaogan10000.Font = new Font("微軟正黑體", 15F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaogan10000.Location = new Point(14, 30);
            buttonyaogan10000.Name = "buttonyaogan10000";
            buttonyaogan10000.Size = new Size(135, 40);
            buttonyaogan10000.TabIndex = 16;
            buttonyaogan10000.Text = "单独搜索";
            buttonyaogan10000.Click += buttonyaogan10000_Click;
            // 
            // label8
            // 
            label8.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(153, 220);
            label8.Name = "label8";
            label8.Size = new Size(95, 23);
            label8.TabIndex = 17;
            label8.Text = "遥杆回弹";
            // 
            // textboxyght
            // 
            textboxyght.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxyght.Location = new Point(255, 215);
            textboxyght.Margin = new Padding(4, 5, 4, 5);
            textboxyght.MaxLength = 2;
            textboxyght.MinimumSize = new Size(1, 16);
            textboxyght.Name = "textboxyght";
            textboxyght.Padding = new Padding(5);
            textboxyght.RectColor = Color.FromArgb(255, 255, 192);
            textboxyght.ShowText = false;
            textboxyght.Size = new Size(77, 30);
            textboxyght.TabIndex = 16;
            textboxyght.Text = "0";
            textboxyght.TextAlignment = ContentAlignment.MiddleCenter;
            textboxyght.Watermark = "";
            textboxyght.TextChanged += textboxyght_TextChanged;
            textboxyght.KeyPress += uiTextBox2_KeyPress;
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(153, 184);
            label9.Name = "label9";
            label9.Size = new Size(95, 23);
            label9.TabIndex = 15;
            label9.Text = "遥杆容差";
            // 
            // textboxygrc
            // 
            textboxygrc.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxygrc.Location = new Point(255, 179);
            textboxygrc.Margin = new Padding(4, 5, 4, 5);
            textboxygrc.MaxLength = 2;
            textboxygrc.MinimumSize = new Size(1, 16);
            textboxygrc.Name = "textboxygrc";
            textboxygrc.Padding = new Padding(5);
            textboxygrc.RectColor = Color.FromArgb(255, 255, 192);
            textboxygrc.ShowText = false;
            textboxygrc.Size = new Size(77, 30);
            textboxygrc.TabIndex = 14;
            textboxygrc.Text = "0";
            textboxygrc.TextAlignment = ContentAlignment.MiddleCenter;
            textboxygrc.Watermark = "";
            textboxygrc.TextChanged += textboxygrc_TextChanged;
            textboxygrc.KeyPress += uiTextBox2_KeyPress;
            // 
            // checkboxyaogan10000
            // 
            checkboxyaogan10000.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxyaogan10000.Location = new Point(283, 40);
            checkboxyaogan10000.Name = "checkboxyaogan10000";
            checkboxyaogan10000.Size = new Size(135, 23);
            checkboxyaogan10000.TabIndex = 12;
            checkboxyaogan10000.Text = "开启";
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(153, 40);
            label11.Name = "label11";
            label11.Size = new Size(134, 23);
            label11.TabIndex = 0;
            label11.Text = "遥杆10000%";
            // 
            // neicungongneng
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(779, 815);
            Controls.Add(uiGroupBox2);
            Controls.Add(uiGroupBox1);
            Controls.Add(Groupshiye);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "neicungongneng";
            Text = "neicungongneng";
            Load += neicungongneng_Load;
            Groupshiye.ResumeLayout(false);
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        public Sunny.UI.UITextBox textBoxshiyezhi;
        public Sunny.UI.UITextBox textboxshiyemax;
        public Sunny.UI.UITextBox textboxshiyemin;
        public Sunny.UI.UITextBox textboxshiyebuchang;
        public Sunny.UI.UITextBox textboxnianhe;
        public Sunny.UI.UITextBox textboxnichengdaxiao;
        public Sunny.UI.UITextBox textboxbiansu;
        public Sunny.UI.UITextBox textboxyght;
        public Sunny.UI.UITextBox textboxygrc;
        public AntdUI.Checkbox checkboxgunlun;
        public AntdUI.Checkbox checkboxtuqiu;
        public AntdUI.Checkbox checkboxyaogan10000;
        public AntdUI.Checkbox checkboxygjx;
        public AntdUI.Checkbox checkboxygyc;
        public AntdUI.Checkbox checkboxygyh;
        public Sunny.UI.UIGroupBox Groupshiye;
        public AntdUI.Label label1;
        public AntdUI.Label label3;
        public AntdUI.Label label2;
        public Sunny.UI.UIGroupBox uiGroupBox1;
        public AntdUI.Label label6;
        public AntdUI.Label label4;
        public AntdUI.Button buttonshiye;
        public AntdUI.Label label7;
        public AntdUI.Label label5;
        public AntdUI.Button buttontuqiu;
        public AntdUI.Button buttonnichengdaxiao;
        public AntdUI.Button buttonbiansu;
        public AntdUI.Button buttonnianhe;
        public Sunny.UI.UIGroupBox uiGroupBox2;
        public AntdUI.Button buttonyaoganhuitan;
        public AntdUI.Button buttonyaoganrongcha;
        public AntdUI.Button buttonyaoganyanchi;
        public AntdUI.Button buttonyaogan10000;
        public AntdUI.Label label8;
        public AntdUI.Label label9;
        public AntdUI.Label label11;
        public AntdUI.Label label12;
        public AntdUI.Button buttonyaoganjiexian;
        public AntdUI.Label label10;
        public AntdUI.Label label13;
        public AntdUI.Button buttonyaoganyouhua;
        public AntdUI.Label label14;
        public AntdUI.Label label17;
        public AntdUI.Label label15;
        public AntdUI.Label label16;
        public AntdUI.Label label18;
        public AntdUI.Label label19;
        public AntdUI.Label label23;
        public AntdUI.Label label22;
        public AntdUI.Label label21;
        public AntdUI.Label label20;
        public AntdUI.Label label24;
    }
}