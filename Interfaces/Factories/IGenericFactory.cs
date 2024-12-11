// Courtesy of https://medium.com/@gilbert6137/enhancing-c-factory-pattern-with-generics-and-reflection-fe9e9aa49f29

namespace CardGenerator.Interfaces.Factories;

/// <summary>
/// The generic factory interface.
/// </summary>
public interface IGenericFactory
{
    /// <summary>
    /// Creates a new object of type T.
    /// </summary>
    /// <typeparam name="T"/>
    T Create<T>() where T : new();

    /// <summary>
    /// Creates a new object of type T.
    /// </summary>
    /// <typeparam name="T"/>
    T Create<T>(params object[] args);
}
