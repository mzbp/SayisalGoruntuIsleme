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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Close();
            Form2 frm2 = new Form2();
            frm2.Show();
            frm2.pictureBox1.Image = pictureBox1.Image;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Form2 frm2 = new Form2();
                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap bulanik = ortalamaYap(resim);
                pictureBox1.Image = bulanik;

            }
            if (comboBox1.SelectedIndex == 1)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap keskin = keskinlestirmeUygula2(resim);
                pictureBox1.Image = keskin;
            }
            if (comboBox1.SelectedIndex == 2)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap ortanca = ortancaUygula(resim);
                pictureBox1.Image = ortanca;
            }
            if (comboBox1.SelectedIndex == 3)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap laplace = laplaceUygula(resim);
                pictureBox1.Image = laplace;
            }
            if (comboBox1.SelectedIndex == 4)
            {

                Bitmap resim = new Bitmap(pictureBox1.Image);
                Bitmap sobel = sobelUygula(resim);
                pictureBox1.Image = sobel;
            }
        }
        public Bitmap ortalamaYap(Bitmap resim)
        {
            Bitmap gri = resim;
            Bitmap buffer = new Bitmap(gri.Width, gri.Height);
            Color renk;
            int valx, valy, valz;
            int[,] GX = new int[3, 3];
            //x yatay maske
            GX[0, 0] = 1; GX[0, 1] = 1; GX[0, 2] = 1;
            GX[1, 0] = 1; GX[1, 1] = 1; GX[1, 2] = 1;
            GX[2, 0] = 1; GX[2, 1] = 1; GX[2, 2] = 1;
            for (int i = 0; i < gri.Height; i++)
            {
                for (int j = 0; j < gri.Width; j++)
                {
                    if (i == 0 || i == gri.Height - 1 || j == 0 || j == gri.Width - 1)
                    {
                        renk = Color.FromArgb(255, 255, 255);
                        buffer.SetPixel(j, i, renk);
                        valx = 0;
                        valy = 0;
                        valz = 0;

                    }
                    else
                    {
                        valx = (gri.GetPixel(j - 1, i - 1).R * GX[0, 0] +
                             gri.GetPixel(j, i - 1).R * GX[0, 1] +
                             gri.GetPixel(j + 1, i - 1).R * GX[0, 2] +
                             gri.GetPixel(j - 1, i).R * GX[1, 0] +
                             gri.GetPixel(j, i).R * GX[1, 1] +
                             gri.GetPixel(j + 1, i).R * GX[1, 2] +
                             gri.GetPixel(j - 1, i + 1).R * GX[2, 0] +
                             gri.GetPixel(j, i + 1).R * GX[2, 1] +
                             gri.GetPixel(j + 1, i + 1).R * GX[2, 2])/9;
                        valy = (gri.GetPixel(j - 1, i - 1).G * GX[0, 0] +
                             gri.GetPixel(j, i - 1).G * GX[0, 1] +
                             gri.GetPixel(j + 1, i - 1).G * GX[0, 2] +
                             gri.GetPixel(j - 1, i).G * GX[1, 0] +
                             gri.GetPixel(j, i).G * GX[1, 1] +
                             gri.GetPixel(j + 1, i).G * GX[1, 2] +
                             gri.GetPixel(j - 1, i + 1).G * GX[2, 0] +
                             gri.GetPixel(j, i + 1).G * GX[2, 1] +
                             gri.GetPixel(j + 1, i + 1).G * GX[2, 2])/9;
                        valz = (gri.GetPixel(j - 1, i - 1).B * GX[0, 0] +
                           gri.GetPixel(j, i - 1).B * GX[0, 1] +
                           gri.GetPixel(j + 1, i - 1).B * GX[0, 2] +
                           gri.GetPixel(j - 1, i).B * GX[1, 0] +
                           gri.GetPixel(j, i).B * GX[1, 1] +
                           gri.GetPixel(j + 1, i).B * GX[1, 2] +
                           gri.GetPixel(j - 1, i + 1).B * GX[2, 0] +
                           gri.GetPixel(j, i + 1).B * GX[2, 1] +
                           gri.GetPixel(j + 1, i + 1).B * GX[2, 2])/9;
                       
                        
                        renk = Color.FromArgb(valx, valy, valz);
                        buffer.SetPixel(j, i, renk);
                    }
                }
            }


            return buffer;
        }
        public Bitmap keskinlestirmeUygula2(Bitmap resim)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(resim);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3;
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 };
            int MatrisToplami = 0 + -2 + 0 + -2 + 11 + -2 + 0 + -2 + 0;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) 
 {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    
                    int k = 0; 
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            R = toplamR / MatrisToplami;
                            G = toplamG / MatrisToplami;
                            B = toplamB / MatrisToplami;
                           
                            if (R > 255) R = 255;
                            if (G > 255) G = 255;
                            if (B > 255) B = 255;
                            if (R < 0) R = 0;
                            if (G < 0) G = 0;
                            if (B < 0) B = 0;
                           
                            CikisResmi.SetPixel(x, y, Color.FromArgb(R, G, B));
                            k++;
                           
                        }
                    }
                }
            }
            return CikisResmi;
        }
        private Bitmap keskinlestirmeUygula(Bitmap resim)
        {
            Bitmap resim1 = resim;
            Bitmap gri = laplaceUygula(resim1) ;
            
            Bitmap buffer = new Bitmap(gri.Width, gri.Height);
            Color renk;
            int deger1,deger2,deger3;
            for (int i = 0; i < gri.Height; i++)
            {
                for (int j = 0; j < gri.Width; j++)
                {
                    deger1 = gri.GetPixel(j, i).R + resim.GetPixel(j, i).R;
                    deger2 = gri.GetPixel(j, i).G + resim.GetPixel(j, i).G;
                    deger3 = gri.GetPixel(j, i).B + resim.GetPixel(j, i).B;



                    if (deger1 > 255)
                        deger1 = 255;
                    if (deger2 > 255)
                        deger2 = 255;
                    if (deger3 > 255)
                        deger3 = 255;
                    renk = Color.FromArgb(deger1, deger2, deger3);
                    buffer.SetPixel(j, i, renk);
                }
            }
            return buffer;
        }

        public Bitmap laplaceUygula(Bitmap resim)
        {
            Bitmap gri = resim;
            Bitmap buffer = new Bitmap(gri.Width, gri.Height);
            Color renk;
            int valx,valy,valz;
            int[,] GX = new int[3, 3];
            //x yatay maske
            GX[0, 0] = 0; GX[0, 1] = 1; GX[0, 2] = 0;
            GX[1, 0] = 1; GX[1, 1] = -4; GX[1, 2] = 1;
            GX[2, 0] = 0; GX[2, 1] = 1; GX[2, 2] = 0;
            for (int i = 0; i < gri.Height; i++)
            {
                for (int j = 0; j < gri.Width; j++)
                {
                    if (i == 0 || i == gri.Height - 1 || j == 0 || j == gri.Width - 1)
                    {
                        renk = Color.FromArgb(255, 255, 255);
                        buffer.SetPixel(j, i, renk);
                        valx = 0;
                        valy = 0;
                        valz = 0;
                     
                    }
                    else
                    {
                        valx = gri.GetPixel(j - 1, i - 1).R * GX[0, 0] +
                             gri.GetPixel(j, i - 1).R * GX[0, 1] +
                             gri.GetPixel(j + 1, i - 1).R * GX[0, 2] +
                             gri.GetPixel(j - 1, i).R * GX[1, 0] +
                             gri.GetPixel(j, i).R * GX[1, 1] +
                             gri.GetPixel(j + 1, i).R * GX[1, 2] +
                             gri.GetPixel(j - 1, i + 1).R * GX[2, 0] +
                             gri.GetPixel(j, i + 1).R * GX[2, 1] +
                             gri.GetPixel(j + 1, i + 1).R * GX[2, 2];
                        valy = gri.GetPixel(j - 1, i - 1).G * GX[0, 0] +
                             gri.GetPixel(j, i - 1).G * GX[0, 1] +
                             gri.GetPixel(j + 1, i - 1).G * GX[0, 2] +
                             gri.GetPixel(j - 1, i).G * GX[1, 0] +
                             gri.GetPixel(j, i).G * GX[1, 1] +
                             gri.GetPixel(j + 1, i).G * GX[1, 2] +
                             gri.GetPixel(j - 1, i + 1).G * GX[2, 0] +
                             gri.GetPixel(j, i + 1).G * GX[2, 1] +
                             gri.GetPixel(j + 1, i + 1).G * GX[2, 2];
                        valz = gri.GetPixel(j - 1, i - 1).B * GX[0, 0] +
                           gri.GetPixel(j, i - 1).B * GX[0, 1] +
                           gri.GetPixel(j + 1, i - 1).B * GX[0, 2] +
                           gri.GetPixel(j - 1, i).B * GX[1, 0] +
                           gri.GetPixel(j, i).B * GX[1, 1] +
                           gri.GetPixel(j + 1, i).B * GX[1, 2] +
                           gri.GetPixel(j - 1, i + 1).B * GX[2, 0] +
                           gri.GetPixel(j, i + 1).B * GX[2, 1] +
                           gri.GetPixel(j + 1, i + 1).B * GX[2, 2];
                        if (valx < 0)
                            valx = 0;
                        if (valx > 255)
                            valx = 255;
                        if (valy < 0)
                            valy = 0;
                        if (valy > 255)
                            valy = 255;
                        if (valz < 0)
                            valz = 0;
                        if (valz > 255)
                            valz = 255;
                        renk = Color.FromArgb(valx, valy, valz);
                        buffer.SetPixel(j, i, renk);
                    }
                }
            }


            return buffer;
        }

        public Bitmap ortancaUygula(Bitmap resim)
        {
            Bitmap buffer = new Bitmap(resim.Width, resim.Height);
            Color renk;
            for (int i = 0; i < resim.Height; i++)
            {
                for (int j = 0; j < resim.Width; j++)
                {
                    if (i == 0 || i == resim.Height - 1 || j == 0 || j == resim.Width - 1)
                    {
                        continue;
                    }
                    else
                    {
                        int ortanca1 = ortancayiBul1(resim, j, i);
                        int ortanca2 = ortancayiBul2(resim, j, i);
                        int ortanca3 = ortancayiBul3(resim, j, i);
                        renk = Color.FromArgb(ortanca1, ortanca2, ortanca3);
                        buffer.SetPixel(j, i, renk);
                    }
                }


            }
            return buffer;
        }

        int ortancayiBul1(Bitmap resim, int j, int i)
        {
            int [] dizi=new int[9];
            
            int sagKomsu, sagUstCaprazKomsu, ustKomsu, solUstCaprazKomsu, solKomsu, solAltCaprazKomsu, altKomsu, sagAltCaprazKomsu;
            sagKomsu = resim.GetPixel(j + 1, i).R;
            sagUstCaprazKomsu = resim.GetPixel(j + 1, i-1).R;
            ustKomsu= resim.GetPixel(j , i-1).R;
            solUstCaprazKomsu= resim.GetPixel(j - 1, i-1).R;
            solKomsu= resim.GetPixel(j - 1, i).R;
            solAltCaprazKomsu= resim.GetPixel(j - 1, i+1).R;
            altKomsu= resim.GetPixel(j , i+1).R;
            sagAltCaprazKomsu= resim.GetPixel(j + 1, i+1).R;

            dizi[0] = resim.GetPixel(j, i).R;
            dizi[1] = sagKomsu;
            dizi[2] = sagUstCaprazKomsu;
            dizi[3] = ustKomsu;
            dizi[4] = solUstCaprazKomsu;
            dizi[5] = solKomsu;
            dizi[6] = solAltCaprazKomsu;
            dizi[7] = altKomsu;
            dizi[8] = sagAltCaprazKomsu;

            for (int k = 0; k < 8; k++)
            {
                for (int l = k+1; l < 9; l++)
                {
                    if (dizi[k] < dizi[l])
                    {
                        continue;
                    }
                    else
                    {
                        int temp = dizi[l];
                        dizi[l] = dizi[k];
                        dizi[k] = temp;
                    }
                }


            }
            return dizi[4];
        }
        int ortancayiBul2(Bitmap resim, int j, int i)
        {
            int[] dizi = new int[9];

            int sagKomsu, sagUstCaprazKomsu, ustKomsu, solUstCaprazKomsu, solKomsu, solAltCaprazKomsu, altKomsu, sagAltCaprazKomsu;
            sagKomsu = resim.GetPixel(j + 1, i).G;
            sagUstCaprazKomsu = resim.GetPixel(j + 1, i - 1).G;
            ustKomsu = resim.GetPixel(j, i - 1).G;
            solUstCaprazKomsu = resim.GetPixel(j - 1, i - 1).G;
            solKomsu = resim.GetPixel(j - 1, i).G;
            solAltCaprazKomsu = resim.GetPixel(j - 1, i + 1).G;
            altKomsu = resim.GetPixel(j, i + 1).G;
            sagAltCaprazKomsu = resim.GetPixel(j + 1, i + 1).G;

            dizi[0] = resim.GetPixel(j, i).G;
            dizi[1] = sagKomsu;
            dizi[2] = sagUstCaprazKomsu;
            dizi[3] = ustKomsu;
            dizi[4] = solUstCaprazKomsu;
            dizi[5] = solKomsu;
            dizi[6] = solAltCaprazKomsu;
            dizi[7] = altKomsu;
            dizi[8] = sagAltCaprazKomsu;

            for (int k = 0; k < 8; k++)
            {
                for (int l = k + 1; l < 9; l++)
                {
                    if (dizi[k] < dizi[l])
                    {
                        continue;
                    }
                    else
                    {
                        int temp = dizi[l];
                        dizi[l] = dizi[k];
                        dizi[k] = temp;
                    }
                }


            }
            return dizi[4];
        }
        int ortancayiBul3(Bitmap resim, int j, int i)
        {
            int[] dizi = new int[9];

            int sagKomsu, sagUstCaprazKomsu, ustKomsu, solUstCaprazKomsu, solKomsu, solAltCaprazKomsu, altKomsu, sagAltCaprazKomsu;
            sagKomsu = resim.GetPixel(j + 1, i).B;
            sagUstCaprazKomsu = resim.GetPixel(j + 1, i - 1).B;
            ustKomsu = resim.GetPixel(j, i - 1).B;
            solUstCaprazKomsu = resim.GetPixel(j - 1, i - 1).B;
            solKomsu = resim.GetPixel(j - 1, i).B;
            solAltCaprazKomsu = resim.GetPixel(j - 1, i + 1).B;
            altKomsu = resim.GetPixel(j, i + 1).B;
            sagAltCaprazKomsu = resim.GetPixel(j + 1, i + 1).B;

            dizi[0] = resim.GetPixel(j, i).B;
            dizi[1] = sagKomsu;
            dizi[2] = sagUstCaprazKomsu;
            dizi[3] = ustKomsu;
            dizi[4] = solUstCaprazKomsu;
            dizi[5] = solKomsu;
            dizi[6] = solAltCaprazKomsu;
            dizi[7] = altKomsu;
            dizi[8] = sagAltCaprazKomsu;

            for (int k = 0; k < 8; k++)
            {
                for (int l = k + 1; l < 9; l++)
                {
                    if (dizi[k] < dizi[l])
                    {
                        continue;
                    }
                    else
                    {
                        int temp = dizi[l];
                        dizi[l] = dizi[k];
                        dizi[k] = temp;
                    }
                }


            }
            return dizi[4];
        }
        public Bitmap sobelUygula(Bitmap resim)
        {
            Form2 frm2 = new Form2();
            Bitmap gri = frm2.GriYap(resim);
            Bitmap buffer = new Bitmap(gri.Width, gri.Height);
            Color renk;
            int valx, valy, gradient;
            int[,] GX = new int[3, 3];
            int[,] GY = new int[3, 3];
            //x yatay maske
            GX[0, 0] = -1; GX[0, 1] = 0; GX[0, 2] = 1;
            GX[1, 0] = -2; GX[1, 1] = 0; GX[1, 2] = 2;
            GX[2, 0] = -1; GX[2, 1] = 0; GX[2, 2] = 1;
            //y düşey maske
            GY[0, 0] = -1; GY[0, 1] = -2; GY[0, 2] = -1;
            GY[1, 0] = 0; GY[1, 1] = 0; GY[1, 2] = 0;
            GY[2, 0] = 1; GY[2, 1] = 2; GY[2, 2] = 1;

            for (int i = 0; i < gri.Height; i++)
            {
                for (int j = 0; j < gri.Width; j++)
                {
                    if (i == 0 || i == gri.Height - 1 || j == 0 || j == gri.Width - 1)
                    {
                        renk = Color.FromArgb(255, 255, 255);
                        buffer.SetPixel(j, i, renk);
                        valx = 0;
                        valy = 0;
                    }
                    else
                    {
                        valx = gri.GetPixel(j - 1, i - 1).R * GX[0, 0] +
                             gri.GetPixel(j, i - 1).R * GX[0, 1] +
                             gri.GetPixel(j + 1, i - 1).R * GX[0, 2] +
                             gri.GetPixel(j - 1, i).R * GX[1, 0] +
                             gri.GetPixel(j, i).R * GX[1, 1] +
                             gri.GetPixel(j + 1, i).R * GX[1, 2] +
                             gri.GetPixel(j - 1, i + 1).R * GX[2, 0] +
                             gri.GetPixel(j, i + 1).R * GX[2, 1] +
                             gri.GetPixel(j + 1, i + 1).R * GX[2, 2];

                        valy = gri.GetPixel(j - 1, i - 1).R * GY[0, 0] +
                             gri.GetPixel(j, i - 1).R * GY[0, 1] +
                             gri.GetPixel(j + 1, i - 1).R * GY[0, 2] +
                             gri.GetPixel(j - 1, i).R * GY[1, 0] +
                             gri.GetPixel(j, i).R * GY[1, 1] +
                             gri.GetPixel(j + 1, i).R * GY[1, 2] +
                             gri.GetPixel(j - 1, i + 1).R * GY[2, 0] +
                             gri.GetPixel(j, i + 1).R * GY[2, 1] +
                             gri.GetPixel(j + 1, i + 1).R * GY[2, 2];

                        gradient = (int)(Math.Abs(valx) + Math.Abs(valy));
                        if (gradient < 0)
                            gradient = 0;
                        if (gradient > 255)
                            gradient = 255;
                        renk = Color.FromArgb(gradient, gradient, gradient);
                        buffer.SetPixel(j, i, renk);
                    }
                }
            }


            return buffer;
        }

        private void ilr_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Close();
            Form4 frm4 = new Form4();
            frm4.Show();
            frm4.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }
    }
    
}
