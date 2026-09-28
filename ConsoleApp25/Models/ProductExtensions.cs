namespace ConsoleApp25.Models;
public static class ProductExtensions
{
    public static bool IsInStock(Product product)
    {
        Product? product1 = ProductService.Products.Find(x => x == product);
        if (product1 == null)
            return false;
        else
            return true;
    }
    public static decimal GetFinalPrice(Product product)
    {
        decimal total = 0;
        for (int i = 0; i < OrderService.orders.Count; i++)
        {
            foreach (OrderItem item in OrderService.orders[i].Items)
            {
                if (item.Product != null && item.Product ==  product)
                {
                    total += item.TotalPrice;
                }
            }
        }
        return total;
    }
    public static bool IsExpensive(this Product product, decimal threshold)
    {
        return product.Price > threshold;
    }
}
