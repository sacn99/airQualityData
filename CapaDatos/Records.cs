using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SODA;
using Newtonsoft.Json;
using SODA.Utilities;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CapaDatos
{
    public class Records
    {
        Connection c = new Connection();
        DataTable dt = new DataTable();

        public DataTable ShowPage(int nPage)
        {
            var rowsPerPage = 20;
            var x = (nPage-1) * rowsPerPage;

            var client = new SodaClient("https://www.datos.gov.co", "4VQQ9iZluaLN4aeY2wbOFlhF9");
            var dataset = client.GetResource<Object>("ysq6-ri4e");
            var rows = dataset.GetRows(limit: rowsPerPage, offset:x);
            var table = new DataTable();

            var js = JsonConvert.SerializeObject(rows);

            List<Record> RecordList = JsonConvert.DeserializeObject<List<Record>>(js);

            table = ToDataTable(RecordList);

            for (int i = 0; i<rows.Count();i++)
            {
               
                var dt = JsonConvert.DeserializeObject(js);
                Console.WriteLine(dt);
            }
            
            

            return table; 
        }

        public DataTable ToDataTable(IList<Record> data)
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

            for (int i = 0; i < data.Count; i++)
            {
                String[] values = data[i].RecordArray();
                table.Rows.Add(values);
            }
            
            return table;
        }

    }
}
