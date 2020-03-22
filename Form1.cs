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

namespace LabelMeXML_Parser
{
    public partial class Form1 : Form
    {
        /*
         * Constants
         */
        private const string outputFileName = "training.csv";

        // Constructor
        public Form1()
        {
            InitializeComponent();

            this.Text = "LabelMe XML to Training Data CSV";

            textBox_outputFile.Text = outputFileName;

            panel_export.Visible = false;
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

                if (!panel_export.Visible)
                    panel_export.Visible = true;
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

        private string outputPath = "";

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
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
                //debugLabel.Text = outputPath;

                // Process the XML files to export into CSV
                ConvertXMLFiles();
            }
        }
        
        private void ConvertXMLFiles()
        {
            // create new training data list
            trainingObjects = new List<TrainingObject>();

            // initialize export values
            oneObjectClass = (!string.IsNullOrEmpty(textBox_objectClass.Text));

            // retrieve all object data from XML files
            foreach (var file in files)
            {
                OpenXMLFile(file);
            }

            // convert training data into CSV string
            TrainingData trainingData = new TrainingData("headers.txt");
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
            debugLabel.Text = "Export Complete";
        }

        private List<TrainingObject> trainingObjects = null;
        private bool oneObjectClass = false;    // whether to export only a specific object or not (keyed into textBox_objectClass)

        private void OpenXMLFile(string file)
        {
            // Open XML file
            FileStream fs = new FileStream(file, FileMode.Open);

            // Deserialize XML file into data model
            XmlSerializer serializer = new XmlSerializer(typeof(LabelMeAnnotation));
            LabelMeAnnotation labelMeAnnotation = (LabelMeAnnotation)serializer.Deserialize(fs);

            // set debug label to display data
            //debugLabel.Text = labelMeAnnotation.ToString();

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
                    // Check if object name is correct, if only one object to be exported
                    if (oneObjectClass && obj.name != textBox_objectClass.Text)
                        continue;

                    // Create Training Data object
                    TrainingObject trainingObj = CreateTrainingObject(labelMeAnnotation, obj);
                    trainingObjects.Add(trainingObj);
                }
            }
        }

        private TrainingObject CreateTrainingObject(LabelMeAnnotation annotation, LabelMeObject obj)
        {
            return new TrainingObject(annotation,
                                        obj,
                                        textBox_imageSource.Text,
                                        oneObjectClass ? textBox_objectLabelName.Text : ""
                                     );
        }
    }
}
