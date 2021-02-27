using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Globalization;

namespace FetchingData
{
    class Program
    {
        static void Main(string[] args)
        {

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

                    //Console.WriteLine(ds.Tables[0].Columns.Count);

                    var textPrint = "";
                    var i = 1000;
                    var j = 0;
                    var listProd = new List<object>();

                    var cat = "";
                    var nm = "";
                    var pr = 0.0M;
                    var idx = 0;

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        //if (j == i)
                        //    break;

                        //cat = row["Category"].ToString();
                        //pr = Convert.ToDecimal(row["Price"].ToString());
                        //break;
                        ///*
                        foreach (DataColumn column in ds.Tables[0].Columns)
                        {
                            textPrint += "item: " + row[column] + " ";
                            // read column and item
                            //Console.Write("item: ", item + " ");
                            listProd.Add(row[column]);
                        }
                        break;
                        j++;
                        textPrint += "\n";
                        //Console.WriteLine();
                        //*/
                    }
                    //Console.WriteLine(listProd[3].ToString());

                    //dec = listProd[3].ToString().Split(".");
                    /*
                    string amount  = "12.21";
                    var c = System.Threading.Thread.CurrentThread.CurrentCulture;
                    var s = c.NumberFormat.CurrencyDecimalSeparator;

                    amount = amount.Replace(",", s);
                    amount = amount.Replace(".", s);*/
                    string s = "1.21";
                    decimal c2 = decimal.Parse(s, new CultureInfo("en-gb"));

                    Console.WriteLine(c2);
                    //decimal v = listProd[3];
                    //Console.WriteLine(listProd[3].GetType());
                    //Console.WriteLine(listProd[0].ToString(), Convert.ToInt32(listProd[1]), listProd[2].ToString(), Convert.ToDecimal(listProd[3]));
                    //Console.WriteLine(textPrint);
                }

            }
        }
    }
}
