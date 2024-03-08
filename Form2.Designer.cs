namespace Taschenrechner
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnMMinus = new System.Windows.Forms.Button();
            this.btnBerechnen = new System.Windows.Forms.Button();
            this.btnMPlus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(116, 32);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(211, 246);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // btnMMinus
            // 
            this.btnMMinus.Location = new System.Drawing.Point(116, 299);
            this.btnMMinus.Name = "btnMMinus";
            this.btnMMinus.Size = new System.Drawing.Size(94, 29);
            this.btnMMinus.TabIndex = 1;
            this.btnMMinus.Text = "M-";
            this.btnMMinus.UseVisualStyleBackColor = true;
            this.btnMMinus.Click += new System.EventHandler(this.btnMMinus_Click);
            // 
            // btnBerechnen
            // 
            this.btnBerechnen.Location = new System.Drawing.Point(178, 334);
            this.btnBerechnen.Name = "btnBerechnen";
            this.btnBerechnen.Size = new System.Drawing.Size(94, 29);
            this.btnBerechnen.TabIndex = 2;
            this.btnBerechnen.Text = "Berechnen";
            this.btnBerechnen.UseVisualStyleBackColor = true;
            this.btnBerechnen.Click += new System.EventHandler(this.btnBerechnen_Click);
            // 
            // btnMPlus
            // 
            this.btnMPlus.Location = new System.Drawing.Point(233, 299);
            this.btnMPlus.Name = "btnMPlus";
            this.btnMPlus.Size = new System.Drawing.Size(94, 29);
            this.btnMPlus.TabIndex = 3;
            this.btnMPlus.Text = "M+";
            this.btnMPlus.UseVisualStyleBackColor = true;
            this.btnMPlus.Click += new System.EventHandler(this.btnMPlus_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 399);
            this.Controls.Add(this.btnMPlus);
            this.Controls.Add(this.btnBerechnen);
            this.Controls.Add(this.btnMMinus);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Button btnMMinus;
        private Button btnBerechnen;
        private Button btnMPlus;
    }
}