using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CSharp_GDP1
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, string> predef = new Dictionary<string, string>();
            Dictionary<string, double[]> result = new Dictionary<string, double[]>();
            Dictionary<string, double> inter = new Dictionary<string, double>;
            inter.Add("GDP_2012", 0);
            inter.Add("POPULATION_2012", 0);
            result.Add("Asia", inter);
            result.Add("South America",inter);
            result.Add("Oceania", inter);
            result.Add("North America", inter);
            result.Add("Europe", inter);
            result.Add("Africa", inter);
            int i;
            double j, k;
            string[] data = File.ReadAllLines(@"C:\Users\cgi\Desktop\StackRoute\C#\CSharp-GDP\datafile.csv");
            string[] temp = File.ReadAllLines(@"C:\Users\cgi\Desktop\StackRoute\C#\CSharp-GDP\country.csv");
            string[] compdata;
            for (i = 1; i < temp.Length; i++)
            {
                compdata = temp[i].Split(",");
                predef.Add(compdata[1], compdata[0]);
            }
            int x = data.Length;
            for (i = 1; i < x; i++)
            {
                data[i] = data[i].Replace("\"", "");
                temp = data[i].Split(",");
                j = Convert.ToDouble(temp[4]);
                k = Convert.ToDouble(temp[7]);
                result[predef[temp[0]]].["GDP"] += j;
                result[predef[temp[0]]].["POPULATION_2012"] += k;

            }
            string output = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(output);







        }
    }
}
