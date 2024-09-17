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
    public partial class ncbanxuan : Form
    {
        public ncbanxuan()
        {
            InitializeComponent();
        }

        private void ncbanxuan_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("ncbanxuanjian"))
            {
                comboboxncbanxuan.SelectedItem = "A";
            }
            else
            {
                comboboxncbanxuan.SelectedItem = Json.readjson("ncbanxuanjian");
            }
            if (!Json.checkjson("ncbxjcfd1"))
            {
                textboxncbxjcfd1.Text = "100";
            }
            else
            {
                textboxncbxjcfd1.Text = Json.readjson("ncbxjcfd1");
            }
            if (!Json.checkjson("ncbxjcfd2"))
            {
                textboxncbxjcfd2.Text = "100";
            }
            else
            {
                textboxncbxjcfd2.Text = Json.readjson("ncbxjcfd2");
            }
            if (!Json.checkjson("ncbxjcfd3"))
            {
                textboxncbxjcfd3.Text = "120";
            }
            else
            {
                textboxncbxjcfd3.Text = Json.readjson("ncbxjcfd3");
            }
            if (!Json.checkjson("ncbxjcfd4"))
            {
                textboxncbxjcfd4.Text = "120";
            }
            else
            {
                textboxncbxjcfd4.Text = Json.readjson("ncbxjcfd4");
            }
            if (!Json.checkjson("ncbxjd1"))
            {
                textboxncbxjd1.Text = "5";
            }
            else
            {
                textboxncbxjd1.Text = Json.readjson("ncbxjd1");
            }
            if (!Json.checkjson("ncbxjd2"))
            {
                textboxncbxjd2.Text = "20";
            }
            else
            {
                textboxncbxjd2.Text = Json.readjson("ncbxjd2");
            }
            if (!Json.checkjson("ncbxjd3"))
            {
                textboxncbxjd3.Text = "25";
            }
            else
            {
                textboxncbxjd3.Text = Json.readjson("ncbxjd3");
            }
            if (!Json.checkjson("ncbxjd4"))
            {
                textboxncbxjd4.Text = "25";
            }
            else
            {
                textboxncbxjd4.Text = Json.readjson("ncbxjd4");
            }
            if (!Json.checkjson("ncbxyc1"))
            {
                datagridviewncbx.Rows.Add("第一次拖动鼠标", 50);
                datagridviewncbx.Rows.Add("分身", 10);
                datagridviewncbx.Rows.Add("第二次拖动鼠标", 50);
                datagridviewncbx.Rows.Add("分身", 10);
                datagridviewncbx.Rows.Add("第三次拖动鼠标", 50);
                datagridviewncbx.Rows.Add("分身", 10);
                datagridviewncbx.Rows.Add("第四次拖动鼠标", 50);
                datagridviewncbx.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewncbx.Rows.Add("第一次拖动鼠标", Json.readjson("ncbxyc1"));
                datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc2"));
                datagridviewncbx.Rows.Add("第二次拖动鼠标", Json.readjson("ncbxyc3"));
                datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc4"));
                datagridviewncbx.Rows.Add("第三次拖动鼠标", Json.readjson("ncbxyc5"));
                datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc6"));
                datagridviewncbx.Rows.Add("第四次拖动鼠标", Json.readjson("ncbxyc7"));
                datagridviewncbx.Rows.Add("最后分身延迟", Json.readjson("ncbxyc8"));
            }
            neicunheqiu.ncbanxuanjian = MainForm.GetVirtualKeyCode(comboboxncbanxuan.SelectedItem.ToString());
            try
            {
                neicunheqiu.ncbxjcfd1 = Convert.ToInt32(textboxncbxjcfd1.Text);
                neicunheqiu.ncbxjcfd2 = Convert.ToInt32(textboxncbxjcfd2.Text);
                neicunheqiu.ncbxjcfd3 = Convert.ToInt32(textboxncbxjcfd3.Text);
                neicunheqiu.ncbxjcfd4 = Convert.ToInt32(textboxncbxjcfd4.Text);
                neicunheqiu.ncbxjd1 = Convert.ToInt32(textboxncbxjd1.Text);
                neicunheqiu.ncbxjd2 = Convert.ToInt32(textboxncbxjd2.Text);
                neicunheqiu.ncbxjd3 = Convert.ToInt32(textboxncbxjd3.Text);
                neicunheqiu.ncbxjd4 = Convert.ToInt32(textboxncbxjd4.Text);
                neicunheqiu.ncbxyc1 = int.Parse(datagridviewncbx.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc2 = int.Parse(datagridviewncbx.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc3 = int.Parse(datagridviewncbx.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc4 = int.Parse(datagridviewncbx.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc5 = int.Parse(datagridviewncbx.Rows[4].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc6 = int.Parse(datagridviewncbx.Rows[5].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc7 = int.Parse(datagridviewncbx.Rows[6].Cells[1].Value.ToString());
                neicunheqiu.ncbxyc8 = int.Parse(datagridviewncbx.Rows[7].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("ncbanxuan"))
            {
                if (Json.readjson("ncbanxuan") == "true")
                {
                    checkboxncbanxuan.Checked = true;
                }
            }
        }

        private void comboboxncbanxuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxncbanxuan.SelectedItem != null)
            {
                neicunheqiu.ncbanxuanjian = MainForm.GetVirtualKeyCode(comboboxncbanxuan.SelectedItem.ToString());
            }
            Json.writejson("ncbanxuanjian", comboboxncbanxuan.SelectedItem.ToString());
        }

        private void checkboxncbanxuan_CheckedChanged(object sender, bool value)
        {
            if (checkboxncbanxuan.Checked)
            {
                Json.writejson("ncbanxuan", "true");
                neicunheqiu.ncbanxuanflag = true;
                neicunheqiu.ncbanxuanjian = MainForm.GetVirtualKeyCode(comboboxncbanxuan.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncbxjcfd1 = Convert.ToInt32(textboxncbxjcfd1.Text);
                    neicunheqiu.ncbxjcfd2 = Convert.ToInt32(textboxncbxjcfd2.Text);
                    neicunheqiu.ncbxjcfd3 = Convert.ToInt32(textboxncbxjcfd3.Text);
                    neicunheqiu.ncbxjcfd4 = Convert.ToInt32(textboxncbxjcfd4.Text);
                    neicunheqiu.ncbxjd1 = Convert.ToInt32(textboxncbxjd1.Text);
                    neicunheqiu.ncbxjd2 = Convert.ToInt32(textboxncbxjd2.Text);
                    neicunheqiu.ncbxjd3 = Convert.ToInt32(textboxncbxjd3.Text);
                    neicunheqiu.ncbxjd4 = Convert.ToInt32(textboxncbxjd4.Text);
                    neicunheqiu.ncbxyc1 = int.Parse(datagridviewncbx.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc2 = int.Parse(datagridviewncbx.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc3 = int.Parse(datagridviewncbx.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc4 = int.Parse(datagridviewncbx.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc5 = int.Parse(datagridviewncbx.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc6 = int.Parse(datagridviewncbx.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc7 = int.Parse(datagridviewncbx.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc8 = int.Parse(datagridviewncbx.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncbxyc1", neicunheqiu.ncbxyc1.ToString());
                Json.writejson("ncbxyc2", neicunheqiu.ncbxyc2.ToString());
                Json.writejson("ncbxyc3", neicunheqiu.ncbxyc3.ToString());
                Json.writejson("ncbxyc4", neicunheqiu.ncbxyc4.ToString());
                Json.writejson("ncbxyc5", neicunheqiu.ncbxyc5.ToString());
                Json.writejson("ncbxyc6", neicunheqiu.ncbxyc6.ToString());
                Json.writejson("ncbxyc7", neicunheqiu.ncbxyc7.ToString());
                Json.writejson("ncbxyc8", neicunheqiu.ncbxyc8.ToString());
            }
            else
            {
                Json.writejson("ncbanxuan", "false");
                neicunheqiu.ncbanxuanflag = false;
            }
        }

        private void textboxncbxjcfd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjcfd1.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjcfd1 = Convert.ToInt32(textboxncbxjcfd1.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjcfd1 = 100;
                }
            }
            Json.writejson("ncbxjcfd1", textboxncbxjcfd1.Text);
        }

        private void textboxncbxjcfd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjcfd2.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjcfd2 = Convert.ToInt32(textboxncbxjcfd2.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjcfd2 = 100;
                }
            }
            Json.writejson("ncbxjcfd2", textboxncbxjcfd2.Text);
        }

        private void textboxncbxjcfd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjcfd3.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjcfd3 = Convert.ToInt32(textboxncbxjcfd3.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjcfd3 = 120;
                }
            }
            Json.writejson("ncbxjcfd3", textboxncbxjcfd3.Text);
        }

        private void textboxncbxjcfd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjcfd4.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjcfd4 = Convert.ToInt32(textboxncbxjcfd4.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjcfd4 = 120;
                }
            }
            Json.writejson("ncbxjcfd4", textboxncbxjcfd4.Text);
        }

        private void textboxncbxjd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjd1.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjd1 = Convert.ToInt32(textboxncbxjd1.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjd1 = 5;
                }
            }
            Json.writejson("ncbxjd1", textboxncbxjd1.Text);
        }

        private void textboxncbxjd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjd2.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjd2 = Convert.ToInt32(textboxncbxjd2.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjd2 = 20;
                }
            }
            Json.writejson("ncbxjd2", textboxncbxjd2.Text);
        }

        private void textboxncbxjd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjd3.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjd3 = Convert.ToInt32(textboxncbxjd3.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjd3 = 25;
                }
            }
            Json.writejson("ncbxjd3", textboxncbxjd3.Text);
        }

        private void textboxncbxjd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxncbxjd4.Text != null)
            {
                try
                {
                    neicunheqiu.ncbxjd4 = Convert.ToInt32(textboxncbxjd4.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncbxjd4 = 25;
                }
            }
            Json.writejson("ncbxjd4", textboxncbxjd4.Text);
        }

        private void textboxncbxjcfd4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewncbx_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewncbx_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncbxyc1 = int.Parse(datagridviewncbx.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc2 = int.Parse(datagridviewncbx.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc3 = int.Parse(datagridviewncbx.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc4 = int.Parse(datagridviewncbx.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc5 = int.Parse(datagridviewncbx.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc6 = int.Parse(datagridviewncbx.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc7 = int.Parse(datagridviewncbx.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc8 = int.Parse(datagridviewncbx.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncbxyc1", neicunheqiu.ncbxyc1.ToString());
                Json.writejson("ncbxyc2", neicunheqiu.ncbxyc2.ToString());
                Json.writejson("ncbxyc3", neicunheqiu.ncbxyc3.ToString());
                Json.writejson("ncbxyc4", neicunheqiu.ncbxyc4.ToString());
                Json.writejson("ncbxyc5", neicunheqiu.ncbxyc5.ToString());
                Json.writejson("ncbxyc6", neicunheqiu.ncbxyc6.ToString());
                Json.writejson("ncbxyc7", neicunheqiu.ncbxyc7.ToString());
                Json.writejson("ncbxyc8", neicunheqiu.ncbxyc8.ToString());
            }
        }

        private void checkboxncbxtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxncbxtq.Checked)
            {
                neicunheqiu.ncbanxuantq = true;
                Json.writejson("ncbanxuantqflag", "true");
            }
            else
            {
                neicunheqiu.ncbanxuantq = false;
                Json.writejson("ncbanxuantqflag", "false");
            }
        }

        private void buttonncbxcz_Click(object sender, EventArgs e)
        {
            textboxncbxjcfd1.Text = "100";
            textboxncbxjcfd2.Text = "100";
            textboxncbxjcfd3.Text = "120";
            textboxncbxjcfd4.Text = "120";
            textboxncbxjd1.Text = "5";
            textboxncbxjd2.Text = "20";
            textboxncbxjd3.Text = "25";
            textboxncbxjd4.Text = "25";
            MessageBox.Show("重置参数成功");
        }
    }
}
