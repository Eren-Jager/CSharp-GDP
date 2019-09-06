using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace CSharp_GDP1
{
     
    public class Program
    {
        public static void Main(string[] args) { }
        private static Dictionary<string, double> PopulateDict()
        {
            return new Dictionary<string, double>()
            {
                { "GDP_2012", 0 },
                { "POPULATION_2012", 0 }
            };
        } 
        public static void GDP_Calc()
        {
            Dictionary<string, string> predef = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string,double>> result = new Dictionary<string, Dictionary<string,double>>();
            result.Add("Asia", PopulateDict());
            result.Add("South America", PopulateDict());
            result.Add("Oceania", PopulateDict());
            result.Add("North America", PopulateDict());
            result.Add("Europe", PopulateDict());
            result.Add("Africa", PopulateDict());
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
                result[predef[temp[0]]]["GDP_2012"] += k;
                result[predef[temp[0]]]["POPULATION_2012"] += j;

            }
            string output = JsonConvert.SerializeObject(result, Formatting.Indented);
            System.IO.File.WriteAllText(@"C:\Users\cgi\Desktop\StackRoute\C#\CSharp-GDP\Output.json", output);
        }
    }
}
