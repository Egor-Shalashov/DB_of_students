namespace DB_of_students.Forms
{
    partial class Teacher_theme
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
            this.label1 = new System.Windows.Forms.Label();
            this.DGV_theme = new System.Windows.Forms.DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.cb_theme = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_theme)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Предметы ";
            // 
            // DGV_theme
            // 
            this.DGV_theme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_theme.Location = new System.Drawing.Point(12, 64);
            this.DGV_theme.Name = "DGV_theme";
            this.DGV_theme.Size = new System.Drawing.Size(249, 225);
            this.DGV_theme.TabIndex = 1;
            this.DGV_theme.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_theme_CellClick);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(13, 296);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Добавить";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cb_theme
            // 
            this.cb_theme.FormattingEnabled = true;
            this.cb_theme.Location = new System.Drawing.Point(140, 298);
            this.cb_theme.Name = "cb_theme";
            this.cb_theme.Size = new System.Drawing.Size(121, 21);
            this.cb_theme.TabIndex = 3;
            // 
            // Teacher_theme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 334);
            this.Controls.Add(this.cb_theme);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.DGV_theme);
            this.Controls.Add(this.label1);
            this.Name = "Teacher_theme";
            this.Text = "Teacher_theme";
            this.Load += new System.EventHandler(this.Teacher_theme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_theme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGV_theme;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cb_theme;
    }
}