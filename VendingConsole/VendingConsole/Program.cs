using System;
using System.Threading;

namespace VendingConsole
{

    class Vending
    {
        public static void Main()
        {
            /* loads a VendingMachine to do the mechanics,
             * which in turn loads a BalanceSheet
             * holding product and money levels
             */
            VendingMachine vend = new VendingMachine();
            vend.Run();
        }
    }

    public class VendingMachine
    {
        const double Penny = 2.5;
        const double Nickel = 5;
        const double Dime = 2.268;
        const double Quarter = 5.67;

        BalanceSheet bal = new BalanceSheet();

        public void Run()
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            do
            {
                Console.WriteLine();

                Console.WriteLine("VENDING MACHINE");

                Console.WriteLine();

                Console.WriteLine("({0}) cola $1.00  PRESS 1", bal.ColaInvString);

                Console.WriteLine("({0}) chips $0.50  PRESS 2", bal.ChipsInvString);

                Console.WriteLine("({0}) candy $0.65  PRESS 3", bal.CandyInvString);

                Console.WriteLine();

                if (bal.Change > 0)
                {
                    Console.WriteLine("CHANGE RETURNED: {0}", bal.Change);
                    bal.Change = 0;
                    Console.WriteLine("");
                }

                if (bal.Inserted == 0)
                {
                    Console.WriteLine("INSERT COIN");
                }
                else
                {
                    Console.WriteLine("AMT. INSERTED: {0:C}", Convert.ToSingle(bal.Inserted));
                }

                if (bal.CashBalance < .10M)
                {
                    Console.WriteLine("**EXACT CHANGE ONLY**");
                }

                Console.WriteLine();

                Console.WriteLine("Press 'n' for insert Nickel");

                Console.WriteLine("Press 'd' for insert Dime");

                Console.WriteLine("Press 'q' for insert Quarter");

                Console.WriteLine("Press 'p' for insert Penny");

                Console.WriteLine();

                Console.WriteLine("Press 'r' to return change");

                Console.WriteLine();

                Console.WriteLine("Press 'x' to Exit");

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

                else if (cki.Key == ConsoleKey.P)
                {
                    bal.AddChangeToInserted(ConvertCoin(Penny));
                    Console.Clear();
                    Run();

                }
                else if (cki.Key == ConsoleKey.N)
                {
                    bal.AddChangeToInserted(ConvertCoin(Nickel));
                    Console.Clear();
                    Run();

                }
                else if (cki.Key == ConsoleKey.D)
                {
                    bal.AddChangeToInserted(ConvertCoin(Dime));
                    Console.Clear();
                    Run();

                }
                else if (cki.Key == ConsoleKey.Q)
                {
                    bal.AddChangeToInserted(ConvertCoin(Quarter));
                    Console.Clear();
                    Run();

                }
                else if (cki.Key == ConsoleKey.D1)  //Cola
                {
                    bal.SelectItem(1);
                    Console.Clear();
                    //cki.Key.Equals(null);
                    Run();
                }
                else if (cki.Key == ConsoleKey.D2)  //Chips
                {
                    bal.SelectItem(2);
                    Console.Clear();
                    Run();
                }
                else if (cki.Key == ConsoleKey.D3)  //Candy
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

        static int SetProductInventories = 2;
        public int CandyInventory = SetProductInventories;
        public int ColaInventory = SetProductInventories;
        public int ChipsInventory = SetProductInventories;

        static string soldOut = "SOLD OUT";

        private decimal CandyPrice = .65M;
        private decimal ChipsPrice = .5M;
        private decimal ColaPrice = 1;


        public string ColaInvString
        {
            get { return ColaInventory > 0 ? ColaInventory.ToString() : soldOut; }
        }

        public string CandyInvString
        {
            get { return CandyInventory > 0 ? CandyInventory.ToString() : soldOut; }
        }

        public string ChipsInvString
        {
            get { return ChipsInventory > 0 ? ChipsInventory.ToString() : soldOut; }
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
                    if (Inserted >= CandyPrice && CandyInventory > 0)
                    {
                        Change = 0;
                        CandyInventory--;
                        Change = Inserted - CandyPrice;
                        ClearInserted();
                        CashBalance += CandyPrice;
                    }
                    break;
                case 1:
                    if (Inserted >= ColaPrice && ColaInventory > 0)
                    {
                        Change = 0;
                        ColaInventory--;
                        Change = Inserted - ColaPrice;
                        ClearInserted();
                        CashBalance += ColaPrice;
                    }
                    break;
                case 2:
                    if (Inserted >= ChipsPrice && ChipsInventory > 0)
                    {
                        Change = 0;
                        ChipsInventory--;
                        Change = Inserted - ChipsPrice;
                        ClearInserted();
                        CashBalance += ChipsPrice;

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

