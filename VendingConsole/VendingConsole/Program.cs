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
        public static void Main()
        {
            VendingMachine vend = new VendingMachine();
            vend.Run();
        }

    }
    public class VendingMachine
    {
        BalanceSheet bal = new BalanceSheet();
        const double Penny = 2.5;
        const double Nickel = 5;
        const double Dime = 2.268;
        const double Quarter = 5.67;
        public string colaInv;

        public void Run()
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            do
            {
                Console.WriteLine();

                Console.WriteLine("VENDING MACHINE", cki.Key);

                Console.WriteLine();

                Console.WriteLine("({0}) cola $1.00  PRESS 1", bal.ColaInvString);

                Console.WriteLine("(3) chips $0.50  PRESS 2", cki.Key);

                Console.WriteLine("(3) candy $0.65  PRESS 3", cki.Key);

                Console.WriteLine("", cki.Key);

                Console.WriteLine("INSERT COIN / AMT. INSERTED {0}", bal.Inserted);

                if (bal.CashBalance > .10M)
                {
                Console.WriteLine("**EXACT CHANGE ONLY**");
                }

                if (bal.Change > 0)
                {
                Console.WriteLine("CHANGE RETURNED: {0}", bal.Change);
                bal.Change = 0;
                }

                Console.WriteLine();

                Console.WriteLine("Press 'n' for insert Nickel", cki.Key);

                Console.WriteLine("Press 'd' for insert Dime", cki.Key);

                Console.WriteLine("Press 'q' for insert Quarter", cki.Key);

                Console.WriteLine("Press 'p' for insert Penny", cki.Key);

                Console.WriteLine();

                Console.WriteLine("Press 'r' to return change", cki.Key);

                Console.WriteLine();

                Console.WriteLine("Press 'x' to Exit", cki.Key);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                while (Console.KeyAvailable == false)

                    Thread.Sleep(250);
                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.X)
                {
                    System.Environment.Exit(0);
                }

                else if (cki.Key == ConsoleKey.N)
                {
                    bal.AddChangeToInserted(ConvertCoin(Nickel));
                    Console.Clear();
                    Run();

                }
                else if (cki.Key == ConsoleKey.D1)
                {
                    bal.SelectItem(1);
                    Console.Clear();
                    //cki.Key.Equals(null);
                    Run();
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    bal.SelectItem(2);
                    Console.Clear();
                    Run();
                }
                else if (cki.Key == ConsoleKey.D3)
                {
                    bal.SelectItem(0);
                    Console.Clear();
                    Run();
                }
                else if (cki.Key == ConsoleKey.R)
                {
                    bal.SelectItem(0);
                    Console.Clear();
                    Run();
                }

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

    public class BalanceSheet
    {
        public decimal Inserted;
        public decimal Change;
        public decimal CashBalance;
        public int CandyInventory = 2;
        public int ColaInventory = 2;
        public int ChipsInventory = 2;
        string soldOut = "EMPTY";


        public string ColaInvString
        {
            get { return ColaInventory > 0 ? ColaInventory.ToString() : soldOut; }
        }

        public bool CanMakeChange
        {
            get { return CashBalance > .05M ? true : false; }
        }

        public void SelectItem(int selection)
        {
            switch (selection)
            {
                case 0:
                    if (Inserted >= .65M)
                    {
                        CandyInventory -= 1;
                        Inserted -= .65M;
                        Change = Inserted - .65M;
                    }
                    break;
                case 1:
                    if (Inserted >= 1)
                    {
                        ColaInventory -= 1;
                        Inserted -= 1;
                        Change = Inserted - 1;
                    }
                    break;
                case 2:
                    if (Inserted >= .5M)
                    {
                        ChipsInventory -= 1;
                        Inserted -= .5M;
                        Change = Inserted - .5M;
                    }
                    break;
                default:
                    break;
            }
        }


        public void AddChangeToInserted(decimal coinVal)
        {

            Inserted += coinVal;

        }

        public void ClearInserted()
        {

            Inserted = 0;

        }
    }

}

