using System;

// Jordan Neal
// IT112 
// NOTES: Having the UML diagram was a huge help for sure.
// BEHAVIORS NOT IMPLEMENTED AND WHY: N/A

namespace Neal_CashFlowManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IPayable[] payables = new IPayable[20];
            payables[0] = new Invoice("0119", "Tesla Roadster", 1, 200000M);
            payables[1] = new Invoice("5192", "Hyperwave Emissions Enhancement Filter", 13, 649.99M);
            payables[2] = new Invoice("9233", "Null Quantum Field Generator", 50000, 0.01M);
            payables[3] = new HourlyEmployee("Eric", "Cartman", 532502919, 19.92M, 28);
            payables[4] = new HourlyEmployee("Stan", "Marsh", 536092327, 21.23M, 46);
            payables[5] = new HourlyEmployee("Kyle", "Broflovski", 514358637, 18.05M, 42);
            payables[6] = new SalariedEmployee("Anakin", "Skywalker", 514358637, 780.60M);
            payables[7] = new SalariedEmployee("Obi-Wan", "Kenobi", 514358637, 1120.19M);
            payables[8] = new SalariedEmployee("Han", "Solo", 514358637, 975.50M);
            
            int arrayLocation = 9;
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
                    Console.Write("Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    payables[arrayLocation] = new Invoice(
                        partNumber, partDescription, quantity, price);
                    arrayLocation++;
                }
                else if (choice == "2")
                {
                    Console.Write("\nFirst Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("SSN: ");
                    int SSN = int.Parse(Console.ReadLine());
                    Console.Write("Hourly Wage: ");
                    decimal hourlyWage = decimal.Parse(Console.ReadLine());
                    Console.Write("Hours Worked: ");
                    int hoursWorked = int.Parse(Console.ReadLine());

                    payables[arrayLocation] = new HourlyEmployee(
                        firstName, lastName, SSN, hourlyWage, hoursWorked);
                    arrayLocation++;
                }
                else if (choice == "3")
                {
                    Console.Write("\nFirst Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("SSN: ");
                    int SSN = int.Parse(Console.ReadLine());
                    Console.Write("Weekly Salary: ");
                    decimal weeklySalary = decimal.Parse(Console.ReadLine());

                    payables[arrayLocation] = new SalariedEmployee(firstName, lastName, SSN, weeklySalary);
                    arrayLocation++;
                }
                else if (choice == "4")
                {
                    decimal totalPayout = 0;
                    decimal invoiceTotal = 0;
                    decimal salariedTotal = 0;
                    decimal hourlyTotal = 0;

                    Console.Clear();
                    Console.WriteLine("Weekly Cash Flow Analysis is as follows:");

                    for (int i = 0; payables[i] != null; i++)
                    {
                        Console.WriteLine("\n" + payables[i].ToString());
                        totalPayout += payables[i].GetPayableAmount();
                        if (payables[i].GetLedgerType() == IPayable.LedgerType.Invoice)
                        {
                            invoiceTotal += payables[i].GetPayableAmount();
                        }
                        else if (payables[i].GetLedgerType() == IPayable.LedgerType.Salaried)
                        {
                            salariedTotal += payables[i].GetPayableAmount();
                        }
                        else if (payables[i].GetLedgerType() == IPayable.LedgerType.Hourly)
                        {
                            hourlyTotal += payables[i].GetPayableAmount();
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
