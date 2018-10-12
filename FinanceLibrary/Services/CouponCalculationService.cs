using FinanceLibrary.Model;
using FinanceLibrary.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Services
{
    public class CouponCalculationService : ICouponCalculationService
    {
        public TimeSpan GetCouponIncrement(DateTime startDate, CouponType couponType)
        {
            switch (couponType)
            {
                case CouponType.Annual:
                    return startDate.AddYears(1) - startDate;

                case CouponType.SemiAnnual:
                    return startDate.AddMonths(6) - startDate;

                default:
                    throw new UnsupportedCouponTypeException(couponType);
            }
        }

        public decimal GetInterestAmount(decimal notional, decimal interestRate, CouponType couponType)
        {
            decimal couponFactor;
            switch (couponType)
            {
                case CouponType.Annual:
                    couponFactor = 1m;
                    break;

                case CouponType.SemiAnnual:
                    couponFactor = 0.5m;
                    break;

                default:
                    throw new UnsupportedCouponTypeException(couponType);
            }

            return notional * interestRate * couponFactor;
        }
    }
}
