using CreditSuisse.IT.ConsoleApp.Consts;
using CreditSuisse.IT.ConsoleApp.Repository;

namespace CreditSuisse.IT.Tests
{
    public class UnitTests
    {

        [Fact]
        public void TradeHightRisk()
        {
            DateTime referenceDate = new DateTime(2020, 12, 11);

            string clientSector = ClientConsts.Private;

            double value = 2000000;

            DateTime nextPaymentDate = new DateTime(2025, 12, 29);

            TradeRepository tradeRepository = new();
            tradeRepository.SendTrade(value, clientSector, nextPaymentDate, referenceDate);

            var result = tradeRepository.GetCategory().ToArray();

            Assert.Equal(CategoryConsts.High, result[0]);
        }

        [Fact]
        public void Trade30Days()
        {
            DateTime referenceDate = new DateTime(2020, 12, 11);

            string clientSector = ClientConsts.Public;

            double value = 400000;

            DateTime nextPaymentDate = new DateTime(2020, 07, 01);

            TradeRepository tradeRepository = new();
            tradeRepository.SendTrade(value, clientSector, nextPaymentDate, referenceDate);

            var result = tradeRepository.GetCategory().ToArray();

            Assert.Equal(CategoryConsts.Expired, result[0]);
        }

        [Fact]
        public void TradeMediumRisk()
        {
            DateTime referenceDate = new DateTime(2020, 12, 11);

            string clientSector = ClientConsts.Public;

            double value = 5000000;

            DateTime nextPaymentDate = new DateTime(2024, 01, 02);

            TradeRepository tradeRepository = new();
            tradeRepository.SendTrade(value, clientSector, nextPaymentDate, referenceDate);

            var result = tradeRepository.GetCategory().ToArray();

            Assert.Equal(CategoryConsts.Medium, result[0]);
        }

        [Fact]
        public void TradeAnotherMediumRisk()
        {
            DateTime referenceDate = new DateTime(2020, 12, 11);

            string clientSector = ClientConsts.Public;

            double value = 3000000;

            DateTime nextPaymentDate = new DateTime(2023, 10, 26);

            TradeRepository tradeRepository = new();
            tradeRepository.SendTrade(value, clientSector, nextPaymentDate, referenceDate);

            var result = tradeRepository.GetCategory().ToArray();

            Assert.Equal(CategoryConsts.Medium, result[0]);
        }
    }
}