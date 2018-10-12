using FinanceLibrary.Model;
using System;

namespace FinanceLibrary.Services
{
    public interface IDiscountingService
    {
        decimal Discount(DateTime today, CashFlow cashflow);
    }
}
