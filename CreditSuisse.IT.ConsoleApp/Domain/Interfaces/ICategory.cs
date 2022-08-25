namespace CreditSuisse.IT.ConsoleApp.Domain.Interfaces
{
    internal interface ICategory
    {
        bool Check(Trade trade);

        string Name { get; }
    }
}
