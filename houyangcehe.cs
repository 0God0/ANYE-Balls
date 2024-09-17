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
    public partial class houyangcehe : Form
    {
        public houyangcehe()
        {
            InitializeComponent();
        }

        private void houyangcehe_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("houyangjian"))
            {
                comboboxhouyangcehe.SelectedItem = "A";
            }
            else
            {
                comboboxhouyangcehe.SelectedItem = Json.readjson("houyangjian");
            }
            if (!Json.checkjson("hyjcfd"))
            {
                textboxhychjcfd.Text = "120";
            }
            else
            {
                textboxhychjcfd.Text = Json.readjson("hyjcfd");
            }
            if (!Json.checkjson("hyjd"))
            {
                textboxhychjd.Text = "40";
            }
            else
            {
                textboxhychjd.Text = Json.readjson("hyjd");
            }

            if (!Json.checkjson("hyyc1"))
            {
                datagridviewhych.Rows.Add("分身", 10);
                datagridviewhych.Rows.Add("鼠标左键按下", 20);
                datagridviewhych.Rows.Add("第一次拖动鼠标", 50);
                datagridviewhych.Rows.Add("分身", 10);
                datagridviewhych.Rows.Add("第二次拖动鼠标", 50);
                datagridviewhych.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewhych.Rows.Add("分身", Json.readjson("hyyc1"));
                datagridviewhych.Rows.Add("鼠标左键按下", Json.readjson("hyyc2"));
                datagridviewhych.Rows.Add("第一次拖动鼠标", Json.readjson("hyyc3"));
                datagridviewhych.Rows.Add("分身", Json.readjson("hyyc4"));
                datagridviewhych.Rows.Add("第二次拖动鼠标", Json.readjson("hyyc5"));
                datagridviewhych.Rows.Add("最后分身延迟", Json.readjson("hyyc6"));
            }
            zidongheqiu.houyangjian = MainForm.GetVirtualKeyCode(comboboxhouyangcehe.SelectedItem.ToString());
            try
            {
                zidongheqiu.houyangjcfd = Convert.ToInt32(textboxhychjcfd.Text);
                zidongheqiu.houyangjd = Convert.ToInt32(textboxhychjd.Text);
                zidongheqiu.hyyc1 = int.Parse(datagridviewhych.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.hyyc2 = int.Parse(datagridviewhych.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.hyyc3 = int.Parse(datagridviewhych.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.hyyc4 = int.Parse(datagridviewhych.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.hyyc5 = int.Parse(datagridviewhych.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.hyyc6 = int.Parse(datagridviewhych.Rows[5].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("houyang"))
            {
                if (Json.readjson("houyang") == "true")
                {
                    checkboxhouyangcehe.Checked = true;
                }
            }
        }

        private void comboboxhouyangcehe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxhouyangcehe.SelectedItem != null)
            {
                zidongheqiu.houyangjian = MainForm.GetVirtualKeyCode(comboboxhouyangcehe.SelectedItem.ToString());
            }
            Json.writejson("houyangjian", comboboxhouyangcehe.SelectedItem.ToString());
        }

        private void checkboxhouyangcehe_CheckedChanged(object sender, bool value)
        {
            if (checkboxhouyangcehe.Checked)
            {
                Json.writejson("houyang", "true");
                zidongheqiu.houyangflag = true;
                zidongheqiu.houyangjian = MainForm.GetVirtualKeyCode(comboboxhouyangcehe.SelectedItem.ToString());
                try
                {
                    zidongheqiu.houyangjcfd = Convert.ToInt32(textboxhychjcfd.Text);
                    zidongheqiu.houyangjd = Convert.ToInt32(textboxhychjd.Text);
                    zidongheqiu.hyyc1 = int.Parse(datagridviewhych.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.hyyc2 = int.Parse(datagridviewhych.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.hyyc3 = int.Parse(datagridviewhych.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.hyyc4 = int.Parse(datagridviewhych.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.hyyc5 = int.Parse(datagridviewhych.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.hyyc6 = int.Parse(datagridviewhych.Rows[5].Cells[1].Value.ToString());

                }
                catch (Exception ex)
                {

                }
                Json.writejson("hyyc1", zidongheqiu.hyyc1.ToString());
                Json.writejson("hyyc2", zidongheqiu.hyyc2.ToString());
                Json.writejson("hyyc3", zidongheqiu.hyyc3.ToString());
                Json.writejson("hyyc4", zidongheqiu.hyyc4.ToString());
                Json.writejson("hyyc5", zidongheqiu.hyyc5.ToString());
                Json.writejson("hyyc6", zidongheqiu.hyyc6.ToString());
            }
            else
            {
                Json.writejson("houyang", "false");
                zidongheqiu.houyangflag = false;
            }
        }

        private void textboxhychjcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxhychjcfd.Text != null)
            {
                try
                {
                    zidongheqiu.houyangjcfd = Convert.ToInt32(textboxhychjcfd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.houyangjcfd = 120;
                }
            }
            Json.writejson("houyangjcfd", textboxhychjcfd.Text);
        }

        private void textboxhychjd_TextChanged(object sender, EventArgs e)
        {
            if (textboxhychjd.Text != null)
            {
                try
                {
                    zidongheqiu.houyangjd = Convert.ToInt32(textboxhychjd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.houyangjd = 40;
                }
            }
            Json.writejson("houyangjd", textboxhychjd.Text);
        }

        private void textboxhychjcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxhychjd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewhych_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewhych_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.hyyc1 = int.Parse(datagridviewhych.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.hyyc2 = int.Parse(datagridviewhych.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.hyyc3 = int.Parse(datagridviewhych.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.hyyc4 = int.Parse(datagridviewhych.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.hyyc5 = int.Parse(datagridviewhych.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.hyyc6 = int.Parse(datagridviewhych.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("hyyc1", zidongheqiu.hyyc1.ToString());
                Json.writejson("hyyc2", zidongheqiu.hyyc2.ToString());
                Json.writejson("hyyc3", zidongheqiu.hyyc3.ToString());
                Json.writejson("hyyc4", zidongheqiu.hyyc4.ToString());
                Json.writejson("hyyc5", zidongheqiu.hyyc5.ToString());
                Json.writejson("hyyc6", zidongheqiu.hyyc6.ToString());
            }
        }

        private void checkboxhychtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxhychtq.Checked)
            {
                zidongheqiu.houyangtqflag = true;
                Json.writejson("houyangtqflag", "true");
            }
            else
            {
                zidongheqiu.houyangtqflag = false;
                Json.writejson("houyangtqflag", "false");
            }
        }

        private void buttonnchychcz_Click(object sender, EventArgs e)
        {
            textboxhychjcfd.Text = "120";
            textboxhychjd.Text = "40";
            MessageBox.Show("重置参数成功");
        }
    }
}
