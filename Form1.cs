using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace idk_for_now
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Graphics g;
        Bitmap bm;


        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            canvas.Image = bm;

            textbox_angle.Text = "59";
            textbox_length.Text = "0";
            textbox_line_num.Text = "1500";
        }

        //"Draw" button
        public void button1_Click(object sender, EventArgs e) 
        {
            g.Dispose();
            bm = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int start_x = canvas.Width / 2;
            int start_y = canvas.Height / 2;
            int length = Int32.Parse(textbox_length.Text);
            int line_num = Int32.Parse(textbox_line_num.Text);
            int angle = Int32.Parse(textbox_angle.Text);
            int current_angle = 0;

            myPaint(start_x, start_y, length, angle, line_num, current_angle);
            
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void canvas_Paint(object sender, PaintEventArgs e) 
        {

        }

        //"Save" button
        private void button2_Click(object sender, EventArgs e)
        {
           
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            bm.Save(desktop + "/TestImage.jpeg", ImageFormat.Jpeg);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            canvas.Image = bm;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Dispose();
            bm = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int start_x = canvas.Width / 2;
            int start_y = canvas.Height / 2;
            int length = Int32.Parse(textbox_length.Text);
            int line_num = Int32.Parse(textbox_line_num.Text);
            int angle = Int32.Parse(textbox_angle.Text);
            for (int i=0; i<360; i++)
            {
                myPaint(start_x, start_y, length, angle, line_num, i);
            }
            
        }

        public void myPaint(int start_x, int start_y, int length, int angle, int line_num, int start_angle)
        {
            g.Clear(Color.White);
            int current_angle = start_angle;
            for (int i = 0; i < line_num; i++)
            {
                int end_x = (int)(start_x + Math.Cos(current_angle * Math.PI / 180) * length);
                int end_y = (int)(start_y + Math.Sin(current_angle * Math.PI / 180) * length);

                Point[] points =
                {
                    new Point(start_x, start_y),
                    new Point(end_x, end_y)

                };


                g.DrawLines(myPen, points);

                start_x = end_x;
                start_y = end_y;
                current_angle += angle;
                length += 1;
            }
            canvas.Image = bm;
            canvas.Refresh();
        }

        
            
        

        private void button5_Click(object sender, EventArgs e)
        {
            g.Dispose();
            bm = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int start_x = canvas.Width / 2;
            int start_y = canvas.Height / 2;
            int length = Int32.Parse(textbox_length.Text);
            int line_num = Int32.Parse(textbox_line_num.Text);
            int current_angle = 0;
            for (int i = 0; i < 360; i++)
            {
                myPaint(start_x, start_y, length, i, line_num, current_angle);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Dispose();
            bm = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int start_x = canvas.Width / 2;
            int start_y = canvas.Height / 2;
            int length = Int32.Parse(textbox_length.Text);
            int angle = Int32.Parse(textbox_angle.Text);
            int current_angle = 0;
            int line_num = Int32.Parse(textbox_line_num.Text);
            int increment;
           
                for (int i = 0; i < line_num; i=i+increment)
                {
                    myPaint(start_x, start_y, length, angle, i, current_angle);
                    increment = (i / 50)+1;
                }
               
            
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            g.Dispose();
            bm = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int start_x = canvas.Width / 2;
            int start_y = canvas.Height / 2;
            int angle = Int32.Parse(textbox_angle.Text);
            int line_num = Int32.Parse(textbox_line_num.Text);
            int current_angle = 0;
            for (int i = 0; i < 500; i=i+12)
            {
                myPaint(start_x, start_y, i, angle, line_num, current_angle);
            }
        }
    }
    
}
