using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm.Crossover
{
    internal class SinglePointCrossover
    {
        public static Random random = new Random();
        public static (Factory, Factory) cross(Factory parent1, Factory parent2, List<ConnectionCost> connectionCosts, List<ConnectionFlow> connectionFlow)
        {
            List<int> flatGridP1;
            List<int> flatGridP2;

            Dictionary<int, int> used = new Dictionary<int, int>();
            Dictionary<int, int> usedReversed = new Dictionary<int, int>();

            int size = parent1.Size;
            int cut_point = random.Next(0, size);

            transformGrid1D(ref parent1, out flatGridP1);
            transformGrid1D(ref parent2, out flatGridP2);

            int oldGen, newGen;

            for (int i = 0; i < cut_point; i++)
            {
                oldGen = flatGridP1[i];
                newGen = flatGridP2[i];

                if (newGen != oldGen)
                {
                    if (!used.ContainsKey(oldGen) && !usedReversed.ContainsKey(newGen))
                    {
                        used[newGen] = oldGen;
                        usedReversed[oldGen] = newGen;
                    }
                    else if (usedReversed.ContainsKey(newGen) && used.ContainsKey(oldGen))
                    {
                        used[usedReversed[newGen]] = used[oldGen];
                        usedReversed[used[oldGen]] = usedReversed[newGen];
                        used.Remove(oldGen);
                        usedReversed.Remove(newGen);
                    }
                    else if (usedReversed.ContainsKey(newGen))
                    {
                        usedReversed[oldGen] = usedReversed[newGen];
                        used[usedReversed[newGen]] = oldGen;
                        usedReversed.Remove(newGen);
                    }
                    else
                    {
                        used[newGen] = used[oldGen];
                        usedReversed[used[newGen]] = newGen;
                        used.Remove(oldGen);
                    }

                    flatGridP1[i] = newGen;
                    flatGridP2[i] = oldGen;

                }
            }

            for (int i = cut_point; i < size; i++)
            {
                int firstGen = flatGridP1[i];

                if (used.ContainsKey(firstGen))
                {
                    flatGridP1[i] = used[firstGen];
                }

                int secondGen = flatGridP2[i];
                if (usedReversed.ContainsKey(secondGen))
                {
                    flatGridP2[i] = usedReversed[secondGen];
                }

            }

            Factory child;
            Factory childReverse;

            transformGrid2D(out child, ref flatGridP1, parent1.FactoryDimX, parent1.FactoryDimY, parent1.Machines);
            transformGrid2D(out childReverse, ref flatGridP2, parent1.FactoryDimX, parent1.FactoryDimY, parent1.Machines);

            GenotypeCreation.fitnessFunction(connectionCosts, connectionFlow, ref child);
            GenotypeCreation.fitnessFunction(connectionCosts, connectionFlow, ref childReverse);

            return (child, childReverse);
        }


        private static void transformGrid1D(ref Factory f, out List<int> flatGrid)
        {
            flatGrid = new List<int>();

            for (int i = 0; i < f.FactoryDimX; i++)
            {
                for (int j = 0; j < f.FactoryDimY; j++)
                {
                    flatGrid.Add(f.Genotype[i, j]);
                }
            }
        }

        private static void transformGrid2D(out Factory f, ref List<int> flatGrid, int x, int y , List<int> machines)
        {
            int[,] grid = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    grid[i, j] = flatGrid[0];
                    flatGrid.RemoveAt(0);
                }
            }

            f = new Factory(grid, machines, x, y);
        }

    }
}
