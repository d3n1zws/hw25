using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;


namespace ConsoleApp25.Models;

public class ObjectInspector
{
    public static void Inspect(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();
        Console.WriteLine("Properties: ");
        for (int i = 0; i < properties.Length; i++)
        {
            Console.WriteLine(properties[i].Name, properties[i].PropertyType);
        }
        MethodInfo[] methods = type.GetMethods();
        Console.WriteLine("\nMethods: ");
        for (int i = 0;i < methods.Length; i++)
        {
            Console.WriteLine(methods[i].Name, methods[i].ReturnType);
        }
    }
}
