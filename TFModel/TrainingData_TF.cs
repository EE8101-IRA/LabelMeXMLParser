using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabelMeXML_Parser.Model;

namespace LabelMeXML_Parser.TFModel
{
    class TrainingData_TF : TrainingData
    {
        public TrainingData_TF(string file) : base(file)
        {
        }

        protected override string ToCSVString(TrainingObject obj)
        {
            TrainingObject_TF objTF = (TrainingObject_TF)obj;
            
            string str = objTF.ImageName + "," +
                        objTF.XMin + "," +
                        objTF.YMin + "," +
                        objTF.XMax + "," +
                        objTF.YMax + "," +
                        obj.ClassId + "\n";

            return str;
        }
    }
}
