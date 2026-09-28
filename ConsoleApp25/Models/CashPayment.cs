using ConsoleApp25.Enums;
using ConsoleApp25.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class CashPayment : IPaymentService
{
    public PaymentStatus PaymentStatus = PaymentStatus.Pending;
    public PaymentStatus GetPaymentStatus()
    {
        return PaymentStatus;
    }

    public bool Pay(decimal amount)
    {
        if (amount < 0)
        {
            PaymentStatus = PaymentStatus.Failed;
            return false;
        }
        PaymentStatus = PaymentStatus.Paid;
        return true;
    }

    public bool Refund()
    {
        if (PaymentStatus != PaymentStatus.Paid)
            return false;
        PaymentStatus = PaymentStatus.Refunded;
        return true;
    }
}
