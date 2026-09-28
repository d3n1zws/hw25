using ConsoleApp25.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Models;

public class CustomCollection<T> where T: class, IEntity
{
    T[] items = new T[0];
    public void Add(T item)
    {
        Array.Resize(ref items, items.Length + 1);
        items[items.Length] = item;
    }
    public void Remove(T item)
    {
        Array.Resize(ref items, items.Length - 1);
    }

    public T Get(int id)
    {
        T? item = items.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            throw new Exception("tapilmadi");
        }
        return item;
    }

    public bool Contains(int id)
    {
        T? item = items.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return false;
        }
        return true;
    }
    public int Count()
    {
        return items.Length;
    }
    public void Clear()
    {
        Array.Resize(ref items, 0);
    }
}
