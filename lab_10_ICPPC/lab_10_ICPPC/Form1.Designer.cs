namespace lab_10_ICPPC
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioTriangle = new System.Windows.Forms.RadioButton();
            this.radioSquare = new System.Windows.Forms.RadioButton();
            this.radioCircle = new System.Windows.Forms.RadioButton();
            this.radioN = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label_out = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(61, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Длина ребра (радиуса)=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Количество сторон:";
            // 
            // radioTriangle
            // 
            this.radioTriangle.AutoSize = true;
            this.radioTriangle.Location = new System.Drawing.Point(151, 158);
            this.radioTriangle.Name = "radioTriangle";
            this.radioTriangle.Size = new System.Drawing.Size(90, 17);
            this.radioTriangle.TabIndex = 3;
            this.radioTriangle.TabStop = true;
            this.radioTriangle.Text = "Треугольник";
            this.radioTriangle.UseVisualStyleBackColor = true;
            // 
            // radioSquare
            // 
            this.radioSquare.AutoSize = true;
            this.radioSquare.Location = new System.Drawing.Point(151, 182);
            this.radioSquare.Name = "radioSquare";
            this.radioSquare.Size = new System.Drawing.Size(67, 17);
            this.radioSquare.TabIndex = 4;
            this.radioSquare.TabStop = true;
            this.radioSquare.Text = "Квадрат";
            this.radioSquare.UseVisualStyleBackColor = true;
            // 
            // radioCircle
            // 
            this.radioCircle.AutoSize = true;
            this.radioCircle.Location = new System.Drawing.Point(151, 206);
            this.radioCircle.Name = "radioCircle";
            this.radioCircle.Size = new System.Drawing.Size(48, 17);
            this.radioCircle.TabIndex = 5;
            this.radioCircle.TabStop = true;
            this.radioCircle.Text = "Круг";
            this.radioCircle.UseVisualStyleBackColor = true;
            // 
            // radioN
            // 
            this.radioN.AutoSize = true;
            this.radioN.Location = new System.Drawing.Point(151, 230);
            this.radioN.Name = "radioN";
            this.radioN.Size = new System.Drawing.Size(80, 17);
            this.radioN.TabIndex = 6;
            this.radioN.TabStop = true;
            this.radioN.Text = "n-угольник";
            this.radioN.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "S(площадь) = ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Посчитать площадь";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 10;
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(468, 114);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(35, 13);
            this.label_out.TabIndex = 11;
            this.label_out.Text = "label6";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(176, 259);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 20);
            this.textBox2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(148, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "n =";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioN);
            this.Controls.Add(this.radioCircle);
            this.Controls.Add(this.radioSquare);
            this.Controls.Add(this.radioTriangle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "MVC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioTriangle;
        private System.Windows.Forms.RadioButton radioSquare;
        private System.Windows.Forms.RadioButton radioCircle;
        private System.Windows.Forms.RadioButton radioN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
    }
}

