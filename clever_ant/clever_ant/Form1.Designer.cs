namespace clever_ant
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.main_pictureBox = new System.Windows.Forms.PictureBox();
            this.button_nextStep = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_randEat = new System.Windows.Forms.Button();
            this.button_timer = new System.Windows.Forms.Button();
            this.label_eatCount = new System.Windows.Forms.Label();
            this.textBox_matrixSize = new System.Windows.Forms.TextBox();
            this.trackBar_timerTick = new System.Windows.Forms.TrackBar();
            this.button_setHome = new System.Windows.Forms.Button();
            this.button_colorMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.main_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_timerTick)).BeginInit();
            this.SuspendLayout();
            // 
            // main_pictureBox
            // 
            this.main_pictureBox.Location = new System.Drawing.Point(12, 12);
            this.main_pictureBox.Name = "main_pictureBox";
            this.main_pictureBox.Size = new System.Drawing.Size(551, 551);
            this.main_pictureBox.TabIndex = 0;
            this.main_pictureBox.TabStop = false;
            this.main_pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_pictureBox_MouseDown);
            // 
            // button_nextStep
            // 
            this.button_nextStep.Location = new System.Drawing.Point(570, 66);
            this.button_nextStep.Name = "button_nextStep";
            this.button_nextStep.Size = new System.Drawing.Size(75, 23);
            this.button_nextStep.TabIndex = 1;
            this.button_nextStep.Text = "next";
            this.button_nextStep.UseVisualStyleBackColor = true;
            this.button_nextStep.Click += new System.EventHandler(this.button_nextStep_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(570, 37);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 2;
            this.button_load.Text = "load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_randEat
            // 
            this.button_randEat.Location = new System.Drawing.Point(570, 95);
            this.button_randEat.Name = "button_randEat";
            this.button_randEat.Size = new System.Drawing.Size(75, 23);
            this.button_randEat.TabIndex = 3;
            this.button_randEat.Text = "rand eat";
            this.button_randEat.UseVisualStyleBackColor = true;
            this.button_randEat.Click += new System.EventHandler(this.button_randEat_Click);
            // 
            // button_timer
            // 
            this.button_timer.Location = new System.Drawing.Point(570, 124);
            this.button_timer.Name = "button_timer";
            this.button_timer.Size = new System.Drawing.Size(75, 23);
            this.button_timer.TabIndex = 4;
            this.button_timer.Text = "timer on";
            this.button_timer.UseVisualStyleBackColor = true;
            this.button_timer.Click += new System.EventHandler(this.button_timer_Click);
            // 
            // label_eatCount
            // 
            this.label_eatCount.AutoSize = true;
            this.label_eatCount.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_eatCount.ForeColor = System.Drawing.Color.Firebrick;
            this.label_eatCount.Location = new System.Drawing.Point(579, 538);
            this.label_eatCount.Name = "label_eatCount";
            this.label_eatCount.Size = new System.Drawing.Size(20, 24);
            this.label_eatCount.TabIndex = 5;
            this.label_eatCount.Text = "0";
            // 
            // textBox_matrixSize
            // 
            this.textBox_matrixSize.Location = new System.Drawing.Point(570, 11);
            this.textBox_matrixSize.MaxLength = 2;
            this.textBox_matrixSize.Name = "textBox_matrixSize";
            this.textBox_matrixSize.Size = new System.Drawing.Size(74, 20);
            this.textBox_matrixSize.TabIndex = 1;
            this.textBox_matrixSize.Text = "20";
            // 
            // trackBar_timerTick
            // 
            this.trackBar_timerTick.Location = new System.Drawing.Point(600, 211);
            this.trackBar_timerTick.Maximum = 200;
            this.trackBar_timerTick.Minimum = 10;
            this.trackBar_timerTick.Name = "trackBar_timerTick";
            this.trackBar_timerTick.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_timerTick.Size = new System.Drawing.Size(45, 104);
            this.trackBar_timerTick.TabIndex = 7;
            this.trackBar_timerTick.Value = 10;
            this.trackBar_timerTick.Scroll += new System.EventHandler(this.trackBar_timerTick_Scroll);
            // 
            // button_setHome
            // 
            this.button_setHome.Location = new System.Drawing.Point(570, 153);
            this.button_setHome.Name = "button_setHome";
            this.button_setHome.Size = new System.Drawing.Size(75, 23);
            this.button_setHome.TabIndex = 8;
            this.button_setHome.Text = "set home";
            this.button_setHome.UseVisualStyleBackColor = true;
            this.button_setHome.Click += new System.EventHandler(this.button_setHome_Click);
            // 
            // button_colorMode
            // 
            this.button_colorMode.Location = new System.Drawing.Point(570, 182);
            this.button_colorMode.Name = "button_colorMode";
            this.button_colorMode.Size = new System.Drawing.Size(75, 23);
            this.button_colorMode.TabIndex = 9;
            this.button_colorMode.Text = "color mode";
            this.button_colorMode.UseVisualStyleBackColor = true;
            this.button_colorMode.Click += new System.EventHandler(this.button_colorMode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(652, 573);
            this.Controls.Add(this.button_colorMode);
            this.Controls.Add(this.button_setHome);
            this.Controls.Add(this.trackBar_timerTick);
            this.Controls.Add(this.textBox_matrixSize);
            this.Controls.Add(this.label_eatCount);
            this.Controls.Add(this.button_timer);
            this.Controls.Add(this.button_randEat);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_nextStep);
            this.Controls.Add(this.main_pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "clever ant";
            ((System.ComponentModel.ISupportInitialize)(this.main_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_timerTick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox main_pictureBox;
        private System.Windows.Forms.Button button_nextStep;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_randEat;
        private System.Windows.Forms.Button button_timer;
        private System.Windows.Forms.Label label_eatCount;
        private System.Windows.Forms.TextBox textBox_matrixSize;
        private System.Windows.Forms.TrackBar trackBar_timerTick;
        private System.Windows.Forms.Button button_setHome;
        private System.Windows.Forms.Button button_colorMode;
    }
}

