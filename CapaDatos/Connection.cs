using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SODA;

namespace CapaDatos
{
    public class Connection
    {
        private SodaClient client;
        private  Resource<Dictionary<string, string>> dataset;

        public Connection()
        {
            client = new SodaClient("https://www.datos.gov.co", "0ZxbhxPYsq48evOeRDVFeHuCA");
            dataset = client.GetResource<Dictionary<String, String>>("ysq6-ri4e");
        }

        public Resource<Dictionary<string, string>> getDataset()
        {
            return dataset;
        }
    }
}
