// Courtesy of https://medium.com/@gilbert6137/enhancing-c-factory-pattern-with-generics-and-reflection-fe9e9aa49f29

using System;
using System.Collections.Generic;
using CardGenerator.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CardGenerator;

public class GenericFactory(IServiceProvider serviceProvider) : IGenericFactory
{
    public T Create<T>() where T : new()
    {
        return Create<T>(new object[] { });
    }

    public T Create<T>(params object[] args)
    {
        // Get type information
        Type type = typeof(T);

        // Try to create an instance with given arguments
        T instance;
        try
        {
            if (type.IsInterface && args.Length == 0)
            {
                instance = serviceProvider.GetService<T>();
            }
            else
            {
                instance = (T)ActivatorUtilities.CreateInstance(serviceProvider, type, args);
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Could not create an instance of type '{type.FullName}'", ex);
        }

        // Try to set field or property
        //bool success = false;
        //foreach (var member in type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        //{
        //    if (member.Name == memberName)
        //    {
        //        object memberInstance = Activator.CreateInstance(((FieldInfo)member).FieldType);

        //        switch (member.MemberType)
        //        {
        //            case MemberTypes.Field:
        //                ((FieldInfo)member).SetValue(instance, memberInstance);
        //                success = true;
        //                break;
        //            case MemberTypes.Property:
        //                ((PropertyInfo)member).SetValue(instance, memberInstance);
        //                success = true;
        //                break;
        //        }

        //        if (success) break;
        //    }
        //}

        //if (!success)
        //{
        //    throw new ArgumentException($"Member '{memberName}' not found in type '{type.FullName}'");
        //}

        return instance;
    }

    public T Create<T, T1>(params object[] args)
    {
        // Get type information
        Type type = typeof(T);
        Type type1 = typeof(T1);

        // Try to create an instance with given arguments
        T instance;
        try
        {
            var instance1 = Create<T1>();
            var newArgs = new List<object>(args)
            {
                instance1
            };
            instance = (T)Activator.CreateInstance(type, newArgs.ToArray());
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Could not create an instance of type '{type.FullName}'", ex);
        }

        return instance;
    }
}