using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class ProductCollection
{
    public List<Product> products = ProductService.Products;
    public Product this[int index]
    {
        get
        {
            if (index >= products.Count)
                throw new ArgumentOutOfRangeException("index");
            return products[index];
        }
        set
        {
            if (index >= products.Count)
                throw new ArgumentOutOfRangeException("index");
            products[index] = value;
        }
    }
    public Product this[string name]
    {
        get
        {
            Product? product = products.Find(x => x.Name == name);
            if (product == null)
                throw new Exception("Product tapilmadi");
            return product;
        }
        set
        {
            int index = products.FindIndex(x => x.Name == name);
            if (index == -1)
                throw new Exception("Product tapilmadi");
            products[index] = value;
        }
    }
}
