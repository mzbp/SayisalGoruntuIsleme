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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rsmAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "resimler(*.BMP;*.JPG;*.PNG;*.TİF)|*.BMP;*.JPG;*.PNG;*.TİF|All files (*.*)|*.*";
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            pictureBox1.ImageLocation = sfd.FileName;
        }
       
        private void ilr_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Lütfen Resim Seçiniz!");
            }
            else
            {
                Form1 frm1 = new Form1();
                frm1.Close();
                Form2 frm2 = new Form2();
                frm2.Show();
                frm2.pictureBox1.Image = pictureBox1.Image;
                this.Hide();
            }
            
        }
       
    }
}
