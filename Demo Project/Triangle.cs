using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Demo_Project
{
    [Serializable()]
    public class Triangle : ISerializable
    {
        public String Shape { get; set; }
        public String OriginX { get; set; }
        public String OriginY { get; set; }
        public String SideLength { get; set; }
        public String Orientation { get; set; }
        public String PenColor { get; set; }

        public string GetArea()
        {
            string area = Convert.ToString(.4330127 * float.Parse(SideLength) * float.Parse(SideLength));
            return area;

        }
        public string GetPerimeter()
        {
            string perimeter = Convert.ToString(3 * float.Parse(SideLength));
            return perimeter;
        }
        public PointF[] GetArray()
        {
            //Height of Eq Triangle is L * sin(60)
            Double h = float.Parse(SideLength) * .88025;
            float H = Convert.ToSingle(h);

            PointF[] p = new PointF[3];
            p[0].X = float.Parse(OriginX) - float.Parse(SideLength) / 2;
            p[0].Y = float.Parse(OriginY) - H / 2;
            p[1].X = float.Parse(OriginX) + float.Parse(SideLength) / 2;
            p[1].Y = float.Parse(OriginY) - H / 2;
            p[2].X = float.Parse(OriginX);
            p[2].Y = float.Parse(OriginY) + H / 2;

            return p;
        }

        public Pen GetColor()
        {
            Pen Pen = new Pen(Color.FromName(PenColor));
            return Pen;
        }

        public float GetOrientation()
        {
            float orientation = float.Parse(Orientation) * 57.2958F;
            return orientation;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Shape", Shape);
            info.AddValue("OriginX", OriginX);
            info.AddValue("OriginY", OriginY);
            info.AddValue("SideLength", SideLength);
            info.AddValue("Orientation", Orientation);
            info.AddValue("PenColor", PenColor);
        }
        public Triangle(SerializationInfo info, StreamingContext Context)
        {
            Shape = (string)info.GetValue("Shape", typeof(string));
            OriginX = (string)info.GetValue("OriginX", typeof(string));
            OriginY = (string)info.GetValue("OriginY", typeof(string));
            SideLength = (string)info.GetValue("SideLength", typeof(string));
            Orientation = (string)info.GetValue("Orientation", typeof(string));
            PenColor = (string)info.GetValue("PenColor", typeof(string));
        }

        public Triangle()
        {
        }
    }
}
