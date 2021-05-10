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
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadio(false);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadio(true);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCC();
        }

        private void Submitbtn_Click(object sender, EventArgs e)
        {
            LastResult();
            ChangeResult(resultnum);
        }
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Topbtn_Click(object sender, EventArgs e)
        {
            resultnum = 0;
            ChangeResult(resultnum);
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            resultnum--;
            if (resultnum < 0)
                resultnum = 0;
            ChangeResult(resultnum);
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            resultnum++;
            if (resultnum > lastresult.Count - 1)
                resultnum = lastresult.Count - 1;
            ChangeResult(resultnum);
        }

        private void Lastbtn_Click(object sender, EventArgs e)
        {
            resultnum = lastresult.Count - 1;
            ChangeResult(resultnum);
        }
        private void Nextbtn_MouseDown(object sender, MouseEventArgs e)
        {
            timerNEXT.Start();
        }
        private void Nextbtn_MouseUp(object sender, MouseEventArgs e)
        {
            timerNEXT.Stop();
            timerNEXT.Interval = 1000;
        }
        private void timerNEXT_Tick(object sender, EventArgs e)
        {

            if (timerNEXT.Interval - 100 <= 100)
            {
                if (timerNEXT.Interval - 10 <= 10)
                {
                    timerNEXT.Interval = 10;
                }
                else
                    timerNEXT.Interval -= 10;
            }
            else
                timerNEXT.Interval -= 100;

            resultnum++;
            if (resultnum > lastresult.Count - 1)
                resultnum = lastresult.Count - 1;
            ChangeResult(resultnum);
        }
        private void Backbtn_MouseDown(object sender, MouseEventArgs e)
        {
            timerBACK.Start();
        }
        private void Backbtn_MouseUp(object sender, MouseEventArgs e)
        {
            timerBACK.Stop();
            timerBACK.Interval = 1000;
        }
        private void timerBACK_Tick(object sender, EventArgs e)
        {
            if (timerBACK.Interval - 100 <= 100)
            {
                if (timerBACK.Interval - 10 <= 10)
                {
                    timerBACK.Interval = 10;
                }
                else
                    timerBACK.Interval -= 10;
            }
            else
                timerBACK.Interval -= 100;

            resultnum--;
            if (resultnum < 0)
                resultnum = 0;
            ChangeResult(resultnum);
        }

        private void Reset()
        {
            radioButton1.Select();
            comboBox1.Items.Clear();
            foreach (var item in _cars)
            {
                comboBox1.Items.Add(item.CarName);
            }
            comboBox1.SelectedIndex = 0;
            SelectCC();
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
        }
        private void ChangeRadio(bool change)
        {
            if (change)
            {
                label5.Visible = true;
                label6.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
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
            string val = comboBox1.SelectedItem as string;
            var carItem =
                (from item in _cars
                 where string.Compare(item.CarName, val, true) == 0
                 select item).FirstOrDefault();
            foreach (var item in carItem.Cartax)
            {
                comboBox2.Items.Add(item.CarCC);
            }
            comboBox2.SelectedIndex = 0;
        }
        private string Cacu(string cartype, string carcc, int day, int year, out decimal totalmoney)
        {
            var carType =
                (from item in _cars
                 where string.Compare(item.CarName, cartype, true) == 0
                 select item.Cartax).FirstOrDefault();

            List<CarsTax> temp = carType as List<CarsTax>;
            var carTax =
                (from item in temp
                 where string.Compare(item.CarCC, carcc, true) == 0
                 select item).FirstOrDefault();

            CarsTax tax = carTax as CarsTax;
            totalmoney = TotalMoney(tax.Tax, day, year);
            return $"{tax.Tax} × {day} / {year} = {Math.Floor(totalmoney)}元";

        }
        private decimal TotalMoney(int tax, int day, int year)
        {
            if (year == 366)
                return tax * ((decimal)day / 366);
            else
                return tax * ((decimal)day / 365);
        }
        private void LastResult()
        {
            lastresult.Clear();
            resultnum = 0;
            decimal totalmoney;
            if (radioButton1.Checked)
            {
                string nowyear = DateTime.Now.ToString("yyyy");
                int nowyearint = Convert.ToInt32(nowyear);
                if (nowyearint % 4 == 0)
                {
                    lastresult.Add(0, new List<string>() {
                        $"使用期間：{nowyear}-01-01~{nowyear}-12-31",
                        $"計算天數：366天",
                        $"汽缸CC數：{comboBox2.SelectedItem}",
                        $"用途：{comboBox1.SelectedItem}",
                        $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, 366, 366, out totalmoney)}",
                        $"應納稅額：共{Math.Floor(totalmoney)}元"
                    });
                    txt8.Text = "";
                }
                else
                {
                    lastresult.Add(0, new List<string>() {
                        $"使用期間：{nowyear}-01-01~{nowyear}-12-31",
                        $"計算天數：365天",
                        $"汽缸CC數：{comboBox2.SelectedItem}",
                        $"用途：{comboBox1.SelectedItem}",
                        $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, 365, 365, out totalmoney)}",
                        $"應納稅額：共{Math.Floor(totalmoney)}元"
                    });
                    txt8.Text = "";
                }

            }
            else
            {
                decimal fulltotalmoney;
                if (dateTimePicker1.Value < dateTimePicker2.Value)
                {
                    TimeSpan ts = new TimeSpan(dateTimePicker2.Value.Ticks - dateTimePicker1.Value.Ticks);
                    int totaldays = (int)ts.TotalDays + 1;
                    CreateResult(dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"), totaldays, out fulltotalmoney);
                    if (fulltotalmoney != 0)
                        txt8.Text = $"全部應納稅額：共{Math.Floor(fulltotalmoney)}元";

                }
                else
                {
                    TimeSpan ts = new TimeSpan(dateTimePicker1.Value.Ticks - dateTimePicker2.Value.Ticks);
                    int totaldays = (int)ts.TotalDays + 1;
                    CreateResult(dateTimePicker2.Value.ToString("yyyy-MM-dd"), dateTimePicker1.Value.ToString("yyyy-MM-dd"), totaldays, out fulltotalmoney);
                    if (fulltotalmoney != 0)
                        txt8.Text = $"全部應納稅額：共{Math.Floor(fulltotalmoney)}元";
                }

            }
        }
        Dictionary<int, List<string>> lastresult = new Dictionary<int, List<string>>();
        int resultnum = 0;
        private void CreateResult(string yearA, string yearB, int totaldays, out decimal fulltotalmoney)
        {
            fulltotalmoney = 0;
            decimal totalmoney;
            List<int> years = new List<int>();
            List<int> fullyears = new List<int>();
            int smallyear = Convert.ToInt32(Convert.ToDateTime(yearA).ToString("yyyy"));
            int bigyear = Convert.ToInt32(Convert.ToDateTime(yearB).ToString("yyyy"));
            int totalyear = bigyear - smallyear;
            if (totalyear > 0)
            {
                for (int i = smallyear; i <= bigyear; i++)
                {
                    if (i == smallyear || i == bigyear)
                        years.Add(i);
                    fullyears.Add(i);
                }
                for (int i = 0; i < fullyears.Count; i++)
                {

                    if (fullyears[i] == years[0])
                    {
                        TimeSpan ts = new TimeSpan(Convert.ToDateTime($"{smallyear}-12-31").Ticks - Convert.ToDateTime(yearA).Ticks);
                        int thistotaldays = (int)ts.TotalDays + 1;
                        if (fullyears[i] % 4 == 0)
                        {
                            lastresult.Add(i, new List<string>() {
                                $"使用期間：{yearA}~{fullyears[i]}-12-31",
                                $"計算天數：{thistotaldays}天",
                                $"汽缸CC數：{comboBox2.SelectedItem}",
                                $"用途：{comboBox1.SelectedItem}",
                                $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, thistotaldays, 366, out totalmoney)}",
                                $"應納稅額：共{Math.Floor(totalmoney)}元"
                            });
                            fulltotalmoney += totalmoney;
                        }
                        else
                        {
                            lastresult.Add(i, new List<string>() {
                                $"使用期間：{yearA}~{fullyears[i]}-12-31",
                                $"計算天數：{thistotaldays}天",
                                $"汽缸CC數：{comboBox2.SelectedItem}",
                                $"用途：{comboBox1.SelectedItem}",
                                $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, thistotaldays, 365, out totalmoney)}",
                                $"應納稅額：共{Math.Floor(totalmoney)}元"
                            });
                            fulltotalmoney += totalmoney;
                        }
                    }
                    else if (fullyears[i] == years[1])
                    {
                        TimeSpan ts = new TimeSpan(Convert.ToDateTime(yearB).Ticks - Convert.ToDateTime($"{bigyear}-01-01").Ticks);
                        int thistotaldays = (int)ts.TotalDays + 1;
                        if (fullyears[i] % 4 == 0)
                        {
                            lastresult.Add(i, new List<string>() {
                                $"使用期間：{fullyears[i]}-01-01~{yearB}",
                                $"計算天數：{thistotaldays}天",
                                $"汽缸CC數：{comboBox2.SelectedItem}",
                                $"用途：{comboBox1.SelectedItem}",
                                $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, thistotaldays, 366, out totalmoney)}",
                                $"應納稅額：共{Math.Floor(totalmoney)}元"
                            });
                            fulltotalmoney += totalmoney;
                        }
                        else
                        {
                            lastresult.Add(i, new List<string>() {
                                $"使用期間：{fullyears[i]}-01-01~{yearB}",
                                $"計算天數：{thistotaldays}天",
                                $"汽缸CC數：{comboBox2.SelectedItem}",
                                $"用途：{comboBox1.SelectedItem}",
                                $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, thistotaldays, 365, out totalmoney)}",
                                $"應納稅額：共{Math.Floor(totalmoney)}元"
                            });
                            fulltotalmoney += totalmoney;
                        }
                    }
                    else
                    {
                        if (fullyears[i] % 4 == 0)
                        {
                            lastresult.Add(i, new List<string>() {
                                $"使用期間：{fullyears[i]}-01-01~{fullyears[i]}-12-31",
                                $"計算天數：366天",
                                $"汽缸CC數：{comboBox2.SelectedItem}",
                                $"用途：{comboBox1.SelectedItem}",
                                $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, 366, 366, out totalmoney)}",
                                $"應納稅額：共{Math.Floor(totalmoney)}元"
                            });
                            fulltotalmoney += totalmoney;
                        }
                        else
                        {
                            lastresult.Add(i, new List<string>() {
                                $"使用期間：{fullyears[i]}-01-01~{fullyears[i]}-12-31",
                                $"計算天數：365天",
                                $"汽缸CC數：{comboBox2.SelectedItem}",
                                $"用途：{comboBox1.SelectedItem}",
                                $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, 365, 365, out totalmoney)}",
                                $"應納稅額：共{Math.Floor(totalmoney)}元"
                            });
                            fulltotalmoney += totalmoney;
                        }
                    }

                }

            }
            else
            {
                if (smallyear % 4 == 0 || bigyear % 4 == 0)
                {
                    lastresult.Add(0, new List<string>() {
                        $"使用期間：{yearA}~{yearB}",
                        $"計算天數：{totaldays}天",
                        $"汽缸CC數：{comboBox2.SelectedItem}",
                        $"用途：{comboBox1.SelectedItem}",
                        $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, totaldays, 366, out totalmoney)}",
                        $"應納稅額：共{Math.Floor(totalmoney)}元"
                    });
                    txt8.Text = "";
                }
                else
                {
                    lastresult.Add(0, new List<string>() {
                        $"使用期間：{yearA}~{yearB}",
                        $"計算天數：{totaldays}天",
                        $"汽缸CC數：{comboBox2.SelectedItem}",
                        $"用途：{comboBox1.SelectedItem}",
                        $"計算公式：計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, totaldays, 365, out totalmoney)}",
                        $"應納稅額：共{Math.Floor(totalmoney)}元"
                    });
                    txt8.Text = "";
                }
            }
        }
        private void ChangeResult(int nowresult)
        {
            txt1.Text = lastresult[nowresult][0];
            txt2.Text = lastresult[nowresult][1];
            txt3.Text = lastresult[nowresult][2];
            txt4.Text = lastresult[nowresult][3];
            txt5.Text = lastresult[nowresult][4];
            txt6.Text = lastresult[nowresult][5];
            txt7.Text = $"{nowresult + 1}/{lastresult.Count}頁";
        }




        private class Cars
        {
            public string CarName { get; set; }
            public List<CarsTax> Cartax { get; set; }

        }
        private class CarsTax
        {
            public string CarCC { get; set; }
            public int Tax { get; set; }

        }
        private List<Cars> _cars = new List<Cars>()
        {
            new Cars()
            {
                CarName="機車",
                Cartax=new List<CarsTax>(){
                   new CarsTax(){CarCC="150以下 / 12HP以下(12.2PS以下)",Tax=0},
                   new CarsTax(){CarCC="151-250 / 12.1-20HP(12.3-20.3PS)",Tax=800},
                   new CarsTax(){CarCC="251-500 / 20.1HP以下(20.4PS以下)",Tax=1620},
                   new CarsTax(){CarCC="501-600",Tax=2160},
                   new CarsTax(){CarCC="601-1200",Tax=4320},
                   new CarsTax(){CarCC="1201-1800",Tax=7120},
                   new CarsTax(){CarCC="1801或以上",Tax=11230}
                }
            },
            new Cars()
            {
                CarName="貨車",
                Cartax=new List<CarsTax>(){
                   new CarsTax(){CarCC= "500以下",Tax =900},
                   new CarsTax(){CarCC= "501-600",Tax =1080},
                   new CarsTax(){CarCC= "601-1200",Tax =1800},
                   new CarsTax(){CarCC= "1201-1800",Tax =2700},
                   new CarsTax(){CarCC= "1801-2400",Tax =3600},
                   new CarsTax(){CarCC= "2401-3000 / 138HP以下(140.1PS以下)",Tax =4500},
                   new CarsTax(){CarCC= "3001-3600",Tax =5400},
                   new CarsTax(){CarCC= "3601-4200 / 138.1-200HP(140.2-203.0PS)",Tax =6300},
                   new CarsTax(){CarCC= "4201-4800",Tax =7200},
                   new CarsTax(){CarCC= "4801-5400 / 200.1-247HP(203.1-250.7PS)",Tax =8100},
                   new CarsTax(){CarCC= "5401-6000",Tax =9000},
                   new CarsTax(){CarCC= "6001-6600 / 247.1-286HP(250.8-290.3PS)",Tax =9900},
                   new CarsTax(){CarCC= "6601-7200",Tax =10800},
                   new CarsTax(){CarCC= "7201-7800 / 286.1-336HP(290.4-341.0PS)",Tax =11700},
                   new CarsTax(){CarCC= "7801-8400",Tax =12600},
                   new CarsTax(){CarCC= "8401-9000 / 336.1-361HP(341.1-366.4PS)",Tax =13500},
                   new CarsTax(){CarCC= "9001-9600",Tax =14400},
                   new CarsTax(){CarCC= "9601-10200 / 361.1HP以上(366.5PS以上)",Tax =15300},
                   new CarsTax(){CarCC= "10201以上",Tax =16200}
                }
            },
            new Cars()
            {
                CarName="大客車",
                Cartax=new List<CarsTax>(){
                   new CarsTax(){CarCC= "600以下",Tax =1080},
                   new CarsTax(){CarCC= "601-1200",Tax =1800},
                   new CarsTax(){CarCC= "1201-1800",Tax =2700},
                   new CarsTax(){CarCC= "1801-2400",Tax =3600},
                   new CarsTax(){CarCC= "2401-3000 / 138HP以下(140.1PS以下)",Tax =4500},
                   new CarsTax(){CarCC= "3001-3600",Tax =5400},
                   new CarsTax(){CarCC= "3601-4200 / 138.1-200HP(140.2-203.0PS)",Tax =6300},
                   new CarsTax(){CarCC= "4201-4800",Tax =7200},
                   new CarsTax(){CarCC= "4801-5400 / 200.1-247HP(203.1-250.7PS)",Tax =8100},
                   new CarsTax(){CarCC= "5401-6000",Tax =9000},
                   new CarsTax(){CarCC= "6001-6600 / 247.1-286HP(250.8-290.3PS)",Tax =9900},
                   new CarsTax(){CarCC= "6601-7200",Tax =10800},
                   new CarsTax(){CarCC= "7201-7800 / 286.1-336HP(290.4-341.0PS)",Tax =11700},
                   new CarsTax(){CarCC= "7801-8400",Tax =12600},
                   new CarsTax(){CarCC= "8401-9000 / 336.1-361HP(341.1-366.4PS)",Tax =13500},
                   new CarsTax(){CarCC= "9001-9600",Tax =14400},
                   new CarsTax(){CarCC= "9601-10200 / 361.1HP以上(366.5PS以上)",Tax =15300},
                   new CarsTax(){CarCC= "10201以上",Tax =16200}
                }
            },
            new Cars()
            {
                CarName="自用小客車",
                Cartax=new List<CarsTax>(){
                   new CarsTax(){CarCC= "500以下 / 38HP以下(38.6PS以下)",Tax =1620},
                   new CarsTax(){CarCC= "501~600 / 38.1-56HP(38.7-56.8PS)",Tax =2160},
                   new CarsTax(){CarCC= "601~1200 / 56.1-83HP(56.9-84.2PS)",Tax =4320},
                   new CarsTax(){CarCC= "1201~1800 / 83.1-182HP(84.3-184.7PS)",Tax =7120},
                   new CarsTax(){CarCC= "1801~2400 / 182.1-262HP(184.8-265.9PS)",Tax =11230},
                   new CarsTax(){CarCC= "2401~3000 / 262.1-322HP(266-326.8PS)",Tax =15210},
                   new CarsTax(){CarCC= "3001-4200 / 322.1-414HP(326.9-420.2PS)",Tax =28220},
                   new CarsTax(){CarCC= "4201-5400 / 414.1-469HP(420.3-476.0PS)",Tax =46170},
                   new CarsTax(){CarCC= "5401-6600 / 469.1-509HP(476.1-516.6PS)",Tax =69690},
                   new CarsTax(){CarCC= "6601-7800 / 509.1HP以上(516.7PS以上)",Tax =117000},
                   new CarsTax(){CarCC= "7801以上",Tax =151200}
                }
            },
            new Cars()
            {
                CarName="營業用小客車",
                Cartax=new List<CarsTax>(){
                   new CarsTax(){CarCC= "500以下 / 38HP以下(38.6PS以下)",Tax =900},
                   new CarsTax(){CarCC= "501~600 / 38.1-56HP(38.7-56.8PS)",Tax =1260},
                   new CarsTax(){CarCC= "601~1200 / 56.1-83HP(56.9-84.2PS)",Tax =2160},
                   new CarsTax(){CarCC= "1201~1800 / 83.1-182HP(84.3-184.7PS)",Tax =3060},
                   new CarsTax(){CarCC= "1801~2400 / 182.1-262HP(184.8-265.9PS)",Tax =6480},
                   new CarsTax(){CarCC= "2401~3000 / 262.1-322HP(266-326.8PS)",Tax =9900},
                   new CarsTax(){CarCC= "3001-4200 / 322.1-414HP(326.9-420.2PS)",Tax =16380},
                   new CarsTax(){CarCC= "4201-5400 / 414.1-469HP(420.3-476.0PS)",Tax =24300},
                   new CarsTax(){CarCC= "5401-6600 / 469.1-509HP(476.1-516.6PS)",Tax =33660},
                   new CarsTax(){CarCC= "6601-7800 / 509.1HP以上(516.7PS以上)",Tax =44460},
                   new CarsTax(){CarCC= "7801以上",Tax =56700}
                }
            },
        };





    }
}
