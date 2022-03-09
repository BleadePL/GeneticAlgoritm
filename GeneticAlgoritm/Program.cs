using System;
using System.Collections.Generic;

namespace GeneticAlgoritm
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var d1 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\easy_cost.json");
            var d2 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\easy_flow.json");

            var factory1 = DataManagment.factoriesInit(d1, 3, 3);

            var test = DataManagment.fitnessFunction(d1, d2, ref factory1);

            Console.WriteLine();
            
            var d3 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\flat_cost.json");
            var d4 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\flat_flow.json");

            var factory2 = DataManagment.factoriesInit(d3, 1, 12);


            var test2 = DataManagment.fitnessFunction(d3, d4, ref factory2);


            Console.WriteLine();

            var d5 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\hard_cost.json");
            var d6 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\hard_flow.json");

            var factory3 = DataManagment.factoriesInit(d5, 5, 6);


            var test3 = DataManagment.fitnessFunction(d5, d6, ref factory3);
        }
    }
}
