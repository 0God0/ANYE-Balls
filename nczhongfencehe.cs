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
    public partial class nczhongfencehe : Form
    {
        public nczhongfencehe()
        {
            InitializeComponent();
        }

        private void nczhongfencehe_Load(object sender, EventArgs e)
        {
            if (!Json.checkjson("ncyuandijian"))
            {
                comboboxnczhongfencehe.SelectedItem = "A";
            }
            else
            {
                comboboxnczhongfencehe.SelectedItem = Json.readjson("ncyuandijian");
            }
            if (!Json.checkjson("ncydjcfd"))
            {
                textboxnczfchjcfd.Text = "100";
            }
            else
            {
                textboxnczfchjcfd.Text = Json.readjson("ncydjcfd");
            }
            if (!Json.checkjson("ncydhqyc1"))
            {
                datagridviewnczfch.Rows.Add("分身", 10);
                datagridviewnczfch.Rows.Add("第二次拖动鼠标", 50);
                datagridviewnczfch.Rows.Add("分身", 10);
                datagridviewnczfch.Rows.Add("第三次拖动鼠标", 50);
                datagridviewnczfch.Rows.Add("最后分身延迟", 20);
            }
            else
            {
                datagridviewnczfch.Rows.Add("分身", Json.readjson("ncydhqyc1"));
                datagridviewnczfch.Rows.Add("第二次拖动鼠标", Json.readjson("ncydhqyc2"));
                datagridviewnczfch.Rows.Add("分身", Json.readjson("ncydhqyc3"));
                datagridviewnczfch.Rows.Add("第三次拖动鼠标", Json.readjson("ncydhqyc4"));
                datagridviewnczfch.Rows.Add("最后分身延迟", Json.readjson("ncydhqyc5"));
            }
            neicunheqiu.ncyuandiheqiujian = MainForm.GetVirtualKeyCode(comboboxnczhongfencehe.SelectedItem.ToString());
            try
            {
                neicunheqiu.ncyuandiheqiujcfd = Convert.ToInt32(textboxnczfchjcfd.Text);
                neicunheqiu.ncydhqyc1 = int.Parse(datagridviewnczfch.Rows[0].Cells[1].Value.ToString());
                neicunheqiu.ncydhqyc2 = int.Parse(datagridviewnczfch.Rows[1].Cells[1].Value.ToString());
                neicunheqiu.ncydhqyc3 = int.Parse(datagridviewnczfch.Rows[2].Cells[1].Value.ToString());
                neicunheqiu.ncydhqyc4 = int.Parse(datagridviewnczfch.Rows[3].Cells[1].Value.ToString());
                neicunheqiu.ncydhqyc5 = int.Parse(datagridviewnczfch.Rows[4].Cells[1].Value.ToString());
            }
            catch (Exception ex)
            {

            }
            if (Json.checkjson("ncyuandi"))
            {
                if (Json.readjson("ncyuandi") == "true")
                {
                    checkboxnczhongfencehe.Checked = true;
                }
            }
        }

        private void comboboxnczhongfencehe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxnczhongfencehe.SelectedItem != null)
            {
                neicunheqiu.ncyuandiheqiujian = MainForm.GetVirtualKeyCode(comboboxnczhongfencehe.SelectedItem.ToString());
            }
            Json.writejson("ncyuandijian", comboboxnczhongfencehe.SelectedItem.ToString());
        }

        private void checkboxnczhongfencehe_CheckedChanged(object sender, bool value)
        {
            if (checkboxnczhongfencehe.Checked)
            {
                Json.writejson("ncyuandi", "true");
                neicunheqiu.ncyuandiheqiuflag = true;
                neicunheqiu.ncyuandiheqiujian = MainForm.GetVirtualKeyCode(comboboxnczhongfencehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncyuandiheqiujcfd = Convert.ToInt32(textboxnczfchjcfd.Text);
                    neicunheqiu.ncydhqyc1 = int.Parse(datagridviewnczfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc2 = int.Parse(datagridviewnczfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc3 = int.Parse(datagridviewnczfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc4 = int.Parse(datagridviewnczfch.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc5 = int.Parse(datagridviewnczfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncydhqyc1", neicunheqiu.ncydhqyc1.ToString());
                Json.writejson("ncydhqyc2", neicunheqiu.ncydhqyc2.ToString());
                Json.writejson("ncydhqyc3", neicunheqiu.ncydhqyc3.ToString());
                Json.writejson("ncydhqyc4", neicunheqiu.ncydhqyc4.ToString());
                Json.writejson("ncydhqyc5", neicunheqiu.ncydhqyc5.ToString());
            }
            else
            {
                Json.writejson("ncyuandi", "false");
                neicunheqiu.ncyuandiheqiuflag = false;
            }
        }

        private void textboxnczfchjcfd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxnczfchjcfd_TextChanged(object sender, EventArgs e)
        {
            if (textboxnczfchjcfd.Text != null)
            {
                try
                {
                    neicunheqiu.ncyuandiheqiujcfd = Convert.ToInt32(textboxnczfchjcfd.Text);
                }
                catch (Exception ex)
                {
                    neicunheqiu.ncyuandiheqiujcfd = 100;
                }
            }
            Json.writejson("ncydjcfd", textboxnczfchjcfd.Text);
        }

        private void datagridviewnczfch_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue?.ToString()))
                {
                    ((DataGridView)sender).CancelEdit();
                }
            }
        }

        private void datagridviewnczfch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                object newValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                try
                {
                    neicunheqiu.ncydhqyc1 = int.Parse(datagridviewnczfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc2 = int.Parse(datagridviewnczfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc3 = int.Parse(datagridviewnczfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc4 = int.Parse(datagridviewnczfch.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc5 = int.Parse(datagridviewnczfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                Json.writejson("ncydhqyc1", neicunheqiu.ncydhqyc1.ToString());
                Json.writejson("ncydhqyc2", neicunheqiu.ncydhqyc2.ToString());
                Json.writejson("ncydhqyc3", neicunheqiu.ncydhqyc3.ToString());
                Json.writejson("ncydhqyc4", neicunheqiu.ncydhqyc4.ToString());
                Json.writejson("ncydhqyc5", neicunheqiu.ncydhqyc5.ToString());
            }
        }

        private void checkboxnczfchtq_CheckedChanged(object sender, bool value)
        {
            if (checkboxnczfchtq.Checked)
            {
                neicunheqiu.ncyuandiheqiutq = true;
                Json.writejson("ncyuandiheqiutqflag", "true");
            }
            else
            {
                neicunheqiu.ncyuandiheqiutq = false;
                Json.writejson("ncyuandiheqiutqflag", "false");
            }
        }

        private void buttonnczfchcz_Click(object sender, EventArgs e)
        {
            textboxnczfchjcfd.Text = "100";
            MessageBox.Show("重置参数成功");
        }
    }
}
