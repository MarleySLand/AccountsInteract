using System.Globalization;
using WithDrawExceptions.Entities;
using WithDrawExceptions.Entities.Exceptions;

namespace WithDrawExceptions
{
    class Program
    {
        static void Main(string[] Args)
        {
            try
            {
                Console.WriteLine("INSTRUCTIONS:");
                Console.WriteLine("> Initial information: Press 'a' to add an account, 's' to interact with an account, 'd' to delete an account, and 'w' to show the accounts list.");
                Console.WriteLine("> Remember: you can't change and remove an account that does not exist, you can't also see the accounts list if it doesn't exist yet.");
                Console.Write("> ");
                char cmnd = char.Parse(Console.ReadLine());

                List<Account> accounts = new List<Account>();
                while (cmnd == 'a' || cmnd == 's' || cmnd == 'd' || cmnd == 'w')
                {
                    if (cmnd == 'a')
                    {
                        Console.WriteLine("Enter account data:");
                        Console.Write("Number: ");
                        int number = int.Parse(Console.ReadLine());
                        Console.Write("Holder: ");
                        string holder = Console.ReadLine();
                        Console.Write("Initial balance: ");
                        double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Withdraw limit: ");
                        double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Deposit limit: ");
                        double depositLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        Account acc = new Account(number, holder, balance, withdrawLimit, depositLimit);
                        accounts.Add(acc);

                        Console.WriteLine();
                        Console.Write("Enter amount for withdraw: ");
                        double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        acc.WithDraw(amount);
                        Console.WriteLine("New balance: " + acc.Balance);
                    } else if (cmnd == 's')
                    {
                        Console.Write("Type the account number: ");
                        int n = int.Parse(Console.ReadLine());
                        Account acc = accounts.Find(x => x.Number == n);
                        Console.WriteLine("Would like to deposit or withdraw?(d/w)");
                        Console.Write("> ");
                        char cmnd2 = char.Parse(Console.ReadLine());
                        switch (cmnd2)
                        {
                            case 'd':
                                Console.Write("Type the amount to deposit: ");
                                double amountD = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                acc.Deposit(amountD);
                                break;
                            case 'w':
                                Console.Write("Type the amount to withdraw: ");
                                double amountW = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                                acc.WithDraw(amountW);
                                break;
                        }
                    }
                }
            } catch(DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

        }
    }
}