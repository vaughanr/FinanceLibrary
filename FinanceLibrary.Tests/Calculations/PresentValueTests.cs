using FinanceLibrary.Calculations;
using FinanceLibrary.Model;
using FinanceLibrary.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Tests.Calculations
{
    [TestFixture]
    public class PresentValueTests
    {
        Mock<IDiscountingService> _discountingService;
        DateTime _today = new DateTime(2018, 4, 1);

        [SetUp]
        public void Setup()
        {
            _discountingService = new Mock<IDiscountingService>();

            _discountingService.Setup(d => d.Discount(It.IsAny<DateTime>(), It.IsAny<CashFlow>())).Returns(80);
        }

        ICouponCalculationService GetCouponService()
        {
            return new CouponCalculationService();
        }

        private IInstrument GetBond()
        {
            return new Bond(GetCouponService(), _today, 1, CouponType.SemiAnnual, 100, "ZAR", 0.05m);
        }


        private PresentValue GetSUT()
        {
            return new PresentValue(_discountingService.Object);
        }
       
        [Test]
        public void Can_run_Calculation()
        {
            var sut = GetSUT();

            var result = sut.RunCalculation(_today, new IInstrument[] { GetBond() });

            Assert.AreEqual(160, result.Value);
        }

    }
}
