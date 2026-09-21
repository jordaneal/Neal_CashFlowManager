using Xunit;

namespace Neal_CashFlowManager.Tests
{
    public class SalariedEmployeeTests
    {
        [Fact]
        public void Earnings_ReturnsWeeklySalary()
        {
            var employee = new SalariedEmployee("Jane", "Doe", "123456789", 1000M);

            Assert.Equal(1000M, employee.Earnings());
        }

        [Fact]
        public void GetLedgerType_ReturnsSalaried()
        {
            var employee = new SalariedEmployee("Jane", "Doe", "123456789", 1000M);

            Assert.Equal(IPayable.LedgerType.Salaried, employee.GetLedgerType());
        }
    }
}
