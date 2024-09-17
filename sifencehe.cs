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
    public partial class sifencehe : Form
    {
        public sifencehe()
        {
            InitializeComponent();
        }

        private void sifencehe_Load(object sender, EventArgs e)
        {

            if (!Json.checkjson("sifencehejian"))
            {
                comboboxsifencehe.SelectedItem = "A";
            }
            else
            {
                comboboxsifencehe.SelectedItem = Json.readjson("sifencehejian");
            }
            if (!Json.checkjson("sfchjcfd"))
            {
                textboxsfchjcfd.Text = "100";
            }
            else
            {
                textboxsfchjcfd.Text = Json.readjson("sfchjcfd");
            }
            if (!Json.checkjson("sfchyc1"))
            {
                datagridviewsfch.Rows.Add("分身", 10);
                datagridviewsfch.Rows.Add("分身", 10);
                datagridviewsfch.Rows.Add("第一次拖动鼠标", 50);
                datagridviewsfch.Rows.Add("第二次拖动鼠标", 50);
                datagridviewsfch.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewsfch.Rows.Add("分身", Json.readjson("sfchyc1"));
                datagridviewsfch.Rows.Add("分身", Json.readjson("sfchyc2"));
                datagridviewsfch.Rows.Add("第一次拖动鼠标", Json.readjson("sfchyc3"));
                datagridviewsfch.Rows.Add("第二次拖动鼠标", Json.readjson("sfchyc4"));
                datagridviewsfch.Rows.Add("最后分身延迟", Json.readjson("sfchyc5"));
            }
            zidongheqiu.sifencehejian = MainForm.GetVirtualKeyCode(comboboxsifencehe.SelectedItem.ToString());
            try
            {
                zidongheqiu.sifencehejcfd = Convert.ToInt32(textboxsfchjcfd.Text);
                zidongheqiu.sfchyc1 = int.Parse(datagridviewsfch.Rows[0].Cells[1].Value.ToString());
                zidongheqiu.sfchyc2 = int.Parse(datagridviewsfch.Rows[1].Cells[1].Value.ToString());
                zidongheqiu.sfchyc3 = int.Parse(datagridviewsfch.Rows[2].Cells[1].Value.ToString());
                zidongheqiu.sfchyc4 = int.Parse(datagridviewsfch.Rows[3].Cells[1].Value.ToString());
                zidongheqiu.sfchyc5 = int.Parse(datagridviewsfch.Rows[4].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("sifencehe"))
            {
                if (Json.readjson("sifencehe") == "true")
                {
                    checkboxsifencehe.Checked = true;
                }
            }

        }

        private void comboboxsifencehe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxsifencehe.SelectedItem != null)
            {
                zidongheqiu.sifencehejian = MainForm.GetVirtualKeyCode(comboboxsifencehe.SelectedItem.ToString());
            }
            Json.writejson("sifencehejian", comboboxsifencehe.SelectedItem.ToString());
        }

        private void checkboxsifencehe_CheckedChanged(object sender, bool value)
        {
            if (checkboxsifencehe.Checked)
            {
                Json.writejson("sifencehe", "true");
                zidongheqiu.sifenceheflag = true;
                zidongheqiu.sifencehejian = MainForm.GetVirtualKeyCode(comboboxsifencehe.SelectedItem.ToString());
                try
                {
                    zidongheqiu.sifencehejcfd = Convert.ToInt32(textboxsfchjcfd.Text);
                    zidongheqiu.sfchyc1 = int.Parse(datagridviewsfch.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc2 = int.Parse(datagridviewsfch.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc3 = int.Parse(datagridviewsfch.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc4 = int.Parse(datagridviewsfch.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc5 = int.Parse(datagridviewsfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("sfchyc1", zidongheqiu.sfchyc1.ToString());
                Json.writejson("sfchyc2", zidongheqiu.sfchyc2.ToString());
                Json.writejson("sfchyc3", zidongheqiu.sfchyc3.ToString());
                Json.writejson("sfchyc4", zidongheqiu.sfchyc4.ToString());
                Json.writejson("sfchyc5", zidongheqiu.sfchyc5.ToString());
            }
            else
            {
                Json.writejson("sifencehe", "false");
                zidongheqiu.sifenceheflag = false;
            }
        }

        private void textboxsfchjcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxsfchjcfd.Text != null)
            {
                try
                {
                    zidongheqiu.sifencehejcfd = Convert.ToInt32(textboxsfchjcfd.Text);
                }
                catch (Exception ex)
                {
                    zidongheqiu.sifencehejcfd = 100;
                }
            }
            Json.writejson("sfchjcfd", textboxsfchjcfd.Text);
        }

        private void textboxsfchjcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewsfch_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewsfch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    zidongheqiu.sfchyc1 = int.Parse(datagridviewsfch.Rows[0].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc2 = int.Parse(datagridviewsfch.Rows[1].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc3 = int.Parse(datagridviewsfch.Rows[2].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc4 = int.Parse(datagridviewsfch.Rows[3].Cells[1].Value.ToString());
                    zidongheqiu.sfchyc5 = int.Parse(datagridviewsfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("sfchyc1", zidongheqiu.sfchyc1.ToString());
                Json.writejson("sfchyc2", zidongheqiu.sfchyc2.ToString());
                Json.writejson("sfchyc3", zidongheqiu.sfchyc3.ToString());
                Json.writejson("sfchyc4", zidongheqiu.sfchyc4.ToString());
                Json.writejson("sfchyc5", zidongheqiu.sfchyc5.ToString());
            }
        }

        private void checkboxsfchtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxsfchtq.Checked)
            {
                zidongheqiu.sifencehetqflag = true;
                Json.writejson("sifencehetqflag", "true");
            }
            else
            {
                zidongheqiu.sifencehetqflag = false;
                Json.writejson("sifencehetqflag", "false");
            }
        }

        private void buttonsfchcz_Click(object sender, EventArgs e)
        {
            textboxsfchjcfd.Text = "100";
            MessageBox.Show("重置参数成功");
        }
    }
}
