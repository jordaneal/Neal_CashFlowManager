using Xunit;

namespace Neal_CashFlowManager.Tests
{
    public class HourlyEmployeeTests
    {
        [Fact]
        public void Earnings_NoOvertime_PaysStraightTime()
        {
            var employee = new HourlyEmployee("Jane", "Doe", "123456789", 20M, 40);

            Assert.Equal(800M, employee.Earnings());
        }

        [Fact]
        public void Earnings_WithOvertime_PaysTimeAndAHalfPastForty()
        {
            var employee = new HourlyEmployee("Jane", "Doe", "123456789", 20M, 45);

            // 40 * 20 + 5 * (20 * 1.5) = 800 + 150 = 950
            Assert.Equal(950M, employee.Earnings());
        }

        [Fact]
        public void GetLedgerType_ReturnsHourly()
        {
            var employee = new HourlyEmployee("Jane", "Doe", "123456789", 20M, 40);

            Assert.Equal(IPayable.LedgerType.Hourly, employee.GetLedgerType());
        }
    }
}
