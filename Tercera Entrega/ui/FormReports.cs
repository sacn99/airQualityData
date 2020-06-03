using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using CapaDatos;
using Brushes = System.Windows.Media.Brushes;
using System.Net;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Collections;
using SODA.Utilities;
using System.Globalization;

namespace ui
{
    public partial class FormReports : Form
    {
        ChartValues<DateModel> Values;
        LineSeries Ls;

        public FormReports()
        {
            InitializeComponent();
            this.radioButtonPM10.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            this.radioButtonPM25.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            this.radioButtonNO.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            this.radioButtonCO.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            this.radioButtonNO2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            this.radioButtonO3.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            this.radioButtonSO2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
             var dayConfig = Mappers.Xy<DateModel>().X(dateModel => dateModel.DateTime.Ticks / TimeSpan.FromDays(1).Ticks).Y(dateModel => dateModel.Value);
            Values = new ChartValues<DateModel>();
            Ls = new LineSeries(Values);
            cartesianChart1.Series = new SeriesCollection(dayConfig);
            cartesianChart1.Series.Add(Ls);
            /*cartesianChart1.AxisX.Add(new Axis
            {
                LabelFormatter = value => new DateTime((long)(value * TimeSpan.FromDays(1).Ticks)).ToString("d")
        });*/
            
        }

        public static DateModel threadPrototype()
        {
            DateModel dm = new DateModel
            {

            };
            return dm;
        }

        public void SetChartValues(String variable, int n)
        {
            try
            {
                var query = "$query=SELECT%20fecha,%20variable,%20concentraci_n%20" +
                    "WHERE%20variable%20=%20%27" + variable.ToUpper() + "%27%20" +
                    "ORDER%20BY%20fecha%20ASC%20" +
                    "LIMIT%2020%20" +
                    "OFFSET%20" + n;
                var url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?" + query;
                var wc = new WebClient();
                WebHeaderCollection whc = wc.ResponseHeaders;
                var stream = wc.OpenRead(url);
                var reader = new StreamReader(stream);
       
                String line;
                while ((line = reader.ReadLine()) != null)
                   {
                    line.Remove(0, 1);
                    line = line.Replace("[", "");
                    line = line.Replace("{", "");
                    line = line.Replace("}", "");
                    line = line.Replace("]", "");
                    
                    var subtv = line.Split(',');
                    var dateA = subtv[0].Split(':');
                    var date = dateA[1].Remove(0, 1);
                    date = date + ":" + dateA[2] + ":" + dateA[3];
                    date = date.Remove(date.Length-1);

                    Console.WriteLine(date);

                    var concentration = subtv[2].Split(':');

                    var x = DateTime.ParseExact(date, "dd/MM/yyyy hh:mm:ss t. t.", CultureInfo.InvariantCulture);


                    Values.Add(new DateModel { 
                        DateTime=x,
                        Value= Double.Parse(concentration[1])
                    });
                   }
               
            }
            catch (WebException e)
            {
                Console.WriteLine("No se pudo encontrar la BD");
            }

            n++;
            SetChartValues(variable, 20 * n);
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb.Checked)
            {
                if (rb.Text.Equals("PM10"))
                {
                    SetChartValues("PM10", 0);
                }else if (rb.Text.Equals("PM2.5"))
                {
                    SetChartValues("PM2.5", 0);
                }else if (rb.Text.Equals("NO"))
                {
                    SetChartValues("NO", 0);
                }else if (rb.Text.Equals("SO2"))
                {
                    SetChartValues("SO2", 0);
                }else if (rb.Text.Equals("NO2"))
                {
                    SetChartValues("NO2", 0);
                }else if(rb.Text.Equals("O3"))
                {
                    SetChartValues("O3", 0);
                }
                else
                {

                }
            }
        }
        
    }
}
