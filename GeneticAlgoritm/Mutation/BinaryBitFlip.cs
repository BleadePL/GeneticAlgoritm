using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Mutation
{
    internal class BinaryBitFlip
    {
        private const double PROPABILITY_MUTATION = 0.005;

        public static void mutation(ref List<Factory> population, List<ConnectionCost> connectionCosts, List<ConnectionFlow> connectionFlow)
        {
            population.ForEach(x => mutateSingleGrid(ref x, connectionCosts, connectionFlow));

            Console.WriteLine("MUTATION - DONE");
        }

        private static void mutateSingleGrid(ref Factory grid, List<ConnectionCost> connectionCosts,  List<ConnectionFlow> connectionFlow)
        {
            Random random = new Random();
            for (int i = 0; i < grid.FactoryDimX; i++)
            {
                for (int j = 0; j < grid.FactoryDimY; j++)
                {
                    var tmp = random.NextDouble();
                    if (tmp < PROPABILITY_MUTATION)
                    {
                        var coordinates = mutateSingleGene(grid.FactoryDimX, grid.FactoryDimY);

                        int prevIndex = grid.Genotype[coordinates.Item1, coordinates.Item2];
                        grid.Genotype[coordinates.Item1, coordinates.Item2] = grid.Genotype[i, j];
                        grid.Genotype[i, j] = prevIndex;
                        grid.mutationOccured = true;
                    }

                }
            }
            if (grid.mutationOccured)
            {
                GenotypeCreation.fitnessFunction(connectionCosts, connectionFlow, ref grid);
            }

        }

        private static (int, int) mutateSingleGene(int x, int y)
        {
            Random random = new Random();
            int xNew, yNew;

            xNew = random.Next(0, x);
            yNew = random.Next(0, y);

            return (xNew, yNew);
        }


    }
}
