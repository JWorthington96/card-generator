// Courtesy of https://medium.com/@gilbert6137/enhancing-c-factory-pattern-with-generics-and-reflection-fe9e9aa49f29

using System;
using CardGenerator.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CardGenerator.Factories;

/// <summary>
/// The generic factory.
/// </summary>
/// <param name="serviceProvider">The service provider.</param>
public class GenericFactory(IServiceProvider serviceProvider) : IGenericFactory
{
    /// <inheritdoc />
    public T Create<T>() where T : new()
    {
        return Create<T>([]);
    }

    /// <inheritdoc />
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
                instance = serviceProvider.GetService<T>() ?? (T)ActivatorUtilities.CreateInstance(serviceProvider, type, args);
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

        return instance;
    }
}