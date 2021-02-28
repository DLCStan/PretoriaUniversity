using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Web;
using System.Globalization;
using GendacMVCForAPI.Models;

namespace GendacMVCForAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            /*
            context.Products.Add( new Product
            {
                Category = "CategoryC",
                Name = "Product HHKSD",
                Price = 2145.00M
            });

            context.Products.Add(new Product
            {
                Category = "CategoryA",
                Name = "Product HKLLSH",
                Price = 1244.99M
            });

            context.Products.Add(new Product
            {
                Category = "CategoryC",
                Name = "Product HHKSD",
                Price = 999.49M
            });
            
            context.SaveChanges();
            */
            
            //Console.WriteLine("Hello World!");
            var url = "http://gendacproficiencytest.azurewebsites.net/API/ProductsAPI/";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);

                    StringReader sr = new StringReader(xdoc.ToString());

                    DataSet ds = new DataSet();

                    ds.ReadXml(sr);

                    string category_got;
                    int id_got;
                    string name_got;
                    decimal price_got;
                    //Categories cat;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        //cat = Categories.(row[ds.Tables[0].Columns[0]].ToString());
                        category_got = row[ds.Tables[0].Columns[0]].ToString();
                        id_got = Convert.ToInt32(row[ds.Tables[0].Columns[1]]);
                        name_got = row[ds.Tables[0].Columns[2]].ToString();
                        price_got = Convert.ToDecimal(row[ds.Tables[0].Columns[3]]);


                        context.Add(new Product
                        {
                            Category = category_got,
                            Name = name_got,
                            Price = price_got
                        });
                    }
                    context.SaveChanges();
                }
                
            }
        }
    }
}
