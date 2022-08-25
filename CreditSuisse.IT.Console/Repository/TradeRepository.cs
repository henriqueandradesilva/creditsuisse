using CreditSuisse.IT.ConsoleApp.Domain;
using CreditSuisse.IT.ConsoleApp.Domain.Interfaces;
using CreditSuisse.IT.ConsoleApp.Repository.Interfaces;

namespace CreditSuisse.IT.ConsoleApp.Repository
{
    public class TradeRepository : ITradeRepository
    {
        private DateTime referenceDate { get; set; }

        private Trade _trade;

        public TradeRepository()
        {
            _trade = new Trade();
        }

        public void SendTrade(double value, string clientSector, DateTime nextPaymentDate, DateTime referenceDate)
        {
            this.referenceDate = referenceDate;

            _trade = new();
            _trade.Value = value;
            _trade.ClientSector = clientSector;
            _trade.NextPaymentDate = nextPaymentDate;
        }

        public List<string> GetCategory()
        {
            CategoryExpired categoryExpired = new CategoryExpired(referenceDate);
            CategoryHigh categoryHigh = new CategoryHigh();
            CategoryMedium categoryMedium = new CategoryMedium();

            List<ICategory> listCategory = new();
            listCategory.Add(categoryExpired);
            listCategory.Add(categoryHigh);
            listCategory.Add(categoryMedium);

            List<string> categories = new();

            try
            {
                foreach (var category in listCategory)
                {
                    if (category.Check(_trade))
                    {
                        categories.Add(category.Name);

                        break;
                    }
                }

                if (categories.Count() == 0)
                    throw new ArgumentException("Range Category not implemented!");

                return categories;
            }
            catch
            {
                throw new ArgumentException("Category type not implemented!");
            }
        }
    }
}
