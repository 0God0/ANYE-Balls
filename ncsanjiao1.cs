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
    public partial class ncsanjiao1 : Form
    {
        public ncsanjiao1()
        {
            InitializeComponent();
        }

        private void ncsanjiao1_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("ncsanjiaojian"))
            {
                comboboxncsanjiao1.SelectedItem = "A";
            }
            else
            {
                comboboxncsanjiao1.SelectedItem = Json.readjson("ncsanjiaojian");
            }
            if (!Json.checkjson("ncsjjcfd"))
            {
                textboxncsj1jcfd.Text = "100";
            }
            else
            {
                textboxncsj1jcfd.Text = Json.readjson("ncsjjcfd");
            }
            if (!Json.checkjson("ncsjjd"))
            {
                textboxncsj1jd.Text = "180";
            }
            else
            {
                textboxncsj1jd.Text = Json.readjson("ncsjjd");
            }
            if (!Json.checkjson("ncsjyc1"))
            {
                datagridviewncsj1.Rows.Add("第一次拖动鼠标", 50);
                datagridviewncsj1.Rows.Add("分身", 10);
                datagridviewncsj1.Rows.Add("第二次拖动鼠标", 50);
                datagridviewncsj1.Rows.Add("分身", 10);
                datagridviewncsj1.Rows.Add("第三次拖动鼠标", 50);
                datagridviewncsj1.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewncsj1.Rows.Add("第一次拖动鼠标", Json.readjson("ncsjyc1"));
                datagridviewncsj1.Rows.Add("分身", Json.readjson("ncsjyc2"));
                datagridviewncsj1.Rows.Add("第二次拖动鼠标", Json.readjson("ncsjyc3"));
                datagridviewncsj1.Rows.Add("分身", Json.readjson("ncsjyc4"));
                datagridviewncsj1.Rows.Add("第三次拖动鼠标", Json.readjson("ncsjyc5"));
                datagridviewncsj1.Rows.Add("最后分身延迟", Json.readjson("ncsjyc6"));
            }
            try
            {
                neicunheqiu.ncsanjiaojcfd = Convert.ToInt32(textboxncsj1jcfd.Text);
                neicunheqiu.ncsanjiaojd = Convert.ToInt32(textboxncsj1jd.Text);
                neicunheqiu.ncsanjiaojian = MainForm.GetVirtualKeyCode(comboboxncsanjiao1.SelectedItem.ToString());
            }
            catch
            {

            }
            try
            {
                neicunheqiu.ncsjyc1 = int.Parse(datagridviewncsj1.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncsjyc2 = int.Parse(datagridviewncsj1.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncsjyc3 = int.Parse(datagridviewncsj1.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncsjyc4 = int.Parse(datagridviewncsj1.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.ncsjyc5 = int.Parse(datagridviewncsj1.Rows[4].Cells[1].Value.ToString());
                neicunheqiu.ncsjyc6 = int.Parse(datagridviewncsj1.Rows[5].Cells[1].Value.ToString());

            }
            catch
            {

            }

            if (Json.checkjson("ncsanjiao"))
            {
                if (Json.readjson("ncsanjiao") == "true")
                {
                    checkboxncsanjiao1.Checked = true;
                }
            }
            if (Json.checkjson("ncsanjiaojiantou"))
            {
                if (Json.readjson("ncsanjiaojiantou") == "true")
                {
                    checkboxncsanjiao1.Checked = true;
                }
            }
        }

        private void datagridviewncsj1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewncsj1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncsjyc1 = int.Parse(datagridviewncsj1.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc2 = int.Parse(datagridviewncsj1.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc3 = int.Parse(datagridviewncsj1.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc4 = int.Parse(datagridviewncsj1.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc5 = int.Parse(datagridviewncsj1.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc6 = int.Parse(datagridviewncsj1.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncsjyc1", neicunheqiu.ncsjyc1.ToString());
                Json.writejson("ncsjyc2", neicunheqiu.ncsjyc2.ToString());
                Json.writejson("ncsjyc3", neicunheqiu.ncsjyc3.ToString());
                Json.writejson("ncsjyc4", neicunheqiu.ncsjyc4.ToString());
                Json.writejson("ncsjyc5", neicunheqiu.ncsjyc5.ToString());
                Json.writejson("ncsjyc6", neicunheqiu.ncsjyc6.ToString());
            }
        }

        private void textboxncsj1jcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxncsj1jcfd.Text != null)
            {
                try
                {
                    neicunheqiu.ncsanjiaojcfd = Convert.ToInt32(textboxncsj1jcfd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncsanjiaojcfd = 100;
                }
            }
            Json.writejson("ncsjjcfd", textboxncsj1jcfd.Text);
        }

        private void textboxncsj1jd_TextChanged(object sender, EventArgs e)
        {
            if (textboxncsj1jd.Text != null)
            {
                try
                {
                    neicunheqiu.ncsanjiaojd = Convert.ToInt32(textboxncsj1jd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncsanjiaojd = 180;
                }
            }
            Json.writejson("ncsjjd", textboxncsj1jd.Text);
        }

        private void comboboxncsanjiao1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxncsanjiao1.SelectedItem != null)
            {
                neicunheqiu.ncsanjiaojian = MainForm.GetVirtualKeyCode(comboboxncsanjiao1.SelectedItem.ToString());
            }
            Json.writejson("ncsanjiaojian", comboboxncsanjiao1.SelectedItem.ToString());
        }

        private void checkboxncsj1jt_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsj1jt.Checked)
            {
                neicunheqiu.ncsanjiaojiantou = true;
                Json.writejson("ncsanjiaojiantou", "true");
            }
            else
            {
                neicunheqiu.ncsanjiaojiantou = false;
                Json.writejson("ncsanjiaojiantou", "false");
            }
        }

        private void checkboxncsj1tq_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsj1tq.Checked)
            {
                neicunheqiu.ncsanjiaotq = true;
                Json.writejson("ncsanjiaotqflag", "true");
            }
            else
            {
                neicunheqiu.ncsanjiaotq = false;
                Json.writejson("ncsanjiaotqflag", "false");
            }
        }

        private void textboxncsj1jcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxncsj1jd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void checkboxncsanjiao1_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsanjiao1.Checked)
            {
                Json.writejson("ncsanjiao", "true");
                neicunheqiu.ncsanjiaoflag = true;
                neicunheqiu.ncsanjiaojian = MainForm.GetVirtualKeyCode(comboboxncsanjiao1.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncsanjiaojcfd = Convert.ToInt32(textboxncsj1jcfd.Text);
                    neicunheqiu.ncsanjiaojd = Convert.ToInt32(textboxncsj1jd.Text);
                    neicunheqiu.ncsjyc1 = int.Parse(datagridviewncsj1.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc2 = int.Parse(datagridviewncsj1.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc3 = int.Parse(datagridviewncsj1.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc4 = int.Parse(datagridviewncsj1.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc5 = int.Parse(datagridviewncsj1.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc6 = int.Parse(datagridviewncsj1.Rows[5].Cells[1].Value.ToString());

                }
                catch (Exception ex)
                {


                }
                Json.writejson("ncsjyc1", neicunheqiu.ncsjyc1.ToString());
                Json.writejson("ncsjyc2", neicunheqiu.ncsjyc2.ToString());
                Json.writejson("ncsjyc3", neicunheqiu.ncsjyc3.ToString());
                Json.writejson("ncsjyc4", neicunheqiu.ncsjyc4.ToString());
                Json.writejson("ncsjyc5", neicunheqiu.ncsjyc5.ToString());
                Json.writejson("ncsjyc6", neicunheqiu.ncsjyc6.ToString());
            }
            else
            {
                Json.writejson("ncsanjiao", "false");
                neicunheqiu.ncsanjiaoflag = false;
            }
        }

        private void buttonncsjcz_Click(object sender, EventArgs e)
        {
            textboxncsj1jcfd.Text = "100";
            textboxncsj1jd.Text = "180";
            MessageBox.Show("重置参数成功");
        }
    }
}
