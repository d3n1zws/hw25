using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class DiscountCode
{
    public string Code { get; set; }

    public decimal DiscountPercentage { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public decimal MinimumOrderAmount { get; set; }
}
