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
    public partial class ncxuanzhuan : Form
    {
        public ncxuanzhuan()
        {
            InitializeComponent();
        }

        private void ncxuanzhuan_Load(object sender, EventArgs e)
        {

            if (!Json.checkjson("ncxuanzhuanjian"))
            {
                comboboxncxuanzhuan.SelectedItem = "A";
            }
            else
            {
                comboboxncxuanzhuan.SelectedItem = Json.readjson("ncxuanzhuanjian");
            }
            if (!Json.checkjson("ncxzjcfd1"))
            {
                textboxncxzjcfd1.Text = "90";
            }
            else
            {
                textboxncxzjcfd1.Text = Json.readjson("ncxzjcfd1");
            }
            if (!Json.checkjson("ncxzjcfd2"))
            {
                textboxncxzjcfd2.Text = "85";
            }
            else
            {
                textboxncxzjcfd2.Text = Json.readjson("ncxzjcfd2");
            }
            if (!Json.checkjson("ncxzjcfd3"))
            {
                textboxncxzjcfd3.Text = "75";
            }
            else
            {
                textboxncxzjcfd3.Text = Json.readjson("ncxzjcfd3");
            }
            if (!Json.checkjson("ncxzjcfd4"))
            {
                textboxncxzjcfd4.Text = "70";
            }
            else
            {
                textboxncxzjcfd4.Text = Json.readjson("ncxzjcfd4");
            }
            if (!Json.checkjson("ncxzjd1"))
            {
                textboxncxzjd1.Text = "20";
            }
            else
            {
                textboxncxzjd1.Text = Json.readjson("ncxzjd1");
            }
            if (!Json.checkjson("ncxzjd2"))
            {
                textboxncxzjd2.Text = "25";
            }
            else
            {
                textboxncxzjd2.Text = Json.readjson("ncxzjd2");
            }
            if (!Json.checkjson("ncxzjd3"))
            {
                textboxncxzjd3.Text = "25";
            }
            else
            {
                textboxncxzjd3.Text = Json.readjson("ncxzjd3");
            }
            if (!Json.checkjson("ncxzjd4"))
            {
                textboxncxzjd4.Text = "40";
            }
            else
            {
                textboxncxzjd4.Text = Json.readjson("ncxzjd4");
            }
            if (!Json.checkjson("ncxzyc1"))
            {
                datagridviewncxz.Rows.Add("第一次拖动鼠标", 50);
                datagridviewncxz.Rows.Add("分身", 10);
                datagridviewncxz.Rows.Add("第二次拖动鼠标", 50);
                datagridviewncxz.Rows.Add("分身", 10);
                datagridviewncxz.Rows.Add("第三次拖动鼠标", 50);
                datagridviewncxz.Rows.Add("分身", 10);
                datagridviewncxz.Rows.Add("第四次拖动鼠标", 50);
                datagridviewncxz.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewncxz.Rows.Add("第一次拖动鼠标", Json.readjson("ncxzyc1"));
                datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc2"));
                datagridviewncxz.Rows.Add("第二次拖动鼠标", Json.readjson("ncxzyc3"));
                datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc4"));
                datagridviewncxz.Rows.Add("第三次拖动鼠标", Json.readjson("ncxzyc5"));
                datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc6"));
                datagridviewncxz.Rows.Add("第四次拖动鼠标", Json.readjson("ncxzyc7"));
                datagridviewncxz.Rows.Add("最后分身延迟", Json.readjson("ncxzyc8"));
            }
            neicunheqiu.ncxuanzhuanjian = MainForm.GetVirtualKeyCode(comboboxncxuanzhuan.SelectedItem.ToString());
            try
            {
                neicunheqiu.ncxzjcfd1 = Convert.ToInt32(textboxncxzjcfd1.Text);
                neicunheqiu.ncxzjcfd2 = Convert.ToInt32(textboxncxzjcfd2.Text);
                neicunheqiu.ncxzjcfd3 = Convert.ToInt32(textboxncxzjcfd3.Text);
                neicunheqiu.ncxzjcfd4 = Convert.ToInt32(textboxncxzjcfd4.Text);
                neicunheqiu.ncxzjd1 = Convert.ToInt32(textboxncxzjd1.Text);
                neicunheqiu.ncxzjd2 = Convert.ToInt32(textboxncxzjd2.Text);
                neicunheqiu.ncxzjd3 = Convert.ToInt32(textboxncxzjd3.Text);
                neicunheqiu.ncxzjd4 = Convert.ToInt32(textboxncxzjd4.Text);
                neicunheqiu.ncxzyc1 = int.Parse(datagridviewncxz.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc2 = int.Parse(datagridviewncxz.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc3 = int.Parse(datagridviewncxz.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc4 = int.Parse(datagridviewncxz.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc5 = int.Parse(datagridviewncxz.Rows[4].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc6 = int.Parse(datagridviewncxz.Rows[5].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc7 = int.Parse(datagridviewncxz.Rows[6].Cells[1].Value.ToString());
                neicunheqiu.ncxzyc8 = int.Parse(datagridviewncxz.Rows[7].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("ncxuanzhuan"))
            {
                if (Json.readjson("ncxuanzhuan") == "true")
                {
                    checkboxncxuanzhuan.Checked = true;
                }
            }
        }

        private void comboboxncxuanzhuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxncxuanzhuan.SelectedItem != null)
            {
                neicunheqiu.ncxuanzhuanjian = MainForm.GetVirtualKeyCode(comboboxncxuanzhuan.SelectedItem.ToString());
            }
            Json.writejson("ncxuanzhuanjian", comboboxncxuanzhuan.SelectedItem.ToString());
        }

        private void checkboxncxuanzhuan_CheckedChanged(object sender, bool value)
        {
            if (checkboxncxuanzhuan.Checked)
            {
                Json.writejson("ncxuanzhuan", "true");
                neicunheqiu.ncxuanzhuanflag = true;
                neicunheqiu.ncxuanzhuanjian = MainForm.GetVirtualKeyCode(comboboxncxuanzhuan.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncxzjcfd1 = Convert.ToInt32(textboxncxzjcfd1.Text);
                    neicunheqiu.ncxzjcfd2 = Convert.ToInt32(textboxncxzjcfd2.Text);
                    neicunheqiu.ncxzjcfd3 = Convert.ToInt32(textboxncxzjcfd3.Text);
                    neicunheqiu.ncxzjcfd4 = Convert.ToInt32(textboxncxzjcfd4.Text);
                    neicunheqiu.ncxzjd1 = Convert.ToInt32(textboxncxzjd1.Text);
                    neicunheqiu.ncxzjd2 = Convert.ToInt32(textboxncxzjd2.Text);
                    neicunheqiu.ncxzjd3 = Convert.ToInt32(textboxncxzjd3.Text);
                    neicunheqiu.ncxzjd4 = Convert.ToInt32(textboxncxzjd4.Text);
                    neicunheqiu.ncxzyc1 = int.Parse(datagridviewncxz.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc2 = int.Parse(datagridviewncxz.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc3 = int.Parse(datagridviewncxz.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc4 = int.Parse(datagridviewncxz.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc5 = int.Parse(datagridviewncxz.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc6 = int.Parse(datagridviewncxz.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc7 = int.Parse(datagridviewncxz.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc8 = int.Parse(datagridviewncxz.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncxzyc1", neicunheqiu.ncxzyc1.ToString());
                Json.writejson("ncxzyc2", neicunheqiu.ncxzyc2.ToString());
                Json.writejson("ncxzyc3", neicunheqiu.ncxzyc3.ToString());
                Json.writejson("ncxzyc4", neicunheqiu.ncxzyc4.ToString());
                Json.writejson("ncxzyc5", neicunheqiu.ncxzyc5.ToString());
                Json.writejson("ncxzyc6", neicunheqiu.ncxzyc6.ToString());
                Json.writejson("ncxzyc7", neicunheqiu.ncxzyc7.ToString());
                Json.writejson("ncxzyc8", neicunheqiu.ncxzyc8.ToString());
            }
            else
            {
                Json.writejson("ncxuanzhuan", "false");
                neicunheqiu.ncxuanzhuanflag = false;
            }
        }

        private void textboxncxzjcfd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjcfd1.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjcfd1 = Convert.ToInt32(textboxncxzjcfd1.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjcfd1 = 90;
                }
            }
            Json.writejson("ncxzjcfd1", textboxncxzjcfd1.Text);
        }

        private void textboxncxzjcfd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjcfd2.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjcfd2 = Convert.ToInt32(textboxncxzjcfd2.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjcfd2 = 85;
                }
            }
            Json.writejson("ncxzjcfd2", textboxncxzjcfd2.Text);
        }

        private void textboxncxzjcfd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjcfd3.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjcfd3 = Convert.ToInt32(textboxncxzjcfd3.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjcfd3 = 75;
                }
            }
            Json.writejson("ncxzjcfd3", textboxncxzjcfd3.Text);
        }

        private void textboxncxzjcfd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjcfd4.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjcfd4 = Convert.ToInt32(textboxncxzjcfd4.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjcfd4 = 70;
                }
            }
            Json.writejson("ncxzjcfd4", textboxncxzjcfd4.Text);
        }

        private void textboxncxzjd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjd1.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjd1 = Convert.ToInt32(textboxncxzjd1.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjd1 = 20;
                }
            }
            Json.writejson("ncxzjd1", textboxncxzjd1.Text);
        }

        private void textboxncxzjd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjd2.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjd2 = Convert.ToInt32(textboxncxzjd2.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjd2 = 25;
                }
            }
            Json.writejson("ncxzjd2", textboxncxzjd2.Text);
        }

        private void textboxncxzjd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjd3.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjd3 = Convert.ToInt32(textboxncxzjd3.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjd3 = 25;
                }
            }
            Json.writejson("ncxzjd3", textboxncxzjd3.Text);
        }

        private void textboxncxzjd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxncxzjd4.Text != null)
            {
                try
                {
                    neicunheqiu.ncxzjd4 = Convert.ToInt32(textboxncxzjd4.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncxzjd4 = 40;
                }
            }
            Json.writejson("ncxzjd4", textboxncxzjd4.Text);
        }

        private void textboxncxzjcfd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewncxz_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewncxz_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncxzyc1 = int.Parse(datagridviewncxz.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc2 = int.Parse(datagridviewncxz.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc3 = int.Parse(datagridviewncxz.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc4 = int.Parse(datagridviewncxz.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc5 = int.Parse(datagridviewncxz.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc6 = int.Parse(datagridviewncxz.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc7 = int.Parse(datagridviewncxz.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc8 = int.Parse(datagridviewncxz.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncxzyc1", neicunheqiu.ncxzyc1.ToString());
                Json.writejson("ncxzyc2", neicunheqiu.ncxzyc2.ToString());
                Json.writejson("ncxzyc3", neicunheqiu.ncxzyc3.ToString());
                Json.writejson("ncxzyc4", neicunheqiu.ncxzyc4.ToString());
                Json.writejson("ncxzyc5", neicunheqiu.ncxzyc5.ToString());
                Json.writejson("ncxzyc6", neicunheqiu.ncxzyc6.ToString());
                Json.writejson("ncxzyc7", neicunheqiu.ncxzyc7.ToString());
                Json.writejson("ncxzyc8", neicunheqiu.ncxzyc8.ToString());
            }
        }

        private void checkboxncxztq_CheckedChanged(object sender, bool value)
        {
            if (checkboxncxztq.Checked)
            {
                neicunheqiu.ncxuanzhuantq = true;
                Json.writejson("ncxuanzhuantqflag", "true");
            }
            else
            {
                neicunheqiu.ncxuanzhuantq = false;
                Json.writejson("ncxuanzhuantqflag", "false");
            }
        }

        private void buttonncxzcz_Click(object sender, EventArgs e)
        {
            textboxncxzjcfd1.Text = "90";
            textboxncxzjcfd2.Text = "85";
            textboxncxzjcfd3.Text = "75";
            textboxncxzjcfd4.Text = "70";
            textboxncxzjd1.Text = "20";
            textboxncxzjd2.Text = "25";
            textboxncxzjd3.Text = "25";
            textboxncxzjd4.Text = "40";
            MessageBox.Show("重置参数成功");
        }
    }
}
