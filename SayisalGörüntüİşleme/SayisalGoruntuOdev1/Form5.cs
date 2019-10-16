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
    public partial class Form5 : Form
    {
        public Form5()
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
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Close();
            Form4 frm4 = new Form4();
            frm4.Show();
            frm4.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Bitmap resim = new Bitmap(pictureBox1.Image);
                int sobel = otsuEsiklemeYap(resim);
                textBox1.Text = Convert.ToString(sobel);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                siyahBeyazNesneBulma();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Form4 frm4 = new Form4();
                
                Bitmap resim = new Bitmap(pictureBox1.Image);

                resim = binaryYap2(resim);
                resim = frm4.erezyonYap(resim);
                resim = frm4.genisletmeYap(resim);
                resim = frm4.erezyonYap(resim);
                pictureBox1.Image = resim;
                siyahBeyazNesneBulma();


       
            }
            if (comboBox1.SelectedIndex == 3)
            {

                Form4 frm4 = new Form4();

                Form2 frm2 = new Form2();
                Bitmap resim = new Bitmap(pictureBox1.Image);

                resim = frm2.GriYap(resim); 
                resim = binaryYap2(resim);
                resim = frm4.erezyonYap(resim);
                resim = frm4.genisletmeYap(resim);
                resim = frm4.erezyonYap(resim);
                resim = frm2.NegatifeDonustur(resim);
                pictureBox1.Image = resim;
                siyahBeyazNesneBulma();
              
            }
        }
       
    public Bitmap binaryYap2(Bitmap resim)
        {
            Form5 frm5 = new Form5();
            Form2 frm2 = new Form2();
            Bitmap gri = frm2.GriYap(resim);
            int esik = frm5.otsuEsiklemeYap(resim);
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
        public int otsuEsiklemeYap(Bitmap resim)
        {
            Form2 frm2 = new Form2();
            Bitmap gri = frm2.GriYap(resim);
            int[] piksel=new int[256];
            int[] pikselSayisi = new int[256];

            int otsuValue=0;
            int renk;
            int toplamPiksel=0,n1=0,n2, nTop = 0;
            double toplam2 = 0.0,m1,m2,toplam1=0.0;
            double fmax = -1.0;
            double S;
            for (int x = 0; x < gri.Width; x++)
            {
                for (int y = 0; y < gri.Height; y++)
                {
                   
                    renk = gri.GetPixel(x, y).R;
                    pikselSayisi[renk]++;
                    piksel[renk] = 1;
                    toplamPiksel++;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                toplam1 += (double)i * (double)piksel[i];
                nTop += piksel[i];
            }
            for (int i = 0; i < 255; i++)
            {
                n1 += piksel[i];
                if (n1 == 0)
                    continue;
                n2 = nTop - n1;
                if (n2 == 0)
                    break;
                toplam2 += (double)i * piksel[i];
                m1 = toplam2 / n1;
                m2 = (toplam1 - toplam2) / n2;
                S = (double)n1 * (double)n2 * (m1 - m2) * (m1 - m2);

                if (S > fmax)
                {
                    fmax = S;
                    otsuValue = i;
                }
            }
            return otsuValue;
        }

        private void ilr_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Close();
            Form6 frm6 = new Form6();
            frm6.Show();
            frm6.pictureBox1.Image = pictureBox1.Image;
            this.Hide();
        }
       
        private void siyahBeyazNesneBulma()
        {
            Bitmap GirisResmi, CikisResmi;
            int KomsularinEnKucukEtiketDegeri = 0;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            int PikselSayisi = ResimGenisligi * ResimYuksekligi;
            pictureBox1.Image = GirisResmi; //Resmin son halini gösteriyor.
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int x, y, i, j, EtiketNo = 0;
            int[,] EtiketNumarasi = new int[ResimGenisligi, ResimYuksekligi]; 
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    EtiketNumarasi[x, y] = 0;
                }
            }
            int IlkDeger = 0, SonDeger = 0;
            bool DegisimVar = false; 
            do 
            {
                DegisimVar = false;
                                for (y = 1; y < ResimYuksekligi - 1; y++) 
                {
                    for (x = 1; x < ResimGenisligi - 1; x++)
                    {
                        
                        if (GirisResmi.GetPixel(x, y).R > 128)
                        {
                           
                            IlkDeger = EtiketNumarasi[x, y];
                           
                            KomsularinEnKucukEtiketDegeri = 0;
                            for (j = -1; j <= 1; j++) 
                            {
                                for (i = -1; i <= 1; i++)
                                {
                                    if (EtiketNumarasi[x + i, y + j] != 0 && KomsularinEnKucukEtiketDegeri == 0) 
                                                                                                                 
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[x + i, y + j];
                                    }
                                    else if (EtiketNumarasi[x + i, y + j] < KomsularinEnKucukEtiketDegeri && EtiketNumarasi[x
                                    + i, y + j] != 0 && KomsularinEnKucukEtiketDegeri != 0) 
                                    {
                                        KomsularinEnKucukEtiketDegeri = EtiketNumarasi[x + i, y + j];
                                    }
                                }
                            }
                            if (KomsularinEnKucukEtiketDegeri != 0) 
                            {
                                EtiketNumarasi[x, y] = KomsularinEnKucukEtiketDegeri;
                            }
                            else if (KomsularinEnKucukEtiketDegeri == 0) 
                            {
                                EtiketNo = EtiketNo + 1;
                                EtiketNumarasi[x, y] = EtiketNo;
                            }
                            SonDeger = EtiketNumarasi[x, y]; 
                            if (IlkDeger != SonDeger)
                                DegisimVar = true;
                        }
                    }
                }
            } while (DegisimVar == true);
                        int[] DiziEtiket = new int[PikselSayisi];
            i = 0;
            for (x = 1; x < ResimGenisligi - 1; x++)
            {
                for (y = 1; y < ResimYuksekligi - 1; y++)
                {
                    i++;
                    DiziEtiket[i] = EtiketNumarasi[x, y];
                }
            }
           
            Array.Sort(DiziEtiket);
            
            int[] TekrarsizEtiketNumaralari = DiziEtiket.Distinct().ToArray();
            int[] RenkDizisi = new int[TekrarsizEtiketNumaralari.Length];
            for (j = 0; j < TekrarsizEtiketNumaralari.Length; j++)
            {
                RenkDizisi[j] = TekrarsizEtiketNumaralari[j]; 
            }
            int RenkSayisi = RenkDizisi.Length;
            Color[] Renkler = new Color[RenkSayisi];
            Random Rastgele = new Random();
            int Kirmizi, Yesil, Mavi;
            for (int r = 0; r < RenkSayisi; r++) 
            {
                Kirmizi = Rastgele.Next(5, 25) * 10; 
                Yesil = Rastgele.Next(5, 25) * 10;
                Mavi = Rastgele.Next(5, 25) * 10;
                Renkler[r] = Color.FromArgb(Kirmizi, Yesil, Mavi);
            }

            for (x = 1; x < ResimGenisligi - 1; x++) 
            {
                for (y = 1; y < ResimYuksekligi - 1; y++)
                {
                    int RenkSiraNo = Array.IndexOf(RenkDizisi, EtiketNumarasi[x, y]); 
                    if (GirisResmi.GetPixel(x, y).R < 128) 
                    {
                        CikisResmi.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        CikisResmi.SetPixel(x, y, Renkler[RenkSiraNo]);
                    }
                                    }
            }
            pictureBox1.Image = CikisResmi;

        }






    }
}
