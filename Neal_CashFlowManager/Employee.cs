namespace Neal_CashFlowManager
{
    class Employee: IPayable
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
        public virtual decimal Earnings()
        {
            throw new System.NotImplementedException();
        }
        public virtual IPayable.LedgerType GetLedgerType()
        {
            throw new System.NotImplementedException();
        }
        public decimal GetPayableAmount()
        {
            return Earnings();
        }
    }
}
