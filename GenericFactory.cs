// Courtesy of https://medium.com/@gilbert6137/enhancing-c-factory-pattern-with-generics-and-reflection-fe9e9aa49f29

using System;
using DrinkingBuddy.Interfaces.Factories;

namespace DrinkingBuddy;

public class GenericFactory : IGenericFactory
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
            instance = (T)Activator.CreateInstance(type, args);
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
}