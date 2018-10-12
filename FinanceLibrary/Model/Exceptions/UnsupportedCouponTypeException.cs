using System;

namespace FinanceLibrary.Model.Exceptions
{
    public class UnsupportedCouponTypeException : Exception
    {
        public UnsupportedCouponTypeException(CouponType couponType)
            : base(string.Format("Unsupported coupon type:{0}", couponType))
        {
        }
    }
}
