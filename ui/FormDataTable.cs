using SODA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ui
{
    public partial class FormDataTable : Form
    {
        DataTable dataTable;
        private String filter;

        public FormDataTable()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filter = "";
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            String comboBox = comboBox1.Text.ToLower();
            String[] comboBoxSplit = comboBox.Split(' ');
            comboBox = comboBoxSplit.GetValue(0).ToString();
            String comboFixed;
            for (int i = 1; i < comboBoxSplit.Length; i++)
            {
                comboBox = comboBox + "_" + comboBoxSplit.GetValue(i);
            }
            comboFixed = comboBox;
            if (!filter.Equals(""))
            {
                filter = filter + "&" + comboFixed + "=" + textBox4.Text;
            }
            else
            {
                filter = comboFixed + "=" + textBox4.Text;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            List<String> data = Soda(textBox1.Text, textBox2.Text, textBox3.Text);
            for (int i = 0; i < data.Count; i++)
            {
                String[] valor = data[i].Split(':');
                dataTable.Columns.Add(new DataColumn(valor[0], typeof(String)));
            }
            readInfo(textBox2.Text);
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[1].Visible = true; //Fecha
            dataGridView1.Columns[2].Visible = true; //Autoridad Ambiental
            dataGridView1.Columns[3].Visible = true; //Nombre de la Estacion
            dataGridView1.Columns[4].Visible = true; //Tecnologia
            dataGridView1.Columns[5].Visible = true; //Latitud
            dataGridView1.Columns[6].Visible = true; //Codigo del Departamento
            dataGridView1.Columns[7].Visible = true; //Departamento
            dataGridView1.Columns[8].Visible = true; //Codigo del Municipio
            dataGridView1.Columns[9].Visible = true; //Nombre del Municipio
            dataGridView1.Columns[10].Visible = true; //Tipo de Estacion
            dataGridView1.Columns[11].Visible = true; //Tipo de Exposicion
            dataGridView1.Columns[12].Visible = true; //Variable
            dataGridView1.Columns[13].Visible = true; //Unidades
            dataGridView1.Columns[14].Visible = true; //Concentracion
            dataGridView1.Columns[15].Visible = true; //Georeferencia
        }


        public List<String> Soda(String url, String bdId, String token)
        {


            // Install the package from Nuget first:
            // PM> Install-Package CSM.SodaDotNet
            //"oipJOeStVp83pvoG20CMSGiXe"

            var client = new SodaClient(url, token);

            // Get a reference to the resource itself
            // The result (a Resouce object) is a generic type
            // The type parameter represents the underlying rows of the resource
            // and can be any JSON-serializable class
            var dataset = client.GetResource<Object>(bdId);

            // Resource objects read their own data
            /*var rows = dataset.GetRows(limit: 5000);         
            Console.WriteLine("Got {0} results. Dumping first results:", rows.Count());
            */
            var columns = dataset.Columns;
            List<String> l = new List<String>();
            foreach (var keyValue in columns)
            {
                l.Add(keyValue.Name);

            }
            return l;
        }

        public void readInfo(String bdId)
        {
            string result;
            try
            {

                var url = "https://www.datos.gov.co/resource/" + bdId + ".json?" + filter + "&$limit=10&$offset=20";
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    String line = reader.ReadLine();
                    int count = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] args = line.Split(',');
                        dataTable.Rows.Add("" + args[1], "" + args[2], "" + args[3], "" + args[4], "" + args[5], "" + args[6], "" + args[7], "" + args[8], "" + args[9], "" + args[10], "" + args[11], "" + args[12], "" + args[13], "" + args[14], "" + args[15], "" + args[16]);
                        count++;
                    }
                    reader.Close();
                    stream.Close();
                }

            }
            catch (WebException e)
            {
                result = string.Format("" + e);
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mapa_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            gMapControl.Visible = true;

        }
    }
}
