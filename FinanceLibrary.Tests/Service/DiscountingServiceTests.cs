using FinanceLibrary.Model;
using FinanceLibrary.Model.Discount;
using FinanceLibrary.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibrary.Tests.Service
{
    [TestFixture]
    public class DiscountingServiceTests
    {
        Mock<ICurveSource> _curveSource;
        DateTime _today = new DateTime(2018, 10, 12);

        [SetUp]
        public void Setup()
        {
            _curveSource = new Mock<ICurveSource>();

            _curveSource.Setup(cs => cs.Get(It.Is<DateTime>(d => d == _today), It.IsAny<string>()))
            .Returns(GetSampleDiscountFactors());
        }

        private IDiscountingService GetSUT()
        {
            return new DiscountingService(_curveSource.Object);
        }

        private DiscountFactor[] GetSampleDiscountFactors()
        {
            return new DiscountFactor[]
            {
                new DiscountFactor {Date = _today, Discount = 1 },
                new DiscountFactor {Date = _today.AddMonths(1), Discount = 0.99m },
                new DiscountFactor {Date = _today.AddMonths(2), Discount = 0.98m },
                new DiscountFactor {Date = _today.AddMonths(3), Discount = 0.95m },
                new DiscountFactor {Date = _today.AddMonths(6), Discount = 0.90m },

            };
        }

        [Test]
        public void Can_discount_cash_flow()
        {

            CashFlow cf = new CashFlow
            {
                Amount = 100,
                Currency = "USD",
                Date = _today.AddMonths(6)
            };

            var sut = GetSUT();


            var value = sut.Discount(_today, cf);

            Assert.AreEqual(90,value);
        }
    }
}
