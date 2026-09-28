using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models
{
    public class SalesStatisticsService
    {
        private readonly List<Order> _orders;
        public SalesStatisticsService(List<Order> orders)
        {
            _orders = orders;
        }
        public decimal GetTotalSales()
        {
            return _orders.Sum(x => x.TotalPrice);
        }
        public int GetTotalOrders()
        {
            return _orders.Count;
        }
        public decimal GetAverageOrderValue()
        {
            if (_orders.Count == 0)
                return 0;

            return _orders.Average(x => x.TotalPrice);
        }

        public Product? GetBestSellingProduct()
        {
            return _orders
                .SelectMany(x => x.Items)
                .GroupBy(x => x.Product)
                .OrderByDescending(x => x.Sum(i => i.Quantity))
                .Select(x => x.Key)
                .FirstOrDefault();
        }

        public Customer? GetBestCustomer()
        {
            return _orders
                .GroupBy(x => x.Customer)
                .OrderByDescending(x => x.Sum(o => o.TotalPrice))
                .Select(x => x.Key)
                .FirstOrDefault();
        }

        public Dictionary<string, decimal> GetSalesByCategory()
        {
            return _orders
                .SelectMany(x => x.Items)
                .GroupBy(x => x.Product.Category)
                .ToDictionary(
                    x => x.Key,
                    x => x.Sum(i => i.Product.Price * i.Quantity)
                );
        }

        public Dictionary<DateTime, decimal> GetSalesByDate()
        {
            return _orders
                .GroupBy(x => x.CreatedAt.Date)
                .ToDictionary(
                    x => x.Key,
                    x => x.Sum(o => o.TotalPrice)
                );
        }
    }
}
