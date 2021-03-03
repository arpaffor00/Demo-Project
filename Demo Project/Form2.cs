using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Demo_Project
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();

        }
        public string[] DisplayShape { get; set; }
        public string PenColor { get; set; }

        // Creating variables for each shape to pass between the the Paint method and the button_click_1 method used for saving
        public Triangle triangle { get; set; }
        public Square square { get; set; }
        public Polygon polygon { get; set; }
        public Circle circle { get; set; }
        public Ellipse ellipse { get; set; }


        private void Form2_Load(object sender, EventArgs e)
        {

            textBox1.Text = (DisplayShape[0]);

        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //Known issues
            //1) orientation of the shape is currently rotating the shape about the (0,0) point instead of the 
            //   center point of the graphic. This can lead to the shape not displaying in the window.  I am currently 
            //   choosing to keep the rotateTransform code commented out so the shapes display in the display window.

            // Seperating by Shape For display
            if (DisplayShape[0] == "Circle")
            {
                circle = new Circle
                {
                    Shape = DisplayShape[0],
                    OriginX = DisplayShape[2],
                    OriginY = DisplayShape[4],
                    Radius = DisplayShape[6],
                    PenColor = PenColor
                };
                Pen Pen = circle.GetColor();

                e.Graphics.DrawEllipse(Pen, float.Parse(circle.OriginX), float.Parse(circle.OriginY), float.Parse(circle.Radius), float.Parse(circle.Radius));
                textBox2.Text = circle.GetArea();
                textBox3.Text = circle.GetPerimeter();
                textBox1.Text = circle.Shape;

            }

            else if (DisplayShape[0] == "Ellipse")
            {
                ellipse = new Ellipse
                {
                    Shape = DisplayShape[0],
                    OriginX = DisplayShape[2],
                    OriginY = DisplayShape[4],
                    Radius1 = DisplayShape[6],
                    Radius2 = DisplayShape[8],
                    Orientation = DisplayShape[10],
                    PenColor = PenColor
                };
                Pen Pen = ellipse.GetColor();

                //Graphic is currently rotating around the 0,0 origin and not the center of the object
                //e.Graphics.RotateTransform(ellipse.GetOrientation());

                //attempting to move the origin of the shape back the it's correct location.  This is still not working as desired.
                //e.Graphics.TranslateTransform(float.Parse(DisplayShape[2]), float.Parse(DisplayShape[4]));

                //Matrix myMatrix = new Matrix();
                //myMatrix.Rotate(ellipse.GetOrientation(), MatrixOrder.Append);
                //e.Graphics.Transform = myMatrix;

                // Need to spend some time trying to understand why this works but my other methods did not.
                e.Graphics.TranslateTransform(float.Parse(ellipse.OriginX), float.Parse(ellipse.OriginY));
                e.Graphics.RotateTransform(ellipse.GetOrientation());
                e.Graphics.TranslateTransform(-float.Parse(ellipse.OriginX), -float.Parse(ellipse.OriginY));


                e.Graphics.DrawEllipse(Pen, float.Parse(ellipse.OriginX), float.Parse(ellipse.OriginY), float.Parse(ellipse.Radius1), float.Parse(ellipse.Radius2));
                textBox2.Text = ellipse.GetArea();
                textBox3.Text = ellipse.GetPerimeter();
                textBox1.Text = ellipse.Shape;
            }

            else if (DisplayShape[0] == "Square")
            {
                square = new Square
                {
                    Shape = DisplayShape[0],
                    OriginX = DisplayShape[2],
                    OriginY = DisplayShape[4],
                    SideLength = DisplayShape[6],
                    Orientation = DisplayShape[8],
                    PenColor = PenColor

                };
                Pen Pen = square.GetColor();
                //Graphic is currently rotating around the 0,0 origin and not the center of the object
                //e.Graphics.RotateTransform(square.GetOrientation());

                //attempting to move the origin of the shape back the it's correct location.  This is still not working as desired.
                //e.Graphics.TranslateTransform(float.Parse(DisplayShape[2]), float.Parse(DisplayShape[4]));
                e.Graphics.TranslateTransform(float.Parse(square.OriginX), float.Parse(square.OriginY));
                e.Graphics.RotateTransform(square.GetOrientation());
                e.Graphics.TranslateTransform(-float.Parse(square.OriginX), -float.Parse(square.OriginY));


                e.Graphics.DrawRectangle(Pen, float.Parse(square.OriginX), float.Parse(square.OriginY), float.Parse(square.SideLength), float.Parse(square.SideLength));
                textBox2.Text = square.GetArea();
                textBox3.Text = square.GetPerimeter();
                textBox1.Text = square.Shape;
            }

            else if (DisplayShape[0] == "Equilateral Triangle")
            {
                triangle = new Triangle
                {
                    Shape = DisplayShape[0],
                    OriginX = DisplayShape[2],
                    OriginY = DisplayShape[4],
                    SideLength = DisplayShape[6],
                    Orientation = DisplayShape[8],
                    PenColor = PenColor
                };
                
               
                PointF[] p = triangle.GetArray();
                Pen Pen = triangle.GetColor();

                //convert radians to degrees and rotate shape

                //Graphic is currently rotating around the 0,0 origin and not the center of the object
                //e.Graphics.RotateTransform(triangle.GetOrientation());

                //attempting to move the origin of the shape back the it's correct location.  This is still not working as desired.
                //e.Graphics.TranslateTransform(float.Parse(DisplayShape[2]), float.Parse(DisplayShape[4]));

                e.Graphics.TranslateTransform(float.Parse(triangle.OriginX), float.Parse(triangle.OriginY));
                e.Graphics.RotateTransform(triangle.GetOrientation());
                e.Graphics.TranslateTransform(-float.Parse(triangle.OriginX), -float.Parse(triangle.OriginY));

                e.Graphics.DrawPolygon(Pen, p);
                textBox2.Text = triangle.GetArea();
                textBox3.Text = triangle.GetPerimeter();
                textBox1.Text = triangle.Shape;


            }

            else if (DisplayShape[0] == "Polygon")
            {
                polygon = new Polygon
                {
                    Shape = DisplayShape[0],
                    DisplayShape = DisplayShape,
                    PenColor = PenColor

                };
                PointF[] ff = polygon.GetArray();
                Pen Pen = polygon.GetColor();
                e.Graphics.DrawPolygon(Pen, ff);
                textBox3.Text = polygon.GetPerimeter();
                textBox2.Text = polygon.GetArea();
                textBox1.Text = polygon.Shape;
            }
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        //Know Issues:
        //1) I am assuming that this is a very simplistic way of approaching saving the created objects but it was the only way I could think to seperate it
        //   by shape due to technical limitations in my programming skills. Hopefully it won't cause to many problems with loading the objects back in.
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();
                if (DisplayShape[0] == "Circle")
                {
                    Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, circle);
                    stream.Close();
                }
                else if (DisplayShape[0] == "Ellipse")
                {
                    Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, ellipse);
                    stream.Close();

                }
                else if (DisplayShape[0] == "Square")
                {
                    Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, square);
                    stream.Close();
                }
                else if (DisplayShape[0] == "Equilateral Triangle")
                {

                    Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, triangle);
                    stream.Close();
                }
                else if (DisplayShape[0] == "Polygon")
                {
                    Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, polygon);
                    stream.Close();
                }
            }
            catch(System.ArgumentException)
            {
                MessageBox.Show("Empty pathname is not legal.  Select a valid fily path to save", "No File Found",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //    //Here I am just trying to understand what the data actually looks like when I deserialize it and
            //    //how I might be able to reload it into the code in Form 2

            //    //Select the CSV file to initialize the collection of shapes
            openFileDialog1.ShowDialog();
            object shape = null;
            //txtFilePath.Text = openFileDialog1.FileName;
            // load object file in txtFilePath text box  
            Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
            //textBox1.Text = Convert.ToString(stream.GetType());
            
                BinaryFormatter bf = new BinaryFormatter();
                shape = bf.Deserialize(stream);
                stream.Close();
            
            

            if (Convert.ToString(shape) == "Demo_Project.Circle")
            {
                //DisplayShape = null;
               Stream stream1 = File.Open(openFileDialog1.FileName, FileMode.Open);
               Circle circle = (Circle)bf.Deserialize(stream1);
               stream1.Close();
    
                DisplayShape[0] = circle.Shape ;
                DisplayShape[2] = circle.OriginX;
                DisplayShape[4] = circle.OriginY;
                DisplayShape[6] = circle.Radius;
                PenColor = circle.PenColor;
                


            }
            else if (Convert.ToString(shape) == "Demo_Project.Ellipse")
            {
                //DisplayShape = null;
                Stream stream1 = File.Open(openFileDialog1.FileName, FileMode.Open);                               
                Ellipse ellipse = (Ellipse)bf.Deserialize(stream1);
                stream1.Close();
                
                DisplayShape[0] = ellipse.Shape;
                DisplayShape[2] = ellipse.OriginX;
                DisplayShape[4] = ellipse.OriginY;
                DisplayShape[6] = ellipse.Radius1;
                DisplayShape[8] = ellipse.Radius2;
                DisplayShape[10] = ellipse.Orientation;
                PenColor = ellipse.PenColor;
                


            }
            else if (Convert.ToString(shape) == "Demo_Project.Square")
            {
                // DisplayShape = null;
                Stream stream1 = File.Open(openFileDialog1.FileName, FileMode.Open);
                Square square = (Square)bf.Deserialize(stream1);
                stream1.Close();

                DisplayShape[0] = square.Shape;
                DisplayShape[2] = square.OriginX;
                DisplayShape[4] = square.OriginY;
                DisplayShape[6] = square.SideLength;
                DisplayShape[8] = square.Orientation;
                PenColor = square.PenColor;
                


            }
            else if (Convert.ToString(shape) == "Demo_Project.Polygon")
            {
                // DisplayShape = null;
                Stream stream1 = File.Open(openFileDialog1.FileName, FileMode.Open);
                Polygon polygon = (Polygon)bf.Deserialize(stream1);
                stream1.Close();
                DisplayShape[0] = polygon.Shape;
                DisplayShape = polygon.DisplayShape;
                PenColor = polygon.PenColor;
                



            }
            else if (Convert.ToString(shape) == "Demo_Project.Triangle")
            {
                //DisplayShape = null;
                Stream stream1 = File.Open(openFileDialog1.FileName, FileMode.Open);
                Triangle triangle = (Triangle)bf.Deserialize(stream1);
                stream1.Close();
                DisplayShape[0] = triangle.Shape;
                DisplayShape[2] = triangle.OriginX;
                DisplayShape[4] = triangle.OriginY;
                DisplayShape[6] = triangle.SideLength;
                DisplayShape[8] = triangle.Orientation;
                PenColor = triangle.PenColor;
                

            }
            Refresh();
            
            
        }
    }
    
    
}
