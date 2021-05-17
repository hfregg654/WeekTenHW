
namespace WeekElevenHW
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Submitbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.Label();
            this.txt5 = new System.Windows.Forms.Label();
            this.txt6 = new System.Windows.Forms.Label();
            this.Nextbtn = new System.Windows.Forms.Button();
            this.Topbtn = new System.Windows.Forms.Button();
            this.Backbtn = new System.Windows.Forms.Button();
            this.Lastbtn = new System.Windows.Forms.Button();
            this.txt7 = new System.Windows.Forms.Label();
            this.txt8 = new System.Windows.Forms.Label();
            this.timerNEXT = new System.Windows.Forms.Timer(this.components);
            this.timerBACK = new System.Windows.Forms.Timer(this.components);
            this.labelDate = new System.Windows.Forms.Label();
            this.labelCar = new System.Windows.Forms.Label();
            this.labelCC = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pictureBox1.Location = new System.Drawing.Point(12, 302);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 250);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pictureBox2.Location = new System.Drawing.Point(12, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(360, 100);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Teal;
            this.pictureBox3.Location = new System.Drawing.Point(12, 206);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(360, 100);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Teal;
            this.pictureBox4.Location = new System.Drawing.Point(12, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(360, 100);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("新細明體", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(115, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "使用期間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Font = new System.Drawing.Font("新細明體", 20F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 34);
            this.label2.TabIndex = 9;
            this.label2.Text = "汽缸CC數/馬達馬力";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Font = new System.Drawing.Font("新細明體", 20F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(115, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 34);
            this.label4.TabIndex = 11;
            this.label4.Text = "試算結果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Font = new System.Drawing.Font("新細明體", 20F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(146, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 34);
            this.label3.TabIndex = 12;
            this.label3.Text = "用途";
            // 
            // Submitbtn
            // 
            this.Submitbtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Submitbtn.Font = new System.Drawing.Font("新細明體", 20F);
            this.Submitbtn.ForeColor = System.Drawing.Color.White;
            this.Submitbtn.Location = new System.Drawing.Point(781, 37);
            this.Submitbtn.Name = "Submitbtn";
            this.Submitbtn.Size = new System.Drawing.Size(225, 50);
            this.Submitbtn.TabIndex = 21;
            this.Submitbtn.Text = "選取並送出";
            this.Submitbtn.UseVisualStyleBackColor = false;
            this.Submitbtn.Click += new System.EventHandler(this.Submitbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Cancelbtn.Font = new System.Drawing.Font("新細明體", 20F);
            this.Cancelbtn.ForeColor = System.Drawing.Color.White;
            this.Cancelbtn.Location = new System.Drawing.Point(781, 109);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(225, 50);
            this.Cancelbtn.TabIndex = 22;
            this.Cancelbtn.Text = "取消重填";
            this.Cancelbtn.UseVisualStyleBackColor = false;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // txt1
            // 
            this.txt1.AutoSize = true;
            this.txt1.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt1.Location = new System.Drawing.Point(391, 308);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(112, 25);
            this.txt1.TabIndex = 23;
            this.txt1.Text = "使用期間";
            // 
            // txt2
            // 
            this.txt2.AutoSize = true;
            this.txt2.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt2.Location = new System.Drawing.Point(391, 352);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(112, 25);
            this.txt2.TabIndex = 24;
            this.txt2.Text = "計算天數";
            // 
            // txt3
            // 
            this.txt3.AutoSize = true;
            this.txt3.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt3.Location = new System.Drawing.Point(391, 397);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(119, 25);
            this.txt3.TabIndex = 25;
            this.txt3.Text = "汽缸CC數";
            // 
            // txt4
            // 
            this.txt4.AutoSize = true;
            this.txt4.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt4.Location = new System.Drawing.Point(391, 440);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(62, 25);
            this.txt4.TabIndex = 26;
            this.txt4.Text = "用途";
            // 
            // txt5
            // 
            this.txt5.AutoSize = true;
            this.txt5.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt5.Location = new System.Drawing.Point(391, 482);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(112, 25);
            this.txt5.TabIndex = 27;
            this.txt5.Text = "計算公式";
            // 
            // txt6
            // 
            this.txt6.AutoSize = true;
            this.txt6.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt6.Location = new System.Drawing.Point(391, 527);
            this.txt6.Name = "txt6";
            this.txt6.Size = new System.Drawing.Size(112, 25);
            this.txt6.TabIndex = 28;
            this.txt6.Text = "應納稅額";
            // 
            // Nextbtn
            // 
            this.Nextbtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Nextbtn.Font = new System.Drawing.Font("新細明體", 10F);
            this.Nextbtn.ForeColor = System.Drawing.Color.White;
            this.Nextbtn.Location = new System.Drawing.Point(560, 578);
            this.Nextbtn.Name = "Nextbtn";
            this.Nextbtn.Size = new System.Drawing.Size(50, 50);
            this.Nextbtn.TabIndex = 32;
            this.Nextbtn.Text = ">";
            this.Nextbtn.UseVisualStyleBackColor = false;
            this.Nextbtn.Click += new System.EventHandler(this.Nextbtn_Click);
            this.Nextbtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Nextbtn_MouseDown);
            this.Nextbtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Nextbtn_MouseUp);
            // 
            // Topbtn
            // 
            this.Topbtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Topbtn.Font = new System.Drawing.Font("新細明體", 10F);
            this.Topbtn.ForeColor = System.Drawing.Color.White;
            this.Topbtn.Location = new System.Drawing.Point(396, 578);
            this.Topbtn.Name = "Topbtn";
            this.Topbtn.Size = new System.Drawing.Size(50, 50);
            this.Topbtn.TabIndex = 33;
            this.Topbtn.Text = "<<";
            this.Topbtn.UseVisualStyleBackColor = false;
            this.Topbtn.Click += new System.EventHandler(this.Topbtn_Click);
            // 
            // Backbtn
            // 
            this.Backbtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Backbtn.Font = new System.Drawing.Font("新細明體", 10F);
            this.Backbtn.ForeColor = System.Drawing.Color.White;
            this.Backbtn.Location = new System.Drawing.Point(477, 578);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(50, 50);
            this.Backbtn.TabIndex = 34;
            this.Backbtn.Text = "<";
            this.Backbtn.UseVisualStyleBackColor = false;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            this.Backbtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Backbtn_MouseDown);
            this.Backbtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Backbtn_MouseUp);
            // 
            // Lastbtn
            // 
            this.Lastbtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Lastbtn.Font = new System.Drawing.Font("新細明體", 10F);
            this.Lastbtn.ForeColor = System.Drawing.Color.White;
            this.Lastbtn.Location = new System.Drawing.Point(643, 578);
            this.Lastbtn.Name = "Lastbtn";
            this.Lastbtn.Size = new System.Drawing.Size(50, 50);
            this.Lastbtn.TabIndex = 35;
            this.Lastbtn.Text = ">>";
            this.Lastbtn.UseVisualStyleBackColor = false;
            this.Lastbtn.Click += new System.EventHandler(this.Lastbtn_Click);
            // 
            // txt7
            // 
            this.txt7.AutoSize = true;
            this.txt7.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt7.Location = new System.Drawing.Point(870, 308);
            this.txt7.Name = "txt7";
            this.txt7.Size = new System.Drawing.Size(130, 25);
            this.txt7.TabIndex = 36;
            this.txt7.Text = "NOW/MAX";
            // 
            // txt8
            // 
            this.txt8.AutoSize = true;
            this.txt8.Font = new System.Drawing.Font("新細明體", 15F);
            this.txt8.Location = new System.Drawing.Point(684, 550);
            this.txt8.Name = "txt8";
            this.txt8.Size = new System.Drawing.Size(249, 25);
            this.txt8.TabIndex = 37;
            this.txt8.Text = "全部應納稅額：共0元";
            // 
            // timerNEXT
            // 
            this.timerNEXT.Interval = 1000;
            this.timerNEXT.Tick += new System.EventHandler(this.timerNEXT_Tick);
            // 
            // timerBACK
            // 
            this.timerBACK.Interval = 1000;
            this.timerBACK.Tick += new System.EventHandler(this.timerBACK_Tick);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("新細明體", 15F);
            this.labelDate.Location = new System.Drawing.Point(391, 52);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(112, 25);
            this.labelDate.TabIndex = 39;
            this.labelDate.Text = "使用期間";
            // 
            // labelCar
            // 
            this.labelCar.AutoSize = true;
            this.labelCar.Font = new System.Drawing.Font("新細明體", 15F);
            this.labelCar.Location = new System.Drawing.Point(391, 149);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(62, 25);
            this.labelCar.TabIndex = 40;
            this.labelCar.Text = "用途";
            // 
            // labelCC
            // 
            this.labelCC.AutoSize = true;
            this.labelCC.Font = new System.Drawing.Font("新細明體", 15F);
            this.labelCC.Location = new System.Drawing.Point(391, 245);
            this.labelCC.Name = "labelCC";
            this.labelCC.Size = new System.Drawing.Size(119, 25);
            this.labelCC.TabIndex = 41;
            this.labelCC.Text = "汽缸CC數";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button1.Font = new System.Drawing.Font("新細明體", 20F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(60, 578);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 50);
            this.button1.TabIndex = 42;
            this.button1.Text = "匯入輸出結果";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.button2.Font = new System.Drawing.Font("新細明體", 20F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(734, 578);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 50);
            this.button2.TabIndex = 43;
            this.button2.Text = "儲存輸出結果";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "D:\\ShowTax.txt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 640);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelCC);
            this.Controls.Add(this.labelCar);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.txt8);
            this.Controls.Add(this.txt7);
            this.Controls.Add(this.Lastbtn);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.Topbtn);
            this.Controls.Add(this.Nextbtn);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Submitbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Submitbtn;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.Label txt2;
        private System.Windows.Forms.Label txt3;
        private System.Windows.Forms.Label txt4;
        private System.Windows.Forms.Label txt5;
        private System.Windows.Forms.Label txt6;
        private System.Windows.Forms.Button Nextbtn;
        private System.Windows.Forms.Button Topbtn;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button Lastbtn;
        private System.Windows.Forms.Label txt7;
        private System.Windows.Forms.Label txt8;
        private System.Windows.Forms.Timer timerNEXT;
        private System.Windows.Forms.Timer timerBACK;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Label labelCC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

