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
    public partial class nchouyangcehe : Form
    {
        public nchouyangcehe()
        {
            InitializeComponent();
        }

        private void nchouyangcehe_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("nchouyangjian"))
            {
                comboboxnchouyangcehe.SelectedItem = "A";
            }
            else
            {
                comboboxnchouyangcehe.SelectedItem = Json.readjson("nchouyangjian");
            }
            if (!Json.checkjson("nchyjcfd"))
            {
                textboxnchychjcfd.Text = "120";
            }
            else
            {
                textboxnchychjcfd.Text = Json.readjson("nchyjcfd");
            }
            if (!Json.checkjson("nchyjd"))
            {
                textboxnchychjd.Text = "40";
            }
            else
            {
                textboxnchychjd.Text = Json.readjson("nchyjd");
            }

            if (!Json.checkjson("nchyyc1"))
            {
                datagridviewnchych.Rows.Add("分身", 10);
                datagridviewnchych.Rows.Add("第一次拖动鼠标", 50);
                datagridviewnchych.Rows.Add("分身", 10);
                datagridviewnchych.Rows.Add("第二次拖动鼠标", 50);
                datagridviewnchych.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewnchych.Rows.Add("分身", Json.readjson("nchyyc1"));
                datagridviewnchych.Rows.Add("第一次拖动鼠标", Json.readjson("nchyyc2"));
                datagridviewnchych.Rows.Add("分身", Json.readjson("nchyyc3"));
                datagridviewnchych.Rows.Add("第二次拖动鼠标", Json.readjson("nchyyc4"));
                datagridviewnchych.Rows.Add("最后分身延迟", Json.readjson("nchyyc5"));
            }
            neicunheqiu.nchouyangjian = MainForm.GetVirtualKeyCode(comboboxnchouyangcehe.SelectedItem.ToString());
            try
            {
                neicunheqiu.nchouyangjcfd = Convert.ToInt32(textboxnchychjcfd.Text);
                neicunheqiu.nchouyangjd = Convert.ToInt32(textboxnchychjd.Text);
                neicunheqiu.nchyyc1 = int.Parse(datagridviewnchych.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.nchyyc2 = int.Parse(datagridviewnchych.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.nchyyc3 = int.Parse(datagridviewnchych.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.nchyyc4 = int.Parse(datagridviewnchych.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.nchyyc5 = int.Parse(datagridviewnchych.Rows[4].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("nchouyang"))
            {
                if (Json.readjson("nchouyang") == "true")
                {
                    checkboxnchouyangcehe.Checked = true;
                }
            }
        }

        private void comboboxnchouyangcehe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxnchouyangcehe.SelectedItem != null)
            {
                neicunheqiu.nchouyangjian = MainForm.GetVirtualKeyCode(comboboxnchouyangcehe.SelectedItem.ToString());
            }
            Json.writejson("nchouyangjian", comboboxnchouyangcehe.SelectedItem.ToString());
        }

        private void checkboxnchouyangcehe_CheckedChanged(object sender, bool value)
        {
            if (checkboxnchouyangcehe.Checked)
            {
                Json.writejson("nchouyang", "true");
                neicunheqiu.nchouyangflag = true;
                neicunheqiu.nchouyangjian = MainForm.GetVirtualKeyCode(comboboxnchouyangcehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.nchouyangjcfd = Convert.ToInt32(textboxnchychjcfd.Text);
                    neicunheqiu.nchouyangjd = Convert.ToInt32(textboxnchychjd.Text);
                    neicunheqiu.nchyyc1 = int.Parse(datagridviewnchych.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc2 = int.Parse(datagridviewnchych.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc3 = int.Parse(datagridviewnchych.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc4 = int.Parse(datagridviewnchych.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc5 = int.Parse(datagridviewnchych.Rows[4].Cells[1].Value.ToString());

                }
                catch (Exception ex)
                {

                }
                Json.writejson("nchyyc1", neicunheqiu.nchyyc1.ToString());
                Json.writejson("nchyyc2", neicunheqiu.nchyyc2.ToString());
                Json.writejson("nchyyc3", neicunheqiu.nchyyc3.ToString());
                Json.writejson("nchyyc4", neicunheqiu.nchyyc4.ToString());
                Json.writejson("nchyyc5", neicunheqiu.nchyyc5.ToString());
            }
            else
            {
                Json.writejson("nchouyang", "false");
                neicunheqiu.nchouyangflag = false;
            }
        }

        private void textboxnchychjcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxnchychjcfd.Text != null)
            {
                try
                {
                    neicunheqiu.nchouyangjcfd = Convert.ToInt32(textboxnchychjcfd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.nchouyangjcfd = 120;
                }
            }
            Json.writejson("nchouyangjcfd", textboxnchychjcfd.Text);
        }

        private void textboxnchychjd_TextChanged(object sender, EventArgs e)
        {
            if (textboxnchychjd.Text != null)
            {
                try
                {
                    neicunheqiu.nchouyangjd = Convert.ToInt32(textboxnchychjd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.nchouyangjd = 40;
                }
            }
            Json.writejson("nchouyangjd", textboxnchychjd.Text);
        }

        private void textboxnchychjcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxnchychjd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewnchych_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewnchych_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.nchyyc1 = int.Parse(datagridviewnchych.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc2 = int.Parse(datagridviewnchych.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc3 = int.Parse(datagridviewnchych.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc4 = int.Parse(datagridviewnchych.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc5 = int.Parse(datagridviewnchych.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("nchyyc1", neicunheqiu.nchyyc1.ToString());
                Json.writejson("nchyyc2", neicunheqiu.nchyyc2.ToString());
                Json.writejson("nchyyc3", neicunheqiu.nchyyc3.ToString());
                Json.writejson("nchyyc4", neicunheqiu.nchyyc4.ToString());
                Json.writejson("nchyyc5", neicunheqiu.nchyyc5.ToString());
            }
        }

        private void checkboxnchychtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxnchychtq.Checked)
            {
                neicunheqiu.nchouyangtq = true;
                Json.writejson("nchouyangtqflag", "true");
            }
            else
            {
                neicunheqiu.nchouyangtq = false;
                Json.writejson("nchouyangtqflag", "false");
            }
        }

        private void buttonnchychcz_Click(object sender, EventArgs e)
        {
            textboxnchychjcfd.Text = "120";
            textboxnchychjd.Text = "40";
            MessageBox.Show("重置参数成功");
        }
    }
}
