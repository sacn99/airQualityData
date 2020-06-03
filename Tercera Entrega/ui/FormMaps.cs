using System;
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
            string latitud = dataGridView.Rows[filaSeleccionada].Cells[4].Value.ToString();
            string longitud = dataGridView.Rows[filaSeleccionada].Cells[5].Value.ToString();
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
    }
}
