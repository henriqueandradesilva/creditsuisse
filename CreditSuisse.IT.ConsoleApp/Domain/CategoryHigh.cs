using CreditSuisse.IT.ConsoleApp.Consts;
using CreditSuisse.IT.ConsoleApp.Domain.Interfaces;

namespace CreditSuisse.IT.ConsoleApp.Domain
{
    internal class CategoryHigh : ICategory
    {
        #region Properties

        public string Name { get; }

        #endregion

        #region Constructor

        public CategoryHigh()
        {
            Name = CategoryConsts.High;
        }

        #endregion

        #region Methods

        public bool Check(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector?.ToUpper() == ClientConsts.Private)
                return true;

            return false;
        }

        #endregion
    }
}
