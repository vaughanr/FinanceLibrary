using FinanceLibrary.Model;
using FinanceLibrary.Model.Calculations;
using FinanceLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Calculations
{
    public class PresentValue
    {
        IDiscountingService _discountingService;

        public PresentValue(IDiscountingService discountingService)
        {
            _discountingService = discountingService;
        }

        public ScalarValue RunCalculation(DateTime today, IEnumerable<IInstrument> instruments)
        {
            decimal total = 0;
            //Assuming all instruments are the same currency
            string firstCurrency = "";

            foreach(var instrument in instruments)
            {
                foreach(var cf in instrument.GetCashflows())
                {
                    if (string.IsNullOrWhiteSpace(firstCurrency))
                    {
                        firstCurrency = cf.Currency;
                    }
                    total += _discountingService.Discount(today, cf);
                }
            }
            return new ScalarValue
            {
                Value = total,
                Currency = firstCurrency,
            };
        }
    }
}
