using System;
using System.Collections.Generic;

// Jordan Neal
// IT112
// NOTES: Having the UML diagram was a huge help for sure.
// BEHAVIORS NOT IMPLEMENTED AND WHY: N/A

namespace Neal_CashFlowManager
{
    class Program
    {
        static int ReadInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid number, please try again.\n" + prompt);
            }
            return value;
        }

        static decimal ReadDecimal(string prompt)
        {
            decimal value;
            Console.Write(prompt);
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid number, please try again.\n" + prompt);
            }
            return value;
        }

        static void Main(string[] args)
        {
            List<IPayable> payables = new List<IPayable>
            {
                new Invoice("0119", "Tesla Roadster", 1, 200000M),
                new Invoice("5192", "Hyperwave Emissions Enhancement Filter", 13, 649.99M),
                new Invoice("9233", "Null Quantum Field Generator", 50000, 0.01M),
                new HourlyEmployee("Eric", "Cartman", 532502919, 19.92M, 28),
                new HourlyEmployee("Stan", "Marsh", 536092327, 21.23M, 46),
                new HourlyEmployee("Kyle", "Broflovski", 514358637, 18.05M, 42),
                new SalariedEmployee("Anakin", "Skywalker", 514358637, 780.60M),
                new SalariedEmployee("Obi-Wan", "Kenobi", 514358637, 1120.19M),
                new SalariedEmployee("Han", "Solo", 514358637, 975.50M)
            };

            string choice;
            do
            {
                Console.Clear();
                Console.Write(
                    "1: Add Invoice" +
                    "\n2: Add Hourly Employee" +
                    "\n3: Add Salaried Employee" +
                    "\n4: Print Report and Close Program" +
                    "\nSelection: ");
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("\nPart Number: ");
                    string partNumber = Console.ReadLine();
                    Console.Write("Part Description: ");
                    string partDescription = Console.ReadLine();
                    int quantity = ReadInt("Quantity: ");
                    decimal price = ReadDecimal("Price: ");

                    payables.Add(new Invoice(partNumber, partDescription, quantity, price));
                }
                else if (choice == "2")
                {
                    Console.Write("\nFirst Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    int SSN = ReadInt("SSN: ");
                    decimal hourlyWage = ReadDecimal("Hourly Wage: ");
                    int hoursWorked = ReadInt("Hours Worked: ");

                    payables.Add(new HourlyEmployee(firstName, lastName, SSN, hourlyWage, hoursWorked));
                }
                else if (choice == "3")
                {
                    Console.Write("\nFirst Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    int SSN = ReadInt("SSN: ");
                    decimal weeklySalary = ReadDecimal("Weekly Salary: ");

                    payables.Add(new SalariedEmployee(firstName, lastName, SSN, weeklySalary));
                }
                else if (choice == "4")
                {
                    decimal totalPayout = 0;
                    decimal invoiceTotal = 0;
                    decimal salariedTotal = 0;
                    decimal hourlyTotal = 0;

                    Console.Clear();
                    Console.WriteLine("Weekly Cash Flow Analysis is as follows:");

                    foreach (IPayable payable in payables)
                    {
                        Console.WriteLine("\n" + payable.ToString());
                        decimal amount = payable.GetPayableAmount();
                        totalPayout += amount;
                        switch (payable.GetLedgerType())
                        {
                            case IPayable.LedgerType.Invoice:
                                invoiceTotal += amount;
                                break;
                            case IPayable.LedgerType.Salaried:
                                salariedTotal += amount;
                                break;
                            case IPayable.LedgerType.Hourly:
                                hourlyTotal += amount;
                                break;
                        }
                    }
                    Console.Write(
                        $"\nTotal Weekly Payout: {totalPayout.ToString("C")}" +
                        $"\nCategory Breakdown:" +
                        $"\n\tInvoices: {invoiceTotal.ToString("C")}" +
                        $"\n\tSalaried Payroll: {salariedTotal.ToString("C")}" +
                        $"\n\tHourly Payroll: {hourlyTotal.ToString("C")}" +
                        $"\n\nPress any key to close application...");
                    Console.ReadKey();
                }
            } while (choice != "4");
        }
    }
}
