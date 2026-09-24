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

}