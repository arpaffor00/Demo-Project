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
    public class Polygon : ISerializable
    {
        public String Shape { get; set; }
        public String[] DisplayShape { get; set; }
        public String PenColor { get; set; }
        public Pen GetColor()
        {
            Pen Pen = new Pen(Color.FromName(PenColor));
            return Pen;
        }
        public PointF[] GetArray()
        {
            int max = DisplayShape.Length;
            //number of verticies
            int verticies = (max - 1) / 4;
            PointF[] ff = new PointF[verticies];

            float[] xx = new float[(max - 1) / 4];
            float[] yy = new float[(max - 1) / 4];
            int first_X = 2;
            int remainderX = (first_X % 4);
            for (int i = first_X; i <= max; i++)
            {
                // every other even is separated by 4, 
                // and will thus have the same remainder by 4
                if (i % 4 == remainderX)
                {
                    ff[(i - 2) / 4].X = float.Parse(DisplayShape[i]);
                    xx[(i - 2) / 4] = float.Parse(DisplayShape[i]);
                    ff[(i - 2) / 4].Y = float.Parse(DisplayShape[i + 2]);
                    yy[(i - 2) / 4] = float.Parse(DisplayShape[i + 2]);
                    //Console.WriteLine(xx[i]);
                    //Console.WriteLine(yy[i]);


                }
                

            }
            return ff;
        }
        
        public string GetArea()
        {
            int max = DisplayShape.Length;
            //number of verticies
            int verticies = (max - 1) / 4;
            PointF[] ff = new PointF[verticies];

            float[] xx = new float[(max - 1) / 4];
            float[] yy = new float[(max - 1) / 4];
            int first_X = 2;
            int remainderX = (first_X % 4);
            for (int i = first_X; i <= max; i++)
            {
                // every other even is separated by 4, 
                // and will thus have the same remainder by 4
                if (i % 4 == remainderX)
                {
                    ff[(i - 2) / 4].X = float.Parse(DisplayShape[i]);
                    xx[(i - 2) / 4] = float.Parse(DisplayShape[i]);
                    ff[(i - 2) / 4].Y = float.Parse(DisplayShape[i + 2]);
                    yy[(i - 2) / 4] = float.Parse(DisplayShape[i + 2]);
                    //Console.WriteLine(xx[i]);
                    //Console.WriteLine(yy[i]);


                }


            }
            ////perimeter and area of polygon
            ////created the xx and yy arrays because I was having issues with the Math class
            ////the perimeter equation was staight forward  
            ////found the area equation here: http://csharphelper.com/blog/2014/07/calculate-the-area-of-a-polygon-in-c/to 
            int maxxx = xx.Length;
            double area = new float();
            double perimeter = new double();
            double[] l = new double[maxxx];
            for (int j = 0; j <= maxxx - 2; j++)
            {
                float a = (xx[j + 1] - xx[j]);
                float b = yy[j + 1] - yy[j];
                l[j] = Math.Sqrt((a * a) + (b * b));
                perimeter += l[j];
                area += (ff[j + 1].X - ff[j].X) * (ff[j + 1].Y + ff[j].Y) / 2;
                //Console.WriteLine(l[j]);
            }
            
            return Convert.ToString(Math.Abs(area));

        }
        public string GetPerimeter()
        {
            int max = DisplayShape.Length;
            //number of verticies
            int verticies = (max - 1) / 4;
            PointF[] ff = new PointF[verticies];

            float[] xx = new float[(max - 1) / 4];
            float[] yy = new float[(max - 1) / 4];
            int first_X = 2;
            int remainderX = (first_X % 4);
            for (int i = first_X; i <= max; i++)
            {
                // every other even is separated by 4, 
                // and will thus have the same remainder by 4
                if (i % 4 == remainderX)
                {
                    ff[(i - 2) / 4].X = float.Parse(DisplayShape[i]);
                    xx[(i - 2) / 4] = float.Parse(DisplayShape[i]);
                    ff[(i - 2) / 4].Y = float.Parse(DisplayShape[i + 2]);
                    yy[(i - 2) / 4] = float.Parse(DisplayShape[i + 2]);
                    //Console.WriteLine(xx[i]);
                    //Console.WriteLine(yy[i]);


                }


            }
            int maxxx = xx.Length;
            double area = new float();
            double perimeter = new double();
            double[] l = new double[maxxx];
            for (int j = 0; j <= maxxx - 2; j++)
            {
                float a = (xx[j + 1] - xx[j]);
                float b = yy[j + 1] - yy[j];
                l[j] = Math.Sqrt((a * a) + (b * b));
                perimeter += l[j];
                area += (ff[j + 1].X - ff[j].X) * (ff[j + 1].Y + ff[j].Y) / 2;
                //Console.WriteLine(l[j]);
            }

            return Convert.ToString(perimeter);

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Shape", Shape);
            info.AddValue("DisplayShape", DisplayShape);
            info.AddValue("PenColor", PenColor);
        }
        public Polygon(SerializationInfo info, StreamingContext Context)
        {
            Shape = (string)info.GetValue("Shape", typeof(string));
            DisplayShape = (string[])info.GetValue("DisplayShape", typeof(string[]));
            PenColor = (string)info.GetValue("PenColor", typeof(string));
        }
        public Polygon()
        {

        }
    }
}
