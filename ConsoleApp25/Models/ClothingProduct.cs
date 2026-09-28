namespace ConsoleApp25.Models;

public class ClothingProduct : Product
{
    public ClothingProduct(string name, string description, decimal price, int stock, string category, bool isDeleted, string size, string material, string gender)
        : base(name, description, price, stock, category, isDeleted)
    {
        Size = size;
        Material = material;
        Gender = gender;
    }
    public string Size { get; set; } = null!;
    public string Material { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public override void GetProductInfo()
    {
        Console.WriteLine($"Id : {Id}, Name : {Name}, Description : {Description}, Price : {Price}, Stock : {Stock}, Category : {Category}, Is Deleted : {IsDeleted}, Created At : {CreatedAt}, Size : {Size}, Material : {Material}, Gender : {Gender}");
    }

}