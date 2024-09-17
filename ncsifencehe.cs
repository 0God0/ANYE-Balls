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
    public partial class ncsifencehe : Form
    {
        public ncsifencehe()
        {
            InitializeComponent();
        }

        private void ncsifencehe_Load(object sender, EventArgs e)
        {

            if (!Json.checkjson("ncsifencehejian"))
            {
                comboboxncsifencehe.SelectedItem = "A";
            }
            else
            {
                comboboxncsifencehe.SelectedItem = Json.readjson("ncsifencehejian");
            }
            if (!Json.checkjson("ncsfchjcfd"))
            {
                textboxncsfchjcfd.Text = "100";
            }
            else
            {
                textboxncsfchjcfd.Text = Json.readjson("ncsfchjcfd");
            }
            if (!Json.checkjson("ncsfchyc1"))
            {
                datagridviewncsfch.Rows.Add("分身", 10);
                datagridviewncsfch.Rows.Add("分身", 10);
                datagridviewncsfch.Rows.Add("第一次拖动鼠标", 50);
                datagridviewncsfch.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewncsfch.Rows.Add("分身", Json.readjson("ncsfchyc1"));
                datagridviewncsfch.Rows.Add("分身", Json.readjson("ncsfchyc2"));
                datagridviewncsfch.Rows.Add("第一次拖动鼠标", Json.readjson("ncsfchyc3"));
                datagridviewncsfch.Rows.Add("最后分身延迟", Json.readjson("ncsfchyc4"));
            }
            neicunheqiu.ncsifencehejian = MainForm.GetVirtualKeyCode(comboboxncsifencehe.SelectedItem.ToString());
            try
            {
                neicunheqiu.ncsifencehejcfd = Convert.ToInt32(textboxncsfchjcfd.Text);
                neicunheqiu.ncsfchyc1 = int.Parse(datagridviewncsfch.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncsfchyc2 = int.Parse(datagridviewncsfch.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncsfchyc3 = int.Parse(datagridviewncsfch.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncsfchyc4 = int.Parse(datagridviewncsfch.Rows[3].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("ncsifencehe"))
            {
                if (Json.readjson("ncsifencehe") == "true")
                {
                    checkboxncsifencehe.Checked = true;
                }
            }

        }

        private void comboboxncsifencehe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxncsifencehe.SelectedItem != null)
            {
                neicunheqiu.ncsifencehejian = MainForm.GetVirtualKeyCode(comboboxncsifencehe.SelectedItem.ToString());
            }
            Json.writejson("ncsifencehejian", comboboxncsifencehe.SelectedItem.ToString());
        }

        private void checkboxncsifencehe_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsifencehe.Checked)
            {
                Json.writejson("ncsifencehe", "true");
                neicunheqiu.ncsifenceheflag = true;
                neicunheqiu.ncsifencehejian = MainForm.GetVirtualKeyCode(comboboxncsifencehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncsifencehejcfd = Convert.ToInt32(textboxncsfchjcfd.Text);
                    neicunheqiu.ncsfchyc1 = int.Parse(datagridviewncsfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc2 = int.Parse(datagridviewncsfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc3 = int.Parse(datagridviewncsfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc4 = int.Parse(datagridviewncsfch.Rows[3].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncsfchyc1", neicunheqiu.ncsfchyc1.ToString());
                Json.writejson("ncsfchyc2", neicunheqiu.ncsfchyc2.ToString());
                Json.writejson("ncsfchyc3", neicunheqiu.ncsfchyc3.ToString());
                Json.writejson("ncsfchyc4", neicunheqiu.ncsfchyc4.ToString());
            }
            else
            {
                Json.writejson("ncsifencehe", "false");
                neicunheqiu.ncsifenceheflag = false;
            }
        }

        private void textboxncsfchjcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxncsfchjcfd.Text != null)
            {
                try
                {
                    neicunheqiu.ncsifencehejcfd = Convert.ToInt32(textboxncsfchjcfd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncsifencehejcfd = 100;
                }
            }
            Json.writejson("ncsfchjcfd", textboxncsfchjcfd.Text);
        }

        private void textboxncsfchjcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void datagridviewncsfch_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewncsfch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncsfchyc1 = int.Parse(datagridviewncsfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc2 = int.Parse(datagridviewncsfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc3 = int.Parse(datagridviewncsfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc4 = int.Parse(datagridviewncsfch.Rows[3].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncsfchyc1", neicunheqiu.ncsfchyc1.ToString());
                Json.writejson("ncsfchyc2", neicunheqiu.ncsfchyc2.ToString());
                Json.writejson("ncsfchyc3", neicunheqiu.ncsfchyc3.ToString());
                Json.writejson("ncsfchyc4", neicunheqiu.ncsfchyc4.ToString());
            }
        }

        private void checkboxncsfchtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxncsfchtq.Checked)
            {
                neicunheqiu.ncsifencehetq = true;
                Json.writejson("ncsifencehetqflag", "true");
            }
            else
            {
                neicunheqiu.ncsifencehetq = false;
                Json.writejson("ncsifencehetqflag", "false");
            }
        }

        private void buttonncsfchcz_Click(object sender, EventArgs e)
        {
            textboxncsfchjcfd.Text = "100";
            MessageBox.Show("重置参数成功");
        }
    }
}
