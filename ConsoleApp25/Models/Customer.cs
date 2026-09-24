using System;

namespace ConsoleApp25.Models;

public class Customer
{
    static int id = 0;

    public Customer(string firstName, string lastName, string email, string phone, bool isDeleted, DateTime createdAt)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
        Id = id++;
        FullName = firstName + ' ' + lastName;
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string FullName { get; set; } = null!;
   
}
