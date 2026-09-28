namespace ConsoleApp25.Models;

public class ElectronicProduct : Product
{
    public ElectronicProduct(string name, string description, decimal price, int stock, string category, bool isDeleted, string brand, int warratyMonths) 
        : base(name, description, price, stock, category, isDeleted)
    {
        Brand = brand;
        WarratyMonths = warratyMonths;
    }
    public override void GetProductInfo()
    {
        Console.WriteLine($"Id : {Id}, Name : {Name}, Description : {Description}, Price : {Price}, Stock : {Stock}, Category : {Category}, Is Deleted : {IsDeleted}, Created At : {CreatedAt}, Brand : {Brand}, Warraty Months : {WarratyMonths}");
    }
    public string Brand { get; set; } = null!;
    public int WarratyMonths { get; set; }

}