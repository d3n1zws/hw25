using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class MemoryTest
{
    public static void Run()
    {
        Console.WriteLine("before memory: " + GC.GetTotalMemory(false));
        for (int i = 0; i < 100000; i++)
        {
            Customer cust = new Customer("a", "a", "a@mail", "1234", false);
        }
        Console.WriteLine("after memory" + GC.GetTotalMemory(false));
        Customer cust1 = new Customer("b", "b", "b@mail", "1234", false);
        Console.WriteLine("generation: " + GC.GetGeneration(cust1));
        Console.WriteLine("allocated bytes: " + GC.GetAllocatedBytesForCurrentThread());
    }
}
