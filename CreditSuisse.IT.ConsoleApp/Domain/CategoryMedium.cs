using CreditSuisse.IT.ConsoleApp.Consts;
using CreditSuisse.IT.ConsoleApp.Domain.Interfaces;

namespace CreditSuisse.IT.ConsoleApp.Domain
{
    internal class CategoryMedium : ICategory
    {
        #region Properties

        public string Name { get; }

        #endregion

        #region Constructor

        public CategoryMedium()
        {
            Name = CategoryConsts.Medium;
        }

        #endregion

        #region Methods

        public bool Check(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector?.ToUpper() == ClientConsts.Public)
                return true;

            return false;
        }

        #endregion
    }
}
