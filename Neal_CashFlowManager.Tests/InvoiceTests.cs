using Xunit;

namespace Neal_CashFlowManager.Tests
{
    public class InvoiceTests
    {
        [Fact]
        public void GetPayableAmount_ReturnsQuantityTimesPrice()
        {
            var invoice = new Invoice("0001", "Widget", 3, 9.99M);

            Assert.Equal(29.97M, invoice.GetPayableAmount());
        }

        [Fact]
        public void GetLedgerType_ReturnsInvoice()
        {
            var invoice = new Invoice("0001", "Widget", 3, 9.99M);

            Assert.Equal(IPayable.LedgerType.Invoice, invoice.GetLedgerType());
        }
    }
}
