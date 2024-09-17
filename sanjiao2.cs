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
    public partial class sanjiao2 : Form
    {
        public sanjiao2()
        {
            InitializeComponent();
        }

        private void sanjiao2_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("sanjiao2jian"))
            {
                comboboxsanjiao2.SelectedItem = "A";
            }
            else
            {
                comboboxsanjiao2.SelectedItem = Json.readjson("sanjiao2jian");
            }
            if (!Json.checkjson("sj2jcfd"))
            {
                textboxsj2jcfd.Text = "100";
            }
            else
            {
                textboxsj2jcfd.Text = Json.readjson("sj2jcfd");
            }
            if (!Json.checkjson("sj2jd"))
            {
                textboxsj2jd.Text = "160";
            }
            else
            {
                textboxsj2jd.Text = Json.readjson("sj2jd");
            }
            if (!Json.checkjson("sj2yc1"))
            {
                datagridviewsj2.Rows.Add("鼠标左键按下", 20);
                datagridviewsj2.Rows.Add("第一次拖动鼠标", 50);
                datagridviewsj2.Rows.Add("分身", 10);
                datagridviewsj2.Rows.Add("第二次拖动鼠标", 50);
                datagridviewsj2.Rows.Add("分身", 10);
                datagridviewsj2.Rows.Add("第三次拖动鼠标", 50);
                datagridviewsj2.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewsj2.Rows.Add("鼠标左键按下", Json.readjson("sj2yc1"));
                datagridviewsj2.Rows.Add("第一次拖动鼠标", Json.readjson("sj2yc2"));
                datagridviewsj2.Rows.Add("分身", Json.readjson("sj2yc3"));
                datagridviewsj2.Rows.Add("第二次拖动鼠标", Json.readjson("sj2yc4"));
                datagridviewsj2.Rows.Add("分身", Json.readjson("sj2yc5"));
                datagridviewsj2.Rows.Add("第三次拖动鼠标", Json.readjson("sj2yc6"));
                datagridviewsj2.Rows.Add("最后分身延迟", Json.readjson("sj2yc7"));
            }
            try
            {
                zidongheqiu.sanjiao2jcfd = Convert.ToInt32(textboxsj2jcfd.Text);
                zidongheqiu.sanjiao2jd = Convert.ToInt32(textboxsj2jd.Text);
                zidongheqiu.sanjiao2jian = MainForm.GetVirtualKeyCode(comboboxsanjiao2.SelectedItem.ToString());
            }
            catch
            {

            }
            try
            {
                zidongheqiu.sj2yc1 = int.Parse(datagridviewsj2.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.sj2yc2 = int.Parse(datagridviewsj2.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.sj2yc3 = int.Parse(datagridviewsj2.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.sj2yc4 = int.Parse(datagridviewsj2.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.sj2yc5 = int.Parse(datagridviewsj2.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.sj2yc6 = int.Parse(datagridviewsj2.Rows[5].Cells[1].Value.ToString());
                zidongheqiu.sj2yc7 = int.Parse(datagridviewsj2.Rows[6].Cells[1].Value.ToString());

            }
            catch
            {

            }

            if (Json.checkjson("sanjiao2"))
            {
                if (Json.readjson("sanjiao2") == "true")
                {
                    checkboxsanjiao2.Checked = true;
                }
            }
            if (Json.checkjson("sanjiao2jiantou"))
            {
                if (Json.readjson("sanjiao2jiantou") == "true")
                {
                    checkboxsanjiao2.Checked = true;
                }
            }
        }

        private void checkboxsanjiao2_CheckedChanged(object sender, bool value)
        {
            if (checkboxsanjiao2.Checked)
            {
                Json.writejson("sanjiao2", "true");
                zidongheqiu.sanjiao2flag = true;
                zidongheqiu.sanjiao2jian = MainForm.GetVirtualKeyCode(comboboxsanjiao2.SelectedItem.ToString());
                try
                {
                    zidongheqiu.sanjiao2jcfd = Convert.ToInt32(textboxsj2jcfd.Text);
                    zidongheqiu.sanjiao2jd = Convert.ToInt32(textboxsj2jd.Text);
                    zidongheqiu.sj2yc1 = int.Parse(datagridviewsj2.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc2 = int.Parse(datagridviewsj2.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc3 = int.Parse(datagridviewsj2.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc4 = int.Parse(datagridviewsj2.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc5 = int.Parse(datagridviewsj2.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc6 = int.Parse(datagridviewsj2.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc7 = int.Parse(datagridviewsj2.Rows[6].Cells[1].Value.ToString());

                }
                catch (Exception ex)
                {


                }
                Json.writejson("sj2yc1", zidongheqiu.sj2yc1.ToString());
                Json.writejson("sj2yc2", zidongheqiu.sj2yc2.ToString());
                Json.writejson("sj2yc3", zidongheqiu.sj2yc3.ToString());
                Json.writejson("sj2yc4", zidongheqiu.sj2yc4.ToString());
                Json.writejson("sj2yc5", zidongheqiu.sj2yc5.ToString());
                Json.writejson("sj2yc6", zidongheqiu.sj2yc6.ToString());
                Json.writejson("sj2yc7", zidongheqiu.sj2yc7.ToString());
            }
            else
            {
                Json.writejson("sanjiao2", "false");
                zidongheqiu.sanjiao2flag = false;
            }
        }

        private void comboboxsanjiao2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxsanjiao2.SelectedItem != null)
            {
                zidongheqiu.sanjiao2jian = MainForm.GetVirtualKeyCode(comboboxsanjiao2.SelectedItem.ToString());
            }
            Json.writejson("sanjiao2jian", comboboxsanjiao2.SelectedItem.ToString());
        }

        private void textboxsj2jcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxsj2jcfd.Text != null)
            {
                try
                {
                    zidongheqiu.sanjiao2jcfd = Convert.ToInt32(textboxsj2jcfd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.sanjiao2jcfd = 100;
                }
            }
            Json.writejson("sj2jcfd", textboxsj2jcfd.Text);
        }

        private void textboxsj2jd_TextChanged(object sender, EventArgs e)
        {
            if (textboxsj2jd.Text != null)
            {
                try
                {
                    zidongheqiu.sanjiao2jd = Convert.ToInt32(textboxsj2jd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.sanjiao2jd = 180;
                }
            }
            Json.writejson("sj2jd", textboxsj2jd.Text);
        }

        private void textboxsj2jcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxsj2jd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewsj2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewsj2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.sj2yc1 = int.Parse(datagridviewsj2.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc2 = int.Parse(datagridviewsj2.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc3 = int.Parse(datagridviewsj2.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc4 = int.Parse(datagridviewsj2.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc5 = int.Parse(datagridviewsj2.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc6 = int.Parse(datagridviewsj2.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.sj2yc7 = int.Parse(datagridviewsj2.Rows[6].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("sj2yc1", zidongheqiu.sj2yc1.ToString());
                Json.writejson("sj2yc2", zidongheqiu.sj2yc2.ToString());
                Json.writejson("sj2yc3", zidongheqiu.sj2yc3.ToString());
                Json.writejson("sj2yc4", zidongheqiu.sj2yc4.ToString());
                Json.writejson("sj2yc5", zidongheqiu.sj2yc5.ToString());
                Json.writejson("sj2yc6", zidongheqiu.sj2yc6.ToString());
                Json.writejson("sj2yc7", zidongheqiu.sj2yc7.ToString());
            }
        }

        private void checkboxsj2tq_CheckedChanged(object sender, bool value)
        {
            if (checkboxsj2tq.Checked)
            {
                zidongheqiu.sanjiao2tqflag = true;
                Json.writejson("sanjiao2tqflag", "true");
            }
            else
            {
                zidongheqiu.sanjiao2tqflag = false;
                Json.writejson("sanjiao2tqflag", "false");
            }
        }

        private void checkboxsj2jt_CheckedChanged(object sender, bool value)
        {
            if (checkboxsj2jt.Checked)
            {
                zidongheqiu.sanjiao2jiantou = true;
                Json.writejson("sanjiao2jiantou", "true");
            }
            else
            {
                zidongheqiu.sanjiao2jiantou = false;
                Json.writejson("sanjiao2jiantou", "false");
            }
        }

        private void buttonsj2cz_Click(object sender, EventArgs e)
        {
            textboxsj2jcfd.Text = "100";
            textboxsj2jd.Text = "160";
            MessageBox.Show("重置参数成功");
        }
    }
}
