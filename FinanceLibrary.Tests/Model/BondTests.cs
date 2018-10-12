using FinanceLibrary.Model;
using FinanceLibrary.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Tests.Model
{
    [TestFixture]
    public class BondTests
    {
        ICouponCalculationService GetCouponService()
        {
            return new CouponCalculationService();
        }

        [Test]
        public void one_year_semi_anual_bond_has_2_cashflows()
        {
            var bond = new Bond(GetCouponService(), new DateTime(2018, 4, 10), 1, CouponType.SemiAnnual, 100, "ZAR", 0.05m);

            var cashflows = bond.GetCashflows().ToList();

            Assert.AreEqual(2, cashflows.Count());
            Assert.AreEqual(2.5m, cashflows[0].Amount);
            Assert.AreEqual(102.5m, cashflows[1].Amount);
        }
    }
}
