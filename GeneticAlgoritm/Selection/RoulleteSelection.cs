using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Selection
{
    internal class RoulleteSelection
    {
        public static Dictionary<double, int> probabilityValues = new Dictionary<double, int>();
        public static Random random = new Random();

        public static List<Factory> newPopulation(List<Factory> actPopulation)
        {
            var newPopulation = new List<Factory>();


            double fitnessSum = actPopulation.Sum(f => f.Fitness);

            double accum = 0.0d;

            foreach (var elem in actPopulation)
            {
                double tmp = (double)elem.Fitness / (double)fitnessSum;
                accum += tmp;
                probabilityValues.Add(accum, elem.GetHashCode());
            }

            double chosenPoint;

            for (int i = 0; i < actPopulation.Count; i++)
            {
                chosenPoint = random.NextDouble();

                var chosen = probabilityValues.Keys.Where(k => k >= chosenPoint).First();
                newPopulation.Add(
                    actPopulation.Find(f => f.GetHashCode() == probabilityValues[chosen])
                    );
            }

            return newPopulation;
        }
    }
}
