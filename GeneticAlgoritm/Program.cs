using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using GeneticAlgoritm.Selection;

namespace GeneticAlgoritm
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            //Connection costs and flow of machines
            var d1 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\easy_cost.json");
            var d2 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\easy_flow.json");

            var populationEasy = GenotypeCreation.generatePopulation(d1, d2, 3, 3);

            var best = GeneticAlgoritm.bestSpecimens(populationEasy, ref d1, ref d2);


            /*
                        var d3 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\flat_cost.json");
                        var d4 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\flat_flow.json");

                        var populationFlat = GenotypeCreation.generatePopulation(d3, d4, 1, 12);
                        var best = GeneticAlgoritm.bestSpecimens(populationFlat, ref d3, ref d4);*/





            /*            var d5 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\hard_cost.json");
                        var d6 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\hard_flow.json");

                        var populationHard = GenotypeCreation.generatePopulation(d5, d6, 5, 6);
                        var best = GeneticAlgoritm.bestSpecimens(populationHard, ref d5, ref d6);*/



            DataTable table = new DataTable();

            table.Columns.Add("Best", typeof(double));
            table.Columns.Add("Average", typeof(double));
            table.Columns.Add("Worst", typeof(double));

            
            table.Rows.Add(populationEasy.Min(a => a.score), (int)populationEasy.Average(a => a.score), populationEasy.Max(a => a.score));


            for (int i = 0; i < best.Item1.Count(); i++)
            {
                table.Rows.Add(best.Item1[i].score, best.Item2[i], best.Item3[i]);
            }


            var lines = new List<string>();

            string[] columnNames = table.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToArray();

            var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
            lines.Add(header);

            var valueLines = table.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));

            lines.AddRange(valueLines);

            File.WriteAllLines("excel.csv", lines);


        }
    }
}
