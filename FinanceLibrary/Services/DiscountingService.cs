using FinanceLibrary.Model;
using System;
using System.Linq;

namespace FinanceLibrary.Services
{
    public class DiscountingService : IDiscountingService
    {
        ICurveSource _curveSource;

        public DiscountingService(ICurveSource curveSource)
        {
            _curveSource = curveSource;
        }

        public decimal Discount(DateTime today, CashFlow cashflow)
        {
            var discounts = _curveSource.Get(today, cashflow.Currency);

            //No interpolation intially. Assume the date is exactly there
            var discount = discounts.Single(d=>d.Date == cashflow.Date);

            return discount.Discount * cashflow.Amount;
        }
    }
}
