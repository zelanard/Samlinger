using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinosBlancos
{
    internal class VinosBlancos
    {
        public const int MAX = 175388;
        public const byte MAX_STAR = 100;
        public const int YEAR = 0;
        public const int SALE = 1;
        static void Main(string[] args)
        {
            Execute();
        }

        #region Model
        static int[] GetStars(bool sort, int type, int year = 0, int modification = 0)
        {
            int[,] wineSale = new int[11, 2] {
                {2009,175134},
                {2010,175388},
                {2011,172818},
                {2012,142709},
                {2013,151437},
                {2014,152620},
                {2015,150979},
                {2016,152210},
                {2017,149450},
                {2018,154398},
                {2019,150160}
            };
            int[] years = new int[11];
            int[] sales = new int[11];

            //Correct Error for 2014
            for (int i = 0; i < wineSale.GetLength(0); i++)
            {
                if (wineSale[i, 0] == year)
                {
                    wineSale[i, 0] += modification;
                }
            }

            for (int i = 0; i < wineSale.GetLength(0); i++)
            {
                years[i] = wineSale[i, 0];
                sales[i] = wineSale[i, 1];
            }

            if (sort)
            {
                Array.Sort(sales);
                Array.Reverse(sales);
                for (int i = 0; i < years.Length; i++)
                {
                    for (int j = 0; j < years.Length; j++)
                    {
                        if (sales[j] == wineSale[i, 1])
                        {
                            years[j] = wineSale[i, 0];
                        }
                    }
                }
            }

            switch (type)
            {
                case YEAR:
                    {
                        return years;
                    }
                case SALE:
                    {
                        return sales;
                    }
                default:
                    return null;
            }

        }
        static int Stars(int input)
        {
            return MAX_STAR * input / MAX;
        }

        #endregion

        #region Controller
        private static void Execute()
        {
            while (true)
            {
                InitGUI();
                bool sort = true;
                int[] sales = GetStars(sort, SALE);
                int[] years = GetStars(sort, YEAR);

                for (int i = 0; i < sales.GetLength(0); i++)
                {
                    Print("Year: " + years[i] + ": ");
                    PrintStars(Stars(sales[i]));
                    TerminateLine();
                }
                Console.ReadKey();
            }
        }

        #endregion

        #region View
        private static void InitGUI()
        {
            Console.Clear();
            Console.WriteLine(
                "----------------------------------------------------------------------------------------------------------------\r\n" +
                "                                        Danmarks Statestik for vin salg:\r\n" +
                "----------------------------------------------------------------------------------------------------------------\r\n");
        }
        private static void TerminateLine()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Print(object input)
        {
            Console.Write(input);
        }
        static void PrintStars(int stars)
        {
            for (int i = 0; i < stars; i++)
            {
                if (i < 25)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (i < 50)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (i < 75)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Print("*");
            }
        }

        #endregion
    }
}
