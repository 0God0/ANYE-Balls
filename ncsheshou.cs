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
    public partial class ncsheshou : Form
    {
        public ncsheshou()
        {
            InitializeComponent();
        }

        private void ncsheshou_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("ncsheshoujian"))
            {
                comboboxncsheshou.SelectedItem = "A";
            }
            else
            {
                comboboxncsheshou.SelectedItem = Json.readjson("ncsheshoujian");
            }
            if (!Json.checkjson("ncssjcfd1"))
            {
                textboxncssjcfd1.Text = "135";
            }
            else
            {
                textboxncssjcfd1.Text = Json.readjson("ncssjcfd1");
            }
            if (!Json.checkjson("ncssjcfd2"))
            {
                textboxncssjcfd2.Text = "135";
            }
            else
            {
                textboxncssjcfd2.Text = Json.readjson("ncssjcfd2");
            }
            if (!Json.checkjson("ncssjcfd3"))
            {
                textboxncssjcfd3.Text = "100";
            }
            else
            {
                textboxncssjcfd3.Text = Json.readjson("ncssjcfd3");
            }
            if (!Json.checkjson("ncssjcfd4"))
            {
                textboxncssjcfd4.Text = "150";
            }
            else
            {
                textboxncssjcfd4.Text = Json.readjson("ncssjcfd4");
            }
            if (!Json.checkjson("ncssjd1"))
            {
                textboxncssjd1.Text = "0";
            }
            else
            {
                textboxncssjd1.Text = Json.readjson("ncssjd1");
            }
            if (!Json.checkjson("ncssjd2"))
            {
                textboxncssjd2.Text = "60";
            }
            else
            {
                textboxncssjd2.Text = Json.readjson("ncssjd2");
            }
            if (!Json.checkjson("ncssjd3"))
            {
                textboxncssjd3.Text = "-50";
            }
            else
            {
                textboxncssjd3.Text = Json.readjson("ncssjd3");
            }
            if (!Json.checkjson("ncssjd4"))
            {
                textboxncssjd4.Text = "0";
            }
            else
            {
                textboxncssjd4.Text = Json.readjson("ncssjd4");
            }
            if (!Json.checkjson("ncssyc1"))
            {
                datagridviewncss.Rows.Add("第一次拖动鼠标", 50);
                datagridviewncss.Rows.Add("分身", 10);
                datagridviewncss.Rows.Add("第二次拖动鼠标", 50);
                datagridviewncss.Rows.Add("分身", 10);
                datagridviewncss.Rows.Add("第三次拖动鼠标", 50);
                datagridviewncss.Rows.Add("分身", 10);
                datagridviewncss.Rows.Add("第四次拖动鼠标", 50);
                datagridviewncss.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewncss.Rows.Add("第一次拖动鼠标", Json.readjson("ncssyc1"));
                datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc2"));
                datagridviewncss.Rows.Add("第二次拖动鼠标", Json.readjson("ncssyc3"));
                datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc4"));
                datagridviewncss.Rows.Add("第三次拖动鼠标", Json.readjson("ncssyc5"));
                datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc6"));
                datagridviewncss.Rows.Add("第四次拖动鼠标", Json.readjson("ncssyc7"));
                datagridviewncss.Rows.Add("最后分身延迟", Json.readjson("ncssyc8"));
            }
            neicunheqiu.ncsheshoujian = MainForm.GetVirtualKeyCode(comboboxncsheshou.SelectedItem.ToString());
            try
            {
                neicunheqiu.ncssjcfd1 = Convert.ToInt32(textboxncssjcfd1.Text);
                neicunheqiu.ncssjcfd2 = Convert.ToInt32(textboxncssjcfd2.Text);
                neicunheqiu.ncssjcfd3 = Convert.ToInt32(textboxncssjcfd3.Text);
                neicunheqiu.ncssjcfd4 = Convert.ToInt32(textboxncssjcfd4.Text);
                neicunheqiu.ncssjd1 = Convert.ToInt32(textboxncssjd1.Text);
                neicunheqiu.ncssjd2 = Convert.ToInt32(textboxncssjd2.Text);
                neicunheqiu.ncssjd3 = Convert.ToInt32(textboxncssjd3.Text);
                neicunheqiu.ncssjd4 = Convert.ToInt32(textboxncssjd4.Text);
                neicunheqiu.ncssyc1 = int.Parse(datagridviewncss.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncssyc2 = int.Parse(datagridviewncss.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncssyc3 = int.Parse(datagridviewncss.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncssyc4 = int.Parse(datagridviewncss.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.ncssyc5 = int.Parse(datagridviewncss.Rows[4].Cells[1].Value.ToString());
                neicunheqiu.ncssyc6 = int.Parse(datagridviewncss.Rows[5].Cells[1].Value.ToString());
                neicunheqiu.ncssyc7 = int.Parse(datagridviewncss.Rows[6].Cells[1].Value.ToString());
                neicunheqiu.ncssyc8 = int.Parse(datagridviewncss.Rows[7].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("ncsheshou"))
            {
                if (Json.readjson("ncsheshou") == "true")
                {
                    checkboxncsheshou.Checked = true;
                }
            }
        }

        private void comboboxncsheshou_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxncsheshou.SelectedItem != null)
            {
                neicunheqiu.ncsheshoujian = MainForm.GetVirtualKeyCode(comboboxncsheshou.SelectedItem.ToString());
            }
            Json.writejson("ncsheshoujian", comboboxncsheshou.SelectedItem.ToString());
        }

        private void checkboxncsheshou_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsheshou.Checked)
            {
                Json.writejson("ncsheshou", "true");
                neicunheqiu.ncsheshouflag = true;
                neicunheqiu.ncsheshoujian = MainForm.GetVirtualKeyCode(comboboxncsheshou.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncssjcfd1 = Convert.ToInt32(textboxncssjcfd1.Text);
                    neicunheqiu.ncssjcfd2 = Convert.ToInt32(textboxncssjcfd2.Text);
                    neicunheqiu.ncssjcfd3 = Convert.ToInt32(textboxncssjcfd3.Text);
                    neicunheqiu.ncssjcfd4 = Convert.ToInt32(textboxncssjcfd4.Text);
                    neicunheqiu.ncssjd1 = Convert.ToInt32(textboxncssjd1.Text);
                    neicunheqiu.ncssjd2 = Convert.ToInt32(textboxncssjd2.Text);
                    neicunheqiu.ncssjd3 = Convert.ToInt32(textboxncssjd3.Text);
                    neicunheqiu.ncssjd4 = Convert.ToInt32(textboxncssjd4.Text);
                    neicunheqiu.ncssyc1 = int.Parse(datagridviewncss.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc2 = int.Parse(datagridviewncss.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc3 = int.Parse(datagridviewncss.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc4 = int.Parse(datagridviewncss.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc5 = int.Parse(datagridviewncss.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc6 = int.Parse(datagridviewncss.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc7 = int.Parse(datagridviewncss.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc8 = int.Parse(datagridviewncss.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncssyc1", neicunheqiu.ncssyc1.ToString());
                Json.writejson("ncssyc2", neicunheqiu.ncssyc2.ToString());
                Json.writejson("ncssyc3", neicunheqiu.ncssyc3.ToString());
                Json.writejson("ncssyc4", neicunheqiu.ncssyc4.ToString());
                Json.writejson("ncssyc5", neicunheqiu.ncssyc5.ToString());
                Json.writejson("ncssyc6", neicunheqiu.ncssyc6.ToString());
                Json.writejson("ncssyc7", neicunheqiu.ncssyc7.ToString());
                Json.writejson("ncssyc8", neicunheqiu.ncssyc8.ToString());
            }
            else
            {
                Json.writejson("ncsheshou", "false");
                neicunheqiu.ncsheshouflag = false;
            }
        }

        private void textboxncssjcfd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjcfd1.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjcfd1 = Convert.ToInt32(textboxncssjcfd1.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjcfd1 = 135;
                }
            }
            Json.writejson("ncssjcfd1", textboxncssjcfd1.Text);
        }

        private void textboxncssjcfd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjcfd2.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjcfd2 = Convert.ToInt32(textboxncssjcfd2.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjcfd2 = 135;
                }
            }
            Json.writejson("ncssjcfd2", textboxncssjcfd2.Text);
        }

        private void textboxncssjcfd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjcfd3.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjcfd3 = Convert.ToInt32(textboxncssjcfd3.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjcfd3 = 100;
                }
            }
            Json.writejson("ncssjcfd3", textboxncssjcfd3.Text);
        }

        private void textboxncssjcfd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjcfd4.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjcfd4 = Convert.ToInt32(textboxncssjcfd4.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjcfd4 = 150;
                }
            }
            Json.writejson("ncssjcfd4", textboxncssjcfd4.Text);
        }

        private void textboxncssjd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjd1.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjd1 = Convert.ToInt32(textboxncssjd1.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjd1 = 20;
                }
            }
            Json.writejson("ncssjd1", textboxncssjd1.Text);
        }

        private void textboxncssjd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjd2.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjd2 = Convert.ToInt32(textboxncssjd2.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjd2 = 25;
                }
            }
            Json.writejson("ncssjd2", textboxncssjd2.Text);
        }

        private void textboxncssjd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjd3.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjd3 = Convert.ToInt32(textboxncssjd3.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjd3 = 25;
                }
            }
            Json.writejson("ncssjd3", textboxncssjd3.Text);
        }

        private void textboxncssjd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxncssjd4.Text != null)
            {
                try
                {
                    neicunheqiu.ncssjd4 = Convert.ToInt32(textboxncssjd4.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncssjd4 = 40;
                }
            }
            Json.writejson("ncssjd4", textboxncssjd4.Text);
        }

        private void datagridviewncss_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void checkboxncsstq_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsstq.Checked)
            {
                neicunheqiu.ncsheshoutq = true;
                Json.writejson("ncsheshoutqflag", "true");
            }
            else
            {
                neicunheqiu.ncsheshoutq = false;
                Json.writejson("ncsheshoutqflag", "false");
            }
        }

        private void datagridviewncss_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncssyc1 = int.Parse(datagridviewncss.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc2 = int.Parse(datagridviewncss.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc3 = int.Parse(datagridviewncss.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc4 = int.Parse(datagridviewncss.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc5 = int.Parse(datagridviewncss.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc6 = int.Parse(datagridviewncss.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc7 = int.Parse(datagridviewncss.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc8 = int.Parse(datagridviewncss.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncssyc1", neicunheqiu.ncssyc1.ToString());
                Json.writejson("ncssyc2", neicunheqiu.ncssyc2.ToString());
                Json.writejson("ncssyc3", neicunheqiu.ncssyc3.ToString());
                Json.writejson("ncssyc4", neicunheqiu.ncssyc4.ToString());
                Json.writejson("ncssyc5", neicunheqiu.ncssyc5.ToString());
                Json.writejson("ncssyc6", neicunheqiu.ncssyc6.ToString());
                Json.writejson("ncssyc7", neicunheqiu.ncssyc7.ToString());
                Json.writejson("ncssyc8", neicunheqiu.ncssyc8.ToString());
            }
        }

        private void textboxncssjcfd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void buttonncsscz_Click(object sender, EventArgs e)
        {
            textboxncssjcfd1.Text = "135";
            textboxncssjcfd2.Text = "135";
            textboxncssjcfd3.Text = "100";
            textboxncssjcfd4.Text = "150";
            textboxncssjd1.Text = "0";
            textboxncssjd2.Text = "60";
            textboxncssjd3.Text = "-50";
            textboxncssjd4.Text = "0";
            MessageBox.Show("重置参数成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textboxncssjcfd1.Text = "135";
            textboxncssjcfd2.Text = "135";
            textboxncssjcfd3.Text = "100";
            textboxncssjcfd4.Text = "120";
            textboxncssjd1.Text = "0";
            textboxncssjd2.Text = "40";
            textboxncssjd3.Text = "-20";
            textboxncssjd4.Text = "-20";
            MessageBox.Show("重置参数为旋转蛇手成功");
        }
    }
}
