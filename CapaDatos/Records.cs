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

            var client = new SodaClient("https://www.datos.gov.co", "0ZxbhxPYsq48evOeRDVFeHuCA");
            var dataset = client.GetResource<Object>("ysq6-ri4e");
            var rows = dataset.GetRows(limit: rowsPerPage, offset:x);
            var table = new DataTable();

            var js = JsonConvert.SerializeObject(rows);

            List<Record> RecordList = JsonConvert.DeserializeObject<List<Record>>(js);

            table = ToDataTable<Record>(RecordList);

            for (int i = 0; i<rows.Count();i++)
            {
               
                var dt = JsonConvert.DeserializeObject(js);
                Console.WriteLine(dt);
            }
            
            

            return table; 
        }

        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

    }
}
