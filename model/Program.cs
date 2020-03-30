using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SODA;
using SODA.Models;
using SODA.Utilities;
using Json.Net;
using System.Net;
using System.IO;

namespace airQualityData
{
    class Program
    {

        public static String URL = "https://www.datos.gov.co/resource/ysq6-ri4e.json?";

        private static String DATA = "";

        static void Main(string[] args)
        {
            read(URL + "$limit=5");

            var dataSet = JsonNet.Deserialize<Dictionary<string, string>[]>(DATA);

           // Console.WriteLine(dataSet[0]);

            Thread.Sleep(60 * (Int32)Math.Pow(10, 3));

        }

        private static void read(String data)
        {
            try
            {
                var url = data;
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    String line = reader.ReadLine();
                    while (line != null)
                    {
                        DATA += line;
                        line = reader.ReadLine();
                    }
                    reader.Close();
                    stream.Close();
                }

            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}