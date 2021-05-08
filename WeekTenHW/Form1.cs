using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekTenHW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
            comboBox1.SelectedItem = "機車";
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt3.Text = string.Empty;
            txt4.Text = string.Empty;
            txt5.Text = string.Empty;
            txt6.Text = string.Empty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            switch (comboBox1.SelectedItem)
            {
                case "機車":
                    comboBox2.Items.Add("150以下 / 12HP以下(12.2PS以下)");
                    comboBox2.Items.Add("151-250 / 12.1-20HP(12.3-20.3PS)");
                    comboBox2.Items.Add("251-500 / 20.1HP以下(20.4PS以下)");
                    comboBox2.Items.Add("501-600");
                    comboBox2.Items.Add("601-1200");
                    comboBox2.Items.Add("1201-1800");
                    comboBox2.Items.Add("1801以上");
                    comboBox2.SelectedIndex = 0;
                    break;
                case "貨車":
                    comboBox2.Items.Add("500以下");
                    comboBox2.Items.Add("501-600");
                    comboBox2.Items.Add("601-1200");
                    comboBox2.Items.Add("1201-1800");
                    comboBox2.Items.Add("1801-2400");
                    comboBox2.Items.Add("2401-3000 / 138HP以下(140.1PS以下)");
                    comboBox2.Items.Add("3001-3600");
                    comboBox2.Items.Add("3601-4200 / 138.1-200HP(140.2-203.0PS)");
                    comboBox2.Items.Add("4201-4800");
                    comboBox2.Items.Add("4801-5400 / 200.1-247HP(203.1-250.7PS)");
                    comboBox2.Items.Add("5401-6000");
                    comboBox2.Items.Add("6001-6600 / 247.1-286HP(250.8-290.3PS)");
                    comboBox2.Items.Add("6601-7200");
                    comboBox2.Items.Add("7201-7800 / 286.1-336HP(290.4-341.0PS)");
                    comboBox2.Items.Add("7801-8400");
                    comboBox2.Items.Add("8401-9000 / 336.1-361HP(341.1-366.4PS)");
                    comboBox2.Items.Add("9001-9600");
                    comboBox2.Items.Add("9601-10200 / 361.1HP以上(366.5PS以上)");
                    comboBox2.Items.Add("10201以上");
                    comboBox2.SelectedIndex = 0;
                    break;
                case "大客車":
                    comboBox2.Items.Add("600以下");
                    comboBox2.Items.Add("601-1200");
                    comboBox2.Items.Add("1201-1800");
                    comboBox2.Items.Add("1801-2400");
                    comboBox2.Items.Add("2401-3000 / 138HP以下(140.1PS以下)");
                    comboBox2.Items.Add("3001-3600");
                    comboBox2.Items.Add("3601-4200 / 138.1-200HP(140.2-203.0PS)");
                    comboBox2.Items.Add("4201-4800");
                    comboBox2.Items.Add("4801-5400 / 200.1-247HP(203.1-250.7PS)");
                    comboBox2.Items.Add("5401-6000");
                    comboBox2.Items.Add("6001-6600 / 247.1-286HP(250.8-290.3PS)");
                    comboBox2.Items.Add("6601-7200");
                    comboBox2.Items.Add("7201-7800 / 286.1-336HP(290.4-341.0PS)");
                    comboBox2.Items.Add("7801-8400");
                    comboBox2.Items.Add("8401-9000 / 336.1-361HP(341.1-366.4PS)");
                    comboBox2.Items.Add("9001-9600");
                    comboBox2.Items.Add("9601-10200 / 361.1HP以上(366.5PS以上)");
                    comboBox2.Items.Add("10201以上");
                    comboBox2.SelectedIndex = 0;
                    break;
                case "自用小客車":
                    comboBox2.Items.Add("500以下 / 38HP以下(38.6PS以下)");
                    comboBox2.Items.Add("501~600 / 38.1-56HP(38.7-56.8PS)");
                    comboBox2.Items.Add("601~1200 / 56.1-83HP(56.9-84.2PS)");
                    comboBox2.Items.Add("1201~1800 / 83.1-182HP(84.3-184.7PS)");
                    comboBox2.Items.Add("1801~2400 / 182.1-262HP(184.8-265.9PS)");
                    comboBox2.Items.Add("2401~3000 / 262.1-322HP(266-326.8PS)");
                    comboBox2.Items.Add("3001-4200 / 322.1-414HP(326.9-420.2PS");
                    comboBox2.Items.Add("4201-5400 / 414.1-469HP(420.3-476.0PS)");
                    comboBox2.Items.Add("5401-6600 / 469.1-509HP(476.1-516.6PS)");
                    comboBox2.Items.Add("6601-7800 / 509.1HP以上(516.7PS以上)");
                    comboBox2.Items.Add("7801以上");
                    comboBox2.SelectedIndex = 0;
                    break;
                case "營業用小客車":
                    comboBox2.Items.Add("500以下 / 38HP以下(38.6PS以下)");
                    comboBox2.Items.Add("501~600 / 38.1-56HP(38.7-56.8PS)");
                    comboBox2.Items.Add("601~1200 / 56.1-83HP(56.9-84.2PS)");
                    comboBox2.Items.Add("1201~1800 / 83.1-182HP(84.3-184.7PS)");
                    comboBox2.Items.Add("1801~2400 / 182.1-262HP(184.8-265.9PS)");
                    comboBox2.Items.Add("2401~3000 / 262.1-322HP(266-326.8PS)");
                    comboBox2.Items.Add("3001-4200 / 322.1-414HP(326.9-420.2PS");
                    comboBox2.Items.Add("4201-5400 / 414.1-469HP(420.3-476.0PS)");
                    comboBox2.Items.Add("5401-6600 / 469.1-509HP(476.1-516.6PS)");
                    comboBox2.Items.Add("6601-7800 / 509.1HP以上(516.7PS以上)");
                    comboBox2.Items.Add("7801以上");
                    comboBox2.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            radioButton1.Select();
            comboBox1.SelectedItem = "機車";
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt3.Text = string.Empty;
            txt4.Text = string.Empty;
            txt5.Text = string.Empty;
            txt6.Text = string.Empty;
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string nowyear = DateTime.Now.ToString("yyyy");
                int nowyearint = Convert.ToInt32(nowyear);
                string lastyear = (nowyearint - 1).ToString();
                if (nowyearint % 4 == 0)
                {
                    txt1.Text = $"使用期間：{lastyear}-01-01~{lastyear}-12-31";
                    txt2.Text = $"計算天數：366天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：";
                    txt6.Text = $"應納稅額：";
                }
                else
                {
                    txt1.Text = $"使用期間：{lastyear}-01-01~{lastyear}-12-31";
                    txt2.Text = $"計算天數：366天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：";
                    txt6.Text = $"應納稅額：";
                }

            }
            else
            {
                
                if (dateTimePicker1.Value < dateTimePicker2.Value)
                {
                    TimeSpan ts = new TimeSpan(dateTimePicker2.Value.Ticks - dateTimePicker1.Value.Ticks);
                    txt1.Text = $"使用期間：{dateTimePicker1.Value.ToString("yyyy-MM-dd")}~{dateTimePicker2.Value.ToString("yyyy-MM-dd")}";
                    txt2.Text = $"計算天數：{ts.TotalDays}天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：";
                    txt6.Text = $"應納稅額：";
                }
                else
                {
                    TimeSpan ts = new TimeSpan(dateTimePicker1.Value.Ticks - dateTimePicker2.Value.Ticks);
                    txt1.Text = $"使用期間：{dateTimePicker2.Value.ToString("yyyy-MM-dd")}~{dateTimePicker1.Value.ToString("yyyy-MM-dd")}";
                    txt2.Text = $"計算天數：{ts.TotalDays}天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：";
                    txt6.Text = $"應納稅額：";
                }

            }

        }
    }
}
