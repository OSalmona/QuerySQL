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
            this.Excute_Btn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGredView)).BeginInit();
            this.SuspendLayout();
            // 
            // Query_Input
            // 
            this.Query_Input.Location = new System.Drawing.Point(15, 70);
            this.Query_Input.Name = "Query_Input";
            this.Query_Input.Size = new System.Drawing.Size(443, 20);
            this.Query_Input.TabIndex = 0;
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
            this.ResultGredView.Location = new System.Drawing.Point(12, 96);
            this.ResultGredView.Name = "ResultGredView";
            this.ResultGredView.ReadOnly = true;
            this.ResultGredView.Size = new System.Drawing.Size(446, 236);
            this.ResultGredView.TabIndex = 2;
            // 
            // Excute_Btn
            // 
            this.Excute_Btn.Location = new System.Drawing.Point(363, 38);
            this.Excute_Btn.Name = "Excute_Btn";
            this.Excute_Btn.Size = new System.Drawing.Size(75, 23);
            this.Excute_Btn.TabIndex = 3;
            this.Excute_Btn.Text = "Excute";
            this.Excute_Btn.UseVisualStyleBackColor = true;
            this.Excute_Btn.Click += new System.EventHandler(this.Excute_Btn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 344);
            this.Controls.Add(this.Excute_Btn);
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
        private System.Windows.Forms.Button Excute_Btn;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

