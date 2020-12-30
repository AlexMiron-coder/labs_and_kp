namespace lab12_CRPPC
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.элементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioElf = new System.Windows.Forms.RadioButton();
            this.radioOrk = new System.Windows.Forms.RadioButton();
            this.radioPeople = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioPaladin = new System.Windows.Forms.RadioButton();
            this.radioVoin = new System.Windows.Forms.RadioButton();
            this.radioMag = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioHammer = new System.Windows.Forms.RadioButton();
            this.radioStaff = new System.Windows.Forms.RadioButton();
            this.radioSword = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.элементыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // элементыToolStripMenuItem
            // 
            this.элементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeViewToolStripMenuItem});
            this.элементыToolStripMenuItem.Name = "элементыToolStripMenuItem";
            this.элементыToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.элементыToolStripMenuItem.Text = "Элементы";
            // 
            // treeViewToolStripMenuItem
            // 
            this.treeViewToolStripMenuItem.Name = "treeViewToolStripMenuItem";
            this.treeViewToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.treeViewToolStripMenuItem.Text = "TreeView";
            this.treeViewToolStripMenuItem.Click += new System.EventHandler(this.treeViewToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioElf);
            this.groupBox1.Controls.Add(this.radioOrk);
            this.groupBox1.Controls.Add(this.radioPeople);
            this.groupBox1.Location = new System.Drawing.Point(49, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Раса";
            // 
            // radioElf
            // 
            this.radioElf.AutoSize = true;
            this.radioElf.Location = new System.Drawing.Point(6, 44);
            this.radioElf.Name = "radioElf";
            this.radioElf.Size = new System.Drawing.Size(52, 17);
            this.radioElf.TabIndex = 1;
            this.radioElf.TabStop = true;
            this.radioElf.Text = "Эльф";
            this.radioElf.UseVisualStyleBackColor = true;
            // 
            // radioOrk
            // 
            this.radioOrk.AutoSize = true;
            this.radioOrk.Location = new System.Drawing.Point(6, 67);
            this.radioOrk.Name = "radioOrk";
            this.radioOrk.Size = new System.Drawing.Size(45, 17);
            this.radioOrk.TabIndex = 0;
            this.radioOrk.TabStop = true;
            this.radioOrk.Text = "Орк";
            this.radioOrk.UseVisualStyleBackColor = true;
            // 
            // radioPeople
            // 
            this.radioPeople.AutoSize = true;
            this.radioPeople.Location = new System.Drawing.Point(6, 21);
            this.radioPeople.Name = "radioPeople";
            this.radioPeople.Size = new System.Drawing.Size(69, 17);
            this.radioPeople.TabIndex = 0;
            this.radioPeople.TabStop = true;
            this.radioPeople.Text = "Человек";
            this.radioPeople.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioPaladin);
            this.groupBox2.Controls.Add(this.radioVoin);
            this.groupBox2.Controls.Add(this.radioMag);
            this.groupBox2.Location = new System.Drawing.Point(302, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Класс";
            // 
            // radioPaladin
            // 
            this.radioPaladin.AutoSize = true;
            this.radioPaladin.Location = new System.Drawing.Point(6, 67);
            this.radioPaladin.Name = "radioPaladin";
            this.radioPaladin.Size = new System.Drawing.Size(69, 17);
            this.radioPaladin.TabIndex = 2;
            this.radioPaladin.TabStop = true;
            this.radioPaladin.Text = "Паладин";
            this.radioPaladin.UseVisualStyleBackColor = true;
            // 
            // radioVoin
            // 
            this.radioVoin.AutoSize = true;
            this.radioVoin.Location = new System.Drawing.Point(6, 21);
            this.radioVoin.Name = "radioVoin";
            this.radioVoin.Size = new System.Drawing.Size(50, 17);
            this.radioVoin.TabIndex = 0;
            this.radioVoin.TabStop = true;
            this.radioVoin.Text = "Воин";
            this.radioVoin.UseVisualStyleBackColor = true;
            // 
            // radioMag
            // 
            this.radioMag.AutoSize = true;
            this.radioMag.Location = new System.Drawing.Point(6, 44);
            this.radioMag.Name = "radioMag";
            this.radioMag.Size = new System.Drawing.Size(45, 17);
            this.radioMag.TabIndex = 1;
            this.radioMag.TabStop = true;
            this.radioMag.Text = "Маг";
            this.radioMag.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioHammer);
            this.groupBox3.Controls.Add(this.radioStaff);
            this.groupBox3.Controls.Add(this.radioSword);
            this.groupBox3.Location = new System.Drawing.Point(553, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Оружие";
            // 
            // radioHammer
            // 
            this.radioHammer.AutoSize = true;
            this.radioHammer.Location = new System.Drawing.Point(7, 67);
            this.radioHammer.Name = "radioHammer";
            this.radioHammer.Size = new System.Drawing.Size(57, 17);
            this.radioHammer.TabIndex = 2;
            this.radioHammer.TabStop = true;
            this.radioHammer.Text = "Молот";
            this.radioHammer.UseVisualStyleBackColor = true;
            // 
            // radioStaff
            // 
            this.radioStaff.AutoSize = true;
            this.radioStaff.Location = new System.Drawing.Point(7, 44);
            this.radioStaff.Name = "radioStaff";
            this.radioStaff.Size = new System.Drawing.Size(56, 17);
            this.radioStaff.TabIndex = 1;
            this.radioStaff.TabStop = true;
            this.radioStaff.Text = "Посох";
            this.radioStaff.UseVisualStyleBackColor = true;
            // 
            // radioSword
            // 
            this.radioSword.AutoSize = true;
            this.radioSword.Location = new System.Drawing.Point(7, 20);
            this.radioSword.Name = "radioSword";
            this.radioSword.Size = new System.Drawing.Size(45, 17);
            this.radioSword.TabIndex = 0;
            this.radioSword.TabStop = true;
            this.radioSword.Text = "Меч";
            this.radioSword.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(651, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(49, 232);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 190);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem элементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeViewToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RadioButton radioPeople;
        public System.Windows.Forms.RadioButton radioElf;
        public System.Windows.Forms.RadioButton radioOrk;
        public System.Windows.Forms.RadioButton radioPaladin;
        public System.Windows.Forms.RadioButton radioMag;
        public System.Windows.Forms.RadioButton radioHammer;
        public System.Windows.Forms.RadioButton radioStaff;
        public System.Windows.Forms.RadioButton radioSword;
        public System.Windows.Forms.RadioButton radioVoin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

