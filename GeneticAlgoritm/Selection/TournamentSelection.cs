using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Selection
{
    internal class TournamentSelection
    {
        private const int TOURNAMENT_BATCH_SIZE = 100;


        public static List<Factory> newPopulation(List<Factory> actPopulation)
        {
            var newPopulation = new List<Factory>();
            Random random = new Random();
            List<Factory> randomChoose = new List<Factory>();
            var tmpIndex = random.Next(0, actPopulation.Count());
            Factory best = actPopulation[tmpIndex];

            for (int i = 0; i < actPopulation.Count; i++)
            {
                /*var randomChoose = 
                    actPopulation.OrderBy(arg => Guid.NewGuid()).Take(TOURNAMENT_BATCH_SIZE).ToList();*/
                /*

                                for (int j = 0; j < TOURNAMENT_BATCH_SIZE; j++)
                                {
                                    var index = random.Next(0, actPopulation.Count());
                                    randomChoose.Add(actPopulation[index]);
                                    randomChoose.Sort((f, s) => f.score.CompareTo(s.score));
                                }
                                newPopulation.Add(randomChoose.First());
                                randomChoose.Clear();*/
                int actBestScore = int.MaxValue;

                for (int j = 0; j < TOURNAMENT_BATCH_SIZE; j++)
                {
                    var index = random.Next(0, actPopulation.Count());
                    var chosenGen = actPopulation[index];
                    if (actBestScore > chosenGen.score)
                    {
                        actBestScore = chosenGen.score;
                        best = chosenGen;
                    }
                }
                newPopulation.Add(best);

            }

            Console.WriteLine("TOURNAMENT SELECTION - DONE!");

            return newPopulation;
        }

  
    }
}
