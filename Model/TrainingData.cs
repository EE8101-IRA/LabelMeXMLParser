using System;
using System.Collections.Generic;
using System.IO;

namespace LabelMeXML_Parser.Model
{
    class TrainingData
    {
        private string headerText;
        public string BuiltText
        {
            get; private set;
        }

        public TrainingData(string file)
        {
            // read text in file
            headerText = File.ReadAllText(file);

            // start building CSV
            BuiltText = headerText + "\n";
        }

        public void AddToCSV(TrainingObject obj)
        {
            string str = obj.ImageID + "," +
                        obj.Source + "," + 
                        obj.LabelName + "," +
                        obj.Confidence + "," + 
                        obj.XMin + "," + 
                        obj.XMax + "," +
                        obj.YMin + "," +
                        obj.YMax + "," +
                        obj.IsOccluded + "," +
                        obj.IsTruncated + "," +
                        obj.IsGroupOf + "," +
                        obj.IsDepiction + "," +
                        obj.IsInside + "\n";

            BuiltText += str;
        }
    }
}
