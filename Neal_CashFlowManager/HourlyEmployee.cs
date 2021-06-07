using System;

namespace Neal_CashFlowManager
{
    class HourlyEmployee : Employee
    {
        private decimal _hourlyWage;
        private int _hoursWorked;
        public HourlyEmployee(string firstName, string lastName, int SSN, 
            decimal hourlyWage, int hoursWorked) : base(firstName, lastName, SSN)
        {
            _hourlyWage = hourlyWage;
            _hoursWorked = hoursWorked;
        }
        public decimal HourlyWage
        {
            get { return _hourlyWage; }
        }
        public int HoursWorked
        {
            get { return _hoursWorked; }
        }
        public override decimal Earnings()
        {
            if (HoursWorked > 40)
            {
                int overtimeHours = HoursWorked - 40;
                decimal earnings = 40 * HourlyWage;
                return earnings += overtimeHours * (HourlyWage * 1.5M);
            }
            else
            {
                return HoursWorked * HourlyWage;
            }
        }
        public override IPayable.LedgerType GetLedgerType()
        {
            return IPayable.LedgerType.Hourly;
        }
        public override string ToString()
        {
            return
                $"Hourly Employee: {FirstName} {LastName}" +
                $"\nSSN: {String.Format("{0:###-##-####}", SSN)}" +
                $"\nHourly Wage Salary: {HourlyWage.ToString("C")}" +
                $"\nHours Worked: {HoursWorked}" +
                $"\nEarned: {Earnings().ToString("C")}";
        }
    }
}
