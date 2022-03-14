﻿using System;
using System.Collections.Generic;
using GeneticAlgoritm.Selection;

namespace GeneticAlgoritm
{
    internal class Program
    {


        static void Main(string[] args)
        {
            var d1 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\easy_cost.json");
            var d2 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\easy_flow.json");

            var populationEasy = GenotypeCreation.generatePopulation(d1, d2, 3, 3);

            var newPop = TournamentSelection.newPopulation(populationEasy);
            var newPopR = RoulleteSelection.newPopulation(populationEasy);


            Console.WriteLine();

            var d3 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\flat_cost.json");
            var d4 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\flat_flow.json");


            var populationFlat = GenotypeCreation.generatePopulation(d3, d4, 1, 12);
            //var newPop1 = TournamentSelection.newPopulation(populationFlat);


            Console.WriteLine();

            var d5 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\hard_cost.json");
            var d6 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\hard_flow.json");

            var populationHard = GenotypeCreation.generatePopulation(d5, d6, 5, 6);

        }
    }
}
