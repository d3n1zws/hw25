namespace ConsoleApp25.Models;
using ConsoleApp25.Interfaces;
public class Repository<T> : IRepository<T> where T : class, IEntity
{
    public List<T> Items = new List<T>();

    public void Add(T entity)
    {
        Items.Add(entity);
    }

    public void Delete(T entity)
    {
        Items.Remove(entity);
    }

    public List<T> GetAll()
    {
        return Items;
    }

    public T GetById(int id)
    {
        T? item = Items.Find(x => x.Id  == id);
        if (item == null)
        {
            throw new Exception("Tapilmadi");
        }
        return item;
    }

    public void Update(int id, T entity)
    {
        int index = Items.FindIndex(x => x.Id == id);
        if (index == -1)
        {
            throw new Exception("Tapilmadi");
        }
        Items[index] = entity;
    }
}
