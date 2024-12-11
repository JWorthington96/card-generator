namespace CardGenerator.Interfaces.ViewModels;

/// <summary>
/// The entity view model interface.
/// </summary>
public interface IEntityViewModel
{
    /// <summary>
    /// Gets or sets whether the entity has been modified.
    /// </summary>
    bool IsModified { get; set; }
}
