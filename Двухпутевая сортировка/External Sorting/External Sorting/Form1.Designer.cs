namespace External_Sorting
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
            this.createMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceFileTextBox = new System.Windows.Forms.TextBox();
            this.addFilmButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.fillRandomlyButton = new System.Windows.Forms.Button();
            this.sourceFileLabel = new System.Windows.Forms.Label();
            this.taskButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1136, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createMenuButton,
            this.openMenuButton,
            this.saveMenuButton});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // createMenuButton
            // 
            this.createMenuButton.Name = "createMenuButton";
            this.createMenuButton.Size = new System.Drawing.Size(145, 24);
            this.createMenuButton.Text = "Создать";
            this.createMenuButton.Click += new System.EventHandler(this.CreateMenuButton_Click);
            // 
            // openMenuButton
            // 
            this.openMenuButton.Name = "openMenuButton";
            this.openMenuButton.Size = new System.Drawing.Size(145, 24);
            this.openMenuButton.Text = "Открыть";
            this.openMenuButton.Click += new System.EventHandler(this.OpenMenuButton_Click);
            // 
            // saveMenuButton
            // 
            this.saveMenuButton.Name = "saveMenuButton";
            this.saveMenuButton.Size = new System.Drawing.Size(145, 24);
            this.saveMenuButton.Text = "Сохранить";
            this.saveMenuButton.Click += new System.EventHandler(this.SaveMenuButton_Click);
            // 
            // sourceFileTextBox
            // 
            this.sourceFileTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sourceFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sourceFileTextBox.Location = new System.Drawing.Point(9, 55);
            this.sourceFileTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sourceFileTextBox.Multiline = true;
            this.sourceFileTextBox.Name = "sourceFileTextBox";
            this.sourceFileTextBox.ReadOnly = true;
            this.sourceFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceFileTextBox.Size = new System.Drawing.Size(465, 454);
            this.sourceFileTextBox.TabIndex = 1;
            // 
            // addFilmButton
            // 
            this.addFilmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addFilmButton.Location = new System.Drawing.Point(485, 55);
            this.addFilmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addFilmButton.Name = "addFilmButton";
            this.addFilmButton.Size = new System.Drawing.Size(166, 67);
            this.addFilmButton.TabIndex = 2;
            this.addFilmButton.Text = "Добавить фильм";
            this.addFilmButton.UseVisualStyleBackColor = true;
            this.addFilmButton.Click += new System.EventHandler(this.AddFilmButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sortButton.Location = new System.Drawing.Point(485, 228);
            this.sortButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(166, 80);
            this.sortButton.TabIndex = 3;
            this.sortButton.Text = "Отсортировать файл";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // fillRandomlyButton
            // 
            this.fillRandomlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fillRandomlyButton.Location = new System.Drawing.Point(485, 136);
            this.fillRandomlyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fillRandomlyButton.Name = "fillRandomlyButton";
            this.fillRandomlyButton.Size = new System.Drawing.Size(166, 80);
            this.fillRandomlyButton.TabIndex = 5;
            this.fillRandomlyButton.Text = "Заполнить файл случайными фильмами";
            this.fillRandomlyButton.UseVisualStyleBackColor = true;
            this.fillRandomlyButton.Click += new System.EventHandler(this.fillRandomlyButton_Click);
            // 
            // sourceFileLabel
            // 
            this.sourceFileLabel.AutoSize = true;
            this.sourceFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sourceFileLabel.Location = new System.Drawing.Point(5, 32);
            this.sourceFileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sourceFileLabel.Name = "sourceFileLabel";
            this.sourceFileLabel.Size = new System.Drawing.Size(135, 20);
            this.sourceFileLabel.TabIndex = 6;
            this.sourceFileLabel.Text = "Исходный файл:";
            // 
            // taskButton
            // 
            this.taskButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.taskButton.Location = new System.Drawing.Point(485, 429);
            this.taskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.taskButton.Name = "taskButton";
            this.taskButton.Size = new System.Drawing.Size(166, 80);
            this.taskButton.TabIndex = 7;
            this.taskButton.Text = "Выполнить задание";
            this.taskButton.UseVisualStyleBackColor = true;
            this.taskButton.Click += new System.EventHandler(this.TaskButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTextBox.Location = new System.Drawing.Point(663, 55);
            this.resultTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultTextBox.Size = new System.Drawing.Size(465, 454);
            this.resultTextBox.TabIndex = 8;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultLabel.Location = new System.Drawing.Point(659, 32);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(93, 20);
            this.resultLabel.TabIndex = 9;
            this.resultLabel.Text = "Результат:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(512, 353);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxTime.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 518);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.taskButton);
            this.Controls.Add(this.sourceFileLabel);
            this.Controls.Add(this.fillRandomlyButton);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.addFilmButton);
            this.Controls.Add(this.sourceFileTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMenuButton;
        private System.Windows.Forms.ToolStripMenuItem openMenuButton;
        private System.Windows.Forms.TextBox sourceFileTextBox;
        private System.Windows.Forms.Button addFilmButton;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button fillRandomlyButton;
        private System.Windows.Forms.Label sourceFileLabel;
        private System.Windows.Forms.Button taskButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.ToolStripMenuItem saveMenuButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}

