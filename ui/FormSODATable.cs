using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SODA;
using SODA.Utilities;
using Newtonsoft.Json;
using System.Threading;
using CapaDatos;

namespace ui
{
    public partial class FormSODATable : Form
    {

        public FormSODATable()
        {
            InitializeComponent();
        }

        private void FormSODATable_Load(object sender, EventArgs e)
        {
            Records r = new Records();
            DataTable ds = r.ShowPage(1);
            showRecords(ds);
        }

        private void showRecords(DataTable ds)
        {
            dataGridView1.DataSource = ds;
            Console.WriteLine(""+ds.Columns.Count);
            dataGridView1.Columns[0].Visible = true; //Fecha
            dataGridView1.Columns[1].Visible = true; //Autoridad Ambiental
            dataGridView1.Columns[2].Visible = true; //Nombre de la Estacion
            dataGridView1.Columns[3].Visible = true; //Tecnologia
            dataGridView1.Columns[4].Visible = true; //Latitud
            dataGridView1.Columns[5].Visible = true; //Codigo del Departamento
            dataGridView1.Columns[6].Visible = true; //Departamento
            dataGridView1.Columns[7].Visible = true; //Codigo del Municipio
            dataGridView1.Columns[8].Visible = true; //Nombre del Municipio
            dataGridView1.Columns[9].Visible = true; //Tipo de Estacion
            dataGridView1.Columns[10].Visible = true; //Tipo de Exposicion
            dataGridView1.Columns[11].Visible = true; //Variable
            dataGridView1.Columns[12].Visible = true; //Unidades
            dataGridView1.Columns[13].Visible = true; //Concentracion
            dataGridView1.Columns[14].Visible = true; //Concentracion
        }
    }
}
