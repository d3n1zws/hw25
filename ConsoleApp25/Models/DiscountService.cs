using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class DiscountService
{
    private readonly List<DiscountCode> _discountCodes;

    public DiscountService(List<DiscountCode> discountCodes)
    {
        _discountCodes = discountCodes;
    }

    public decimal ApplyDiscount(string code, decimal orderAmount)
    {
        DiscountCode? discount = _discountCodes.FirstOrDefault(x => x.Code == code);

        if (discount == null)
            throw new Exception("Discount tapilmadi");

        if (!discount.IsActive)
            throw new Exception("Discount aktiv deyil");

        if (DateTime.Now > discount.ExpirationDate)
            throw new Exception("Discount-un vaxti kecib");

        if (orderAmount < discount.MinimumOrderAmount)
            throw new Exception($"kupon ucun {discount.MinimumOrderAmount} xerclemelisiz");

        decimal discountAmount = orderAmount * discount.DiscountPercentage / 100;

        return orderAmount - discountAmount;
    }
}
