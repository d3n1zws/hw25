using System.Collections.Generic;
using ConsoleApp25.Models;

namespace ConsoleApp25.Interfaces;

public interface IProductService
{
    void AddProduct(Product product);
    void RemoveProduct(int id);
    void RestoreProduct(int id);
    Product GetProduct(int id);
    List<Product> GetAllProducts();
    List<Product> SearchProducts(string s);
}
