using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayisalGoruntuOdev1
{
    public partial class Form6 : Form
    {
        TextBox cell = new TextBox();

        public Form6()
        {
            InitializeComponent();
            cell = new TextBox();
            cell.Size = new Size(100, 20);
            cell.Left = 110;
            cell.Top = 170;
            cell.BorderStyle = BorderStyle.FixedSingle;
            cell.TextAlign = HorizontalAlignment.Center;
            cell.Font = new Font(Font.FontFamily, 10);
            cell.Tag = 1;
            this.Controls.Add(cell);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Close();
            Form5 frm5 = new Form5();
            frm5.Show();
            frm5.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {            
            if (cell.Text == "")
            {
                MessageBox.Show("Lütfen bir isim giriniz");

            }
            else if (comboBox1.SelectedIndex == 0)
            {
                int durum = 0;
                try
                {
                    if (pictureBox1.Image != null)
                    {
                        Image img = pictureBox1.Image;
                        Bitmap bmp = new Bitmap(img.Width, img.Height);
                        Graphics gra = Graphics.FromImage(bmp);
                        gra.DrawImageUnscaled(img, new Point(0, 0));
                        gra.Dispose();

                        string isim = cell.Text;
                        string belgelerim = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        DirectoryInfo di = new DirectoryInfo(belgelerim);
                        FileInfo[] files = di.GetFiles();
                        foreach (FileInfo fi in files)
                        {
                            if (cell.Text+".jpg" == fi.Name)
                            {
                                MessageBox.Show("Lütfen farklı bir isim giriniz");
                                durum = 1;
                            }

                        }
                        if (durum == 0)
                        {
                            bmp.Save(belgelerim + "\\" + isim + ".jpg", ImageFormat.Jpeg);
                            bmp.Dispose();
                        }
                    }
                }
                catch { }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int durum = 0;
                try
                {
                    if (pictureBox1.Image != null)
                    {
                        Image img = pictureBox1.Image;
                        Bitmap bmp = new Bitmap(img.Width, img.Height);
                        Graphics gra = Graphics.FromImage(bmp);
                        gra.DrawImageUnscaled(img, new Point(0, 0));
                        gra.Dispose();

                        string isim = cell.Text;
                        string belgelerim = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        DirectoryInfo di = new DirectoryInfo(belgelerim);
                        FileInfo[] files = di.GetFiles();
                        foreach (FileInfo fi in files)
                        {
                            if (cell.Text + ".bmp" == fi.Name)
                            {
                                MessageBox.Show("Lütfen farklı bir isim giriniz");
                                durum = 1;
                            }

                        }
                        if (durum == 0)
                        {
                            bmp.Save(belgelerim + "\\" + isim + ".bmp", ImageFormat.Jpeg);
                            bmp.Dispose();
                        }

                    }
                }
                catch { }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                int durum = 0;
                try
                {
                    if (pictureBox1.Image != null)
                    {
                        Image img = pictureBox1.Image;
                        Bitmap bmp = new Bitmap(img.Width, img.Height);
                        Graphics gra = Graphics.FromImage(bmp);
                        gra.DrawImageUnscaled(img, new Point(0, 0));
                        gra.Dispose();

                        string isim = cell.Text;
                        string belgelerim = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        DirectoryInfo di = new DirectoryInfo(belgelerim);
                        FileInfo[] files = di.GetFiles();
                        foreach (FileInfo fi in files)
                        {
                            if (cell.Text + ".tif" == fi.Name)
                            {
                                MessageBox.Show("Lütfen farklı bir isim giriniz");
                                durum = 1;
                            }

                        }
                        if (durum == 0)
                        {
                            bmp.Save(belgelerim + "\\" + isim + ".tif", ImageFormat.Jpeg);
                            bmp.Dispose();
                        }
                    }
                }
                catch { }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                int durum = 0;
                try
                {
                    if (pictureBox1.Image != null)
                    {
                        Image img = pictureBox1.Image;
                        Bitmap bmp = new Bitmap(img.Width, img.Height);
                        Graphics gra = Graphics.FromImage(bmp);
                        gra.DrawImageUnscaled(img, new Point(0, 0));
                        gra.Dispose();

                        string isim = cell.Text;
                        string belgelerim = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        DirectoryInfo di = new DirectoryInfo(belgelerim);
                        FileInfo[] files = di.GetFiles();
                        foreach (FileInfo fi in files)
                        {
                            if (cell.Text + ".png" == fi.Name)
                            {
                                MessageBox.Show("Lütfen farklı bir isim giriniz");
                                durum = 1;
                            }

                        }
                        if (durum == 0)
                        {
                            bmp.Save(belgelerim + "\\" + isim + ".png", ImageFormat.Jpeg);
                            bmp.Dispose();
                        }
                    }
                }
                catch { }
              
            }
            
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


    }
}
