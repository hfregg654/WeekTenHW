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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            ChooseDate = labelDate;
            ALLTotalmoney = txt8;
            CarType = labelCar;
            CarCC = labelCC;
            Reset();
        }
        //送出表單顯示結果
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            Choose form = new Choose();
            form.main = this;
            form.ShowDialog();
        }
        //初始化
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
        //跳到第一筆結果
        private void Topbtn_Click(object sender, EventArgs e)
        {
            resultnum = 0;
            ChangeResult(resultnum);
        }
        //往前一筆結果
        private void Backbtn_Click(object sender, EventArgs e)
        {
            resultnum--;
            if (resultnum < 0)
                resultnum = 0;
            ChangeResult(resultnum);
        }
        //往後一筆結果
        private void Nextbtn_Click(object sender, EventArgs e)
        {
            resultnum++;
            if (resultnum > lastresult.Count - 2)
                resultnum = lastresult.Count - 2;
            ChangeResult(resultnum);
        }
        //跳到最後一筆結果
        private void Lastbtn_Click(object sender, EventArgs e)
        {
            resultnum = lastresult.Count - 2;
            ChangeResult(resultnum);
        }
        //長按下一筆結果時能連續下一筆 Timer
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
            if (resultnum > lastresult.Count - 2)
                resultnum = lastresult.Count - 2;
            ChangeResult(resultnum);
        }
        //長按上一筆結果時能連續上一筆 Timer
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
        //初始化方法
        private void Reset()
        {
            //重製選項及欄位,並重新將假資料填入以及清空結果
            labelDate.Text = "";
            labelCar.Text = "";
            labelCC.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
        }



        //輸出表單的字典
        public Dictionary<int, List<string>> lastresult = new Dictionary<int, List<string>>();
        //表單頁數
        public int resultnum = 0;
        public bool IsfullYear;
        public DateTime ChoosedSmallDate;
        public DateTime ChoosedBigDate;
        public Label ChooseDate;
        public Label ALLTotalmoney;
        public Label CarType;
        public Label CarCC;

        //輸出結果換頁
        public void ChangeResult(int nowresult)
        {
            //將label改為當前頁數字典中的結果
            txt1.Text = lastresult[nowresult][0];
            txt2.Text = lastresult[nowresult][1];
            txt3.Text = lastresult[nowresult][2];
            txt4.Text = lastresult[nowresult][3];
            txt5.Text = lastresult[nowresult][4];
            txt6.Text = lastresult[nowresult][5];
            txt7.Text = $"{nowresult + 1}/{lastresult.Count - 1}頁";
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

        private void button2_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filepath = openFileDialog1.FileName;
                string context = string.Empty;
                foreach (var item in lastresult)
                {
                    foreach (var itemtext in item.Value)
                    {
                        context += $"{itemtext}|";
                    }
                    context += Environment.NewLine;
                }
                try
                {
                    System.IO.File.WriteAllText(filepath, context);
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lastresult.Clear();
                string filepath = openFileDialog1.FileName;
                string context = System.IO.File.ReadAllText(filepath);

                string[] openedlastresult = context.Split('|', '\r', '\n');


                int keycount = 0;
                int vcount = 0;
                List<string> temp = null;
                foreach (var item in openedlastresult)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        if (vcount == 0)
                        {
                            temp = new List<string>();
                            temp.Add(item);
                            vcount++;
                        }
                        else if (vcount == 5)
                        {
                            temp.Add(item);
                            lastresult.Add(keycount, temp);
                            keycount++;
                            vcount = 0;
                        }
                        else
                        {
                            temp.Add(item);
                            vcount++;
                        }

                    }
                }
                if (lastresult[lastresult.Count - 1][5] != "-")
                {
                    txt8.Text = lastresult[lastresult.Count - 1][5];
                    resultnum = 0;
                    ChangeResult(resultnum);
                }
                else
                {
                    txt8.Text = "";
                    resultnum = 0;
                    ChangeResult(resultnum);
                }

            }
        }
    }
}
