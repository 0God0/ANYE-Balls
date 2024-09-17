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
    public partial class banxuan : Form
    {
        public banxuan()
        {
            InitializeComponent();
        }

        private void banxuan_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("banxuanjian"))
            {
                comboboxbanxuan.SelectedItem = "A";
            }
            else
            {
                comboboxbanxuan.SelectedItem = Json.readjson("banxuanjian");
            }
            if (!Json.checkjson("bxjcfd1"))
            {
                textboxbxjcfd1.Text = "100";
            }
            else
            {
                textboxbxjcfd1.Text = Json.readjson("bxjcfd1");
            }
            if (!Json.checkjson("bxjcfd2"))
            {
                textboxbxjcfd2.Text = "100";
            }
            else
            {
                textboxbxjcfd2.Text = Json.readjson("bxjcfd2");
            }
            if (!Json.checkjson("bxjcfd3"))
            {
                textboxbxjcfd3.Text = "120";
            }
            else
            {
                textboxbxjcfd3.Text = Json.readjson("bxjcfd3");
            }
            if (!Json.checkjson("bxjcfd4"))
            {
                textboxbxjcfd4.Text = "120";
            }
            else
            {
                textboxbxjcfd4.Text = Json.readjson("bxjcfd4");
            }
            if (!Json.checkjson("bxjd1"))
            {
                textboxbxjd1.Text = "5";
            }
            else
            {
                textboxbxjd1.Text = Json.readjson("bxjd1");
            }
            if (!Json.checkjson("bxjd2"))
            {
                textboxbxjd2.Text = "20";
            }
            else
            {
                textboxbxjd2.Text = Json.readjson("bxjd2");
            }
            if (!Json.checkjson("bxjd3"))
            {
                textboxbxjd3.Text = "25";
            }
            else
            {
                textboxbxjd3.Text = Json.readjson("bxjd3");
            }
            if (!Json.checkjson("bxjd4"))
            {
                textboxbxjd4.Text = "25";
            }
            else
            {
                textboxbxjd4.Text = Json.readjson("bxjd4");
            }
            if (!Json.checkjson("bxyc1"))
            {
                datagridviewbx.Rows.Add("鼠标左键按下", 20);
                datagridviewbx.Rows.Add("第一次拖动鼠标", 50);
                datagridviewbx.Rows.Add("分身", 10);
                datagridviewbx.Rows.Add("第二次拖动鼠标", 50);
                datagridviewbx.Rows.Add("分身", 10);
                datagridviewbx.Rows.Add("第三次拖动鼠标", 50);
                datagridviewbx.Rows.Add("分身", 10);
                datagridviewbx.Rows.Add("第四次拖动鼠标", 50);
                datagridviewbx.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewbx.Rows.Add("鼠标左键按下", Json.readjson("bxyc1"));
                datagridviewbx.Rows.Add("第一次拖动鼠标", Json.readjson("bxyc2"));
                datagridviewbx.Rows.Add("分身", Json.readjson("bxyc3"));
                datagridviewbx.Rows.Add("第二次拖动鼠标", Json.readjson("bxyc4"));
                datagridviewbx.Rows.Add("分身", Json.readjson("bxyc5"));
                datagridviewbx.Rows.Add("第三次拖动鼠标", Json.readjson("bxyc6"));
                datagridviewbx.Rows.Add("分身", Json.readjson("bxyc7"));
                datagridviewbx.Rows.Add("第四次拖动鼠标", Json.readjson("bxyc8"));
                datagridviewbx.Rows.Add("最后分身延迟", Json.readjson("bxyc9"));
            }
            zidongheqiu.banxuanjian = MainForm.GetVirtualKeyCode(comboboxbanxuan.SelectedItem.ToString());
            try
            {
                zidongheqiu.bxjcfd1 = Convert.ToInt32(textboxbxjcfd1.Text);
                zidongheqiu.bxjcfd2 = Convert.ToInt32(textboxbxjcfd2.Text);
                zidongheqiu.bxjcfd3 = Convert.ToInt32(textboxbxjcfd3.Text);
                zidongheqiu.bxjcfd4 = Convert.ToInt32(textboxbxjcfd4.Text);
                zidongheqiu.bxjd1 = Convert.ToInt32(textboxbxjd1.Text);
                zidongheqiu.bxjd2 = Convert.ToInt32(textboxbxjd2.Text);
                zidongheqiu.bxjd3 = Convert.ToInt32(textboxbxjd3.Text);
                zidongheqiu.bxjd4 = Convert.ToInt32(textboxbxjd4.Text);
                zidongheqiu.bxyc1 = int.Parse(datagridviewbx.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.bxyc2 = int.Parse(datagridviewbx.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.bxyc3 = int.Parse(datagridviewbx.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.bxyc4 = int.Parse(datagridviewbx.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.bxyc5 = int.Parse(datagridviewbx.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.bxyc6 = int.Parse(datagridviewbx.Rows[5].Cells[1].Value.ToString());
                zidongheqiu.bxyc7 = int.Parse(datagridviewbx.Rows[6].Cells[1].Value.ToString());
                zidongheqiu.bxyc8 = int.Parse(datagridviewbx.Rows[7].Cells[1].Value.ToString());
                zidongheqiu.bxyc9 = int.Parse(datagridviewbx.Rows[8].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("banxuan"))
            {
                if (Json.readjson("banxuan") == "true")
                {
                    checkboxbanxuan.Checked = true;
                }
            }
        }

        private void comboboxbanxuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxbanxuan.SelectedItem != null)
            {
                zidongheqiu.banxuanjian = MainForm.GetVirtualKeyCode(comboboxbanxuan.SelectedItem.ToString());
            }
            Json.writejson("banxuanjian", comboboxbanxuan.SelectedItem.ToString());
        }

        private void checkboxbanxuan_CheckedChanged(object sender, bool value)
        {
            if (checkboxbanxuan.Checked)
            {
                Json.writejson("banxuan", "true");
                zidongheqiu.banxuanflag = true;
                zidongheqiu.banxuanjian = MainForm.GetVirtualKeyCode(comboboxbanxuan.SelectedItem.ToString());
                try
                {
                    zidongheqiu.bxjcfd1 = Convert.ToInt32(textboxbxjcfd1.Text);
                    zidongheqiu.bxjcfd2 = Convert.ToInt32(textboxbxjcfd2.Text);
                    zidongheqiu.bxjcfd3 = Convert.ToInt32(textboxbxjcfd3.Text);
                    zidongheqiu.bxjcfd4 = Convert.ToInt32(textboxbxjcfd4.Text);
                    zidongheqiu.bxjd1 = Convert.ToInt32(textboxbxjd1.Text);
                    zidongheqiu.bxjd2 = Convert.ToInt32(textboxbxjd2.Text);
                    zidongheqiu.bxjd3 = Convert.ToInt32(textboxbxjd3.Text);
                    zidongheqiu.bxjd4 = Convert.ToInt32(textboxbxjd4.Text);
                    zidongheqiu.bxyc1 = int.Parse(datagridviewbx.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.bxyc2 = int.Parse(datagridviewbx.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.bxyc3 = int.Parse(datagridviewbx.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.bxyc4 = int.Parse(datagridviewbx.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.bxyc5 = int.Parse(datagridviewbx.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.bxyc6 = int.Parse(datagridviewbx.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.bxyc7 = int.Parse(datagridviewbx.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.bxyc8 = int.Parse(datagridviewbx.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.bxyc9 = int.Parse(datagridviewbx.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("bxyc1", zidongheqiu.bxyc1.ToString());
                Json.writejson("bxyc2", zidongheqiu.bxyc2.ToString());
                Json.writejson("bxyc3", zidongheqiu.bxyc3.ToString());
                Json.writejson("bxyc4", zidongheqiu.bxyc4.ToString());
                Json.writejson("bxyc5", zidongheqiu.bxyc5.ToString());
                Json.writejson("bxyc6", zidongheqiu.bxyc6.ToString());
                Json.writejson("bxyc7", zidongheqiu.bxyc7.ToString());
                Json.writejson("bxyc8", zidongheqiu.bxyc8.ToString());
                Json.writejson("bxyc9", zidongheqiu.bxyc9.ToString());
            }
            else
            {
                Json.writejson("banxuan", "false");
                zidongheqiu.banxuanflag = false;
            }
        }

        private void textboxbxjcfd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjcfd1.Text != null)
            {
                try
                {
                    zidongheqiu.bxjcfd1 = Convert.ToInt32(textboxbxjcfd1.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjcfd1 = 100;
                }
            }
            Json.writejson("bxjcfd1", textboxbxjcfd1.Text);
        }

        private void textboxbxjcfd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjcfd2.Text != null)
            {
                try
                {
                    zidongheqiu.bxjcfd2 = Convert.ToInt32(textboxbxjcfd2.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjcfd2 = 100;
                }
            }
            Json.writejson("bxjcfd2", textboxbxjcfd2.Text);
        }

        private void textboxbxjcfd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjcfd3.Text != null)
            {
                try
                {
                    zidongheqiu.bxjcfd3 = Convert.ToInt32(textboxbxjcfd3.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjcfd3 = 120;
                }
            }
            Json.writejson("bxjcfd3", textboxbxjcfd3.Text);
        }

        private void textboxbxjcfd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjcfd4.Text != null)
            {
                try
                {
                    zidongheqiu.bxjcfd4 = Convert.ToInt32(textboxbxjcfd4.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjcfd4 = 120;
                }
            }
            Json.writejson("bxjcfd4", textboxbxjcfd4.Text);
        }

        private void textboxbxjd1_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjd1.Text != null)
            {
                try
                {
                    zidongheqiu.bxjd1 = Convert.ToInt32(textboxbxjd1.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjd1 = 5;
                }
            }
            Json.writejson("bxjd1", textboxbxjd1.Text);
        }

        private void textboxbxjd2_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjd2.Text != null)
            {
                try
                {
                    zidongheqiu.bxjd2 = Convert.ToInt32(textboxbxjd2.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjd2 = 20;
                }
            }
            Json.writejson("bxjd2", textboxbxjd2.Text);
        }

        private void textboxbxjd3_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjd3.Text != null)
            {
                try
                {
                    zidongheqiu.bxjd3 = Convert.ToInt32(textboxbxjd3.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjd3 = 25;
                }
            }
            Json.writejson("bxjd3", textboxbxjd3.Text);
        }

        private void textboxbxjd4_TextChanged(object sender, EventArgs e)
        {
            if (textboxbxjd4.Text != null)
            {
                try
                {
                    zidongheqiu.bxjd4 = Convert.ToInt32(textboxbxjd4.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.bxjd4 = 25;
                }
            }
            Json.writejson("bxjd4", textboxbxjd4.Text);
        }

        private void textboxbxjcfd4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewbx_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewbx_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.bxyc1 = int.Parse(datagridviewbx.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.bxyc2 = int.Parse(datagridviewbx.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.bxyc3 = int.Parse(datagridviewbx.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.bxyc4 = int.Parse(datagridviewbx.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.bxyc5 = int.Parse(datagridviewbx.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.bxyc6 = int.Parse(datagridviewbx.Rows[5].Cells[1].Value.ToString());
                    zidongheqiu.bxyc7 = int.Parse(datagridviewbx.Rows[6].Cells[1].Value.ToString());
                    zidongheqiu.bxyc8 = int.Parse(datagridviewbx.Rows[7].Cells[1].Value.ToString());
                    zidongheqiu.bxyc9 = int.Parse(datagridviewbx.Rows[8].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("bxyc1", zidongheqiu.bxyc1.ToString());
                Json.writejson("bxyc2", zidongheqiu.bxyc2.ToString());
                Json.writejson("bxyc3", zidongheqiu.bxyc3.ToString());
                Json.writejson("bxyc4", zidongheqiu.bxyc4.ToString());
                Json.writejson("bxyc5", zidongheqiu.bxyc5.ToString());
                Json.writejson("bxyc6", zidongheqiu.bxyc6.ToString());
                Json.writejson("bxyc7", zidongheqiu.bxyc7.ToString());
                Json.writejson("bxyc8", zidongheqiu.bxyc8.ToString());
                Json.writejson("bxyc9", zidongheqiu.bxyc9.ToString());
            }
        }

        private void checkboxbxtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxbxtq.Checked)
            {
                zidongheqiu.banxuantqflag = true;
                Json.writejson("banxuantqflag", "true");
            }
            else
            {
                zidongheqiu.banxuantqflag = false;
                Json.writejson("banxuantqflag", "false");
            }
        }

        private void buttonbxcz_Click(object sender, EventArgs e)
        {
            textboxbxjcfd1.Text = "100";
            textboxbxjcfd2.Text = "100";
            textboxbxjcfd3.Text = "120";
            textboxbxjcfd4.Text = "120";
            textboxbxjd1.Text = "5";
            textboxbxjd2.Text = "20";
            textboxbxjd3.Text = "25";
            textboxbxjd4.Text = "25";
            MessageBox.Show("重置参数成功");
        }
    }
}
