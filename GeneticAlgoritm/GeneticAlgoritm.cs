using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    internal class GeneticAlgoritm
    {
        private const int TESTING_PARAMETER = 100;

        public static List<Factory> bestSpecimens(List<Factory> population, ref List<ConnectionCost> connectionCosts, ref List<ConnectionFlow> connectionFlow)
        {
            List<Factory> bestSpecimens = new List<Factory>();
            Random random = new Random();
            var currentPopulation = population;

            Console.WriteLine($"Current population size: {currentPopulation.Count()}");

            for (int i = 0; i < TESTING_PARAMETER; i++)
            {
                var testPop = Selection.TournamentSelection.newPopulation(currentPopulation);

                List<Factory> childSpecimens = new List<Factory>();

                /*
                                var specimenPairs = testPop.Select((v, i) => new { Index = i, Value = v })
                                                    .GroupBy(x => x.Index / 2, x => x.Value)
                                                    .Select(g => Tuple.Create(g.First(), g.Skip(1).First())).ToList();*/

                for (int j = 0; j < testPop.Count(); j += 2)
                {
                    var tmp = random.NextDouble();
                    if (tmp <= 0.5)
                    {
                        var newChildren = Crossover.SinglePointCrossover.cross(testPop[j], testPop[j + 1], connectionCosts, connectionFlow);
                        childSpecimens.Add(newChildren.Item1);
                        childSpecimens.Add(newChildren.Item2);
                    }
                    else
                    {
                        childSpecimens.Add(testPop[j]);
                        childSpecimens.Add(testPop[j + 1]);
                    }
                }

                /*                foreach (var elem in specimenPairs)
                                {
                                    var newChildren = Crossover.SinglePointCrossover.cross(elem.Item1, elem.Item2, connectionCosts, connectionFlow);
                                    childSpecimens.Add(newChildren.Item1);
                                    childSpecimens.Add(newChildren.Item2);
                                }*/

                Mutation.BinaryBitFlip.mutation(ref childSpecimens,  connectionCosts, connectionFlow);


                var min = childSpecimens.Min(a => a.score);
                Console.WriteLine($"Najlepszy: {min}");
                bestSpecimens.Add(childSpecimens.Find(a => a.score ==  min));

                currentPopulation = childSpecimens;
                Console.WriteLine($"Current population size: {currentPopulation.Count()}");
                Console.WriteLine("Koniec populacji");
            }
            return bestSpecimens;
        }



    }
}
