using System;
using CsvHelper;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;


namespace ConsoleApp1
{
    public class ProgrammingLanguage
    {
        public string Year { get; set; }
        public string Industry_aggregation_NZSIOC { get; set; }
        public string Industry_code_NZSIOC { get; set; }
        public string Industry_name_NZSIOC { get; set; }
        public string Units { get; set; }
        public string Variable_code { get; set; }
        public string Variable_name { get; set; }
        public string Variable_category { get; set; }
        public string Value { get; set; }
        public string Industry_code_ANZSIC06 { get; set; }
    }

    public class RocketLaunchClassMap : ClassMap<ProgrammingLanguage>
    {
        public RocketLaunchClassMap()
        {
            Map(m => m.Year).Name("Year");
            Map(m => m.Industry_aggregation_NZSIOC).Name("Industry_aggregation_NZSIOC");
            Map(m => m.Industry_code_NZSIOC).Name("Industry_code_NZSIOC");
            Map(m => m.Industry_name_NZSIOC).Name("Industry_name_NZSIOC");
            Map(m => m.Units).Name("Units");
            Map(m => m.Variable_code).Name("Variable_code");
            Map(m => m.Variable_name).Name("Variable_name");
            Map(m => m.Variable_category).Name("Variable_category");
            Map(m => m.Value).Name("Value");
            Map(m => m.Industry_code_ANZSIC06).Name("Industry_code_ANZSIC06");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var streamReader = new StreamReader(@"C:\Users\user\RiderProjects\ConsoleApp1\ConsoleApp1\Example.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<RocketLaunchClassMap>();
                    var records = csvReader.GetRecords<ProgrammingLanguage>().ToList();
                    foreach (var i in records)
                    {
                        Console.WriteLine(i.Year);
                    }
                }
            }
        }
    }


}