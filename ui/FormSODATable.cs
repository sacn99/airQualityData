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
            showRecords(r.ShowPage(1));
            DataTable ds = new DataTable();
        }

        private void showRecords(DataTable ds)
        {

            dataGridView1.DataSource = ds; 
        }
    }
}
