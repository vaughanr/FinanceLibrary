using FinanceLibrary.Model.Discount;
using System;

namespace FinanceLibrary.Services
{
    public interface ICurveSource
    {
        DiscountFactor[] Get(DateTime today, string currency);
    }
}
