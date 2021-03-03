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
    public class Square : ISerializable
    {
        public String Shape { get; set; }
        public String OriginX { get; set; }
        public String OriginY { get; set; }
        public String SideLength { get; set; }
        public String Orientation { get; set; }
        public String PenColor { get; set; }
        public string GetArea()
        {
            string area = Convert.ToString(float.Parse(SideLength) * float.Parse(SideLength));
            return area;

        }
        public string GetPerimeter()
        {
            string perimeter = Convert.ToString(4 * float.Parse(SideLength));
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
            info.AddValue("SideLength", SideLength);
            info.AddValue("Orientation", Orientation);
            info.AddValue("PenColor", PenColor);
        }
        public Square(SerializationInfo info, StreamingContext Context)
        {
            Shape = (string)info.GetValue("Shape", typeof(string));
            OriginX = (string)info.GetValue("OriginX", typeof(string));
            OriginY = (string)info.GetValue("OriginY", typeof(string));
            SideLength = (string)info.GetValue("SideLength", typeof(string));
            Orientation = (string)info.GetValue("Orientation", typeof(string));
            PenColor = (string)info.GetValue("PenColor", typeof(string));
        }
        public Square()
        {

        }
    }
}
