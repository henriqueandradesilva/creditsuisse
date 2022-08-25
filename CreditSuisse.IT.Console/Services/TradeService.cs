using CreditSuisse.IT.ConsoleApp.Repository;
using CreditSuisse.IT.ConsoleApp.Services.Interfaces;
using System.Globalization;

namespace CreditSuisse.IT.ConsoleApp.Services
{
    public class TradeService : ITradeService
    {
        #region Methods Public

        public void Run()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

            Console.WriteLine("Enter reference date format (Ex: mm/dd/yyyy)");
            DateTime date = ReadReferenceDate();

            Console.WriteLine("Enter number trades (Ex: 10)");
            int tradesNumber = ReadTradeNumber();

            ReadTradeFull(date, tradesNumber);

            Console.ReadKey();
        }

        #endregion

        #region Methods Private

        private DateTime ReadReferenceDate()
        {
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Reference date is incorrect format (Ex: mm/dd/yyyy)");

                date = ReadReferenceDate();
            }

            return date.Date;
        }

        private int ReadTradeNumber()
        {
            if (!int.TryParse(Console.ReadLine(), out int numbers))
            {
                Console.WriteLine("Number is incorrect format (Ex: 10)");

                numbers = ReadTradeNumber();
            }

            return numbers;
        }

        private void ReadTradeFull(DateTime referenceDate, int numbers)
        {
            Console.WriteLine("Enter trades format (Ex: Amount, Private/Public, Next Pending Payment)");

            List<string> inputs = new List<string>();

            for (int i = 0; i < numbers; i++)
            {
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                    inputs.Add(input);
            }

            foreach (var input in inputs)
            {
                if (ValidateTradeInput(input))
                {
                    try
                    {
                        CreateTrade(input, referenceDate);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);

                        ReadTradeFull(referenceDate, numbers);
                    }
                }
                else
                    ReadTradeFull(referenceDate, numbers);
            }
        }

        private void CreateTrade(string input, DateTime referenceDate)
        {
            string[] fields = input.Split(" ");

            double value = Convert.ToDouble(fields[0]);
            string client = fields[1].ToUpper();
            DateTime nextPaymentDate = Convert.ToDateTime(fields[2]);

            TradeRepository tradeRepository = new();
            tradeRepository.SendTrade(value,
                                  client,
                                  nextPaymentDate,
                                  referenceDate);

            tradeRepository.GetCategory().ForEach(delegate (string s)
            {
                Console.WriteLine(s);
            });
        }

        private bool ValidateTradeInput(string input)
        {
            string[] fields = input.Split(" ");

            return
                fields.Length == 3 &&
                double.TryParse(fields[0], out _) &&
                (fields[1].ToUpper() == Consts.ClientConsts.Private || fields[1].ToUpper() == Consts.ClientConsts.Public) &&
                DateTime.TryParse(fields[2], out _);
        }

        #endregion
    }
}
