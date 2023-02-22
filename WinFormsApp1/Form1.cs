
using System.Drawing.Imaging;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form



    {
        private Point _startPoint;
        private Point _endPoint;
        private bool _isDrawing;
        private Pen _pen;

        public Form1()
        {
            InitializeComponent();
            _pen = new Pen(Color.Black, 2);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fillColor = dialog.Color;

                    using (var dialog2 = new ColorDialog())
                    {
                        if (dialog2.ShowDialog() == DialogResult.OK)
                        {
                            var borderColor = dialog2.Color;
                            DrawSquare(fillColor, borderColor);
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fillColor = dialog.Color;

                    using (var dialog2 = new ColorDialog())
                    {
                        if (dialog2.ShowDialog() == DialogResult.OK)
                        {
                            var borderColor = dialog2.Color;
                            DrawRectangle(fillColor, borderColor);
                        }
                    }
                }
            }
        }



        private void DrawSquare(Color fillColor, Color borderColor)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(borderColor);
            SolidBrush brush = new SolidBrush(fillColor);
            Rectangle rectangle = new Rectangle(50, 50, 100, 100);
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }

        private void DrawRectangle(Color fillColor, Color borderColor)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(borderColor);
            SolidBrush brush = new SolidBrush(fillColor);
            Rectangle rectangle = new Rectangle(50, 50, 150, 100);
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);
        }
        private void DrawCircle(Color fillColor, Color borderColor)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(borderColor);
            SolidBrush brush = new SolidBrush(fillColor);
            Rectangle rectangle = new Rectangle(50, 50, 100, 100);
            graphics.FillEllipse(brush, rectangle);
            graphics.DrawEllipse(pen, rectangle);
        }

        private void DrawLine(Color lineColor)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(lineColor);
            graphics.DrawLine(pen, new Point(50, 50), new Point(150, 150));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fillColor = dialog.Color;

                    using (var dialog2 = new ColorDialog())
                    {
                        if (dialog2.ShowDialog() == DialogResult.OK)
                        {
                            var borderColor = dialog2.Color;
                            DrawCircle(fillColor, borderColor);
                        }
                    }
                }
            }
        }

        private void DrawEllipse(Color fillColor, Color borderColor)
        {
            Graphics graphics = panel1.CreateGraphics();
            Pen pen = new Pen(borderColor);
            graphics.FillEllipse(new SolidBrush(fillColor), new Rectangle(50, 50, 100, 150));
            graphics.DrawEllipse(pen, new Rectangle(50, 50, 100, 150));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var fillColor = dialog.Color;

                    using (var dialog2 = new ColorDialog())
                    {
                        if (dialog2.ShowDialog() == DialogResult.OK)
                        {
                            var borderColor = dialog2.Color;
                            DrawEllipse(fillColor, borderColor);
                        }
                    }
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            _isDrawing = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _endPoint = e.Location;
                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_isDrawing)
            {
                e.Graphics.DrawLine(_pen, _startPoint, _endPoint);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var penColor = dialog.Color;
                    _pen.Color = penColor;
                }
            }
        }

        private void button7_CLick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG files (*.png)|*.png";
            saveFileDialog.FileName = "MyDrawing.png";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(bitmap, new Rectangle(Point.Empty, panel1.Size));
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            // kreiramo novi OpenFileDialog objekat
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // postavljamo opcije za dijalog
            openFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            // prikazujemo dijalog i proveravamo da li je korisnik izabrao sliku
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // učitavamo sliku u PictureBox kontrolu
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
          
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG files (*.jpg)|*.jpg";
                saveFileDialog.FileName = "MyDrawing.jpg";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bitmap = new Bitmap(panel1.Width * 2, panel1.Height * 2);

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.White);
                        graphics.ScaleTransform(2f, 2f);
                        panel1.DrawToBitmap(bitmap, panel1.Bounds);
                    }

                    bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
