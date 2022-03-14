using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    internal class Factory
    {
        public int[,] Genotype { get; set; }

        public int FactoryDimX { get; set; }
        public int FactoryDimY { get; set; }
        public List<int> Machines { get; set; }

        public bool mutationOccured { get; set; }

        public double score { get; set; }
        public double Fitness
        {
            get
            {
                if (score == 0) return 0d;
                else
                {
                    return 1 / (double)score;
                }

            }
        }

        public int Size
        {
            get { return FactoryDimX * FactoryDimY; }
        }



        public Factory(int[,] genotype, List<int> machines, int factoryDimX, int factoryDimY)
        {
            Genotype = genotype;
            Machines = machines;
            FactoryDimX = factoryDimX;
            FactoryDimY = factoryDimY;
        }

        public override string ToString()
        {
            return $"Fabryka {FactoryDimX} X {FactoryDimY}, funkcja przystosowania: {Fitness}, score: {score}";
        }

    }
}
