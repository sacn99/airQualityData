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
    public partial class Busqueda : Form
    {
        public Busqueda()
        {
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns.Add("Autoridad Ambiental", "Autoridad Ambiental");
            dataGridView1.Columns.Add("Nombre de la estación", "Nombre de la estación");
            dataGridView1.Columns.Add("Tecnología", "Tecnología");
            dataGridView1.Columns.Add("Latitud", "Latitud");
            dataGridView1.Columns.Add("Longitud", "Longitud");
            dataGridView1.Columns.Add("Tipo de Dato", "Tipo de Dato");
            dataGridView1.Columns.Add("Código del departamento	", "Código del departamento	");
            dataGridView1.Columns.Add("Departamento", "Departamento");
            dataGridView1.Columns.Add("Código del municipio", "Código del municipio");
            dataGridView1.Columns.Add("Nombre del municipio", "Nombre del municipio");
            dataGridView1.Columns.Add("Tipo de estación", "Tipo de estación");
            dataGridView1.Columns.Add("Tipo de Dato", "Tipo de Dato");
            dataGridView1.Columns.Add("Tiempo de exposición", "Tiempo de exposición");
            dataGridView1.Columns.Add("Variable", "Variable");
            dataGridView1.Columns.Add("Unidades", "Unidades");
            dataGridView1.Columns.Add("Concentración", "Concentración");
            dataGridView1.Columns.Add("Nueva columna georreferenciada", "Nueva columna georreferenciada");
            dataGridView1.Columns.Add("Nueva columna georreferenciada", "Nueva columna georreferenciada");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
