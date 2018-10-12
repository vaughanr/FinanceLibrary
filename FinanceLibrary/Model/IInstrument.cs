using System;
using System.Collections.Generic;

namespace FinanceLibrary.Model
{
    public interface IInstrument
    {
        IEnumerable<CashFlow> GetCashflows();
    }
}
