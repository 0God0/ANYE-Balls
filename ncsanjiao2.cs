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
    public partial class ncsanjiao2 : Form
    {
        public ncsanjiao2()
        {
            InitializeComponent();
        }

        private void ncsanjiao2_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("ncsanjiao2jian"))
            {
                comboboxncsanjiao2.SelectedItem = "A";
            }
            else
            {
                comboboxncsanjiao2.SelectedItem = Json.readjson("ncsanjiao2jian");
            }
            if (!Json.checkjson("ncsj2jcfd"))
            {
                textboxncsj2jcfd.Text = "100";
            }
            else
            {
                textboxncsj2jcfd.Text = Json.readjson("ncsj2jcfd");
            }
            if (!Json.checkjson("ncsj2jd"))
            {
                textboxncsj2jd.Text = "160";
            }
            else
            {
                textboxncsj2jd.Text = Json.readjson("ncsj2jd");
            }
            if (!Json.checkjson("ncsj2yc1"))
            {
                datagridviewncsj2.Rows.Add("第一次拖动鼠标", 50);
                datagridviewncsj2.Rows.Add("分身", 10);
                datagridviewncsj2.Rows.Add("第二次拖动鼠标", 50);
                datagridviewncsj2.Rows.Add("分身", 10);
                datagridviewncsj2.Rows.Add("第三次拖动鼠标", 50);
                datagridviewncsj2.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewncsj2.Rows.Add("第一次拖动鼠标", Json.readjson("ncsj2yc1"));
                datagridviewncsj2.Rows.Add("分身", Json.readjson("ncsj2yc2"));
                datagridviewncsj2.Rows.Add("第二次拖动鼠标", Json.readjson("ncsj2yc3"));
                datagridviewncsj2.Rows.Add("分身", Json.readjson("ncsj2yc4"));
                datagridviewncsj2.Rows.Add("第三次拖动鼠标", Json.readjson("ncsj2yc5"));
                datagridviewncsj2.Rows.Add("最后分身延迟", Json.readjson("ncsj2yc6"));
            }
            try
            {
                neicunheqiu.ncsanjiao2jcfd = Convert.ToInt32(textboxncsj2jcfd.Text);
                neicunheqiu.ncsanjiao2jd = Convert.ToInt32(textboxncsj2jd.Text);
                neicunheqiu.ncsanjiao2jian = MainForm.GetVirtualKeyCode(comboboxncsanjiao2.SelectedItem.ToString());
            }
            catch
            {

            }
            try
            {
                neicunheqiu.ncsj2yc1 = int.Parse(datagridviewncsj2.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncsj2yc2 = int.Parse(datagridviewncsj2.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncsj2yc3 = int.Parse(datagridviewncsj2.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncsj2yc4 = int.Parse(datagridviewncsj2.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.ncsj2yc5 = int.Parse(datagridviewncsj2.Rows[4].Cells[1].Value.ToString());
                neicunheqiu.ncsj2yc6 = int.Parse(datagridviewncsj2.Rows[5].Cells[1].Value.ToString());

            }
            catch
            {

            }

            if (Json.checkjson("ncsanjiao2"))
            {
                if (Json.readjson("ncsanjiao2") == "true")
                {
                    checkboxncsanjiao2.Checked = true;
                }
            }
            if (Json.checkjson("ncsanjiao2jiantou"))
            {
                if (Json.readjson("ncsanjiao2jiantou") == "true")
                {
                    checkboxncsanjiao2.Checked = true;
                }
            }
        }

        private void checkboxncsanjiao2_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsanjiao2.Checked)
            {
                Json.writejson("ncsanjiao2", "true");
                neicunheqiu.ncsanjiao2flag = true;
                neicunheqiu.ncsanjiao2jian = MainForm.GetVirtualKeyCode(comboboxncsanjiao2.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncsanjiao2jcfd = Convert.ToInt32(textboxncsj2jcfd.Text);
                    neicunheqiu.ncsanjiao2jd = Convert.ToInt32(textboxncsj2jd.Text);
                    neicunheqiu.ncsj2yc1 = int.Parse(datagridviewncsj2.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc2 = int.Parse(datagridviewncsj2.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc3 = int.Parse(datagridviewncsj2.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc4 = int.Parse(datagridviewncsj2.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc5 = int.Parse(datagridviewncsj2.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc6 = int.Parse(datagridviewncsj2.Rows[5].Cells[1].Value.ToString());

                }
                catch (Exception ex)
                {


                }
                Json.writejson("ncsj2yc1", neicunheqiu.ncsj2yc1.ToString());
                Json.writejson("ncsj2yc2", neicunheqiu.ncsj2yc2.ToString());
                Json.writejson("ncsj2yc3", neicunheqiu.ncsj2yc3.ToString());
                Json.writejson("ncsj2yc4", neicunheqiu.ncsj2yc4.ToString());
                Json.writejson("ncsj2yc5", neicunheqiu.ncsj2yc5.ToString());
                Json.writejson("ncsj2yc6", neicunheqiu.ncsj2yc6.ToString());
            }
            else
            {
                Json.writejson("ncsanjiao2", "false");
                neicunheqiu.ncsanjiao2flag = false;
            }
        }

        private void comboboxncsanjiao2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxncsanjiao2.SelectedItem != null)
            {
                neicunheqiu.ncsanjiao2jian = MainForm.GetVirtualKeyCode(comboboxncsanjiao2.SelectedItem.ToString());
            }
            Json.writejson("ncsanjiao2jian", comboboxncsanjiao2.SelectedItem.ToString());
        }

        private void textboxncsj2jcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxncsj2jcfd.Text != null)
            {
                try
                {
                    neicunheqiu.ncsanjiao2jcfd = Convert.ToInt32(textboxncsj2jcfd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncsanjiao2jcfd = 100;
                }
            }
            Json.writejson("ncsj2jcfd", textboxncsj2jcfd.Text);
        }

        private void textboxncsj2jd_TextChanged(object sender, EventArgs e)
        {
            if (textboxncsj2jd.Text != null)
            {
                try
                {
                    neicunheqiu.ncsanjiao2jd = Convert.ToInt32(textboxncsj2jd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncsanjiao2jd = 180;
                }
            }
            Json.writejson("ncsj2jd", textboxncsj2jd.Text);
        }

        private void textboxncsj2jcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxncsj2jd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewncsj2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewncsj2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncsj2yc1 = int.Parse(datagridviewncsj2.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc2 = int.Parse(datagridviewncsj2.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc3 = int.Parse(datagridviewncsj2.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc4 = int.Parse(datagridviewncsj2.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc5 = int.Parse(datagridviewncsj2.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc6 = int.Parse(datagridviewncsj2.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncsj2yc1", neicunheqiu.ncsj2yc1.ToString());
                Json.writejson("ncsj2yc2", neicunheqiu.ncsj2yc2.ToString());
                Json.writejson("ncsj2yc3", neicunheqiu.ncsj2yc3.ToString());
                Json.writejson("ncsj2yc4", neicunheqiu.ncsj2yc4.ToString());
                Json.writejson("ncsj2yc5", neicunheqiu.ncsj2yc5.ToString());
                Json.writejson("ncsj2yc6", neicunheqiu.ncsj2yc6.ToString());
            }
        }

        private void checkboxncsj2tq_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsj2tq.Checked)
            {
                neicunheqiu.ncsanjiao2tq = true;
                Json.writejson("ncsanjiao2tqflag", "true");
            }
            else
            {
                neicunheqiu.ncsanjiao2tq = false;
                Json.writejson("ncsanjiao2tqflag", "false");
            }
        }

        private void checkboxncsj2jt_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsj2jt.Checked)
            {
                neicunheqiu.ncsanjiao2jiantou = true;
                Json.writejson("ncsanjiao2jiantou", "true");
            }
            else
            {
                neicunheqiu.ncsanjiao2jiantou = false;
                Json.writejson("ncsanjiao2jiantou", "false");
            }
        }

        private void buttonncsj2cz_Click(object sender, EventArgs e)
        {
            textboxncsj2jcfd.Text = "100";
            textboxncsj2jd.Text = "160";
            MessageBox.Show("重置参数成功");
        }
    }
}
