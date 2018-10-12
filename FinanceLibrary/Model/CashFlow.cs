using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Model
{
    public class CashFlow
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
