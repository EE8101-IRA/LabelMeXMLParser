using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LabelMeXML_Parser.Model
{
    public class Imagesize
    {
        [XmlElement]
        public int nrows;
        [XmlElement]
        public int ncols;
    }

    public class Object
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
        public Polygon polygon;
    }

    public class Polygon
    {
        [XmlElement]
        public Point[] pt;
    }

    public class Point
    {
        [XmlElement]
        public int x;
        [XmlElement]
        public int y;
    }

    [XmlRoot("annotation")]
    public class LabelMeAnnotation
    {
        [XmlElement]
        public string filename;
        [XmlElement]
        public Imagesize imagesize;
        [XmlElement("object")]
        public Object[] objects;

        public override string ToString()
        {
            string text = "filename: " + filename + "\n" +
                "imagesize: " + imagesize.nrows + ", " + imagesize.ncols + "\n" +
                "objects:\n";

            foreach (Object obj in objects)
            {
                text += "  name: " + obj.name +
                    ", deleted: " + obj.deleted +
                    ", verified: " + obj.verified +
                    ", occluded: " + obj.occluded + ",\n" +
                    "    polygon: ";
                foreach (Point p in obj.polygon.pt)
                {
                    text += "pt<" + p.x + "," + p.y + ">,";
                }
                text += "\n";
            }

            return text;
        }
    }
}
