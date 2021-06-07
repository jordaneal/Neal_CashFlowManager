using System;

namespace Neal_CashFlowManager
{
    class SalariedEmployee : Employee
    {
        private decimal _weeklySalary;
        public decimal WeeklySalary
        {
            get { return _weeklySalary; }
        }
        public SalariedEmployee(string firstName, string lastName, int SSN, 
            decimal weeklySalary) : base(firstName, lastName, SSN)
        {
            _weeklySalary = weeklySalary;
        }
        public override decimal Earnings()
        {
            return WeeklySalary;
        }
        public override IPayable.LedgerType GetLedgerType()
        {
            return IPayable.LedgerType.Salaried;
        }
        public override string ToString()
        {
            return
                $"Salaried Employee: {FirstName} {LastName}" +
                $"\nSSN: {String.Format("{0:###-##-####}", SSN)}" +
                $"\nWeekly Salary: {WeeklySalary.ToString("C")}" +
                $"\nEarned: {WeeklySalary.ToString("C")}";
        }
    }
}
