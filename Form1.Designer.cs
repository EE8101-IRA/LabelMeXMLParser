namespace LabelMeXML_Parser
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
            this.button_FolderBrowserDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_filePath = new System.Windows.Forms.TextBox();
            this.button_Convert = new System.Windows.Forms.Button();
            this.debugLabel = new System.Windows.Forms.Label();
            this.numFilesLabel = new System.Windows.Forms.Label();
            this.TextBox_outputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_FolderBrowserDialog
            // 
            this.button_FolderBrowserDialog.Location = new System.Drawing.Point(622, 129);
            this.button_FolderBrowserDialog.Name = "button_FolderBrowserDialog";
            this.button_FolderBrowserDialog.Size = new System.Drawing.Size(75, 23);
            this.button_FolderBrowserDialog.TabIndex = 0;
            this.button_FolderBrowserDialog.Text = "Browse";
            this.button_FolderBrowserDialog.UseVisualStyleBackColor = true;
            this.button_FolderBrowserDialog.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "XML Parser";
            // 
            // TextBox_filePath
            // 
            this.TextBox_filePath.Location = new System.Drawing.Point(79, 129);
            this.TextBox_filePath.Name = "TextBox_filePath";
            this.TextBox_filePath.Size = new System.Drawing.Size(537, 22);
            this.TextBox_filePath.TabIndex = 2;
            // 
            // button_Convert
            // 
            this.button_Convert.Location = new System.Drawing.Point(478, 235);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(113, 23);
            this.button_Convert.TabIndex = 3;
            this.button_Convert.Text = "Convert to CSV";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(303, 281);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(74, 17);
            this.debugLabel.TabIndex = 4;
            this.debugLabel.Text = "debug text";
            // 
            // numFilesLabel
            // 
            this.numFilesLabel.AutoSize = true;
            this.numFilesLabel.Location = new System.Drawing.Point(88, 154);
            this.numFilesLabel.Name = "numFilesLabel";
            this.numFilesLabel.Size = new System.Drawing.Size(143, 17);
            this.numFilesLabel.TabIndex = 5;
            this.numFilesLabel.Text = "Number of XML files: ";
            this.numFilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TextBox_outputFile
            // 
            this.TextBox_outputFile.Location = new System.Drawing.Point(306, 236);
            this.TextBox_outputFile.Name = "TextBox_outputFile";
            this.TextBox_outputFile.Size = new System.Drawing.Size(166, 22);
            this.TextBox_outputFile.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Output File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "File Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox_outputFile);
            this.Controls.Add(this.numFilesLabel);
            this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.button_Convert);
            this.Controls.Add(this.TextBox_filePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_FolderBrowserDialog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_FolderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_filePath;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Label numFilesLabel;
        private System.Windows.Forms.TextBox TextBox_outputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

