using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Mutation
{
    internal class BinaryBitFlip
    {
        private static Random random = new Random();
        private const double PROPABILITY_MUTATION = 0.2;

        public static void mutation(ref List<Factory> population)
        {
            population.ForEach(x => mutateSingleGrid(ref x));

            Console.WriteLine("MUTATION - DONE");
        }

        private static void mutateSingleGrid(ref Factory grid)
        {
            for (int i = 0; i < grid.FactoryDimX; i++)
            {
                for (int j = 0; j < grid.FactoryDimY; j++)
                {
                    if (random.Next() > PROPABILITY_MUTATION)
                    {
                        var coordinates = mutateSingleGene(grid.FactoryDimX, grid.FactoryDimY);

                        int prevIndex = grid.Genotype[coordinates.Item1, coordinates.Item2];
                        grid.Genotype[coordinates.Item1, coordinates.Item2] = grid.Genotype[i, j];
                        grid.Genotype[i, j] = prevIndex;
                        grid.mutationOccured = true;
                    }

                }
            }
        }

        private static (int, int) mutateSingleGene(int x, int y)
        {
            int xNew, yNew;

            xNew = random.Next(0, x);
            yNew = random.Next(0, y);

            return (xNew, yNew);
        }


    }
}
