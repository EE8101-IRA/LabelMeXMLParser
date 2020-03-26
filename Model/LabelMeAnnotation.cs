using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LabelMeXML_Parser.Model
{
    public class LabelMeImagesize
    {
        [XmlElement("nrows")]
        public int height;
        [XmlElement("ncols")]
        public int width;
    }

    public class LabelMePolygon
    {
        [XmlElement]
        public LabelMePoint[] pt;
    }

    public class LabelMePoint
    {
        [XmlElement]
        public int x;
        [XmlElement]
        public int y;
    }

    public class LabelMeObject
    {
        [XmlElement]
        public string name;
        [XmlElement]
        public int deleted;
        [XmlElement]
        public int verified;
        [XmlElement]
        public string occluded;
        [XmlElement]
        public string attributes;   // comma-separated string
        [XmlElement]
        public LabelMePolygon polygon;

        private string[] attributesList = null;

        public int XMin;
        public int XMax;
        public int YMin;
        public int YMax;

        public void CalculateMinMax()
        {
            // Set to pt[0] as default
            XMin = polygon.pt[0].x;
            XMax = polygon.pt[0].x;
            YMin = polygon.pt[0].y;
            YMax = polygon.pt[0].y;

            for (int i = 1; i < polygon.pt.Length; i++)
            {
                LabelMePoint pt = polygon.pt[i];
                if (pt.x > XMax)
                    XMax = pt.x;
                else if (pt.x < XMin)
                    XMin = pt.x;
                if (pt.y > YMax)
                    YMax = pt.y;
                else if (pt.y < YMin)
                    YMin = pt.y;
            }
        }

        public int IsOccluded()
        {
            switch (occluded.ToLower())
            {
                case "no":
                    return 0;
                case "yes":
                    return 1;
                default:
                    return 0;
            }
        }

        public int HasAttribute(string attribute)
        {
            if (attributesList == null)
                attributesList = attributes.Split(',');

            foreach (string attr in attributesList)
                if (attr.ToLower() == attribute.ToLower())
                    return 1;   // true

            return 0;   // false
        }
    }

    [XmlRoot("annotation")]
    public class LabelMeAnnotation
    {
        [XmlElement]
        public string filename;
        [XmlElement]
        public LabelMeImagesize imagesize;
        [XmlElement("object")]
        public LabelMeObject[] objects;

        public override string ToString()
        {
            string str = "filename: " + filename + "\n" +
                "imagesize: " + imagesize.height + ", " + imagesize.width + "\n" +
                "objects:\n";

            foreach (LabelMeObject obj in objects)
            {
                str += "  name: " + obj.name +
                    ", deleted: " + obj.deleted +
                    ", verified: " + obj.verified +
                    ", occluded: " + obj.occluded + ",\n" +
                    "    polygon: ";
                foreach (LabelMePoint p in obj.polygon.pt)
                {
                    str += "pt<" + p.x + "," + p.y + ">,";
                }
                str += "\n";
            }

            return str;
        }
    }
}
