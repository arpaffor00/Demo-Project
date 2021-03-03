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
    public class Ellipse : ISerializable
    {
        public String Shape { get; set; }
        public String OriginX { get; set; }
        public String OriginY { get; set; }
        public String Radius1 { get; set; }
        public String Radius2 { get; set; }
        public String Orientation { get; set; }
        public String PenColor { get; set; }
        public string GetArea()
        {
            string area = Convert.ToString(3.14 * float.Parse(Radius1) * float.Parse(Radius2));
            return area;
        }
        public string GetPerimeter()
        {
            string perimeter = Convert.ToString(3.14 * (3 * (float.Parse(Radius1) + float.Parse(Radius2)) - Math.Sqrt((3 * (float.Parse(Radius1))) + (float.Parse(Radius2)) * ((float.Parse(Radius1)) + 3 * ((float.Parse(Radius2)))))));
            return perimeter;
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
            info.AddValue("Radius1", Radius1);
            info.AddValue("Radius2", Radius2);
            info.AddValue("Orientation", Orientation);
            info.AddValue("PenColor", PenColor);
        }
        public Ellipse(SerializationInfo info, StreamingContext Context)
        {
            Shape = (string)info.GetValue("Shape", typeof(string));
            OriginX = (string)info.GetValue("OriginX", typeof(string));
            OriginY = (string)info.GetValue("OriginY", typeof(string));
            Radius1 = (string)info.GetValue("Radius1", typeof(string));
            Radius2 = (string)info.GetValue("Radius2", typeof(string));
            Orientation = (string)info.GetValue("Orientation", typeof(string));
            PenColor = (string)info.GetValue("PenColor", typeof(string));
        }
        public Ellipse()
        {

        }
    }

}
