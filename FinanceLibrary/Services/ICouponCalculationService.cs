using System;
using FinanceLibrary.Model;

namespace FinanceLibrary.Services
{
    public interface ICouponCalculationService
    {
        TimeSpan GetCouponIncrement(DateTime startDate, CouponType couponType);
        decimal GetInterestAmount(decimal notional, decimal interestRate, CouponType couponType);
    }
}
