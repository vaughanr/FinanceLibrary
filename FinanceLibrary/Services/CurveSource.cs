using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceLibrary.Model.Discount;

namespace FinanceLibrary.Services
{
    public class CurveSource : ICurveSource
    {
        public DiscountFactor[] Get(DateTime today, string currency)
        {
            //Harcode intially
            return GetSampleDiscountFactors(today);
        }

        private DiscountFactor[] GetSampleDiscountFactors(DateTime today)
        {
            return new DiscountFactor[]
            {
                new DiscountFactor {Date = today, Discount = 1 },
                new DiscountFactor {Date = today.AddMonths(1), Discount = 0.99m },
                new DiscountFactor {Date = today.AddMonths(2), Discount = 0.98m },
                new DiscountFactor {Date = today.AddMonths(3), Discount = 0.95m },
                new DiscountFactor {Date = today.AddMonths(6), Discount = 0.90m },
            };
        }
    }
}
