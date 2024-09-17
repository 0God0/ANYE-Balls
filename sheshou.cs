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
    public partial class sheshou : Form
    {
        public sheshou()
        {
            InitializeComponent();
        }

        private void sheshou_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("sheshoujian"))
            {
                comboboxsheshou.SelectedItem = "A";
            }
            else
            {
                comboboxsheshou.SelectedItem = Json.readjson("sheshoujian");
            }
            if (!Json.checkjson("ssjcfd1"))
            {
                textboxssjcfd1.Text = "135";
            }
            else
            {
                textboxssjcfd1.Text = Json.readjson("ssjcfd1");
            }
            if (!Json.checkjson("ssjcfd2"))
            {
                textboxssjcfd2.Text = "135";
            }
            else
            {
                textboxssjcfd2.Text = Json.readjson("ssjcfd2");
            }
            if (!Json.checkjson("ssjcfd3"))
            {
                textboxssjcfd3.Text = "100";
            }
            else
            {
                textboxssjcfd3.Text = Json.readjson("ssjcfd3");
            }
            if (!Json.checkjson("ssjcfd4"))
            {
                textboxssjcfd4.Text = "150";
            }
            else
            {
                textboxssjcfd4.Text = Json.readjson("ssjcfd4");
            }
            if (!Json.checkjson("ssjd1"))
            {
                textboxssjd1.Text = "0";
            }
            else
            {
                textboxssjd1.Text = Json.readjson("ssjd1");
            }
            if (!Json.checkjson("ssjd2"))
            {
                textboxssjd2.Text = "60";
            }
            else
            {
                textboxssjd2.Text = Json.readjson("ssjd2");
            }
            if (!Json.checkjson("ssjd3"))
            {
                textboxssjd3.Text = "-50";
            }
            else
            {
                textboxssjd3.Text = Json.readjson("ssjd3");
            }
            if (!Json.checkjson("ssjd4"))
            {
                textboxssjd4.Text = "0";
            }
            else
            {
                textboxssjd4.Text = Json.readjson("ssjd4");
            }
            if (!Json.checkjson("ssyc1"))
            {
                datagridviewss.Rows.Add("鼠标左键按下", 20);
                datagridviewss.Rows.Add("第一次拖动鼠标", 50);
                datagridviewss.Rows.Add("分身", 10);
                datagridviewss.Rows.Add("第二次拖动鼠标", 50);
                datagridviewss.Rows.Add("分身", 10);
                datagridviewss.Rows.Add("第三次拖动鼠标", 50);
                datagridviewss.Rows.Add("分身", 10);
                datagridviewss.Rows.Add("第四次拖动鼠标", 50);
                datagridviewss.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewss.Rows.Add("鼠标左键按下", Json.readjson("ssyc1"));
                datagridviewss.Rows.Add("第一次拖动鼠标", Json.readjson("ssyc2"));
                datagridviewss.Rows.Add("分身", Json.readjson("ssyc3"));
                datagridviewss.Rows.Add("第二次拖动鼠标", Json.readjson("ssyc4"));
                datagridviewss.Rows.Add("分身", Json.readjson("ssyc5"));
                datagridviewss.Rows.Add("第三次拖动鼠标", Json.readjson("ssyc6"));
                datagridviewss.Rows.Add("分身", Json.readjson("ssyc7"));
                datagridviewss.Rows.Add("第四次拖动鼠标", Json.readjson("ssyc8"));
                datagridviewss.Rows.Add("最后分身延迟", Json.readjson("ssyc9"));
            }
            zidongheqiu.sheshoujian = MainForm.GetVirtualKeyCode(comboboxsheshou.SelectedItem.ToString());
            try
            {
                zidongheqiu.ssjcfd1 = Convert.ToInt32(textboxssjcfd1.Text);
                zidongheqiu.ssjcfd2 = Convert.ToInt32(textboxssjcfd2.Text);
                zidongheqiu.ssjcfd3 = Convert.ToInt32(textboxssjcfd3.Text);
                zidongheqiu.ssjcfd4 = Convert.ToInt32(textboxssjcfd4.Text);
                zidongheqiu.ssjd1 = Convert.ToInt32(textboxssjd1.Text);
                zidongheqiu.ssjd2 = Convert.ToInt32(textboxssjd2.Text);
                zidongheqiu.ssjd3 = Convert.ToInt32(textboxssjd3.Text);
                zidongheqiu.ssjd4 = Convert.ToInt32(textboxssjd4.Text);
                zidongheqiu.ssyc1 = int.Parse(datagridviewss.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.ssyc2 = int.Parse(datagridviewss.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.ssyc3 = int.Parse(datagridviewss.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.ssyc4 = int.Parse(datagridviewss.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.ssyc5 = int.Parse(datagridviewss.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.ssyc6 = int.Parse(datagridviewss.Rows[5].Cells[1].Value.ToString());
                zidongheqiu.ssyc7 = int.Parse(datagridviewss.Rows[6].Cells[1].Value.ToString());
                zidongheqiu.ssyc8 = int.Parse(datagridviewss.Rows[7].Cells[1].Value.ToString());
                zidongheqiu.ssyc9 = int.Parse(datagridviewss.Rows[8].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("sheshou"))
            {
                if (Json.readjson("sheshou") == "true")
                {
                    checkboxsheshou.Checked = true;
                }
            }
        }

        private void comboboxsheshou_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxsheshou.SelectedItem != null)
            {
                zidongheqiu.sheshoujian = MainForm.GetVirtualKeyCode(comboboxsheshou.SelectedItem.ToString());
            }
            Json.writejson("sheshoujian", comboboxsheshou.SelectedItem.ToString());
        }

        private void checkboxsheshou_CheckedChanged(object sender, bool value)
        {
            if (checkboxsheshou.Checked)
            {
                Json.writejson("sheshou", "true");
                zidongheqiu.sheshouflag = true;
                zidongheqiu.sheshoujian = MainForm.GetVirtualKeyCode(comboboxsheshou.SelectedItem.ToString());
                try
                {
                    zidongheqiu.ssjcfd1 = Convert.ToInt32(textboxssjcfd1.Text);
                    zidongheqiu.ssjcfd2 = Convert.ToInt32(textboxssjcfd2.Text);
                    zidongheqiu.ssjcfd3 = Convert.ToInt32(textboxssjcfd3.Text);
                    zidongheqiu.ssjcfd4 = Convert.ToInt32(textboxssjcfd4.Text);
                    zidongheqiu.ssjd1 = Convert.ToInt32(textboxssjd1.Text);
                    zidongheqiu.ssjd2 = Convert.ToInt32(textboxssjd2.Text);
                    zidongheqiu.ssjd3 = Convert.ToInt32(textboxssjd3.Text);
                    zidongheqiu.ssjd4 = Convert.ToInt32(textboxssjd4.Text);
                    zidongheqiu.ssyc1 = int.Parse(datagridviewss.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.ssyc2 = int.Parse(datagridviewss.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.ssyc3 = int.Parse(datagridviewss.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.ssyc4 = int.Parse(datagridviewss.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.ssyc5 = int.Parse(datagridviewss.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.ssyc6 = int.Parse(datagridviewss.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.ssyc7 = int.Parse(datagridviewss.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.ssyc8 = int.Parse(datagridviewss.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.ssyc9 = int.Parse(datagridviewss.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ssyc1", zidongheqiu.ssyc1.ToString());
                Json.writejson("ssyc2", zidongheqiu.ssyc2.ToString());
                Json.writejson("ssyc3", zidongheqiu.ssyc3.ToString());
                Json.writejson("ssyc4", zidongheqiu.ssyc4.ToString());
                Json.writejson("ssyc5", zidongheqiu.ssyc5.ToString());
                Json.writejson("ssyc6", zidongheqiu.ssyc6.ToString());
                Json.writejson("ssyc7", zidongheqiu.ssyc7.ToString());
                Json.writejson("ssyc8", zidongheqiu.ssyc8.ToString());
                Json.writejson("ssyc9", zidongheqiu.ssyc9.ToString());
            }
            else
            {
                Json.writejson("sheshou", "false");
                zidongheqiu.sheshouflag = false;
            }
        }

        private void textboxssjcfd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjcfd1.Text != null)
            {
                try
                {
                    zidongheqiu.ssjcfd1 = Convert.ToInt32(textboxssjcfd1.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjcfd1 = 135;
                }
            }
            Json.writejson("ssjcfd1", textboxssjcfd1.Text);
        }

        private void textboxssjcfd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjcfd2.Text != null)
            {
                try
                {
                    zidongheqiu.ssjcfd2 = Convert.ToInt32(textboxssjcfd2.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjcfd2 = 135;
                }
            }
            Json.writejson("ssjcfd2", textboxssjcfd2.Text);
        }

        private void textboxssjcfd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjcfd3.Text != null)
            {
                try
                {
                    zidongheqiu.ssjcfd3 = Convert.ToInt32(textboxssjcfd3.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjcfd3 = 100;
                }
            }
            Json.writejson("ssjcfd3", textboxssjcfd3.Text);
        }

        private void textboxssjcfd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjcfd4.Text != null)
            {
                try
                {
                    zidongheqiu.ssjcfd4 = Convert.ToInt32(textboxssjcfd4.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjcfd4 = 150;
                }
            }
            Json.writejson("ssjcfd4", textboxssjcfd4.Text);
        }

        private void textboxssjd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjd1.Text != null)
            {
                try
                {
                    zidongheqiu.ssjd1 = Convert.ToInt32(textboxssjd1.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjd1 = 20;
                }
            }
            Json.writejson("ssjd1", textboxssjd1.Text);
        }

        private void textboxssjd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjd2.Text != null)
            {
                try
                {
                    zidongheqiu.ssjd2 = Convert.ToInt32(textboxssjd2.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjd2 = 25;
                }
            }
            Json.writejson("ssjd2", textboxssjd2.Text);
        }

        private void textboxssjd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjd3.Text != null)
            {
                try
                {
                    zidongheqiu.ssjd3 = Convert.ToInt32(textboxssjd3.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjd3 = 25;
                }
            }
            Json.writejson("ssjd3", textboxssjd3.Text);
        }

        private void textboxssjd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxssjd4.Text != null)
            {
                try
                {
                    zidongheqiu.ssjd4 = Convert.ToInt32(textboxssjd4.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.ssjd4 = 40;
                }
            }
            Json.writejson("ssjd4", textboxssjd4.Text);
        }

        private void datagridviewss_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void checkboxsstq_CheckedChanged(object sender, bool value)
        {
            if (checkboxsstq.Checked)
            {
                zidongheqiu.sheshoutqflag = true;
                Json.writejson("sheshoutqflag", "true");
            }
            else
            {
                zidongheqiu.sheshoutqflag = false;
                Json.writejson("sheshoutqflag", "false");
            }
        }

        private void datagridviewss_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.ssyc1 = int.Parse(datagridviewss.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.ssyc2 = int.Parse(datagridviewss.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.ssyc3 = int.Parse(datagridviewss.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.ssyc4 = int.Parse(datagridviewss.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.ssyc5 = int.Parse(datagridviewss.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.ssyc6 = int.Parse(datagridviewss.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.ssyc7 = int.Parse(datagridviewss.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.ssyc8 = int.Parse(datagridviewss.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.ssyc9 = int.Parse(datagridviewss.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ssyc1", zidongheqiu.ssyc1.ToString());
                Json.writejson("ssyc2", zidongheqiu.ssyc2.ToString());
                Json.writejson("ssyc3", zidongheqiu.ssyc3.ToString());
                Json.writejson("ssyc4", zidongheqiu.ssyc4.ToString());
                Json.writejson("ssyc5", zidongheqiu.ssyc5.ToString());
                Json.writejson("ssyc6", zidongheqiu.ssyc6.ToString());
                Json.writejson("ssyc7", zidongheqiu.ssyc7.ToString());
                Json.writejson("ssyc8", zidongheqiu.ssyc8.ToString());
                Json.writejson("ssyc9", zidongheqiu.ssyc9.ToString());
            }
        }

        private void textboxssjcfd2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void buttonsscz_Click(object sender, EventArgs e)
        {
            textboxssjcfd1.Text = "135";
            textboxssjcfd2.Text = "135";
            textboxssjcfd3.Text = "100";
            textboxssjcfd4.Text = "150";
            textboxssjd1.Text = "0";
            textboxssjd2.Text = "60";
            textboxssjd3.Text = "-50";
            textboxssjd4.Text = "0";
            MessageBox.Show("重置参数成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textboxssjcfd1.Text = "135";
            textboxssjcfd2.Text = "135";
            textboxssjcfd3.Text = "100";
            textboxssjcfd4.Text = "120";
            textboxssjd1.Text = "0";
            textboxssjd2.Text = "40";
            textboxssjd3.Text = "-20";
            textboxssjd4.Text = "-20";
            MessageBox.Show("重置参数为旋转蛇手成功");
        }
    }
}
