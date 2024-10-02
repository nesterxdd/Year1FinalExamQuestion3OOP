/* ---------------------------------------------------------------------------
    Student code (VIDKO): E4886
    Module code: P175B118
-----------------------------------------------------------------------------*/

using System;
using System.IO;

namespace Question3
{
    /// <summary>
    /// 2D container class
    /// </summary>
    class Water
    {
        public const int Cn = 100;    // maximum number of rows (flats)
        private int[,] W;             // water values (2D array)
                                      // Auto-property

        public int N { get; private set; }    // N: actual number of rows (flats)

        // TODO: implement constructor in 2D container
        public Water(int N = 0)
        {
            W = new int[Cn, Cn];
            this.N = N;
        }
        // TODO: implement indexer in 2D container 
        public int this[int i, int j]
        {
            get
            {
                return W[i, j];
            }
            set
            {
                W[i, j] = value;
            }
        }

    }

    class Program
    {
        const string CFd = "Data.txt";

        static void Main(string[] args)
        {
            
            Water w = new Water();
            w = Read(CFd);
            // Display initial data of water consumption by residents (2D container)
            Print("123", w);
           

            // Display first flat with least water consumption in first half year to console
            int minFlat = FirstFlatOfMinimumConsumption(w, out int minConsumption);
            Console.WriteLine("Flat that has least water consumption in first half year is {0}", minFlat + 1);

            // Display water consumption value for such flat to console
            Console.WriteLine("Its consumption is {0}", minConsumption);

        }

        // Reads initial data from file fv to 2D container of water consumption by residents
        // TODO: implement method by the given header
        // Complete functionality by adding required code (TODO)
        static Water Read(string fv)
        {
            using (StreamReader reader = new StreamReader(fv))
            {
                int number;
                string line = reader.ReadLine();
                char[] delimiters = { ' ' };
                string[] numbers = line.Split(delimiters,
                                      StringSplitOptions.RemoveEmptyEntries);
                int n = int.Parse(numbers[0]);
                // TODO: allocate memory for 2D container
                Water water = new Water(n);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    numbers = line.Split(delimiters,
                                      StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < 12; j++)
                    {
                        number = int.Parse(numbers[j]);
                        // TODO: add element to 2D container
                        water[i, j] = number;
                    }
                }
                // TODO: implement method return value
                return water;
            }
        }

        // Prints contents of 2D container W to console;
        // note - label above 2D container data
        // TODO: implement method by the given header
        // Complete functionality by adding required code (TODO)
        static void Print(string note, Water W)
        {
            Console.WriteLine(note);
            const string header = "----------------------------------------------------\n" +
                                  " No.      Water consumption (12 months)              \n" +
                                  "----------------------------------------------------";
            // Header
            Console.WriteLine(header);

            // TODO: Print contents of W: 2D container - matrix
            // (adapt display format as provided in header above)
            Console.Write("  ");
            for (int k = 0; k < 12; k++)
            {
                Console.Write("{0,3} ", k + 1);
            }
            Console.WriteLine();
            for (int i = 0; i < W.N; i++)
            {
                Console.Write("{0}|", i + 1);
                for (int j = 0; j < 12; j++)
                {
                    Console.Write("{0,3} ", W[i, j]);
                }
                Console.WriteLine();
            }

            // Footer
            Console.WriteLine("----------------------------------------------------");
        }

        // TODO: implement method by the given header
        // Calculates and returns total consumption of water in first half of year for indicated flat k
        static int WaterConsumptionForFlatInHalfYear(Water W, int k)
        {
            int sum = 0;
            for (int j = 0; j < 6; j++)
            {
                sum += W[k, j];
            }
            return sum;
        }

        // TODO: implement method by the given header
        // Finds and returns the first flat with least consumption of water in first half of year 
        // and how much water (minConsumption) was consumed by such flat 
        static int FirstFlatOfMinimumConsumption(Water W, out int minConsumption)
        {
            minConsumption = WaterConsumptionForFlatInHalfYear(W,0);
            int minInd = -1;
            for (int i = 1; i < 6; i++)
            {
                
                    if (WaterConsumptionForFlatInHalfYear(W, i) < minConsumption)
                    {
                        minConsumption = WaterConsumptionForFlatInHalfYear(W, i);
                        minInd = i;
                    }
                
            }
            return minInd;
            
        }

    }
}
