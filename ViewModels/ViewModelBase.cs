using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DrinkingBuddy.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    // In ViewModelBase.cs 
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        VerifyPropertyName(propertyName);
        PropertyChangedEventHandler? handler = PropertyChanged;
        if (handler is not null)
        {
            var e = new PropertyChangedEventArgs(propertyName);
            handler(this, e);
        }
    }

    [Conditional("DEBUG")]
    [DebuggerStepThrough]
    public void VerifyPropertyName(string? propertyName)
    {
        // Verify that the property name matches a real, 
        // public, instance property on this object. 
        if (propertyName is null)
        {
            Debug.Fail("Propery name is null.");
        }
        if (TypeDescriptor.GetProperties(this)[propertyName] is null)
        {
            Debug.Fail($"Invalid property name: {propertyName}");
        }
    }
}
