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

            TextBox_outputFile.Text = outputFileName;
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
            }

            TextBox_filePath.Text = browsedFolderPath;
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
            TextBox_filePath.Text = filePath;
        }

        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            ConvertXMLFiles();
        }

        private void ConvertXMLFiles()
        {
            foreach (var file in files)
            {
                OpenXMLFile(file);
            }
        }

        private void OpenXMLFile(string file)
        {
            //var doc = XDocument.Load(file);
            //var result = doc.Descendants("YearsPlayed").Any(yearsplayed => Convert.ToInt32(yearsplayed.Value) > 15);

            //Console.WriteLine(doc.ToString());
            //debugLabel.Text = doc.ToString();

            FileStream fs = new FileStream(file, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(LabelMeAnnotation));
            LabelMeAnnotation labelMeAnnotation = (LabelMeAnnotation)serializer.Deserialize(fs);

            debugLabel.Text = labelMeAnnotation.ToString();
        }
    }
}
