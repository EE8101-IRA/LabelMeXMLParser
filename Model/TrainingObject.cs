using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelMeXML_Parser.Model
{
    public abstract class TrainingObject
    {
        public string ImageName;    // name of image file
        public string ClassId;      // label of class

        public TrainingObject(string imageName, string classId)
        {
            // Set image/object attributes
            this.ImageName = imageName;
            this.ClassId = classId;
        }
    }
}
