using ConsoleApp25.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Interfaces;

public interface IPaymentService
{
    bool Pay(decimal amount);

    bool Refund();

    PaymentStatus GetPaymentStatus();
}
