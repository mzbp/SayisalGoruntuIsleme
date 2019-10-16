using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SayisalGoruntuOdev1
{
    public partial class Histogram : Form
    {
        public Histogram()
        {
            InitializeComponent();
        }
        public int[] histogramRed()
        {
            Bitmap bmp = Form2.resimHistogram;
            int[] kirmizi = new int[256];

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color renk = bmp.GetPixel(i, j);

                    kirmizi[renk.R]++;
                }
            return kirmizi;
        }
        public int[] histogramBlue()
        {
            Bitmap bmp = Form2.resimHistogram;
            int[] mavi = new int[256];

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color renk = bmp.GetPixel(i, j);

                    mavi[renk.B]++;
                }
            return mavi;
        }
        public int[] histogramGreen()
        {
            Bitmap bmp = Form2.resimHistogram;
            int[] yesil = new int[256];

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color renk = bmp.GetPixel(i, j);

                    yesil[renk.G]++;
                }
            return yesil;
        }
        private void createChart()
        {
            int[] kirmiziChart = histogramRed();
            int[] maviChart = histogramBlue();
            int[] yesilChart = histogramGreen();
            Series series = this.chart1.Series.Add("blue");
            Series series1 = this.chart1.Series.Add("green");
            Series series2 = this.chart1.Series.Add("red");

            for (int i = 1; i < 256; i++)
            {

                series.Points.AddXY(i, maviChart[i]);
                series1.Points.AddXY(i, yesilChart[i]);
                series2.Points.AddXY(i, kirmiziChart[i]);
            }
        }

        private void Histogram_Load(object sender, EventArgs e)
        {
            createChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
