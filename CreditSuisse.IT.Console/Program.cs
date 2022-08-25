using CreditSuisse.IT.ConsoleApp.Services;

namespace CreditSuisse.IT.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new TradeService().Run();
        }
    }
}