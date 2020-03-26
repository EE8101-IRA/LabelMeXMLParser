using System;
using System.Collections.Generic;
using System.IO;

using LabelMeXML_Parser.Model;

namespace LabelMeXML_Parser.DNModel
{
    public class TrainingData_DN : TrainingData
    {
        public TrainingData_DN(string file) : base(file)
        {
        }

        protected override string ToCSVString(TrainingObject obj)
        {
            TrainingObject_DN objDN = (TrainingObject_DN)obj;

            string str = objDN.ImageName + "," +
                        objDN.Source + "," +
                        objDN.ClassId + "," +
                        objDN.Confidence + "," +
                        objDN.XMin + "," +
                        objDN.XMax + "," +
                        objDN.YMin + "," +
                        objDN.YMax + "," +
                        objDN.IsOccluded + "," +
                        objDN.IsTruncated + "," +
                        objDN.IsGroupOf + "," +
                        objDN.IsDepiction + "," +
                        objDN.IsInside + "\n";

            return str;
        }
    }
}
