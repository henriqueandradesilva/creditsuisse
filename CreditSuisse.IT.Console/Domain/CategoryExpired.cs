using CreditSuisse.IT.ConsoleApp.Consts;
using CreditSuisse.IT.ConsoleApp.Domain.Interfaces;

namespace CreditSuisse.IT.ConsoleApp.Domain
{
    internal class CategoryExpired : ICategory
    {
        #region Properties

        private DateTime _referenceDate;

        public string Name { get; }

        #endregion

        #region Constructor

        public CategoryExpired(DateTime referenceDate)
        {
            _referenceDate = referenceDate;
            Name = CategoryConsts.Expired;
        }

        #endregion

        #region Methods

        public bool Check(Trade trade)
        {
            var date = (_referenceDate - trade.NextPaymentDate).Days;

            if (date > 30)
                return true;

            return false;
        }

        #endregion
    }
}
