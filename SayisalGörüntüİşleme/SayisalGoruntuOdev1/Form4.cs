using System;
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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap genisletme = genisletmeYap(resim);
                pictureBox1.Image = genisletme;

            }
            if (comboBox1.SelectedIndex == 1)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap erezyon = erezyonYap(resim);
                pictureBox1.Image = erezyon;

            }
            if (comboBox1.SelectedIndex == 2)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap acma = erezyonYap(resim);
                acma = genisletmeYap(acma);
                pictureBox1.Image = acma;

            }
            if (comboBox1.SelectedIndex == 3)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap kapama = genisletmeYap(resim);
                kapama = erezyonYap(kapama);
                pictureBox1.Image = kapama;

            }
            if (comboBox1.SelectedIndex == 4)
            {
                Form5 frm5 = new Form5();
                Bitmap resim = new Bitmap(pictureBox1.Image);
                resim = frm5.binaryYap2(resim);
                pictureBox1.Image = resim;

            }
        }
        public Bitmap erezyonYap(Bitmap resim)
        {
            Form2 frm2 = new Form2();
            Bitmap binary = frm2.GriYap(resim);
            binary = binaryYap(resim);
            Bitmap buffer = new Bitmap(binary.Width-2, binary.Height - 2);
            Color renk;


            for (int i = 1; i < binary.Height-2; i++)
            {
                for (int j = 1; j < binary.Width-2; j++)
                {

                    if (binary.GetPixel(j-1, i-1).R == 255&& binary.GetPixel(j-1, i).R == 255 && binary.GetPixel(j-1, i+1).R == 255 && binary.GetPixel(j, i-1).R == 255 && binary.GetPixel(j, i).R == 255&&binary.GetPixel(j, i+1).R == 255 && binary.GetPixel(j+1, i - 1).R == 255 && binary.GetPixel(j+1, i ).R == 255 && binary.GetPixel(j+1, i + 1).R == 255)
                    {
                        renk = Color.FromArgb(255, 255, 255);
                        buffer.SetPixel(j , i, renk);
                    }
                    else 
                    {
                        renk = Color.FromArgb(0, 0, 0);
                        buffer.SetPixel(j, i, renk);
                    }


                }
            }
            return buffer;
        }
        public Bitmap genisletmeYap(Bitmap resim)
        {
            Form2 frm2 = new Form2();
            Bitmap binary = frm2.GriYap(resim);
            binary = binaryYap(resim);
            Bitmap buffer = new Bitmap(binary.Width+2, binary.Height+2);
            Color renk;
           
          
            for (int i = 1; i < buffer.Height-1; i++)
            {
                for (int j = 1; j < buffer.Width-1; j++)
                {
                    
                        if (binary.GetPixel(j-1, i-1).R == 255)
                        {
                            renk = Color.FromArgb(255, 255, 255);
                        buffer.SetPixel(j-1 , i-1, renk);
                        buffer.SetPixel(j, i-1, renk);
                        buffer.SetPixel(j+1, i-1, renk);
                        buffer.SetPixel(j-1, i, renk);
                        buffer.SetPixel(j, i, renk);
                        buffer.SetPixel(j+1, i, renk);
                        buffer.SetPixel(j-1, i +1, renk);
                        buffer.SetPixel(j , i + 1, renk);
                        buffer.SetPixel(j + 1, i + 1, renk);
                    }
                        else
                        {
                        renk = Color.FromArgb(0, 0, 0);
                        buffer.SetPixel(j, i, renk);
                        }
                        

                }
            }
            return buffer;
        }
        public Bitmap binaryYap(Bitmap resim)
        {
            Form5 frm5 = new Form5();
            Form2 frm2 = new Form2();
            Bitmap gri = frm2.GriYap(resim);
            int esik = 149;
            int temp = 0;
            Color renk;
            for (int i = 0; i < gri.Height; i++)
            {
                for (int j = 0; j < gri.Width; j++)
                {
                    temp = gri.GetPixel(j, i).R;
                    if (temp < esik)
                    {
                        renk = Color.FromArgb(0, 0, 0);
                        gri.SetPixel(j, i, renk);

                    }
                    else
                    {
                        renk = Color.FromArgb(255, 255, 255);
                        gri.SetPixel(j, i, renk);
                    }
                }
            }
            return gri;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Close();
            Form3 frm3 = new Form3();
            frm3.Show();
            frm3.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }

        private void ilr_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Close();
            Form5 frm5 = new Form5();
            frm5.Show();
            frm5.pictureBox1.Image = pictureBox1.Image;
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
