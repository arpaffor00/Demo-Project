using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Demo_Project
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadCSV_Click(object sender, EventArgs e)
        {
            //Select the CSV file to initialize the collection of shapes
            openFileDialog1.ShowDialog();

            txtFilePath.Text = openFileDialog1.FileName;
            // load CSV file and display name in txtFilePath text box


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string path = openFileDialog1.FileName;
                //making an array from the loaded CSV file
                string[] lines = System.IO.File.ReadAllLines(path);
                foreach (string line in lines)
                {

                }
                //Filter array for specific part shape.
                String[] filteredShape = Array.FindAll(lines, x => x.StartsWith(listBox1.GetItemText(listBox1.SelectedItem)));

                //Program currently errors if you select an index value that doesn't have a data entry in the array 

                //convert the numericUpDown counter to let the user select which entry they want to display
                var index = Convert.ToInt32(numericUpDown1.Value);
                string shape = filteredShape[index];
                textBox4.Text = shape;

                //Splitting selected string into an array to get shape dimensions
                string[] dimensions = shape.Split(',');

                foreach (string column in dimensions)
                {
                    // Console.WriteLine(column);
                }

                // Setting Pen Color based off of user selected colo
                var selectedColor = listBox2.SelectedItem;
                string color = Convert.ToString(selectedColor);





                if (color == "")
                {
                    MessageBox.Show("Please Select A Color", "No Color Found",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //opening up a new form to display the shape
                //passing in neede variables into form 2
                Form2 f2 = new Form2();
                f2.DisplayShape = dimensions;
                f2.PenColor = color;
                f2.ShowDialog(); // Shows Form
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Please Select A Valid File", "No File Found",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("File is Open in a Different Application.  Please Close to Continue", "No File Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("Please Select A Valid File.",  "Incorrect File Type",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //    //Here I am just trying to understand what the data actually looks like when I deserialize it and
        //    //    //how I might be able to reload it into the code in Form 2

        //    //    //Select the CSV file to initialize the collection of shapes
        //    openFileDialog1.ShowDialog();

        //    txtFilePath.Text = openFileDialog1.FileName;
        //    // load object file in txtFilePath text box  
        //    Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
        //    BinaryFormatter bf = new BinaryFormatter();
        //    Circle circle = (Circle)bf.Deserialize(stream);
        //    stream.Close();
        //    textBox4.Text = Convert.ToString(circle.OriginX);



        //}


    }
}
