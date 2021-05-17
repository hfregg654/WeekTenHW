using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeekElevenHW
{
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }
        public MainForm main = null;
        private void ChooseDate_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
            ChangeRadio(false);
            comboBox1.Items.Clear();
            foreach (var item in _cars)
            {
                comboBox1.Items.Add(item.CarName);
            }
            comboBox1.SelectedIndex = 0;
            SelectCC();
        }
        //換選項
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadio(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadio(true);
        }
        //選擇車種帶入CC數
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCC();
        }

        //天數選項交換
        private void ChangeRadio(bool change)
        {
            //選擇範圍則將範圍的輸入框及文字帶出並設定初始值,反之則隱藏
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
        //選取CC數
        private void SelectCC()
        {
            //清空CC數的選單並重新取值
            comboBox2.Items.Clear();
            string val = comboBox1.SelectedItem as string;//以車種的選擇來查詢相對應的假資料並填入
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
        //將輸出結果加入字典
        private void AddLastResult(int key, bool isfullyear, bool isfist, bool islast, DateTime year, DateTime? year2, int day, int yearday, out decimal totalmoney)
        {
            totalmoney = 0;
            if (isfullyear)
            {
                main.lastresult.Add(key, new List<string>() {
                    $"使用期間：{year.Year}-01-01~{year.Year}-12-31",
                    $"計算天數：{yearday}天",
                    $"汽缸CC數：{comboBox2.SelectedItem}",
                    $"用途：{comboBox1.SelectedItem}",
                    $"計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, day, yearday, out totalmoney)}",
                    $"應納稅額：共{Math.Floor(totalmoney)}元"
                });
            }
            if (isfist)
            {
                main.lastresult.Add(key, new List<string>() {
                    $"使用期間：{year.ToString("yyyy-MM-dd")}~{year.Year}-12-31",
                    $"計算天數：{day}天",
                    $"汽缸CC數：{comboBox2.SelectedItem}",
                    $"用途：{comboBox1.SelectedItem}",
                    $"計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, day, yearday, out totalmoney)}",
                    $"應納稅額：共{Math.Floor(totalmoney)}元"
                });
            }
            if (islast)
            {
                main.lastresult.Add(key, new List<string>() {
                    $"使用期間：{year.Year}-01-01~{year.ToString("yyyy-MM-dd")}",
                    $"計算天數：{day}天",
                    $"汽缸CC數：{comboBox2.SelectedItem}",
                    $"用途：{comboBox1.SelectedItem}",
                    $"計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, day, yearday, out totalmoney)}",
                    $"應納稅額：共{Math.Floor(totalmoney)}元"
                });
            }
            if (year2 != null)
            {
                main.lastresult.Add(0, new List<string>() {
                    $"使用期間：{year.ToString("yyyy-MM-dd")}~{Convert.ToDateTime(year2).ToString("yyyy-MM-dd")}",
                    $"計算天數：{day}天",
                    $"汽缸CC數：{comboBox2.SelectedItem}",
                    $"用途：{comboBox1.SelectedItem}",
                    $"計算公式：{Cacu(comboBox1.SelectedItem as string, comboBox2.SelectedItem as string, day, yearday, out totalmoney)}",
                    $"應納稅額：共{Math.Floor(totalmoney)}元"
                });
            }
        }
        //計算公式
        private decimal TotalMoney(int tax, int day, int year)
        {
            //閏年除以366反之則除以365
            if (year == 366)
                return tax * ((decimal)day / 366);
            else
                return tax * ((decimal)day / 365);
        }
        //取得計算公式以及計算結果
        private string Cacu(string cartype, string carcc, int day, int year, out decimal totalmoney)
        {
            //先取得選取車種
            var carType =
                (from item in _cars
                 where string.Compare(item.CarName, cartype, true) == 0
                 select item.Cartax).FirstOrDefault();
            //再取得選取CC數
            List<CarsTax> temp = carType as List<CarsTax>;
            var carTax =
                (from item in temp
                 where string.Compare(item.CarCC, carcc, true) == 0
                 select item).FirstOrDefault();
            //最後帶入公式並計算
            CarsTax tax = carTax as CarsTax;
            totalmoney = TotalMoney(tax.Tax, day, year);
            return $"{tax.Tax} × {day} / {year} = {Math.Floor(totalmoney)}元";

        }
        //最後的輸出表單
        private void LastResult()
        {
            //清空字典及頁數歸零
            main.lastresult.Clear();
            main.resultnum = 0;
            //選擇當年的話只計算當年份
            if (radioButton1.Checked)
            {
                //取得當年的西元年,並多取一個數字型別的
                DateTime nowyeartime = DateTime.Now;
                int nowyear = nowyeartime.Year;
                decimal totalmoney;
                //判斷是否為閏年,並將結果加入字典
                if (DateTime.IsLeapYear(nowyear))
                {
                    AddLastResult(0, true, false, false, nowyeartime, null, 366, 366, out totalmoney);
                    main.ALLTotalmoney.Text = "";
                    main.lastresult.Add(main.lastresult.Count, new List<string>() { "-", "-", "-", "-", "-", "-" });
                }
                else
                {
                    AddLastResult(0, true, false, false, nowyeartime, null, 365, 365, out totalmoney);
                    main.ALLTotalmoney.Text = "";
                    main.lastresult.Add(main.lastresult.Count, new List<string>() { "-", "-", "-", "-", "-", "-" });
                }

            }
            else
            {
                //所有年份的總額
                decimal fulltotalmoney = 0;
                //判斷兩個日期的大小
                if (dateTimePicker2.Value > dateTimePicker1.Value)
                {
                    //計算選取範圍內的總天數
                    TimeSpan ts = new TimeSpan(dateTimePicker2.Value.Ticks - dateTimePicker1.Value.Ticks);
                    int totaldays = (int)ts.TotalDays + 1;
                    //傳入創造表單的函式並帶回結果
                    CreateResult(dateTimePicker1.Value, dateTimePicker2.Value, totaldays, out fulltotalmoney);
                    if (fulltotalmoney != 0)
                    {
                        main.ALLTotalmoney.Text = $"全部應納稅額：共{Math.Floor(fulltotalmoney)}元";
                        main.lastresult.Add(main.lastresult.Count, new List<string>() { "-", "-", "-", "-", "-", $"全部應納稅額：共{Math.Floor(fulltotalmoney)}元" });
                    }
                }
                else
                {
                    //計算選取範圍內的總天數
                    TimeSpan ts = new TimeSpan(dateTimePicker1.Value.Ticks - dateTimePicker2.Value.Ticks);
                    int totaldays = (int)ts.TotalDays + 1;
                    //傳入創造表單的函式並帶回結果
                    CreateResult(dateTimePicker2.Value, dateTimePicker1.Value, totaldays, out fulltotalmoney);
                    if (fulltotalmoney != 0)
                    {
                        main.ALLTotalmoney.Text = $"全部應納稅額：共{Math.Floor(fulltotalmoney)}元";
                        main.lastresult.Add(main.lastresult.Count, new List<string>() { "-", "-", "-", "-", "-", $"全部應納稅額：共{Math.Floor(fulltotalmoney)}元" });
                    }
                }
            }
        }
        //創造表單(選取的範圍)
        private void CreateResult(DateTime smallyear, DateTime bigyear, int totaldays, out decimal fulltotalmoney)
        {
            //先將總額設定為0
            fulltotalmoney = 0;
            decimal totalmoney;
            //頭尾年相減獲得中間有幾年
            int totalyear = bigyear.Year - smallyear.Year;
            //判斷是否在同一年中,不是就進入計算,在同一年則直接計算
            if (totalyear > 0)
            {
                //跑所有年份次數的迴圈
                for (int i = smallyear.Year; i <= bigyear.Year; i++)
                {
                    //頭年的情況
                    if (i == smallyear.Year)
                    {
                        //計算所選日期到頭年的12月31日的天數
                        TimeSpan ts = new TimeSpan(Convert.ToDateTime($"{smallyear.Year}-12-31").Ticks - smallyear.Ticks);
                        int thistotaldays = (int)ts.TotalDays + 1;
                        //判斷閏年
                        if (DateTime.IsLeapYear(i))
                        {
                            AddLastResult(i - smallyear.Year, false, true, false, smallyear, null, thistotaldays, 366, out totalmoney);
                            //將總額加上計算結果
                            fulltotalmoney += totalmoney;
                        }
                        else
                        {
                            AddLastResult(i - smallyear.Year, false, true, false, smallyear, null, thistotaldays, 365, out totalmoney);
                            fulltotalmoney += totalmoney;
                        }
                    }
                    //尾年的情況
                    else if (i == bigyear.Year)
                    {
                        //計算尾年的1月1日到所選日期的天數
                        TimeSpan ts = new TimeSpan(Convert.ToDateTime(bigyear).Ticks - Convert.ToDateTime($"{bigyear.Year}-01-01").Ticks);
                        int thistotaldays = (int)ts.TotalDays + 1;
                        if (DateTime.IsLeapYear(i))
                        {
                            AddLastResult(i - smallyear.Year, false, false, true, bigyear, null, thistotaldays, 366, out totalmoney);
                            fulltotalmoney += totalmoney;
                        }
                        else
                        {
                            AddLastResult(i - smallyear.Year, false, false, true, bigyear, null, thistotaldays, 365, out totalmoney);
                            fulltotalmoney += totalmoney;
                        }
                    }
                    //中間年的情況
                    else
                    {
                        if (DateTime.IsLeapYear(i))
                        {
                            AddLastResult(i - smallyear.Year, true, false, false, new DateTime(i, 1, 1), null, 366, 366, out totalmoney);
                            fulltotalmoney += totalmoney;
                        }
                        else
                        {
                            AddLastResult(i - smallyear.Year, true, false, false, new DateTime(i, 1, 1), null, 365, 365, out totalmoney);
                            fulltotalmoney += totalmoney;
                        }
                    }
                }
            }
            //判斷是否在同一年中,不是就進入計算,在同一年則直接計算
            else
            {
                //判斷閏年
                if (DateTime.IsLeapYear(smallyear.Year) || DateTime.IsLeapYear(bigyear.Year))
                {
                    AddLastResult(0, false, false, false, smallyear, bigyear, totaldays, 366, out totalmoney);
                    main.ALLTotalmoney.Text = "";
                    main.lastresult.Add(main.lastresult.Count, new List<string>() { "-", "-", "-", "-", "-", "-" });
                }
                else
                {
                    AddLastResult(0, false, false, false, smallyear, bigyear, totaldays, 365, out totalmoney);
                    main.ALLTotalmoney.Text = "";
                    main.lastresult.Add(main.lastresult.Count, new List<string>() { "-", "-", "-", "-", "-", "-" });
                }
            }
        }




        private void Submitbtn_Click(object sender, EventArgs e)
        {
            int nowyear = DateTime.Now.Year;
            main.CarType.Text = comboBox1.Text;
            main.CarCC.Text = comboBox2.Text;
            if (radioButton1.Checked)
            {
                LastResult();
                main.ChangeResult(0);
                main.ChooseDate.Text = $"{nowyear}-01-01~{nowyear}-12-31";
            }
            else
            {
                if (dateTimePicker2.Value > dateTimePicker1.Value)
                {
                    LastResult();
                    main.ChangeResult(0);
                    main.ChooseDate.Text = $"{dateTimePicker1.Value.ToString("yyyy-MM-dd")}~{dateTimePicker2.Value.ToString("yyyy-MM-dd")}";

                }
                else
                {
                    LastResult();
                    main.ChangeResult(0);
                    main.ChooseDate.Text = $"{dateTimePicker2.Value.ToString("yyyy-MM-dd")}~{dateTimePicker1.Value.ToString("yyyy-MM-dd")}";
                }
            }
            Close();
        }





        //假資料集合部分
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
