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
    public partial class zhongfencehe : Form
    {
        public zhongfencehe()
        {
            InitializeComponent();
        }

        private void zhongfencehe_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("yuandijian"))
            {
                comboboxzhongfencehe.SelectedItem = "A";
            }
            else
            {
                comboboxzhongfencehe.SelectedItem = Json.readjson("yuandijian");
            }
            if (!Json.checkjson("ydjcfd"))
            {
                textboxzfchjcfd.Text = "100";
            }
            else
            {
                textboxzfchjcfd.Text = Json.readjson("ydjcfd");
            }
            if (!Json.checkjson("ydhqyc1"))
            {
                datagridviewzfch.Rows.Add("第一次拖动鼠标", 50);
                datagridviewzfch.Rows.Add("分身", 10);
                datagridviewzfch.Rows.Add("第二次拖动鼠标", 50);
                datagridviewzfch.Rows.Add("分身", 10);
                datagridviewzfch.Rows.Add("第三次拖动鼠标", 50);
                datagridviewzfch.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewzfch.Rows.Add("第一次拖动鼠标", Json.readjson("ydhqyc1"));
                datagridviewzfch.Rows.Add("分身", Json.readjson("ydhqyc2"));
                datagridviewzfch.Rows.Add("第二次拖动鼠标", Json.readjson("ydhqyc3"));
                datagridviewzfch.Rows.Add("分身", Json.readjson("ydhqyc4"));
                datagridviewzfch.Rows.Add("第三次拖动鼠标", Json.readjson("ydhqyc5"));
                datagridviewzfch.Rows.Add("最后分身延迟", Json.readjson("ydhqyc6"));
            }
            zidongheqiu.yuandiheqiujian = MainForm.GetVirtualKeyCode(comboboxzhongfencehe.SelectedItem.ToString());
            try
            {
                zidongheqiu.yuandiheqiujcfd = Convert.ToInt32(textboxzfchjcfd.Text);
                zidongheqiu.ydhqyc1 = int.Parse(datagridviewzfch.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.ydhqyc2 = int.Parse(datagridviewzfch.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.ydhqyc3 = int.Parse(datagridviewzfch.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.ydhqyc4 = int.Parse(datagridviewzfch.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.ydhqyc5 = int.Parse(datagridviewzfch.Rows[4].Cells[1].Value.ToString());
                zidongheqiu.ydhqyc6 = int.Parse(datagridviewzfch.Rows[5].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("yuandi"))
            {
                if (Json.readjson("yuandi") == "true")
                {
                    checkboxzhongfencehe.Checked = true;
                }
            }
        }

        private void comboboxzhongfencehe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxzhongfencehe.SelectedItem != null)
            {
                zidongheqiu.yuandiheqiujian = MainForm.GetVirtualKeyCode(comboboxzhongfencehe.SelectedItem.ToString());
            }
            Json.writejson("yuandijian", comboboxzhongfencehe.SelectedItem.ToString());
        }

        private void checkboxzhongfencehe_CheckedChanged(object sender, bool value)
        {
            if (checkboxzhongfencehe.Checked)
            {
                Json.writejson("yuandi", "true");
                zidongheqiu.yuandiheqiuflag = true;
                zidongheqiu.yuandiheqiujian = MainForm.GetVirtualKeyCode(comboboxzhongfencehe.SelectedItem.ToString());
                try
                {
                    zidongheqiu.yuandiheqiujcfd = Convert.ToInt32(textboxzfchjcfd.Text);
                    zidongheqiu.ydhqyc1 = int.Parse(datagridviewzfch.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc2 = int.Parse(datagridviewzfch.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc3 = int.Parse(datagridviewzfch.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc4 = int.Parse(datagridviewzfch.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc5 = int.Parse(datagridviewzfch.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc6 = int.Parse(datagridviewzfch.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ydhqyc1", zidongheqiu.ydhqyc1.ToString());
                Json.writejson("ydhqyc2", zidongheqiu.ydhqyc2.ToString());
                Json.writejson("ydhqyc3", zidongheqiu.ydhqyc3.ToString());
                Json.writejson("ydhqyc4", zidongheqiu.ydhqyc4.ToString());
                Json.writejson("ydhqyc5", zidongheqiu.ydhqyc5.ToString());
                Json.writejson("ydhqyc6", zidongheqiu.ydhqyc6.ToString());
            }
            else
            {
                Json.writejson("yuandi", "false");
                zidongheqiu.yuandiheqiuflag = false;
            }
        }

        private void textboxzfchjcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxzfchjcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxzfchjcfd.Text != null)
            {
                try
                {
                    zidongheqiu.yuandiheqiujcfd = Convert.ToInt32(textboxzfchjcfd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.yuandiheqiujcfd = 100;
                }
            }
            Json.writejson("ydjcfd", textboxzfchjcfd.Text);
        }

        private void datagridviewzfch_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewzfch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.ydhqyc1 = int.Parse(datagridviewzfch.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc2 = int.Parse(datagridviewzfch.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc3 = int.Parse(datagridviewzfch.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc4 = int.Parse(datagridviewzfch.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc5 = int.Parse(datagridviewzfch.Rows[4].Cells[1].Value.ToString());
                    zidongheqiu.ydhqyc6 = int.Parse(datagridviewzfch.Rows[5].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ydhqyc1", zidongheqiu.ydhqyc1.ToString());
                Json.writejson("ydhqyc2", zidongheqiu.ydhqyc2.ToString());
                Json.writejson("ydhqyc3", zidongheqiu.ydhqyc3.ToString());
                Json.writejson("ydhqyc4", zidongheqiu.ydhqyc4.ToString());
                Json.writejson("ydhqyc5", zidongheqiu.ydhqyc5.ToString());
                Json.writejson("ydhqyc6", zidongheqiu.ydhqyc6.ToString());
            }
        }

        private void checkboxzfchtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxzfchtq.Checked)
            {
                zidongheqiu.yuandiheqiutqflag = true;
                Json.writejson("yuandiheqiutqflag", "true");
            }
            else
            {
                zidongheqiu.yuandiheqiutqflag = false;
                Json.writejson("yuandiheqiutqflag", "false");
            }
        }

        private void buttonzfchcz_Click(object sender, EventArgs e)
        {
            textboxzfchjcfd.Text = "100";
            MessageBox.Show("重置参数成功");
        }
    }
}
