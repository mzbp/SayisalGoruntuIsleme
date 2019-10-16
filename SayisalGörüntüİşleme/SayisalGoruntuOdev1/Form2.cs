using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayisalGoruntuOdev1
{
    public partial class Form2 : Form
    {
        TextBox[] cell = new TextBox[2];
        TextBox[] cell2 = new TextBox[4];
        int a, b,c,d;

        public Form2()
        {
            InitializeComponent();

            int gen = 100, yuk = 180;
            for (int i = 0; i < 2; i++)
            {
                cell[i] = new TextBox();
                cell[i].Size = new Size(60, 30);
                cell[i].Left = gen;
                cell[i].Top = yuk;
                cell[i].BorderStyle = BorderStyle.FixedSingle;
                cell[i].AutoSize = false;
                cell[i].TextAlign = HorizontalAlignment.Center;
                cell[i].Font = new Font(Font.FontFamily, 18);
                cell[i].ForeColor = Color.Blue;
                cell[i].Tag = i;
                cell[i].MaxLength = 5;
                cell[i].Visible = false;
                this.Controls.Add(cell[i]);
                gen = gen + 90;
            }
            gen = 100;
            yuk = 180;
            for (int i = 0; i < 4; i++)
            {
                cell2[i] = new TextBox();
                cell2[i].Size = new Size(60, 30);
                cell2[i].Left = gen;
                cell2[i].Top = yuk;
                cell2[i].BorderStyle = BorderStyle.FixedSingle;
                cell2[i].AutoSize = false;
                cell2[i].TextAlign = HorizontalAlignment.Center;
                cell2[i].Font = new Font(Font.FontFamily, 18);
                cell2[i].ForeColor = Color.Blue;
                cell2[i].Tag = i;
                cell2[i].MaxLength = 5;
                cell2[i].Visible = false;
                this.Controls.Add(cell2[i]);
                gen = gen + 90;
                if (i == 1)
                {
                    gen = 100;
                    yuk = 220;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Close();
            Form1 frm1 = new Form1();
            frm1.Show();
            frm1.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                comboBox1.Visible = true;
            }
            else
            {
                checkBox2.Checked = true;
                comboBox1.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = false;
            else
                checkBox1.Checked = true;
        }

        public Bitmap GriYap(Bitmap resim)
        {
            for (int i = 0; i < resim.Height - 1; i++)
            {
                for (int j = 0; j < resim.Width - 1; j++)
                {
                    int deger = (resim.GetPixel(j, i).R + resim.GetPixel(j, i).G + resim.GetPixel(j, i).B) / 3;
                    Color renk;
                    renk = Color.FromArgb(deger, deger, deger);
                    resim.SetPixel(j, i, renk);
                }
            }

            return resim;
        }
        public static Bitmap resimHistogram;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = GriYap(resim);
                cell[0].Visible = false;
                cell[1].Visible = false;
                YeniBoyut.Visible = false;
                cell2[0].Visible = false;
                cell2[1].Visible = false;
                cell2[2].Visible = false;
                cell2[3].Visible = false;
                YeniBoyut2.Visible = false;

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Bitmap yeni = new Bitmap(pictureBox1.Image);
                yeni = resmiKucult(yeni);
                pictureBox1.Image = yeni;
                cell[0].Visible = false;
                cell[1].Visible = false;
                YeniBoyut.Visible = false;
                cell2[0].Visible = false;
                cell2[1].Visible = false;
                cell2[2].Visible = false;
                cell2[3].Visible = false;
                YeniBoyut2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                Bitmap yeni = new Bitmap(pictureBox1.Image);
                yeni = resmiBuyult(yeni);
                pictureBox1.Image = yeni;
                cell[0].Visible = false;
                cell[1].Visible = false;
                YeniBoyut.Visible = false;
                cell2[0].Visible = false;
                cell2[1].Visible = false;
                cell2[2].Visible = false;
                cell2[3].Visible = false;
                YeniBoyut2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 3)
            {

                cell[0].Visible = true;
                cell[1].Visible = true;
                YeniBoyut.Visible = true;
                cell[0].Text = Convert.ToString(pictureBox1.Image.Width);
                cell[1].Text = Convert.ToString(pictureBox1.Image.Height);
                YeniBoyut.Visible = true;
               
                cell2[0].Visible = false;
                cell2[1].Visible = false;
                cell2[2].Visible = false;
                cell2[3].Visible = false;
                YeniBoyut2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                cell2[0].Visible = true;
                cell2[1].Visible = true;
                cell2[2].Visible = true;
                cell2[3].Visible = true;
                YeniBoyut2.Visible = true;

                cell2[0].Text = Convert.ToString(pictureBox1.Image.Width);
                cell2[1].Text = Convert.ToString(pictureBox1.Image.Height);
                YeniBoyut2.Visible = true;

                cell[0].Visible = false;
                cell[1].Visible = false;
                YeniBoyut.Visible = false;
                
            }
            else if (comboBox1.SelectedIndex == 5)
            {               
                    resimHistogram = new Bitmap(pictureBox1.Image);
                    Histogram goster = new Histogram();
                    goster.Show();

                

            }
            else if (comboBox1.SelectedIndex == 6)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                pictureBox1.Image = NegatifeDonustur(resim);
                cell[0].Visible = false;
                cell[1].Visible =false ;
                YeniBoyut.Visible = false;
                cell2[0].Visible = false;
                cell2[1].Visible = false;
                cell2[2].Visible = false;
                cell2[3].Visible = false;
                YeniBoyut2.Visible = false;
            }

        }
        public Bitmap NegatifeDonustur(Bitmap bmp)
        {
                int i, j;
                Color r;
                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb(r.A, 255 - r.R, 255 - r.G, 255 - r.B);
                        bmp.SetPixel(i, j, r);

                    }
                }
                return bmp;           
        }
        public Bitmap resmiKucult(Bitmap resim)
        {
            Bitmap yeni = new Bitmap(resim.Width / 2, resim.Height / 2);
            int x = 0, y = 0;
            int a, b, c;
            for (int i = 0; i < yeni.Width; i++)
            {
                for (int j = 0; j < yeni.Height; j++)
                {
                    a = (resim.GetPixel(x, y).R + resim.GetPixel(x, y + 1).R + resim.GetPixel(x + 1, y).R + resim.GetPixel(x + 1, y + 1).R) / 4;
                    b = (resim.GetPixel(x, y).G + resim.GetPixel(x, y + 1).G + resim.GetPixel(x + 1, y).G + resim.GetPixel(x + 1, y + 1).G) / 4;
                    c = (resim.GetPixel(x, y).B + resim.GetPixel(x, y + 1).B + resim.GetPixel(x + 1, y).B + resim.GetPixel(x + 1, y + 1).B) / 4;


                    yeni.SetPixel(i, j, Color.FromArgb(a, b, c));
                    y += 2;
                }
                x += 2;
                y = 0;
            }

            return yeni;
        }
        public Bitmap resmiBuyult(Bitmap resim)
        {
            int x = 0, y = 0;
            Bitmap yeni = new Bitmap(resim.Width * 2, resim.Height * 2);
            for (int i = 0; i < resim.Width * 2; i += 2)
            {
                for (int j = 0; j < resim.Height * 2; j += 2)
                {
                    if ((i + 1) < yeni.Width && (j + 1) < yeni.Height)
                    {
                        yeni.SetPixel(i, j, resim.GetPixel(x, y));
                        yeni.SetPixel(i, j + 1, resim.GetPixel(x, y));
                        yeni.SetPixel(i + 1, j, resim.GetPixel(x, y));
                        yeni.SetPixel(i + 1, j + 1, resim.GetPixel(x, y));
                    }
                    y++;
                }
                x++;
                y = 0;
            }
            return yeni;
        } 
        private void ilr_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Close();
            Form3 frm3 = new Form3();
            frm3.Show();
            frm3.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }

        private void YeniBoyut2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(cell2[0].Text);
            int b = Convert.ToInt32(cell2[1].Text);
            int c = Convert.ToInt32(cell2[2].Text);
            int d = Convert.ToInt32(cell2[3].Text);
            int i = b - a;
            if (i < 0)
                i = i * -1;
            int j = d - c;
            if (j < 0)
                j = j * -1;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap yeni = new Bitmap(i, j);
            Color renk;
            for (int k=0; k < i; k++)
            {
                for (int z=0; z < j; z++)
                {
                    
                        renk = bmp.GetPixel(a+k, c+z);
                        yeni.SetPixel(k, z, renk);
                     
                    
                }
               
            }
            pictureBox1.Image = yeni;
            YeniBoyut2.Visible = false;
            cell2[0].Visible = false;
            cell2[1].Visible = false;
            cell2[2].Visible = false;
            cell2[3].Visible = false;
        }

        private void YeniBoyut_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(cell[0].Text);
            b = Convert.ToInt32(cell[1].Text);
            Bitmap boyut = new Bitmap(pictureBox1.Image, a, b);
            pictureBox1.Image = boyut;
            YeniBoyut.Visible = false;
            cell[0].Visible = false;
            cell[1].Visible = false;

        }
    }
}