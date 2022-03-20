using System;
using System.Collections.Generic;
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

            Console.WriteLine();

            //var newPopR = RoulleteSelection.newPopulation(populationEasy);
           // var newPopS = TournamentSelection.newPopulation(populationEasy);
            
            
            //var test = Crossover.SinglePointCrossover.cross(newPopS[0], newPopS[1], d1, d2);
            //Mutation.BinaryBitFlip.mutation(ref newPopS);



            /*
            Console.WriteLine();

            var d3 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\flat_cost.json");
            var d4 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\flat_flow.json");



            var populationFlat = GenotypeCreation.generatePopulation(d3, d4, 1, 12);
            var newPop1 = TournamentSelection.newPopulation(populationFlat);

            var test1 = Crossover.SinglePointCrossover.cross(newPop1[0], newPop1[1], d3, d4);


            Console.WriteLine();

            var d5 = DataManagment.ReadData<ConnectionCost>("Dane_testowe\\hard_cost.json");
            var d6 = DataManagment.ReadData<ConnectionFlow>("Dane_testowe\\hard_flow.json");

            var populationHard = GenotypeCreation.generatePopulation(d5, d6, 5, 6);
            var newPop2 = TournamentSelection.newPopulation(populationHard);
            var test2 = Crossover.SinglePointCrossover.cross(newPop2[0], newPop2[1], d5, d6);*/
        }
    }
}
