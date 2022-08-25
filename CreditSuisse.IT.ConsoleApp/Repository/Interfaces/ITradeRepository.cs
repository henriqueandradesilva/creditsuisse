namespace CreditSuisse.IT.ConsoleApp.Repository.Interfaces
{
    public interface ITradeRepository
    {
        void SendTrade(double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate);

        List<string> GetCategory();
    }
}
