namespace Neal_CashFlowManager
{
    abstract class Employee: IPayable
    {
        private string _firstName;
        private string _lastName;
        private int _SSN;
        public Employee(string firstName, string lastName, int SSN)
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
        public int SSN
        {
            get { return _SSN; }
        }
        public abstract decimal Earnings();
        public abstract IPayable.LedgerType GetLedgerType();
        public decimal GetPayableAmount()
        {
            return Earnings();
        }
    }
}