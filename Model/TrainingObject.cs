using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelMeXML_Parser.Model
{
    class TrainingObject
    {
        /*
         * Image attributes
         */
        public string ImageID;  // name of the image
        public string Source;   // arbitrary value
        public string LabelName;    // arbitrary value
        public int Confidence;  // arbitrary value

        /*
         * Bounding box values (normalized, 0 to 1)
         */
        public float XMin;
        public float XMax;
        public float YMin;
        public float YMax;

        /*
         * Object attributes
         */
        public int IsOccluded;
        public int IsTruncated;
        public int IsGroupOf;   // not sure what this is
        public int IsDepiction; // not sure what this is
        public int IsInside;    // not sure what this is

        /*
         * Attribute names
         */
        private const string ISTRUNCATED_STR = "istruncated";
        private const string ISGROUPOF_STR = "isgroupof";
        private const string ISDEPICTION_STR = "isdepiction";
        private const string ISINSIDE_STR = "isinside";

        public TrainingObject(LabelMeAnnotation annotation, LabelMeObject obj, string source, string labelName)
        {
            // Set image attributes
            ImageID = annotation.filename;
            Source = source;
            LabelName = labelName;
            Confidence = 1;

            if (obj == null)    // no object attributes available
            {
                // Set object attributes to default (0)
                IsOccluded = 0;
                IsTruncated = 0;
                IsGroupOf = 0;
                IsDepiction = 0;
                IsInside = 0;

                // Set bounding box as entire image
                SetMaxBoundingBox();
            }
            else
            {
                // Set object attributes
                IsOccluded = obj.IsOccluded();
                IsTruncated = obj.HasAttribute(ISTRUNCATED_STR);
                IsGroupOf = obj.HasAttribute(ISGROUPOF_STR);
                IsDepiction = obj.HasAttribute(ISDEPICTION_STR);
                IsInside = obj.HasAttribute(ISINSIDE_STR);

                // Calculate normalized bounding box
                CalculateBoundingBox(annotation, obj);
            }
        }

        private void SetMaxBoundingBox()
        {
            XMin = 0f;
            XMax = 1f;
            YMin = 0f;
            YMax = 1f;
        }

        private void CalculateBoundingBox(LabelMeAnnotation annotation, LabelMeObject obj)
        {   // Assumption: all LabelMeObject data must have one LabelMePolygon

            // Set to pt[0] as default
            XMin = obj.polygon.pt[0].x;
            XMax = obj.polygon.pt[0].x;
            YMin = obj.polygon.pt[0].y;
            YMax = obj.polygon.pt[0].y;

            // Get actual Min/Max values
            for (int i = 1; i < obj.polygon.pt.Length; i++)
            {
                LabelMePoint pt = obj.polygon.pt[i];
                if (pt.x > XMax)
                    XMax = pt.x;
                else if (pt.x < XMin)
                    XMin = pt.x;
                if (pt.y > YMax)
                    YMax = pt.y;
                else if (pt.y < YMin)
                    YMin = pt.y;
            }

            // Normalize Min/Max values
            XMin /= annotation.imagesize.width;
            XMax /= annotation.imagesize.width;
            YMin /= annotation.imagesize.height;
            YMax /= annotation.imagesize.height;
        }
    }
}
