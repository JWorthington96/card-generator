// Courtesy of https://medium.com/@gilbert6137/enhancing-c-factory-pattern-with-generics-and-reflection-fe9e9aa49f29

namespace DrinkingBuddy.Interfaces.Factories;

public interface IGenericFactory
{
    T Create<T>() where T : new();
    T Create<T>(params object[] args);
    T Create<T, T1>(params object[] args);
}
