using FinanceLibrary.Model.Exceptions;
using FinanceLibrary.Services;
using System;
using System.Collections.Generic;

namespace FinanceLibrary.Model
{
    public class Bond : IInstrument
    {
        ICouponCalculationService _couponCalculationService;
        DateTime _startDate;
        DateTime _maturityDate;
        decimal _notional;
        CouponType _couponType;
        string _currency;
        decimal _interestRate;

        public Bond(ICouponCalculationService couponCalculationService, DateTime startDate, int termYears, CouponType couponType, decimal notional, string currency, decimal interestRate)
        {
            _couponCalculationService = couponCalculationService;
            _startDate = startDate;
            _notional = notional;
            _maturityDate = _startDate.AddYears(termYears);
            _couponType = couponType;
            _currency = currency;
            _interestRate = interestRate;
        }


        public IEnumerable<CashFlow> GetCashflows()
        {
            TimeSpan couponIncrement = _couponCalculationService.GetCouponIncrement(_startDate, _couponType);

            DateTime cashflowDate = _startDate.Add(couponIncrement);
            decimal couponAmount = _couponCalculationService.GetInterestAmount(_notional, _interestRate, _couponType);

            while (cashflowDate < _maturityDate)
            {
                yield return new CashFlow
                {
                    Amount = couponAmount,
                    Currency = _currency,
                    Date = cashflowDate
                };

                cashflowDate = cashflowDate.Add(couponIncrement);
            }

            yield return new CashFlow
            {
                Amount = _notional + couponAmount,
                Currency = _currency,
                Date = _maturityDate
            };
        }
    }
}
