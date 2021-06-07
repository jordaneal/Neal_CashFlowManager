using System;

namespace Neal_CashFlowManager
{
    class Invoice : IPayable
    {
        private string _partNumber;
        private int _quantity;
        private string _partDescription;
        private decimal _price;
        private int _invoiceNumber;

        public Invoice(string partNumber, string partDescription, 
            int quantity, decimal price)
        {
            _partNumber = partNumber;
            _partDescription = partDescription;
            _quantity = quantity;
            _price = price;
            _invoiceNumber = RandomNumber();
        }
        public string PartNumber
        {
            get { return _partNumber; }
        }
        public int Quantity
        {
            get { return _quantity; }
        }
        public string PartDescription
        {
            get { return _partDescription; }
        }
        public decimal Price
        {
            get { return _price; }
        }
        public int InvoiceNumber
        {
            get { return _invoiceNumber; }
        }
        private int RandomNumber()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return random.Next(100000, 999999);
        }
        public decimal GetPayableAmount()
        {
            return Quantity * Price;
        }
        public IPayable.LedgerType GetLedgerType()
        {
            return IPayable.LedgerType.Invoice;
        }
        public override string ToString()
        {
            return
                $"Invoice: {InvoiceNumber}_{PartNumber}" +
                $"\nQuantity: {Quantity}" +
                $"\nPart Description: {PartDescription}" +
                $"\nUnit Price: {Price.ToString("C")}" +
                $"\nExtended Price: {GetPayableAmount().ToString("C")}";
        }
    }
}
