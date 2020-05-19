using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ui
{
    public partial class FormMaps : Form
    {
        GMapOverlay markerOverlay;
        GMapMarker markerOrigin;

        int filaSeleccionada = 0;
        double latInicial = 4.6097102;
        double LngInicial = -74.081749;

        GMapOverlay Circulos = new GMapOverlay("Circulos");

        public FormMaps()
        {
            InitializeComponent();
        }

        private void FormMaps_Load(object sender, EventArgs e)
        {
            markerOverlay = new GMapOverlay("Marcador");
            markerOrigin = new GMarkerGoogle(new PointLatLng(latInicial, LngInicial), GMarkerGoogleType.green_dot);
            markerOverlay.Markers.Add(markerOrigin);

            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.CanDragMap = true;
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.Position = new PointLatLng(latInicial, LngInicial);
            gMapControl.MinZoom = 0;
            gMapControl.MaxZoom = 24;
            gMapControl.Zoom = 5;
            gMapControl.AutoScroll = true;

            Records r = new Records();
            DataTable ds = r.ShowPage(1);
            dataGridView.DataSource = ds;

            dataGridView.Columns[1].Visible = false; //Autoridad Ambiental
            dataGridView.Columns[2].Visible = false; //Nombre de la Estacion
            dataGridView.Columns[3].Visible = false; //Tecnologia
            dataGridView.Columns[4].Visible = false; //Latitud
            dataGridView.Columns[5].Visible = false; //Codigo del Departamento
            dataGridView.Columns[6].Visible = false; //Departamento
            dataGridView.Columns[8].Visible = false; //Nombre del Municipio
            dataGridView.Columns[10].Visible = false; //Tipo de Exposicion
            dataGridView.Columns[11].Visible = false; //Variable
            dataGridView.Columns[12].Visible = false; //Unidades
            dataGridView.Columns[13].Visible = false; //Concentracion
            dataGridView.Columns[14].Visible = false; //Concentracion

        }

        private void btnDepto_Click(object sender, EventArgs e)
        {
            Records r = new Records();
            DataTable ds = r.ShowTableDeptoFilter(txtDepto.Text);
            dataGridView.DataSource = ds;

            dataGridView.Columns[1].Visible = false; //Autoridad Ambiental
            dataGridView.Columns[2].Visible = false; //Nombre de la Estacion
            dataGridView.Columns[3].Visible = false; //Tecnologia
            dataGridView.Columns[4].Visible = false; //Latitud
            dataGridView.Columns[5].Visible = false; //Codigo del Departamento
            dataGridView.Columns[6].Visible = false; //Departamento
            dataGridView.Columns[8].Visible = false; //Nombre del Municipio
            dataGridView.Columns[10].Visible = false; //Tipo de Exposicion
            dataGridView.Columns[11].Visible = false; //Variable
            dataGridView.Columns[12].Visible = false; //Unidades
            dataGridView.Columns[13].Visible = false; //Concentracion
            dataGridView.Columns[14].Visible = false; //Concentracion
        }

        private void SeleccionarRegistro(object sender, DataGridViewCellMouseEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
            string fecha = dataGridView.Rows[filaSeleccionada].Cells[0].Value.ToString();
            string autoridadAmbiental = dataGridView.Rows[filaSeleccionada].Cells[1].Value.ToString();
            string nombreEstacion = dataGridView.Rows[filaSeleccionada].Cells[2].Value.ToString();
            string tecnologia = dataGridView.Rows[filaSeleccionada].Cells[3].Value.ToString();
            string departamento = dataGridView.Rows[filaSeleccionada].Cells[7].Value.ToString();
            string municipio = dataGridView.Rows[filaSeleccionada].Cells[9].Value.ToString();
            string tipoEstacion = dataGridView.Rows[filaSeleccionada].Cells[10].Value.ToString();
            string tiempoExposicion = dataGridView.Rows[filaSeleccionada].Cells[11].Value.ToString();
            string variable = dataGridView.Rows[filaSeleccionada].Cells[12].Value.ToString();
            string unidades = dataGridView.Rows[filaSeleccionada].Cells[13].Value.ToString();
            string concentracion = dataGridView.Rows[filaSeleccionada].Cells[14].Value.ToString();

            GeoCoderStatusCode statusCode;
            PointLatLng? pointLatLng1 = OpenStreet4UMapProvider.Instance.GetPoint(municipio + ",COLOMBIA", out statusCode);

            markerOrigin.Position = new PointLatLng(pointLatLng1.Value.Lat, pointLatLng1.Value.Lng);
            gMapControl.Overlays.Add(markerOverlay);
            gMapControl.Position = markerOrigin.Position;

            markerOrigin.ToolTipMode = MarkerTooltipMode.Always;
            markerOrigin.ToolTipText = string.Format("Fecha: {0} \n Autoridad Ambiental: {1} \n Nombre de la Estacion: {2} \n Tecnologia: {3} \n Departamento: {4} \n Municipio: {5} \n Tipo de Estacion: {6} \n Tiempo de Exposicion: {7} \n Variable: {8} \n Unidades: {9} \n Concentracion: {10}"
                , fecha, autoridadAmbiental, nombreEstacion, tecnologia, departamento, municipio, tipoEstacion, tiempoExposicion, variable, unidades, concentracion);

            gMapControl.Zoom = 9;
        }

        private void btnHeatMap_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode statusCode;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                string municipio = dataGridView.Rows[i].Cells[9].Value.ToString();
                PointLatLng? pointLatLng1 = OpenStreet4UMapProvider.Instance.GetPoint(municipio + ",COLOMBIA", out statusCode);
                PointF pointF = new PointF();
                pointF.X = Convert.ToSingle(pointLatLng1.Value.Lat);
                pointF.Y = Convert.ToSingle(pointLatLng1.Value.Lng);
                CreateCircle(pointF, 0.1, 1080);
            }
            gMapControl.Overlays.Add(Circulos);
        }

        private void CreateCircle(PointF point, double radius, int segments)
        {

            List<PointLatLng> gpollist = new List<PointLatLng>();

            double seg = Math.PI * 2 / segments;

            int y = 0;
            for (int i = 0; i < segments; i++)
            {
                double theta = seg * i;
                double a = point.X + Math.Cos(theta) * radius;
                double b = point.Y + Math.Sin(theta) * radius;

                PointLatLng gpoi = new PointLatLng(a, b);

                gpollist.Add(gpoi);
            }
            GMapPolygon gpol = new GMapPolygon(gpollist, "pol");
            gpol.Fill = new SolidBrush(Color.FromArgb(25, Color.Red));
            gpol.Stroke = new Pen(Color.Red, 1);
            Circulos.Polygons.Add(gpol);
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            Records r = new Records();
            DataTable ds = r.ShowTableCiudadFilter(txtCiudad.Text);
            dataGridView.DataSource = ds;

            dataGridView.Columns[1].Visible = false; //Autoridad Ambiental
            dataGridView.Columns[2].Visible = false; //Nombre de la Estacion
            dataGridView.Columns[3].Visible = false; //Tecnologia
            dataGridView.Columns[4].Visible = false; //Latitud
            dataGridView.Columns[5].Visible = false; //Codigo del Departamento
            dataGridView.Columns[6].Visible = false; //Departamento
            dataGridView.Columns[8].Visible = false; //Nombre del Municipio
            dataGridView.Columns[10].Visible = false; //Tipo de Exposicion
            dataGridView.Columns[11].Visible = false; //Variable
            dataGridView.Columns[12].Visible = false; //Unidades
            dataGridView.Columns[13].Visible = false; //Concentracion
            dataGridView.Columns[14].Visible = false; //Concentracion
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Fecha", typeof(String)));
            table.Columns.Add(new DataColumn("Autoridad Ambiental", typeof(String)));
            table.Columns.Add(new DataColumn("Nombre de la Estacion", typeof(String)));
            table.Columns.Add(new DataColumn("Tecnologia", typeof(String)));
            table.Columns.Add(new DataColumn("Latitud", typeof(String)));
            table.Columns.Add(new DataColumn("Longitud", typeof(String)));
            table.Columns.Add(new DataColumn("Codigo del Departamento", typeof(String)));
            table.Columns.Add(new DataColumn("Departamento", typeof(String)));
            table.Columns.Add(new DataColumn("Codigo del Municipio", typeof(String)));
            table.Columns.Add(new DataColumn("Municipio", typeof(String)));
            table.Columns.Add(new DataColumn("Tipo de Estacion", typeof(String)));
            table.Columns.Add(new DataColumn("Tiempo de Exposicion", typeof(String)));
            table.Columns.Add(new DataColumn("Variable", typeof(String)));
            table.Columns.Add(new DataColumn("Unidades", typeof(String)));
            table.Columns.Add(new DataColumn("Concentracion", typeof(String)));

            DataRow[] rows = new DataRow[dataGridView.Rows.Count];
            
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView[0, i].Value.ToString().Contains(txtFecha.Text))
                {
                    rows[i] = (dataGridView.Rows[i].DataBoundItem as DataRowView).Row;
                }
            }

            foreach (DataRow dr in rows)
            {
                table.ImportRow(dr);
            }

            dataGridView.DataSource = table;

            dataGridView.Columns[1].Visible = false; //Autoridad Ambiental
            dataGridView.Columns[2].Visible = false; //Nombre de la Estacion
            dataGridView.Columns[3].Visible = false; //Tecnologia
            dataGridView.Columns[4].Visible = false; //Latitud
            dataGridView.Columns[5].Visible = false; //Codigo del Departamento
            dataGridView.Columns[6].Visible = false; //Departamento
            dataGridView.Columns[8].Visible = false; //Nombre del Municipio
            dataGridView.Columns[10].Visible = false; //Tipo de Exposicion
            dataGridView.Columns[11].Visible = false; //Variable
            dataGridView.Columns[12].Visible = false; //Unidades
            dataGridView.Columns[13].Visible = false; //Concentracion
            dataGridView.Columns[14].Visible = false; //Concentracion

        }

        private void btnVariable_Click(object sender, EventArgs e)
        {
            Records r = new Records();
            DataTable ds = r.ShowTableVariableFilter(txtVariable.Text);
            dataGridView.DataSource = ds;

            dataGridView.Columns[1].Visible = false; //Autoridad Ambiental
            dataGridView.Columns[2].Visible = false; //Nombre de la Estacion
            dataGridView.Columns[3].Visible = false; //Tecnologia
            dataGridView.Columns[4].Visible = false; //Latitud
            dataGridView.Columns[5].Visible = false; //Codigo del Departamento
            dataGridView.Columns[6].Visible = false; //Departamento
            dataGridView.Columns[8].Visible = false; //Nombre del Municipio
            dataGridView.Columns[10].Visible = false; //Tipo de Exposicion
            dataGridView.Columns[11].Visible = false; //Variable
            dataGridView.Columns[12].Visible = false; //Unidades
            dataGridView.Columns[13].Visible = false; //Concentracion
            dataGridView.Columns[14].Visible = false; //Concentracion
        }

        private void btnVariableTabla_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Fecha", typeof(String)));
            table.Columns.Add(new DataColumn("Autoridad Ambiental", typeof(String)));
            table.Columns.Add(new DataColumn("Nombre de la Estacion", typeof(String)));
            table.Columns.Add(new DataColumn("Tecnologia", typeof(String)));
            table.Columns.Add(new DataColumn("Latitud", typeof(String)));
            table.Columns.Add(new DataColumn("Longitud", typeof(String)));
            table.Columns.Add(new DataColumn("Codigo del Departamento", typeof(String)));
            table.Columns.Add(new DataColumn("Departamento", typeof(String)));
            table.Columns.Add(new DataColumn("Codigo del Municipio", typeof(String)));
            table.Columns.Add(new DataColumn("Municipio", typeof(String)));
            table.Columns.Add(new DataColumn("Tipo de Estacion", typeof(String)));
            table.Columns.Add(new DataColumn("Tiempo de Exposicion", typeof(String)));
            table.Columns.Add(new DataColumn("Variable", typeof(String)));
            table.Columns.Add(new DataColumn("Unidades", typeof(String)));
            table.Columns.Add(new DataColumn("Concentracion", typeof(String)));

            DataRow[] rows = new DataRow[dataGridView.Rows.Count];

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView[13, i].Value.ToString().Equals(txtFecha.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    rows[i] = (dataGridView.Rows[i].DataBoundItem as DataRowView).Row;
                }
            }

            foreach (DataRow dr in rows)
            {
                table.ImportRow(dr);
            }

            dataGridView.DataSource = table;

            dataGridView.Columns[1].Visible = false; //Autoridad Ambiental
            dataGridView.Columns[2].Visible = false; //Nombre de la Estacion
            dataGridView.Columns[3].Visible = false; //Tecnologia
            dataGridView.Columns[4].Visible = false; //Latitud
            dataGridView.Columns[5].Visible = false; //Codigo del Departamento
            dataGridView.Columns[6].Visible = false; //Departamento
            dataGridView.Columns[8].Visible = false; //Nombre del Municipio
            dataGridView.Columns[10].Visible = false; //Tipo de Exposicion
            dataGridView.Columns[11].Visible = false; //Variable
            dataGridView.Columns[12].Visible = false; //Unidades
            dataGridView.Columns[13].Visible = false; //Concentracion
            dataGridView.Columns[14].Visible = false; //Concentracion
        }
    }
}
