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

namespace ANYE_Balls
{
    public partial class sanjiao1 : Form
    {
        public sanjiao1()
        {
            InitializeComponent();
        }

        private void sanjiao1_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("sanjiaojian"))
            {
                comboboxsanjiao1.SelectedItem = "A";
            }
            else
            {
                comboboxsanjiao1.SelectedItem = Json.readjson("sanjiaojian");
            }
            if (!Json.checkjson("sjjcfd"))
            {
                textboxsj1jcfd.Text = "100";
            }
            else
            {
                textboxsj1jcfd.Text = Json.readjson("sjjcfd");
            }
            if (!Json.checkjson("sjjd"))
            {
                textboxsj1jd.Text = "180";
            }
            else
            {
                textboxsj1jd.Text = Json.readjson("sjjd");
            }
            if (!Json.checkjson("sjyc1"))
            {
                datagridviewsj1.Rows.Add("鼠标左键按下", 20);
                datagridviewsj1.Rows.Add("第一次拖动鼠标", 50);
                datagridviewsj1.Rows.Add("分身", 10);
                datagridviewsj1.Rows.Add("第二次拖动鼠标", 50);
                datagridviewsj1.Rows.Add("分身", 10);
                datagridviewsj1.Rows.Add("第三次拖动鼠标", 50);
                datagridviewsj1.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewsj1.Rows.Add("鼠标左键按下", Json.readjson("sjyc1"));
                datagridviewsj1.Rows.Add("第一次拖动鼠标", Json.readjson("sjyc2"));
                datagridviewsj1.Rows.Add("分身", Json.readjson("sjyc3"));
                datagridviewsj1.Rows.Add("第二次拖动鼠标", Json.readjson("sjyc4"));
                datagridviewsj1.Rows.Add("分身", Json.readjson("sjyc5"));
                datagridviewsj1.Rows.Add("第三次拖动鼠标", Json.readjson("sjyc6"));
                datagridviewsj1.Rows.Add("最后分身延迟", Json.readjson("sjyc7"));
            }
            try
            {
                zidongheqiu.sanjiaojcfd = Convert.ToInt32(textboxsj1jcfd.Text);
                zidongheqiu.sanjiaojd = Convert.ToInt32(textboxsj1jd.Text);
                zidongheqiu.sanjiaojian = MainForm.GetVirtualKeyCode(comboboxsanjiao1.SelectedItem.ToString());
            }
            catch
            {

            }
            try
            {
                zidongheqiu.sjyc1 = int.Parse(datagridviewsj1.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.sjyc2 = int.Parse(datagridviewsj1.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.sjyc3 = int.Parse(datagridviewsj1.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.sjyc4 = int.Parse(datagridviewsj1.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.sjyc5 = int.Parse(datagridviewsj1.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.sjyc6 = int.Parse(datagridviewsj1.Rows[5].Cells[1].Value.ToString());
                zidongheqiu.sjyc7 = int.Parse(datagridviewsj1.Rows[6].Cells[1].Value.ToString());

            }
            catch
            {

            }

            if (Json.checkjson("sanjiao"))
            {
                if (Json.readjson("sanjiao") == "true")
                {
                    checkboxsanjiao1.Checked = true;
                }
            }
            if (Json.checkjson("sanjiaojiantou"))
            {
                if (Json.readjson("sanjiaojiantou") == "true")
                {
                    checkboxsanjiao1.Checked = true;
                }
            }
        }

        private void datagridviewsj1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewsj1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.sjyc1 = int.Parse(datagridviewsj1.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sjyc2 = int.Parse(datagridviewsj1.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sjyc3 = int.Parse(datagridviewsj1.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sjyc4 = int.Parse(datagridviewsj1.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sjyc5 = int.Parse(datagridviewsj1.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.sjyc6 = int.Parse(datagridviewsj1.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.sjyc7 = int.Parse(datagridviewsj1.Rows[6].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("sjyc1", zidongheqiu.sjyc1.ToString());
                Json.writejson("sjyc2", zidongheqiu.sjyc2.ToString());
                Json.writejson("sjyc3", zidongheqiu.sjyc3.ToString());
                Json.writejson("sjyc4", zidongheqiu.sjyc4.ToString());
                Json.writejson("sjyc5", zidongheqiu.sjyc5.ToString());
                Json.writejson("sjyc6", zidongheqiu.sjyc6.ToString());
                Json.writejson("sjyc7", zidongheqiu.sjyc7.ToString());
            }
        }

        private void textboxsj1jcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxsj1jcfd.Text != null)
            {
                try
                {
                    zidongheqiu.sanjiaojcfd = Convert.ToInt32(textboxsj1jcfd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.sanjiaojcfd = 100;
                }
            }
            Json.writejson("sjjcfd", textboxsj1jcfd.Text);
        }

        private void textboxsj1jd_TextChanged(object sender, EventArgs e)
        {
            if (textboxsj1jd.Text != null)
            {
                try
                {
                    zidongheqiu.sanjiaojd = Convert.ToInt32(textboxsj1jd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.sanjiaojd = 180;
                }
            }
            Json.writejson("sjjd", textboxsj1jd.Text);
        }

        private void comboboxsanjiao1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxsanjiao1.SelectedItem != null)
            {
                zidongheqiu.sanjiaojian = MainForm.GetVirtualKeyCode(comboboxsanjiao1.SelectedItem.ToString());
            }
            Json.writejson("sanjiaojian", comboboxsanjiao1.SelectedItem.ToString());
        }

        private void checkboxsj1jt_CheckedChanged(object sender, bool value)
        {
            if (checkboxsj1jt.Checked)
            {
                zidongheqiu.sanjiaojiantou = true;
                Json.writejson("sanjiaojiantou", "true");
            }
            else
            {
                zidongheqiu.sanjiaojiantou = false;
                Json.writejson("sanjiaojiantou", "false");
            }
        }

        private void checkboxsj1tq_CheckedChanged(object sender, bool value)
        {
            if (checkboxsj1tq.Checked)
            {
                zidongheqiu.sanjiaotqflag = true;
                Json.writejson("sanjiaotqflag", "true");
            }
            else
            {
                zidongheqiu.sanjiaotqflag = false;
                Json.writejson("sanjiaotqflag", "false");
            }
        }

        private void textboxsj1jcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxsj1jd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void checkboxsanjiao1_CheckedChanged(object sender, bool value)
        {
            if (checkboxsanjiao1.Checked)
            {
                Json.writejson("sanjiao", "true");
                zidongheqiu.sanjiaoflag = true;
                zidongheqiu.sanjiaojian = MainForm.GetVirtualKeyCode(comboboxsanjiao1.SelectedItem.ToString());
                try
                {
                    zidongheqiu.sanjiaojcfd = Convert.ToInt32(textboxsj1jcfd.Text);
                    zidongheqiu.sanjiaojd = Convert.ToInt32(textboxsj1jd.Text);
                    zidongheqiu.sjyc1 = int.Parse(datagridviewsj1.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sjyc2 = int.Parse(datagridviewsj1.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sjyc3 = int.Parse(datagridviewsj1.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sjyc4 = int.Parse(datagridviewsj1.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sjyc5 = int.Parse(datagridviewsj1.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.sjyc6 = int.Parse(datagridviewsj1.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.sjyc7 = int.Parse(datagridviewsj1.Rows[6].Cells[1].Value.ToString());

                }
                catch (Exception ex)
                {


                }
                Json.writejson("sjyc1", zidongheqiu.sjyc1.ToString());
                Json.writejson("sjyc2", zidongheqiu.sjyc2.ToString());
                Json.writejson("sjyc3", zidongheqiu.sjyc3.ToString());
                Json.writejson("sjyc4", zidongheqiu.sjyc4.ToString());
                Json.writejson("sjyc5", zidongheqiu.sjyc5.ToString());
                Json.writejson("sjyc6", zidongheqiu.sjyc6.ToString());
                Json.writejson("sjyc7", zidongheqiu.sjyc7.ToString());
            }
            else
            {
                Json.writejson("sanjiao", "false");
                zidongheqiu.sanjiaoflag = false;
            }
        }

        private void buttonsjcz_Click(object sender, EventArgs e)
        {
            textboxsj1jcfd.Text = "100";
            textboxsj1jd.Text = "180";
            MessageBox.Show("重置参数成功");
        }
    }
}
