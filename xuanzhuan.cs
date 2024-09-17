using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANYE_Balls
{
    public partial class xuanzhuan : Form
    {
        public xuanzhuan()
        {
            InitializeComponent();
        }

        private void xuanzhuan_Load(object sender, EventArgs e)
        {

            if (!Json.checkjson("xuanzhuanjian"))
            {
                comboboxxuanzhuan.SelectedItem = "A";
            }
            else
            {
                comboboxxuanzhuan.SelectedItem = Json.readjson("xuanzhuanjian");
            }
            if (!Json.checkjson("xzjcfd1"))
            {
                textboxxzjcfd1.Text = "90";
            }
            else
            {
                textboxxzjcfd1.Text = Json.readjson("xzjcfd1");
            }
            if (!Json.checkjson("xzjcfd2"))
            {
                textboxxzjcfd2.Text = "85";
            }
            else
            {
                textboxxzjcfd2.Text = Json.readjson("xzjcfd2");
            }
            if (!Json.checkjson("xzjcfd3"))
            {
                textboxxzjcfd3.Text = "75";
            }
            else
            {
                textboxxzjcfd3.Text = Json.readjson("xzjcfd3");
            }
            if (!Json.checkjson("xzjcfd4"))
            {
                textboxxzjcfd4.Text = "70";
            }
            else
            {
                textboxxzjcfd4.Text = Json.readjson("xzjcfd4");
            }
            if (!Json.checkjson("xzjd1"))
            {
                textboxxzjd1.Text = "20";
            }
            else
            {
                textboxxzjd1.Text = Json.readjson("xzjd1");
            }
            if (!Json.checkjson("xzjd2"))
            {
                textboxxzjd2.Text = "25";
            }
            else
            {
                textboxxzjd2.Text = Json.readjson("xzjd2");
            }
            if (!Json.checkjson("xzjd3"))
            {
                textboxxzjd3.Text = "25";
            }
            else
            {
                textboxxzjd3.Text = Json.readjson("xzjd3");
            }
            if (!Json.checkjson("xzjd4"))
            {
                textboxxzjd4.Text = "40";
            }
            else
            {
                textboxxzjd4.Text = Json.readjson("xzjd4");
            }
            if (!Json.checkjson("xzyc1"))
            {
                datagridviewxz.Rows.Add("鼠标左键按下", 20);
                datagridviewxz.Rows.Add("第一次拖动鼠标", 50);
                datagridviewxz.Rows.Add("分身", 10);
                datagridviewxz.Rows.Add("第二次拖动鼠标", 50);
                datagridviewxz.Rows.Add("分身", 10);
                datagridviewxz.Rows.Add("第三次拖动鼠标", 50);
                datagridviewxz.Rows.Add("分身", 10);
                datagridviewxz.Rows.Add("第四次拖动鼠标", 50);
                datagridviewxz.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewxz.Rows.Add("鼠标左键按下", Json.readjson("xzyc1"));
                datagridviewxz.Rows.Add("第一次拖动鼠标", Json.readjson("xzyc2"));
                datagridviewxz.Rows.Add("分身", Json.readjson("xzyc3"));
                datagridviewxz.Rows.Add("第二次拖动鼠标", Json.readjson("xzyc4"));
                datagridviewxz.Rows.Add("分身", Json.readjson("xzyc5"));
                datagridviewxz.Rows.Add("第三次拖动鼠标", Json.readjson("xzyc6"));
                datagridviewxz.Rows.Add("分身", Json.readjson("xzyc7"));
                datagridviewxz.Rows.Add("第四次拖动鼠标", Json.readjson("xzyc8"));
                datagridviewxz.Rows.Add("最后分身延迟", Json.readjson("xzyc9"));
            }
            zidongheqiu.xuanzhuanjian = MainForm.GetVirtualKeyCode(comboboxxuanzhuan.SelectedItem.ToString());
            try
            {
                zidongheqiu.xzjcfd1 = Convert.ToInt32(textboxxzjcfd1.Text);
                zidongheqiu.xzjcfd2 = Convert.ToInt32(textboxxzjcfd2.Text);
                zidongheqiu.xzjcfd3 = Convert.ToInt32(textboxxzjcfd3.Text);
                zidongheqiu.xzjcfd4 = Convert.ToInt32(textboxxzjcfd4.Text);
                zidongheqiu.xzjd1 = Convert.ToInt32(textboxxzjd1.Text);
                zidongheqiu.xzjd2 = Convert.ToInt32(textboxxzjd2.Text);
                zidongheqiu.xzjd3 = Convert.ToInt32(textboxxzjd3.Text);
                zidongheqiu.xzjd4 = Convert.ToInt32(textboxxzjd4.Text);
                zidongheqiu.xzyc1 = int.Parse(datagridviewxz.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.xzyc2 = int.Parse(datagridviewxz.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.xzyc3 = int.Parse(datagridviewxz.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.xzyc4 = int.Parse(datagridviewxz.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.xzyc5 = int.Parse(datagridviewxz.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.xzyc6 = int.Parse(datagridviewxz.Rows[5].Cells[1].Value.ToString());
                zidongheqiu.xzyc7 = int.Parse(datagridviewxz.Rows[6].Cells[1].Value.ToString());
                zidongheqiu.xzyc8 = int.Parse(datagridviewxz.Rows[7].Cells[1].Value.ToString());
                zidongheqiu.xzyc9 = int.Parse(datagridviewxz.Rows[8].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("xuanzhuan"))
            {
                if (Json.readjson("xuanzhuan") == "true")
                {
                    checkboxxuanzhuan.Checked = true;
                }
            }
        }

        private void comboboxxuanzhuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxxuanzhuan.SelectedItem != null)
            {
                zidongheqiu.xuanzhuanjian = MainForm.GetVirtualKeyCode(comboboxxuanzhuan.SelectedItem.ToString());
            }
            Json.writejson("xuanzhuanjian", comboboxxuanzhuan.SelectedItem.ToString());
        }

        private void checkboxxuanzhuan_CheckedChanged(object sender, bool value)
        {
            if (checkboxxuanzhuan.Checked)
            {
                Json.writejson("xuanzhuan", "true");
                zidongheqiu.xuanzhuanflag = true;
                zidongheqiu.xuanzhuanjian = MainForm.GetVirtualKeyCode(comboboxxuanzhuan.SelectedItem.ToString());
                try
                {
                    zidongheqiu.xzjcfd1 = Convert.ToInt32(textboxxzjcfd1.Text);
                    zidongheqiu.xzjcfd2 = Convert.ToInt32(textboxxzjcfd2.Text);
                    zidongheqiu.xzjcfd3 = Convert.ToInt32(textboxxzjcfd3.Text);
                    zidongheqiu.xzjcfd4 = Convert.ToInt32(textboxxzjcfd4.Text);
                    zidongheqiu.xzjd1 = Convert.ToInt32(textboxxzjd1.Text);
                    zidongheqiu.xzjd2 = Convert.ToInt32(textboxxzjd2.Text);
                    zidongheqiu.xzjd3 = Convert.ToInt32(textboxxzjd3.Text);
                    zidongheqiu.xzjd4 = Convert.ToInt32(textboxxzjd4.Text);
                    zidongheqiu.xzyc1 = int.Parse(datagridviewxz.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.xzyc2 = int.Parse(datagridviewxz.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.xzyc3 = int.Parse(datagridviewxz.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.xzyc4 = int.Parse(datagridviewxz.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.xzyc5 = int.Parse(datagridviewxz.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.xzyc6 = int.Parse(datagridviewxz.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.xzyc7 = int.Parse(datagridviewxz.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.xzyc8 = int.Parse(datagridviewxz.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.xzyc9 = int.Parse(datagridviewxz.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("xzyc1", zidongheqiu.xzyc1.ToString());
                Json.writejson("xzyc2", zidongheqiu.xzyc2.ToString());
                Json.writejson("xzyc3", zidongheqiu.xzyc3.ToString());
                Json.writejson("xzyc4", zidongheqiu.xzyc4.ToString());
                Json.writejson("xzyc5", zidongheqiu.xzyc5.ToString());
                Json.writejson("xzyc6", zidongheqiu.xzyc6.ToString());
                Json.writejson("xzyc7", zidongheqiu.xzyc7.ToString());
                Json.writejson("xzyc8", zidongheqiu.xzyc8.ToString());
                Json.writejson("xzyc9", zidongheqiu.xzyc9.ToString());
            }
            else
            {
                Json.writejson("xuanzhuan", "false");
                zidongheqiu.xuanzhuanflag = false;
            }
        }

        private void textboxxzjcfd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjcfd1.Text != null)
            {
                try
                {
                    zidongheqiu.xzjcfd1 = Convert.ToInt32(textboxxzjcfd1.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjcfd1 = 90;
                }
            }
            Json.writejson("xzjcfd1", textboxxzjcfd1.Text);
        }

        private void textboxxzjcfd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjcfd2.Text != null)
            {
                try
                {
                    zidongheqiu.xzjcfd2 = Convert.ToInt32(textboxxzjcfd2.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjcfd2 = 85;
                }
            }
            Json.writejson("xzjcfd2", textboxxzjcfd2.Text);
        }

        private void textboxxzjcfd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjcfd3.Text != null)
            {
                try
                {
                    zidongheqiu.xzjcfd3 = Convert.ToInt32(textboxxzjcfd3.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjcfd3 = 75;
                }
            }
            Json.writejson("xzjcfd3", textboxxzjcfd3.Text);
        }

        private void textboxxzjcfd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjcfd4.Text != null)
            {
                try
                {
                    zidongheqiu.xzjcfd4 = Convert.ToInt32(textboxxzjcfd4.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjcfd4 = 70;
                }
            }
            Json.writejson("xzjcfd4", textboxxzjcfd4.Text);
        }

        private void textboxxzjd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjd1.Text != null)
            {
                try
                {
                    zidongheqiu.xzjd1 = Convert.ToInt32(textboxxzjd1.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjd1 = 20;
                }
            }
            Json.writejson("xzjd1", textboxxzjd1.Text);
        }

        private void textboxxzjd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjd2.Text != null)
            {
                try
                {
                    zidongheqiu.xzjd2 = Convert.ToInt32(textboxxzjd2.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjd2 = 25;
                }
            }
            Json.writejson("xzjd2", textboxxzjd2.Text);
        }

        private void textboxxzjd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjd3.Text != null)
            {
                try
                {
                    zidongheqiu.xzjd3 = Convert.ToInt32(textboxxzjd3.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjd3 = 25;
                }
            }
            Json.writejson("xzjd3", textboxxzjd3.Text);
        }

        private void textboxxzjd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxxzjd4.Text != null)
            {
                try
                {
                    zidongheqiu.xzjd4 = Convert.ToInt32(textboxxzjd4.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.xzjd4 = 40;
                }
            }
            Json.writejson("xzjd4", textboxxzjd4.Text);
        }

        private void textboxxzjcfd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewxz_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewxz_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.xzyc1 = int.Parse(datagridviewxz.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.xzyc2 = int.Parse(datagridviewxz.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.xzyc3 = int.Parse(datagridviewxz.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.xzyc4 = int.Parse(datagridviewxz.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.xzyc5 = int.Parse(datagridviewxz.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.xzyc6 = int.Parse(datagridviewxz.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.xzyc7 = int.Parse(datagridviewxz.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.xzyc8 = int.Parse(datagridviewxz.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.xzyc9 = int.Parse(datagridviewxz.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("xzyc1", zidongheqiu.xzyc1.ToString());
                Json.writejson("xzyc2", zidongheqiu.xzyc2.ToString());
                Json.writejson("xzyc3", zidongheqiu.xzyc3.ToString());
                Json.writejson("xzyc4", zidongheqiu.xzyc4.ToString());
                Json.writejson("xzyc5", zidongheqiu.xzyc5.ToString());
                Json.writejson("xzyc6", zidongheqiu.xzyc6.ToString());
                Json.writejson("xzyc7", zidongheqiu.xzyc7.ToString());
                Json.writejson("xzyc8", zidongheqiu.xzyc8.ToString());
                Json.writejson("xzyc9", zidongheqiu.xzyc9.ToString());
            }
        }

        private void checkboxxztq_CheckedChanged(object sender, bool value)
        {
            if (checkboxxztq.Checked)
            {
                zidongheqiu.xuanzhuantqflag = true;
                Json.writejson("xuanzhuantqflag", "true");
            }
            else
            {
                zidongheqiu.xuanzhuantqflag = false;
                Json.writejson("xuanzhuantqflag", "false");
            }
        }

        private void buttonzfchcz_Click(object sender, EventArgs e)
        {

        }

        private void buttonxzcz_Click(object sender, EventArgs e)
        {
            textboxxzjcfd1.Text = "90";
            textboxxzjcfd2.Text = "85";
            textboxxzjcfd3.Text = "75";
            textboxxzjcfd4.Text = "70";
            textboxxzjd1.Text = "20";
            textboxxzjd2.Text = "25";
            textboxxzjd3.Text = "25";
            textboxxzjd4.Text = "40";
            MessageBox.Show("重置参数成功");
        }
    }
}
