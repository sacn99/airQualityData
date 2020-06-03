using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ui
{
    public partial class PredictionForm : Form
    {
        public PredictionForm()
        {
            InitializeComponent();
            //  chart1.Series.Add("Concentracion");
        }


        public static void LinearRegression(double[] xVals, double[] yVals,
                                       int inclusiveStart, int exclusiveEnd,
                                       out double rsquared, out double yintercept,
                                       out double slope)
        {
            //   Debug.Assert(xVals.Length == yVals.Length);
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double ssX = 0;
            double ssY = 0;
            double sumCodeviates = 0;
            double sCo = 0;
            double count = exclusiveEnd - inclusiveStart;

            for (int ctr = inclusiveStart; ctr < exclusiveEnd; ctr++)
            {
                double x = xVals[ctr];
                double y = yVals[ctr];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }
            ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            ssY = sumOfYSq - ((sumOfY * sumOfY) / count);
            double RNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            double RDenom = (count * sumOfXSq - (sumOfX * sumOfX))
             * (count * sumOfYSq - (sumOfY * sumOfY));
            sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            double meanX = sumOfX / count;
            double meanY = sumOfY / count;
            double dblR = RNumerator / Math.Sqrt(RDenom);
            rsquared = dblR * dblR;
            yintercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
        }

        private void PredictionForm_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            if (radioButton1.Checked == true)
            {
                chart1.Series["Concentracion"].Points.AddXY("2011", "130.6");
                chart1.Series["Concentracion"].Points.AddXY("2011", "136.6");
                chart1.Series["Concentracion"].Points.AddXY("2011", "140.6");

                chart1.Series["Concentracion"].Points.AddXY("2012", "138.6");
                chart1.Series["Concentracion"].Points.AddXY("2012", "145.6");
                chart1.Series["Concentracion"].Points.AddXY("2012", "153.6");

                chart1.Series["Concentracion"].Points.AddXY("2013", "150.6");
                chart1.Series["Concentracion"].Points.AddXY("2013", "168.6");
                chart1.Series["Concentracion"].Points.AddXY("2013", "149.6");

                chart1.Series["Concentracion"].Points.AddXY("2014", "158.6");
                chart1.Series["Concentracion"].Points.AddXY("2014", "165.6");
                chart1.Series["Concentracion"].Points.AddXY("2014", "170.6");

                chart1.Series["Concentracion"].Points.AddXY("2015", "158");
                chart1.Series["Concentracion"].Points.AddXY("2015", "165");
                chart1.Series["Concentracion"].Points.AddXY("2015", "172");

                chart1.Series["Concentracion"].Points.AddXY("2016", "160.6");
                chart1.Series["Concentracion"].Points.AddXY("2016", "161.6");
                chart1.Series["Concentracion"].Points.AddXY("2016", "169.6");

                chart1.Series["Concentracion"].Points.AddXY("2017", "149.6");
                chart1.Series["Concentracion"].Points.AddXY("2017", "159.6");
                chart1.Series["Concentracion"].Points.AddXY("2017", "164.6");

                chart1.Series["Concentracion"].Points.AddXY("2018", "162.6");
                chart1.Series["Concentracion"].Points.AddXY("2018", "169.8");
                chart1.Series["Concentracion"].Points.AddXY("2018", "172.9");

            }

            if (radioButton2.Checked == true)
            {

                chart1.Series["Concentracion"].Points.AddXY("2011", "1.6");
                chart1.Series["Concentracion"].Points.AddXY("2011", "1.3");
                chart1.Series["Concentracion"].Points.AddXY("2011", "1.42");

                chart1.Series["Concentracion"].Points.AddXY("2012", "1.5");
                chart1.Series["Concentracion"].Points.AddXY("2012", "1.65");
                chart1.Series["Concentracion"].Points.AddXY("2012", "1.76");

                chart1.Series["Concentracion"].Points.AddXY("2013", "1.8");
                chart1.Series["Concentracion"].Points.AddXY("2013", "1.86");
                chart1.Series["Concentracion"].Points.AddXY("2013", "1.90");

                chart1.Series["Concentracion"].Points.AddXY("2014", "2.01");
                chart1.Series["Concentracion"].Points.AddXY("2014", "2.11");
                chart1.Series["Concentracion"].Points.AddXY("2014", "2.13");

                chart1.Series["Concentracion"].Points.AddXY("2015", "2.20");
                chart1.Series["Concentracion"].Points.AddXY("2015", "2.28");
                chart1.Series["Concentracion"].Points.AddXY("2015", "2.36");

                chart1.Series["Concentracion"].Points.AddXY("2016", "2.46");
                chart1.Series["Concentracion"].Points.AddXY("2016", "2.56");
                chart1.Series["Concentracion"].Points.AddXY("2016", "2.66");

                chart1.Series["Concentracion"].Points.AddXY("2017", "2.72");
                chart1.Series["Concentracion"].Points.AddXY("2017", "2.79");
                chart1.Series["Concentracion"].Points.AddXY("2017", "2.87");

                chart1.Series["Concentracion"].Points.AddXY("2018", "2.92");
                chart1.Series["Concentracion"].Points.AddXY("2018", "2.98");
                chart1.Series["Concentracion"].Points.AddXY("2018", "3.00");

            }
        }
    }
}