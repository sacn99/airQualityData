using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SODA;
using SODA.Models;
using System.Net;
using System.IO;

namespace airQualityData
{
    class Program
    {

        static void Main(string[] args)
        {
          

        }

    /*   private static void read(String data)
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
            
        }*/
    }
}