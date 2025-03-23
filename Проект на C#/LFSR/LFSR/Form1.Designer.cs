namespace LFSR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labText = new Label();
            bttnBrowse = new Button();
            bttnSave = new Button();
            bttnRes = new Button();
            textBoxFile = new TextBox();
            textBoxKey = new TextBox();
            textBox = new TextBox();
            labPolynomial = new Label();
            textBox1 = new TextBox();
            bttnClear = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // labText
            // 
            labText.AutoSize = true;
            labText.Font = new Font("Segoe UI", 10.8F);
            labText.Location = new Point(301, 0);
            labText.Name = "labText";
            labText.Size = new Size(439, 50);
            labText.TabIndex = 0;
            labText.Text = "Вариант 4. \r\nПримитивный многочлен: x^26 + x^8 + x^7 + x + 1";
            labText.TextAlign = ContentAlignment.TopCenter;
            // 
            // bttnBrowse
            // 
            bttnBrowse.Font = new Font("Segoe UI", 10.8F);
            bttnBrowse.Location = new Point(765, 53);
            bttnBrowse.Name = "bttnBrowse";
            bttnBrowse.Size = new Size(130, 39);
            bttnBrowse.TabIndex = 1;
            bttnBrowse.Text = "Просмотреть";
            bttnBrowse.UseVisualStyleBackColor = true;
            bttnBrowse.Click += bttnBrowse_Click;
            // 
            // bttnSave
            // 
            bttnSave.Font = new Font("Segoe UI", 10.8F);
            bttnSave.Location = new Point(475, 178);
            bttnSave.Name = "bttnSave";
            bttnSave.Size = new Size(130, 37);
            bttnSave.TabIndex = 6;
            bttnSave.Text = "Сохранить";
            bttnSave.UseVisualStyleBackColor = true;
            bttnSave.Click += bttnSave_Click;
            // 
            // bttnRes
            // 
            bttnRes.Font = new Font("Segoe UI", 10.8F);
            bttnRes.Location = new Point(339, 178);
            bttnRes.Name = "bttnRes";
            bttnRes.Size = new Size(130, 37);
            bttnRes.TabIndex = 5;
            bttnRes.Text = "Результат";
            bttnRes.UseVisualStyleBackColor = true;
            bttnRes.Click += bttnRes_Click;
            // 
            // textBoxFile
            // 
            textBoxFile.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBoxFile.Location = new Point(12, 53);
            textBoxFile.MinimumSize = new Size(0, 39);
            textBoxFile.Name = "textBoxFile";
            textBoxFile.Size = new Size(747, 39);
            textBoxFile.TabIndex = 2;
            // 
            // textBoxKey
            // 
            textBoxKey.Font = new Font("Segoe UI", 10.8F);
            textBoxKey.Location = new Point(11, 98);
            textBoxKey.MinimumSize = new Size(0, 39);
            textBoxKey.Multiline = true;
            textBoxKey.Name = "textBoxKey";
            textBoxKey.ScrollBars = ScrollBars.Vertical;
            textBoxKey.Size = new Size(884, 61);
            textBoxKey.TabIndex = 3;
            textBoxKey.TextChanged += textBoxKey_TextChanged;
            textBoxKey.KeyPress += textBoxKey_KeyPress;
            // 
            // textBox
            // 
            textBox.Font = new Font("Segoe UI", 10.8F);
            textBox.Location = new Point(11, 221);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Size = new Size(458, 179);
            textBox.TabIndex = 10;
            // 
            // labPolynomial
            // 
            labPolynomial.AutoSize = true;
            labPolynomial.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labPolynomial.Location = new Point(11, 162);
            labPolynomial.Name = "labPolynomial";
            labPolynomial.Size = new Size(79, 17);
            labPolynomial.TabIndex = 8;
            labPolynomial.Text = "Длина LFSR:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.8F);
            textBox1.Location = new Point(475, 221);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(458, 179);
            textBox1.TabIndex = 11;
            // 
            // bttnClear
            // 
            bttnClear.Font = new Font("Segoe UI", 10.8F);
            bttnClear.Location = new Point(746, 406);
            bttnClear.Name = "bttnClear";
            bttnClear.Size = new Size(187, 39);
            bttnClear.TabIndex = 12;
            bttnClear.Text = "Очистить все поля";
            bttnClear.UseVisualStyleBackColor = true;
            bttnClear.Click += bttnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F);
            label1.Location = new Point(10, 199);
            label1.Name = "label1";
            label1.Size = new Size(71, 17);
            label1.TabIndex = 13;
            label1.Text = "Исходный:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F);
            label2.Location = new Point(788, 198);
            label2.Name = "label2";
            label2.Size = new Size(112, 17);
            label2.TabIndex = 14;
            label2.Text = "Зашифрованный:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 449);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bttnClear);
            Controls.Add(textBox1);
            Controls.Add(labPolynomial);
            Controls.Add(textBox);
            Controls.Add(textBoxKey);
            Controls.Add(textBoxFile);
            Controls.Add(bttnRes);
            Controls.Add(bttnSave);
            Controls.Add(bttnBrowse);
            Controls.Add(labText);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Потоковое шифрование";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labText;
        private Button bttnBrowse;
        private Button bttnSave;
        private Button bttnRes;
        private TextBox textBoxFile;
        private TextBox textBoxKey;
        private TextBox textBox;
        private Label labPolynomial;
        private TextBox textBox1;
        private Button bttnClear;
        private Label label1;
        private Label label2;
    }
}
