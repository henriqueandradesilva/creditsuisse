using CreditSuisse.IT.ConsoleApp.Domain.Interfaces;

namespace CreditSuisse.IT.ConsoleApp.Domain
{
    internal class Trade : ITrade
    {
        #region Properties

        public double Value { get; set; }

        public string? ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        #endregion
    }
}
