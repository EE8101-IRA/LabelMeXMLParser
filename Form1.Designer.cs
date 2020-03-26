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
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.button_Convert = new System.Windows.Forms.Button();
            this.debugLabel = new System.Windows.Forms.Label();
            this.numFilesLabel = new System.Windows.Forms.Label();
            this.textBox_outputFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_objectClass = new System.Windows.Forms.TextBox();
            this.textBox_objectLabelName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_imageSource = new System.Windows.Forms.TextBox();
            this.label_imageSource = new System.Windows.Forms.Label();
            this.panel_export = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_trainingType = new System.Windows.Forms.Panel();
            this.panel_export.SuspendLayout();
            this.panel_trainingType.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_FolderBrowserDialog
            // 
            this.button_FolderBrowserDialog.Location = new System.Drawing.Point(622, 129);
            this.button_FolderBrowserDialog.Name = "button_FolderBrowserDialog";
            this.button_FolderBrowserDialog.Size = new System.Drawing.Size(75, 23);
            this.button_FolderBrowserDialog.TabIndex = 1;
            this.button_FolderBrowserDialog.Text = "Browse";
            this.button_FolderBrowserDialog.UseVisualStyleBackColor = true;
            this.button_FolderBrowserDialog.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "XML to CSV for YOLOv3 Training";
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Location = new System.Drawing.Point(79, 129);
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.ReadOnly = true;
            this.textBox_filePath.Size = new System.Drawing.Size(537, 22);
            this.textBox_filePath.TabIndex = 0;
            // 
            // button_Convert
            // 
            this.button_Convert.Location = new System.Drawing.Point(441, 109);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(113, 23);
            this.button_Convert.TabIndex = 6;
            this.button_Convert.Text = "Convert to CSV";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(266, 135);
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
            // textBox_outputFile
            // 
            this.textBox_outputFile.Location = new System.Drawing.Point(269, 110);
            this.textBox_outputFile.Name = "textBox_outputFile";
            this.textBox_outputFile.Size = new System.Drawing.Size(166, 22);
            this.textBox_outputFile.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 113);
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
            // textBox_objectClass
            // 
            this.textBox_objectClass.Location = new System.Drawing.Point(269, 39);
            this.textBox_objectClass.Name = "textBox_objectClass";
            this.textBox_objectClass.Size = new System.Drawing.Size(125, 22);
            this.textBox_objectClass.TabIndex = 3;
            // 
            // textBox_objectLabelName
            // 
            this.textBox_objectLabelName.Location = new System.Drawing.Point(269, 68);
            this.textBox_objectLabelName.Name = "textBox_objectLabelName";
            this.textBox_objectLabelName.Size = new System.Drawing.Size(125, 22);
            this.textBox_objectLabelName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Object Name*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "class ID*";
            // 
            // textBox_imageSource
            // 
            this.textBox_imageSource.Location = new System.Drawing.Point(269, 11);
            this.textBox_imageSource.Name = "textBox_imageSource";
            this.textBox_imageSource.Size = new System.Drawing.Size(125, 22);
            this.textBox_imageSource.TabIndex = 2;
            // 
            // label_imageSource
            // 
            this.label_imageSource.AutoSize = true;
            this.label_imageSource.Location = new System.Drawing.Point(101, 14);
            this.label_imageSource.Name = "label_imageSource";
            this.label_imageSource.Size = new System.Drawing.Size(162, 17);
            this.label_imageSource.TabIndex = 15;
            this.label_imageSource.Text = "Image Source (Optional)";
            // 
            // panel_export
            // 
            this.panel_export.Controls.Add(this.label_imageSource);
            this.panel_export.Controls.Add(this.textBox_imageSource);
            this.panel_export.Controls.Add(this.button_Convert);
            this.panel_export.Controls.Add(this.debugLabel);
            this.panel_export.Controls.Add(this.label5);
            this.panel_export.Controls.Add(this.textBox_outputFile);
            this.panel_export.Controls.Add(this.label4);
            this.panel_export.Controls.Add(this.label2);
            this.panel_export.Controls.Add(this.textBox_objectLabelName);
            this.panel_export.Controls.Add(this.textBox_objectClass);
            this.panel_export.Location = new System.Drawing.Point(51, 210);
            this.panel_export.Name = "panel_export";
            this.panel_export.Size = new System.Drawing.Size(691, 158);
            this.panel_export.TabIndex = 16;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(96, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(79, 21);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Darknet";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(181, 9);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(102, 21);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "TensorFlow";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Train with:";
            // 
            // panel_trainingType
            // 
            this.panel_trainingType.Controls.Add(this.label6);
            this.panel_trainingType.Controls.Add(this.radioButton2);
            this.panel_trainingType.Controls.Add(this.radioButton1);
            this.panel_trainingType.Location = new System.Drawing.Point(222, 174);
            this.panel_trainingType.Name = "panel_trainingType";
            this.panel_trainingType.Size = new System.Drawing.Size(323, 35);
            this.panel_trainingType.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 390);
            this.Controls.Add(this.panel_trainingType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numFilesLabel);
            this.Controls.Add(this.textBox_filePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_FolderBrowserDialog);
            this.Controls.Add(this.panel_export);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_export.ResumeLayout(false);
            this.panel_export.PerformLayout();
            this.panel_trainingType.ResumeLayout(false);
            this.panel_trainingType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_FolderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_filePath;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Label numFilesLabel;
        private System.Windows.Forms.TextBox textBox_outputFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_objectClass;
        private System.Windows.Forms.TextBox textBox_objectLabelName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_imageSource;
        private System.Windows.Forms.Label label_imageSource;
        private System.Windows.Forms.Panel panel_export;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_trainingType;
    }
}

