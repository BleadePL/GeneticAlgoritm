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
            /*            var d1 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\easy_cost.json");
                        var d2 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\easy_flow.json");

                        var populationEasy = GenotypeCreation.generatePopulation(d1, d2, 3, 3);

                        var best = GeneticAlgoritm.bestSpecimens(populationEasy, ref d1, ref d2);
                        var isTrue = best.Min(a => a.score);
                        var test = best.Find(a => a.score == isTrue);*/



            var d3 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\flat_cost.json");
            var d4 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\flat_flow.json");

            var populationFlat = GenotypeCreation.generatePopulation(d3, d4, 1, 12);
            var best = GeneticAlgoritm.bestSpecimens(populationFlat, ref d3, ref d4);
            var isTrue = best.Min(a => a.score);
            var test = best.Find(a => a.score == isTrue);




            /*            var d5 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\hard_cost.json");
                        var d6 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\hard_flow.json");

                        var populationHard = GenotypeCreation.generatePopulation(d5, d6, 5, 6);
                        var best = GeneticAlgoritm.bestSpecimens(populationHard, ref d5, ref d6);

                        var isTrue = best.Min(a => a.score);
                        var test = best.Find(a => a.score == isTrue);
                        Console.WriteLine();*/


            DataTable table = new DataTable();

            table.Columns.Add("Score", typeof(double));

            
            table.Rows.Add(populationFlat.Min(a => a.score));
            

            foreach (var elem in best)
            {
                table.Rows.Add(elem.score);
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
