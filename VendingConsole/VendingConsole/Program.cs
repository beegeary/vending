using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VendingConsole
{
    class Vending
    {
        const double Penny = 2.5;
        const double Nickel = 5;
        const double Dime = 2.268;
        const double Quarter = 5.67;

        public static void Main()
        {
            VendingMachine.Run();
        }

    }
    public static class VendingMachine
    {
        public static void Run()
        {

            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            BalanceSheet scoring = new BalanceSheet();

            do
            {
                Console.WriteLine();

                Console.WriteLine("VENDING MACHINE", cki.Key);

                Console.WriteLine();

                Console.WriteLine("(3) cola $1.00  PRESS 1", cki.Key);

                Console.WriteLine("(3) chips $0.50  PRESS 2", cki.Key);

                Console.WriteLine("(3) candy $0.65  PRESS 3", cki.Key);

                Console.WriteLine("", cki.Key);

                Console.WriteLine("INSERT COIN / AMT. INSERTED", cki.Key);

                Console.WriteLine("**EXACT CHANGE ONLY**", cki.Key);

                Console.WriteLine();

                Console.WriteLine("Press 'n' for insert Nickel", cki.Key);

                Console.WriteLine("Press 'd' for insert Dime", cki.Key);

                Console.WriteLine("Press 'q' for insert Quarter", cki.Key);

                Console.WriteLine("Press 'p' for insert Penny", cki.Key);

                Console.WriteLine();

                Console.WriteLine("Press 'x' to Exit", cki.Key);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                while (Console.KeyAvailable == false)

                    Thread.Sleep(250);
                cki = Console.ReadKey(true);

                //if (cki.Key == ConsoleKey.D1)
                //{
                //    scoring.AddOne();
                //    Console.Clear();

                //    if (scoring.OneScore == 5 | scoring.TwoScore == 5)
                //    {
                //        break;
                //    }
                //    Console.WriteLine("\nScore is Player One: {0}, Player Two: {1}", Convert(scoring.OneScore), Convert(scoring.TwoScore));
                //}

                //if (cki.Key == ConsoleKey.D2)
                //{
                //    scoring.AddTwo();
                //    Console.Clear();

                //    if (scoring.OneScore == 5 | scoring.TwoScore == 5)
                //    {
                //        break;
                //    }
                //    Console.WriteLine("\nScore is Player One: {0}, Player Two: {1}", Convert(scoring.OneScore), Convert(scoring.TwoScore));
                //}

            } while (cki.Key != ConsoleKey.X);

        }

            public static double InsertCoin()
            {
                return 0;
            }

            public static decimal ConvertCoin(double weight)
            {
                if (weight == 5)  //Nickel
                {
                    return .05M;
                }
                else if (weight == 2.268)  //Dime
                {
                    return .1M;
                }
                else if (weight == 5.67)  //Quarter
                {
                    return .25M;
                }
                else
                {
                    return 0;
                }
            }
    }

    class BalanceSheet
    {
        decimal CashBalance;
        int CandyInventory;
        int ColaInventory;
        int ChipsInventory;
    }

}

