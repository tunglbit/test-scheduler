namespace Assignment1_PTTKGT
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
            this.btnImportListExamRoom = new System.Windows.Forms.Button();
            this.lstCourseEnroll = new System.Windows.Forms.ListView();
            this.btnLstCourseEnroll = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnImportListExamRoom
            // 
            this.btnImportListExamRoom.Location = new System.Drawing.Point(13, 13);
            this.btnImportListExamRoom.Name = "btnImportListExamRoom";
            this.btnImportListExamRoom.Size = new System.Drawing.Size(196, 23);
            this.btnImportListExamRoom.TabIndex = 0;
            this.btnImportListExamRoom.Text = "Import list of examination room";
            this.btnImportListExamRoom.UseVisualStyleBackColor = true;
            this.btnImportListExamRoom.Click += new System.EventHandler(this.btnImportListExamRoom_Click);
            // 
            // lstCourseEnroll
            // 
            this.lstCourseEnroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCourseEnroll.FullRowSelect = true;
            this.lstCourseEnroll.GridLines = true;
            this.lstCourseEnroll.Location = new System.Drawing.Point(13, 95);
            this.lstCourseEnroll.Name = "lstCourseEnroll";
            this.lstCourseEnroll.Size = new System.Drawing.Size(685, 289);
            this.lstCourseEnroll.TabIndex = 1;
            this.lstCourseEnroll.UseCompatibleStateImageBehavior = false;
            this.lstCourseEnroll.View = System.Windows.Forms.View.Details;
            // 
            // btnLstCourseEnroll
            // 
            this.btnLstCourseEnroll.Location = new System.Drawing.Point(230, 13);
            this.btnLstCourseEnroll.Name = "btnLstCourseEnroll";
            this.btnLstCourseEnroll.Size = new System.Drawing.Size(205, 23);
            this.btnLstCourseEnroll.TabIndex = 2;
            this.btnLstCourseEnroll.Text = "Import list of course enroll";
            this.btnLstCourseEnroll.UseVisualStyleBackColor = true;
            this.btnLstCourseEnroll.Click += new System.EventHandler(this.btnLstCourseEnroll_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(464, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(685, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 396);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnLstCourseEnroll);
            this.Controls.Add(this.lstCourseEnroll);
            this.Controls.Add(this.btnImportListExamRoom);
            this.Name = "Form1";
            this.Text = "Create examination schedules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportListExamRoom;
        private System.Windows.Forms.ListView lstCourseEnroll;
        private System.Windows.Forms.Button btnLstCourseEnroll;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

