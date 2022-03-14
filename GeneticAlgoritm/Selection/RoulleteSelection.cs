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

            Console.WriteLine(actPopulation.Sum(f => f.score));

            double fitnessSum = actPopulation.Sum(f => f.score);

            double accum = 0.0d;

            foreach (var elem in actPopulation)
            {
                double tmp = (double)elem.score / (double)fitnessSum;
                probabilityValues.Add((double)tmp + accum, elem.GetHashCode());
                accum += tmp;
            }

            double pointLoss;

            for (int i = 0; i < actPopulation.Count; i++)
            {
                pointLoss = random.NextDouble();

                var chosen = probabilityValues.Keys.Where(k => k >= pointLoss).First();
                newPopulation.Add(
                    actPopulation.Find(f => f.GetHashCode() == probabilityValues[chosen])
                    );
            }


            newPopulation.ForEach(Console.WriteLine);

            return newPopulation;
        }




    }
}
