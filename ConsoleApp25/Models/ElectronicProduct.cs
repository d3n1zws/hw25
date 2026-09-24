namespace ConsoleApp25.Models;

public class ElectronicProduct : Product
{
    public ElectronicProduct(string name, string description, decimal price, int stock, string category, bool isDeleted, string brand, int warratyMonths) 
        : base(name, description, price, stock, category, isDeleted)
    {
        Brand = brand;
        WarratyMonths = warratyMonths;
    }

    public string Brand { get; set; } = null!;
    public int WarratyMonths { get; set; }

}