using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp25.Interfaces;

public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
    List<T> GetAll();
    void Update(int id, T entity);
    void Delete(T entity);
}
