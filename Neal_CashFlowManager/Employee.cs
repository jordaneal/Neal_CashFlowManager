namespace Neal_CashFlowManager
{
    abstract class Employee: IPayable
    {
        private string _firstName;
        private string _lastName;
        private string _SSN;
        public Employee(string firstName, string lastName, string SSN)
        {
            _firstName = firstName;
            _lastName = lastName;
            _SSN = SSN;
        }
        public string FirstName
        {
            get { return _firstName; }
        }
        public string LastName
        {
            get { return _lastName; }
        }
        public string SSN
        {
            get { return _SSN; }
        }
        protected string FormattedSSN
        {
            get
            {
                return _SSN.Length == 9
                    ? $"{_SSN.Substring(0, 3)}-{_SSN.Substring(3, 2)}-{_SSN.Substring(5, 4)}"
                    : _SSN;
            }
        }
        public abstract decimal Earnings();
        public abstract IPayable.LedgerType GetLedgerType();
        public decimal GetPayableAmount()
        {
            return Earnings();
        }
    }
}