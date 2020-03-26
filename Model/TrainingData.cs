using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabelMeXML_Parser.Model
{
    public abstract class TrainingData
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
            string str = ToCSVString(obj);
            BuiltText += str;
        }

        protected abstract string ToCSVString(TrainingObject obj);
    }
}
