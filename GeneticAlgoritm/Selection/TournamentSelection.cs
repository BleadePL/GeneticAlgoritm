using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Selection
{
    internal class TournamentSelection
    {
        private const int TOURNAMENT_BATCH_SIZE = 5;


        public static List<Factory> newPopulation(List<Factory> actPopulation)
        {
            var newPopulation = new List<Factory>();

            for (int i = 0; i < actPopulation.Count; i++)
            {
                var randomChoose = 
                    actPopulation.OrderBy(arg => Guid.NewGuid()).Take(TOURNAMENT_BATCH_SIZE).ToList();

                //Testing delete later
                randomChoose.ForEach(Console.WriteLine);

                Console.WriteLine();

                newPopulation.Add(randomChoose.OrderByDescending(arg => arg.Fitness).First());
                
                newPopulation.ForEach(Console.WriteLine);

                Console.WriteLine("-----------NEXT------------");
            }

            return newPopulation;
        }

  
    }
}
