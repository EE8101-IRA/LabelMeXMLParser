using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabelMeXML_Parser.Model;

namespace LabelMeXML_Parser.TFModel
{
    class TrainingObject_TF : TrainingObject
    {
        /*
         * Bounding box values (exact pixel values)
         */
        public int XMin;
        public int YMin;
        public int XMax;
        public int YMax;

        public TrainingObject_TF(LabelMeAnnotation annotation, LabelMeObject obj, string classId)
            : base(annotation.filename, classId)
        {
            if (obj == null)    // no object attributes available
            {
                // set Min and Max values as entire image
                XMin = 0;
                YMin = 0;
                XMax = annotation.imagesize.width;
                YMax = annotation.imagesize.height;
            }
            else
            {
                // calculate Min and Max values
                obj.CalculateMinMax();

                // set Min and Max values
                XMin = obj.XMin;
                YMin = obj.YMin;
                XMax = obj.XMax;
                YMax = obj.YMax;
            }
        }
    }

}
