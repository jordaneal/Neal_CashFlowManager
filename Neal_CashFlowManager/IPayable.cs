namespace Neal_CashFlowManager
{
    interface IPayable
    {
        public enum LedgerType
        {
            Salaried,
            Hourly,
            Invoice
        }
        decimal GetPayableAmount();
    }
}
