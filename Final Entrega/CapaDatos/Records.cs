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
using System.Net;
using System.IO;

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
            var rows = dataset.GetRows(limit:rowsPerPage ,offset:x);
            var table = new DataTable();

            var js = JsonConvert.SerializeObject(rows);

            List<Record> RecordList = JsonConvert.DeserializeObject<List<Record>>(js);

            table = ToDataTable(RecordList);

            return table; 
        }

        public DataTable ShowTableDeptoFilter(string depto)
        {
            String line = "";
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
            string result;
                try
                {

                    var url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?Departamento="+depto.ToUpper();
                    var client = new WebClient();
                    using (var stream = client.OpenRead(url))
                    using (var reader = new StreamReader(stream))
                    {
                        line = reader.ReadLine();
                        line = line.Replace("[", "");
                        line = line.Replace("{", "");
                        line = line.Replace("}", "");
                        line = line.Replace("]", "");

                    int count = 0;
                    String[] values = new String[16];
                        while ((line = reader.ReadLine()) != null)
                        {
                            String[] args = line.Split(',');
                            for (int i = 1; i < args.Length-1; i++)
                            {
                                String[] split = args[i].Split(':');
                                if (split.Length > 2)
                                {
                                    split[1] = split[1] + ":" + split[2];
                                    split[1] = split[1].Remove(0, 1);
                                    split[1] = split[1].Remove(split[1].Length - 1, 1);
                                    values[i] = split[1];
                                }
                                else {
                                    split[1] = split[1].Remove(0, 1);
                                    split[1] = split[1].Remove(split[1].Length - 1, 1);
                                    values[i] = split[1];
                                }
                            }
                        table.Rows.Add("" + values[1], "" + values[2], "" + values[3], "" + values[4], "" + values[4], "" + values[5], "" + values[6], "" + values[7], "" + values[8], "" + values[9], "" + values[10], "" + values[11], "" + values[12], "" + values[13], "" + values[14]);
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

            return table;
        }

        public DataTable ShowTableCiudadFilter(string city)
        {
            String line = "";
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
            string result;
            try
            {

                var url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?nombre_del_municipio=" + city.ToUpper();
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    line = reader.ReadLine();
                    line = line.Replace("[", "");
                    line = line.Replace("{", "");
                    line = line.Replace("}", "");
                    line = line.Replace("]", "");

                    int count = 0;
                    String[] values = new String[16];
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] args = line.Split(',');
                        for (int i = 1; i < args.Length - 1; i++)
                        {
                            String[] split = args[i].Split(':');
                            if (split.Length > 2)
                            {
                                split[1] = split[1] + ":" + split[2];
                                split[1] = split[1].Remove(0, 1);
                                split[1] = split[1].Remove(split[1].Length - 1, 1);
                                values[i] = split[1];
                            }
                            else
                            {
                                split[1] = split[1].Remove(0, 1);
                                split[1] = split[1].Remove(split[1].Length - 1, 1);
                                values[i] = split[1];
                            }
                        }
                        table.Rows.Add("" + values[1], "" + values[2], "" + values[3], "" + values[4], "" + values[4], "" + values[5], "" + values[6], "" + values[7], "" + values[8], "" + values[9], "" + values[10], "" + values[11], "" + values[12], "" + values[13], "" + values[14]);
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

            return table;
        }

        public DataTable ShowTableVariableFilter(string var)
        {
            String line = "";
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
            string result;
            try
            {

                var url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?Variable=" + var;
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    line = reader.ReadLine();
                    line = line.Replace("[", "");
                    line = line.Replace("{", "");
                    line = line.Replace("}", "");
                    line = line.Replace("]", "");

                    int count = 0;
                    String[] values = new String[16];
                    while ((line = reader.ReadLine()) != null)
                    {
                        String[] args = line.Split(',');
                        for (int i = 1; i < args.Length - 1; i++)
                        {
                            String[] split = args[i].Split(':');
                            if (split.Length > 2)
                            {
                                split[1] = split[1] + ":" + split[2];
                                split[1] = split[1].Remove(0, 1);
                                split[1] = split[1].Remove(split[1].Length - 1, 1);
                                values[i] = split[1];
                            }
                            else
                            {
                                split[1] = split[1].Remove(0, 1);
                                split[1] = split[1].Remove(split[1].Length - 1, 1);
                                values[i] = split[1];
                            }
                        }
                        table.Rows.Add("" + values[1], "" + values[2], "" + values[3], "" + values[4], "" + values[4], "" + values[5], "" + values[6], "" + values[7], "" + values[8], "" + values[9], "" + values[10], "" + values[11], "" + values[12], "" + values[13], "" + values[14]);
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
