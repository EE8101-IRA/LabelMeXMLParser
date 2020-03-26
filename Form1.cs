using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

using LabelMeXML_Parser.Model;
using LabelMeXML_Parser.DNModel;
using LabelMeXML_Parser.TFModel;

namespace LabelMeXML_Parser
{
    public partial class Form1 : Form
    {
        /*
         * Constants
         */
        private const string outputFileName = "training.csv";
        private string selectedTrainingtype = "";

        // Constructor
        public Form1()
        {
            InitializeComponent();

            this.Text = "LabelMe XML to Training Data CSV";

            textBox_outputFile.Text = outputFileName;

            panel_trainingType.Visible = false;
            panel_export.Visible = false;

            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                selectedTrainingtype = rb.Text;

                if (!panel_export.Visible)
                    panel_export.Visible = true;
            }
        }


        /*
         * Variables
         */
        private string browsedFolderPath = "";
        private string[] files;

        /*
         * Function callbacks
         */
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFolder();
        }

        private void BrowseForFolder()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                browsedFolderPath = folderBrowserDialog1.SelectedPath;
                files = Directory.GetFiles(browsedFolderPath, "*.xml", SearchOption.TopDirectoryOnly);

                numFilesLabel.Text = "Number of XML files: " + files.Length;

                if (!panel_trainingType.Visible)
                    panel_trainingType.Visible = true;
            }

            textBox_filePath.Text = browsedFolderPath;
        }

        private void BrowseForXMLFile()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    OpenXMLFile(filePath);
                }
            }

            //textBox1.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            textBox_filePath.Text = filePath;
        }

        private void SetDebugText(string text)
        {
            debugLabel.Visible = true;
            debugLabel.Text = text;
        }

        private string outputPath = "";

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            // check if object class or label name was left empty
            if (string.IsNullOrEmpty(textBox_objectClass.Text) || string.IsNullOrEmpty(textBox_objectLabelName.Text))
            {
                SetDebugText("Please key in Object Name and Label Name!");
                return;
            }
            SaveToCSV();
        }

        private void SaveToCSV()
        {
            // Browse for directory to export to
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = textBox_outputFile.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get output path
                outputPath = saveFileDialog.FileName;
                //SetDebugText(outputPath);

                // Process the XML files to export into CSV
                ConvertXMLFiles();
            }
        }
        
        private void ConvertXMLFiles()
        {
            // create new training data list
            trainingObjects = new List<TrainingObject>();

            // retrieve all object data from XML files
            foreach (var file in files)
            {
                OpenXMLFile(file);
            }

            // convert training data into CSV string
            TrainingData trainingData = null;
            switch (selectedTrainingtype)
            {
                case "Darknet":
                    trainingData = new TrainingData_DN("headers_dn.txt");
                    break;
                case "TensorFlow":
                    trainingData = new TrainingData_TF("headers_tf.txt");
                    break;
            }
            foreach (TrainingObject obj in trainingObjects)
            {
                trainingData.AddToCSV(obj);
            }

            // Export to CSV
            using (StreamWriter file = new StreamWriter(outputPath))
            {
                file.WriteLine(trainingData.BuiltText);
            }

            // Complete
            SetDebugText("Export Complete");
        }

        private List<TrainingObject> trainingObjects = null;

        private void OpenXMLFile(string file)
        {
            // Open XML file
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                // Deserialize XML file into data model
                XmlSerializer serializer = new XmlSerializer(typeof(LabelMeAnnotation));
                LabelMeAnnotation labelMeAnnotation = (LabelMeAnnotation)serializer.Deserialize(fs);

                // set debug label to display data
                //SetDebugText(labelMeAnnotation.ToString());

                // create TrainingObject record(s)
                if (labelMeAnnotation.objects == null)  // no bounding boxes; bounding box is entire image
                {
                    // Create Training Data object
                    TrainingObject trainingObj = CreateTrainingObject(labelMeAnnotation, null);
                    trainingObjects.Add(trainingObj);
                }
                else    // one LabelMeObject per bounding box
                {
                    foreach (LabelMeObject obj in labelMeAnnotation.objects)
                    {
                        // check object before exporting
                        if (string.Compare(textBox_objectClass.Text, obj.name) != 0)
                            continue;

                        // Create Training Data object
                        TrainingObject trainingObj = CreateTrainingObject(labelMeAnnotation, obj);
                        trainingObjects.Add(trainingObj);
                    }
                }
            }
        }

        private TrainingObject CreateTrainingObject(LabelMeAnnotation annotation, LabelMeObject obj)
        {
            TrainingObject trainingObj = null;
            switch (selectedTrainingtype)
            {
                case "Darknet":
                    trainingObj = new TrainingObject_DN(annotation,
                                        obj,
                                        textBox_imageSource.Text,
                                        textBox_objectLabelName.Text
                                     );
                    break;
                case "TensorFlow":
                    trainingObj = new TrainingObject_TF(annotation,
                                        obj,
                                        textBox_objectLabelName.Text
                                     );
                    break;
            }
            return trainingObj; 
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
