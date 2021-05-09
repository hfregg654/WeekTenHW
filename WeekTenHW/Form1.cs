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
        private void Form1_Load(object sender, EventArgs e)
        {
            Reset();
            LastResult();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadio(false);
            LastResult();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadio(true);
            LastResult();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LastResult();
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LastResult();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCC();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastResult();
        }
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            LastResult();
        }
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Reset();
            LastResult();
        }



        private void Reset()
        {
            radioButton1.Select();
            comboBox1.SelectedIndex = 0;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt3.Text = string.Empty;
            txt4.Text = string.Empty;
            txt5.Text = string.Empty;
            txt6.Text = string.Empty;
        }
        private void ChangeRadio(bool change)
        {
            if (change)
            {
                label5.Visible = true;
                label6.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
            {
                label5.Visible = false;
                label6.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }
        }
        private void SelectCC()
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
                    comboBox2.Items.Add("1801或以上");
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
            }
        }
        private string Cacu(int typeindex, int index, int day, out int totalmoney)
        {
            switch (typeindex)
            {
                case 0:
                    switch (index)
                    {
                        case 0:
                            totalmoney = TotalMoney(0, day);
                            return $"0 × {day} / 365 = {totalmoney}元";
                        case 1:
                            totalmoney = TotalMoney(800, day);
                            return $"800 × {day} / 365 = {totalmoney}元";
                        case 2:
                            totalmoney = TotalMoney(1620, day);
                            return $"1620 × {day} / 365 = {totalmoney}元";
                        case 3:
                            totalmoney = TotalMoney(2160, day);
                            return $"2160 × {day} / 365 = {totalmoney}元";
                        case 4:
                            totalmoney = TotalMoney(4320, day);
                            return $"4320 × {day} / 365 = {totalmoney}元";
                        case 5:
                            totalmoney = TotalMoney(7120, day);
                            return $"7120 × {day} / 365 = {totalmoney}元";
                        case 6:
                            totalmoney = TotalMoney(11230, day);
                            return $"11230 × {day} / 365 = {totalmoney}元";
                    }
                    totalmoney = -1;
                    return $"錯誤，無法計算";
                case 1:
                    switch (index)
                    {
                        case 0:
                            totalmoney = TotalMoney(900, day);
                            return $"900 × {day} / 365 = {totalmoney}元";
                        case 1:
                            totalmoney = TotalMoney(1080, day);
                            return $"1080 × {day} / 365 = {totalmoney}元";
                        case 2:
                            totalmoney = TotalMoney(1800, day);
                            return $"1800 × {day} / 365 = {totalmoney}元";
                        case 3:
                            totalmoney = TotalMoney(2700, day);
                            return $"2700 × {day} / 365 = {totalmoney}元";
                        case 4:
                            totalmoney = TotalMoney(3600, day);
                            return $"3600 × {day} / 365 = {totalmoney}元";
                        case 5:
                            totalmoney = TotalMoney(4500, day);
                            return $"4500 × {day} / 365 = {totalmoney}元";
                        case 6:
                            totalmoney = TotalMoney(5400, day);
                            return $"5400 × {day} / 365 = {totalmoney}元";
                        case 7:
                            totalmoney = TotalMoney(6300, day);
                            return $"6300 × {day} / 365 = {totalmoney}元";
                        case 8:
                            totalmoney = TotalMoney(7200, day);
                            return $"7200 × {day} / 365 = {totalmoney}元";
                        case 9:
                            totalmoney = TotalMoney(8100, day);
                            return $"8100 × {day} / 365 = {totalmoney}元";
                        case 10:
                            totalmoney = TotalMoney(9000, day);
                            return $"9000 × {day} / 365 = {totalmoney}元";
                        case 11:
                            totalmoney = TotalMoney(9900, day);
                            return $"9900 × {day} / 365 = {totalmoney}元";
                        case 12:
                            totalmoney = TotalMoney(10800, day);
                            return $"10800 × {day} / 365 = {totalmoney}元";
                        case 13:
                            totalmoney = TotalMoney(11700, day);
                            return $"11700 × {day} / 365 = {totalmoney}元";
                        case 14:
                            totalmoney = TotalMoney(12600, day);
                            return $"12600 × {day} / 365 = {totalmoney}元";
                        case 15:
                            totalmoney = TotalMoney(13500, day);
                            return $"13500 × {day} / 365 = {totalmoney}元";
                        case 16:
                            totalmoney = TotalMoney(14400, day);
                            return $"14400 × {day} / 365 = {totalmoney}元";
                        case 17:
                            totalmoney = TotalMoney(15300, day);
                            return $"15300 × {day} / 365 = {totalmoney}元";
                        case 18:
                            totalmoney = TotalMoney(16200, day);
                            return $"16200 × {day} / 365 = {totalmoney}元";
                    }
                    totalmoney = -1;
                    return $"錯誤，無法計算";
                case 2:
                    switch (index)
                    {
                        case 0:
                            totalmoney = TotalMoney(1080, day);
                            return $"1080 × {day} / 365 = {totalmoney}元";
                        case 1:
                            totalmoney = TotalMoney(1800, day);
                            return $"1800 × {day} / 365 = {totalmoney}元";
                        case 2:
                            totalmoney = TotalMoney(2700, day);
                            return $"2700 × {day} / 365 = {totalmoney}元";
                        case 3:
                            totalmoney = TotalMoney(3600, day);
                            return $"3600 × {day} / 365 = {totalmoney}元";
                        case 4:
                            totalmoney = TotalMoney(4500, day);
                            return $"4500 × {day} / 365 = {totalmoney}元";
                        case 5:
                            totalmoney = TotalMoney(5400, day);
                            return $"5400 × {day} / 365 = {totalmoney}元";
                        case 6:
                            totalmoney = TotalMoney(6300, day);
                            return $"6300 × {day} / 365 = {totalmoney}元";
                        case 7:
                            totalmoney = TotalMoney(7200, day);
                            return $"7200 × {day} / 365 = {totalmoney}元";
                        case 8:
                            totalmoney = TotalMoney(8100, day);
                            return $"8100 × {day} / 365 = {totalmoney}元";
                        case 9:
                            totalmoney = TotalMoney(9000, day);
                            return $"9000 × {day} / 365 = {totalmoney}元";
                        case 10:
                            totalmoney = TotalMoney(9900, day);
                            return $"9900 × {day} / 365 = {totalmoney}元";
                        case 11:
                            totalmoney = TotalMoney(10800, day);
                            return $"10800 × {day} / 365 = {totalmoney}元";
                        case 12:
                            totalmoney = TotalMoney(11700, day);
                            return $"11700 × {day} / 365 = {totalmoney}元";
                        case 13:
                            totalmoney = TotalMoney(12600, day);
                            return $"12600 × {day} / 365 = {totalmoney}元";
                        case 14:
                            totalmoney = TotalMoney(13500, day);
                            return $"13500 × {day} / 365 = {totalmoney}元";
                        case 15:
                            totalmoney = TotalMoney(14400, day);
                            return $"14400 × {day} / 365 = {totalmoney}元";
                        case 16:
                            totalmoney = TotalMoney(15300, day);
                            return $"15300 × {day} / 365 = {totalmoney}元";
                        case 17:
                            totalmoney = TotalMoney(16200, day);
                            return $"16200 × {day} / 365 = {totalmoney}元";
                    }
                    totalmoney = -1;
                    return $"錯誤，無法計算";
                case 3:
                    switch (index)
                    {
                        case 0:
                            totalmoney = TotalMoney(1620, day);
                            return $"1620 × {day} / 365 = {totalmoney}元";
                        case 1:
                            totalmoney = TotalMoney(2160, day);
                            return $"2160 × {day} / 365 = {totalmoney}元";
                        case 2:
                            totalmoney = TotalMoney(4320, day);
                            return $"4320 × {day} / 365 = {totalmoney}元";
                        case 3:
                            totalmoney = TotalMoney(7120, day);
                            return $"7120 × {day} / 365 = {totalmoney}元";
                        case 4:
                            totalmoney = TotalMoney(11230, day);
                            return $"11230 × {day} / 365 = {totalmoney}元";
                        case 5:
                            totalmoney = TotalMoney(15210, day);
                            return $"15210 × {day} / 365 = {totalmoney}元";
                        case 6:
                            totalmoney = TotalMoney(28220, day);
                            return $"28220 × {day} / 365 = {totalmoney}元";
                        case 7:
                            totalmoney = TotalMoney(46170, day);
                            return $"46170 × {day} / 365 = {totalmoney}元";
                        case 8:
                            totalmoney = TotalMoney(69690, day);
                            return $"69690 × {day} / 365 = {totalmoney}元";
                        case 9:
                            totalmoney = TotalMoney(117000, day);
                            return $"117000 × {day} / 365 = {totalmoney}元";
                        case 10:
                            totalmoney = TotalMoney(151200, day);
                            return $"151200 × {day} / 365 = {totalmoney}元";
                    }
                    totalmoney = -1;
                    return $"錯誤，無法計算";
                case 4:
                    switch (index)
                    {
                        case 0:
                            totalmoney = TotalMoney(900, day);
                            return $"900 × {day} / 365 = {totalmoney}元";
                        case 1:
                            totalmoney = TotalMoney(1260, day);
                            return $"1260 × {day} / 365 = {totalmoney}元";
                        case 2:
                            totalmoney = TotalMoney(2160, day);
                            return $"2160 × {day} / 365 = {totalmoney}元";
                        case 3:
                            totalmoney = TotalMoney(3060, day);
                            return $"3060 × {day} / 365 = {totalmoney}元";
                        case 4:
                            totalmoney = TotalMoney(6480, day);
                            return $"6480 × {day} / 365 = {totalmoney}元";
                        case 5:
                            totalmoney = TotalMoney(9900, day);
                            return $"9900 × {day} / 365 = {totalmoney}元";
                        case 6:
                            totalmoney = TotalMoney(16380, day);
                            return $"16380 × {day} / 365 = {totalmoney}元";
                        case 7:
                            totalmoney = TotalMoney(24300, day);
                            return $"24300 × {day} / 365 = {totalmoney}元";
                        case 8:
                            totalmoney = TotalMoney(33660, day);
                            return $"33660 × {day} / 365 = {totalmoney}元";
                        case 9:
                            totalmoney = TotalMoney(44460, day);
                            return $"44460 × {day} / 365 = {totalmoney}元";
                        case 10:
                            totalmoney = TotalMoney(56700, day);
                            return $"56700 × {day} / 365 = {totalmoney}元";
                    }
                    totalmoney = -1;
                    return $"錯誤，無法計算";
                default:
                    totalmoney = -1;
                    return $"錯誤，無法計算";
            }
        }
        private int TotalMoney(int tax, int day)
        {
            return Convert.ToInt32(Math.Floor(tax * ((decimal)day / 365)));
        }
        private void LastResult()
        {
            int totalmoney;
            if (radioButton1.Checked)
            {
                string nowyear = DateTime.Now.ToString("yyyy");
                int nowyearint = Convert.ToInt32(nowyear);
                if (nowyearint % 4 == 0)
                {
                    txt1.Text = $"使用期間：{nowyear}-01-01~{nowyear}-12-31";
                    txt2.Text = $"計算天數：366天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：{Cacu(comboBox1.SelectedIndex, comboBox2.SelectedIndex, 366, out totalmoney)}";
                    txt6.Text = $"應納稅額：共{totalmoney}元";
                }
                else
                {
                    txt1.Text = $"使用期間：{nowyear}-01-01~{nowyear}-12-31";
                    txt2.Text = $"計算天數：365天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：{Cacu(comboBox1.SelectedIndex, comboBox2.SelectedIndex, 365, out totalmoney)}";
                    txt6.Text = $"應納稅額：共{totalmoney}元";
                }

            }
            else
            {

                if (dateTimePicker1.Value < dateTimePicker2.Value)
                {
                    TimeSpan ts = new TimeSpan(dateTimePicker2.Value.Ticks - dateTimePicker1.Value.Ticks);
                    int totaldays = (int)ts.TotalDays + 1;
                    txt1.Text = $"使用期間：{dateTimePicker1.Value.ToString("yyyy-MM-dd")}~{dateTimePicker2.Value.ToString("yyyy-MM-dd")}";
                    txt2.Text = $"計算天數：{totaldays}天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：{Cacu(comboBox1.SelectedIndex, comboBox2.SelectedIndex, totaldays, out totalmoney)}";
                    txt6.Text = $"應納稅額：共{totalmoney}元";
                }
                else
                {
                    TimeSpan ts = new TimeSpan(dateTimePicker1.Value.Ticks - dateTimePicker2.Value.Ticks);
                    int totaldays = (int)ts.TotalDays + 1;
                    txt1.Text = $"使用期間：{dateTimePicker2.Value.ToString("yyyy-MM-dd")}~{dateTimePicker1.Value.ToString("yyyy-MM-dd")}";
                    txt2.Text = $"計算天數：{totaldays}天";
                    txt3.Text = $"汽缸CC數：{comboBox2.SelectedItem}";
                    txt4.Text = $"用途：{comboBox1.SelectedItem}";
                    txt5.Text = $"計算公式：{Cacu(comboBox1.SelectedIndex, comboBox2.SelectedIndex, totaldays, out totalmoney)}";
                    txt6.Text = $"應納稅額：共{totalmoney}元";
                }

            }
        }
    }
}
