namespace cpts322hw12_threading
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.urltextbox = new System.Windows.Forms.TextBox();
            this.download = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.downloadresultbox = new System.Windows.Forms.TextBox();
            this.button_sorting = new System.Windows.Forms.Button();
            this.textBox_sortingresult = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.urltextbox);
            this.groupBox1.Location = new System.Drawing.Point(289, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "URL";
            // 
            // urltextbox
            // 
            this.urltextbox.Location = new System.Drawing.Point(6, 19);
            this.urltextbox.Name = "urltextbox";
            this.urltextbox.Size = new System.Drawing.Size(301, 20);
            this.urltextbox.TabIndex = 0;
            // 
            // download
            // 
            this.download.Location = new System.Drawing.Point(295, 69);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(301, 35);
            this.download.TabIndex = 1;
            this.download.Text = "Download string from URL";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.downloadresultbox);
            this.groupBox2.Location = new System.Drawing.Point(289, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 315);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download result";
            // 
            // downloadresultbox
            // 
            this.downloadresultbox.Location = new System.Drawing.Point(18, 30);
            this.downloadresultbox.Multiline = true;
            this.downloadresultbox.Name = "downloadresultbox";
            this.downloadresultbox.ReadOnly = true;
            this.downloadresultbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.downloadresultbox.Size = new System.Drawing.Size(273, 268);
            this.downloadresultbox.TabIndex = 0;
            this.downloadresultbox.TextChanged += new System.EventHandler(this.downloadresultbox_TextChanged);
            // 
            // button_sorting
            // 
            this.button_sorting.Location = new System.Drawing.Point(12, 12);
            this.button_sorting.Name = "button_sorting";
            this.button_sorting.Size = new System.Drawing.Size(271, 51);
            this.button_sorting.TabIndex = 4;
            this.button_sorting.Text = "Go sorting";
            this.button_sorting.UseVisualStyleBackColor = true;
            this.button_sorting.Click += new System.EventHandler(this.button_sorting_Click);
            // 
            // textBox_sortingresult
            // 
            this.textBox_sortingresult.Location = new System.Drawing.Point(13, 83);
            this.textBox_sortingresult.Multiline = true;
            this.textBox_sortingresult.Name = "textBox_sortingresult";
            this.textBox_sortingresult.ReadOnly = true;
            this.textBox_sortingresult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_sortingresult.Size = new System.Drawing.Size(270, 341);
            this.textBox_sortingresult.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 453);
            this.Controls.Add(this.textBox_sortingresult);
            this.Controls.Add(this.button_sorting);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.download);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "hw12 threading by Siyang Li 11443579";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox urltextbox;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox downloadresultbox;
        private System.Windows.Forms.Button button_sorting;
        private System.Windows.Forms.TextBox textBox_sortingresult;

    }
}

