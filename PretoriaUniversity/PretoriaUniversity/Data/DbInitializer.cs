using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PretoriaUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Web;
using System.Collections;
using System.Globalization;

namespace PretoriaUniversity.Data
{
    public static class DbInitializer
    {
        //Console.WriteLine("Hello World!");


        //Console.WriteLine(ds.Tables[0].Columns.Count);

        public static void Initialize(this ModelBuilder modelBuilder)
        {
            var url = "http://gendacproficiencytest.azurewebsites.net/API/ProductsAPI/";
            DataSet ds = new DataSet();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

                    StringReader sr = new StringReader(xdoc.ToString());

                    ds.ReadXml(sr);
                }
            }

            //List<Products> dataArray = new ArrayList<Products>();
            var dataArray = new List<Products>();
            //object[] textPrint = new object[4];
            var textPrint = new List<object>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                
                //var i = 0;
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    //textPrint[i++] = row[column];
                    textPrint.Add(row[column]);
                    //textPrint += "item: " + row[column] + " ";
                    // read column and item
                    //Console.Write("item: ", item + " ");
                }

                ///string s = "1.21";
                //decimal c2 = decimal.Parse(s, new CultureInfo("en-gb"));
                decimal c2 = decimal.Parse(textPrint[3].ToString(), new CultureInfo("en-US"));

                dataArray.Add(new Products { Id = Convert.ToInt32(textPrint[1]), Category = textPrint[0].ToString(), Name = textPrint[2].ToString(), Price = c2}) ;
                
                //textPrint += "\n";
                //Console.WriteLine();
            }

            modelBuilder.Entity<Products>().HasData(dataArray.ToArray());
        }
    }
}

/*new Products { Id = 1, Category = "CategoryA", Name = "Stove", Price = 10.00M },
                new Products { Id = 2, Category = "CategoryB", Name = "Fridge", Price = 19.99M },
                new Products { Id = 3, Category = "CategoryA", Name = "Stove", Price = 29.99M }
                );*/

