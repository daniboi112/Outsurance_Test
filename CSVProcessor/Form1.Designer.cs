namespace CSVProcessor
{
    partial class frmCSVProcessor
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
            this.btnOpenCSV = new System.Windows.Forms.Button();
            this.oDlgCSV = new System.Windows.Forms.OpenFileDialog();
            this.lblOutputDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOpenCSV
            // 
            this.btnOpenCSV.Location = new System.Drawing.Point(12, 12);
            this.btnOpenCSV.Name = "btnOpenCSV";
            this.btnOpenCSV.Size = new System.Drawing.Size(640, 88);
            this.btnOpenCSV.TabIndex = 0;
            this.btnOpenCSV.Text = "Open CSV File";
            this.btnOpenCSV.UseVisualStyleBackColor = true;
            this.btnOpenCSV.Click += new System.EventHandler(this.btnOpenCSV_Click);
            // 
            // oDlgCSV
            // 
            this.oDlgCSV.FileName = "openFileDialog1";
            // 
            // lblOutputDesc
            // 
            this.lblOutputDesc.AutoSize = true;
            this.lblOutputDesc.Location = new System.Drawing.Point(12, 129);
            this.lblOutputDesc.Name = "lblOutputDesc";
            this.lblOutputDesc.Size = new System.Drawing.Size(105, 17);
            this.lblOutputDesc.TabIndex = 2;
            this.lblOutputDesc.Text = "[lblOutputDesc]";
            // 
            // frmCSVProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 338);
            this.Controls.Add(this.lblOutputDesc);
            this.Controls.Add(this.btnOpenCSV);
            this.Name = "frmCSVProcessor";
            this.Text = "CSV Processor - Dintwe Mohutsioa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenCSV;
        private System.Windows.Forms.OpenFileDialog oDlgCSV;
        private System.Windows.Forms.Label lblOutputDesc;
    }
}

