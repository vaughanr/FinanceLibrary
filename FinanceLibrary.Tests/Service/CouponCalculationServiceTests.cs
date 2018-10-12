using FinanceLibrary.Model;
using FinanceLibrary.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Tests.Service
{
    [TestFixture]
    public class CouponCalculationServiceTests
    {

        private ICouponCalculationService GetSUT()
        {
            return new CouponCalculationService();
        }

        [Test]
        public void Adds_annual_increment()
        {
            DateTime start = new DateTime(2018, 4, 1);
            DateTime expectedEnd = new DateTime(2019, 4, 1);
            CouponType coupon = CouponType.Annual;
            var sut = GetSUT();

            var increment = sut.GetCouponIncrement(start, coupon);

            Assert.AreEqual(expectedEnd, start.Add(increment));
        }

        [Test]
        public void Adds_semi_annual_increment()
        {
            DateTime start = new DateTime(2018, 4, 1);
            DateTime expectedEnd = new DateTime(2018, 10, 1);
            CouponType coupon = CouponType.SemiAnnual;
            var sut = GetSUT();

            var increment = sut.GetCouponIncrement(start, coupon);

            Assert.AreEqual(expectedEnd, start.Add(increment));
        }
    }
}
