using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Selection
{
    internal class TournamentSelection
    {
        private const int TOURNAMENT_BATCH_SIZE = 200;


        public static List<Factory> newPopulation(List<Factory> actPopulation)
        {
            var newPopulation = new List<Factory>();
            Random random = new Random();
            List<Factory> randomChoose = new List<Factory>();

            for (int i = 0; i < actPopulation.Count; i++)
            {
                /*var randomChoose = 
                    actPopulation.OrderBy(arg => Guid.NewGuid()).Take(TOURNAMENT_BATCH_SIZE).ToList();*/


                for (int j = 0; j < TOURNAMENT_BATCH_SIZE; j++)
                {
                    var index = random.Next(0, actPopulation.Count());
                    randomChoose.Add(actPopulation[index]);
                    randomChoose.Sort((f, s) => f.score.CompareTo(s.score));
                }
                newPopulation.Add(randomChoose.First());
                randomChoose.Clear();
            }

            Console.WriteLine("TOURNAMENT SELECTION - DONE!");

            return newPopulation;
        }

  
    }
}
