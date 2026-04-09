using System;
using System.Collections.Generic;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Program
{
    //I improved my banking app by introducing object-oriented design with a BankAccount class
    //and added file handling to persist balance and transaction history between sessions.

    //I moved from basic logic to OOP (classes, encapsulation)
    //Also I added real data persistence(file storage)

    static void Main()
    {
        BankAccount account = new BankAccount("pete");


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to banking app v2");
            Console.WriteLine("1.Balance \n2. Deposit\n3. Withdraw\n4. History\n5. Exit");
            Console.WriteLine("Choose an option");
            string option = Console.ReadLine();

            try
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine($"Balance: {account.Balance}");
                        break;
                    case "2":
                        Console.WriteLine("Amount?");
                        decimal deposit = Convert.ToDecimal(Console.ReadLine());
                        if (account.Deposit(deposit))
                        {
                            Console.WriteLine("Deposit successful");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Amount?");
                        decimal withdraw = Convert.ToDecimal(Console.ReadLine());
                        if (account.Withdraw(withdraw))
                        {
                            Console.WriteLine("Withdrawel successful");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount");
                        }

                        break;
                    case "4":
                        Console.WriteLine("Transaction History:");
                        account.ShowHistory();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Invalid input");
                Console.ReadKey();
            }

        }
    }
}


