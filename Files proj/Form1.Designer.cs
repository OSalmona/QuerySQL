namespace Files_proj
{
    partial class Form1
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
            this.Query_Input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ResultGredView = new System.Windows.Forms.DataGridView();
            this.ChooseDB = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Excute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGredView)).BeginInit();
            this.SuspendLayout();
            // 
            // Query_Input
            // 
            this.Query_Input.Location = new System.Drawing.Point(15, 70);
            this.Query_Input.Name = "Query_Input";
            this.Query_Input.Size = new System.Drawing.Size(443, 20);
            this.Query_Input.TabIndex = 0;
            this.Query_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Query_Input_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your query:";
            // 
            // ResultGredView
            // 
            this.ResultGredView.AllowUserToAddRows = false;
            this.ResultGredView.AllowUserToDeleteRows = false;
            this.ResultGredView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGredView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultGredView.Location = new System.Drawing.Point(0, 108);
            this.ResultGredView.Name = "ResultGredView";
            this.ResultGredView.ReadOnly = true;
            this.ResultGredView.Size = new System.Drawing.Size(470, 236);
            this.ResultGredView.TabIndex = 2;
            // 
            // ChooseDB
            // 
            this.ChooseDB.Location = new System.Drawing.Point(24, 3);
            this.ChooseDB.Name = "ChooseDB";
            this.ChooseDB.Size = new System.Drawing.Size(75, 23);
            this.ChooseDB.TabIndex = 3;
            this.ChooseDB.Text = "ChooseDB";
            this.ChooseDB.UseVisualStyleBackColor = true;
            this.ChooseDB.Click += new System.EventHandler(this.Excute_Btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Excute
            // 
            this.Excute.Location = new System.Drawing.Point(383, 33);
            this.Excute.Name = "Excute";
            this.Excute.Size = new System.Drawing.Size(75, 23);
            this.Excute.TabIndex = 4;
            this.Excute.Text = "Excute";
            this.Excute.UseVisualStyleBackColor = true;
            this.Excute.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 344);
            this.Controls.Add(this.Excute);
            this.Controls.Add(this.ChooseDB);
            this.Controls.Add(this.ResultGredView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Query_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ResultGredView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Query_Input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ResultGredView;
        private System.Windows.Forms.Button ChooseDB;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Excute;
    }
}

