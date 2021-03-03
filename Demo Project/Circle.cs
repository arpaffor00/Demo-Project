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
    public class Circle : ISerializable
    {
        public String Shape { get; set; }
        public String OriginX { get; set; }
        public String OriginY { get; set; }
        public String Radius { get; set; }
        public String PenColor { get; set; }
        public string GetArea()
        {
            string area = Convert.ToString(3.14 * float.Parse(Radius) * float.Parse(Radius));
            return area;

        }
        public string GetPerimeter()
        {
            string perimeter = Convert.ToString(3.14 * float.Parse(Radius) * 2);
            return perimeter;
        }
        public Pen GetColor()
        {
            Pen Pen = new Pen(Color.FromName(PenColor));
            return Pen;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Shape", Shape);
            info.AddValue("OriginX", OriginX);
            info.AddValue("OriginY", OriginY);
            info.AddValue("Radius", Radius);
            info.AddValue("PenColor", PenColor);
        }
        public Circle(SerializationInfo info, StreamingContext Context)
        {
            Shape = (string)info.GetValue("Shape", typeof(string));
            OriginX = (string)info.GetValue("OriginX", typeof(string));
            OriginY = (string)info.GetValue("OriginY", typeof(string));
            Radius = (string)info.GetValue("Radius", typeof(string));
            PenColor = (string)info.GetValue("PenColor", typeof(string));
        }
        public Circle()
        {

        }


    }


}
