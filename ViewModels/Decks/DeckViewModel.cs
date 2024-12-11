using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CardGenerator.Entities;
using CardGenerator.Helpers;
using CardGenerator.Input;
using CardGenerator.Interfaces.Factories;
using CardGenerator.Interfaces.Input;
using CardGenerator.Interfaces.ViewModels.Cards;
using CardGenerator.Interfaces.ViewModels.Decks;
using CardGenerator.Interfaces.ViewModels.Dialogs;
using CardGenerator.ViewModels.Cards;
using CardGenerator.Views;
using DynamicData;
using Microsoft.Win32;
using DialogHost = MaterialDesignThemes.Wpf.DialogHost;

namespace CardGenerator.ViewModels.Decks;

/// <summary>
///     The deck view model.
/// </summary>
public sealed class DeckViewModel : ViewModelBase, IDeckViewModel, IDisposable
{
    private readonly IGenericFactory genericFactory;
    private readonly Deck entity;
    private readonly SourceCache<Card, int> cardsCache;
    private readonly ReadOnlyObservableCollection<ICardViewModel> cards;
    private readonly IDisposable disposables;

    /// <summary>
    /// Constructor for the deck view model.
    /// </summary>
    /// <param name="genericFactory">The generic factory.</param>
    /// <param name="entity">The entity for the view model.</param>
    /// <exception cref="ArgumentNullException"/>
    public DeckViewModel(
        IGenericFactory genericFactory,
        Func<Task> saveCallback,
        Action cancelCallback,
        Deck entity)
    {
        this.genericFactory = genericFactory ?? throw new ArgumentNullException(nameof(genericFactory));
        this.entity = entity ?? throw new ArgumentNullException(nameof(entity));

        cardsCache = new SourceCache<Card, int>(card => card.Id);
        cardsCache.AddOrUpdate(entity.Cards);
        var connection = cardsCache.Connect()
            .Transform(card =>
            {
                var vm = genericFactory.Create<CardViewModel>();
                vm.FlavourText = card.FlavourText ?? string.Empty;
                vm.Image = card.Image ?? new();
                vm.Id = card.Id;
                return vm as ICardViewModel;
            })
            .DistinctUntilChanged()
            .OnItemUpdated((current, previous) => current.IsModified = !current.Equals(previous))
            .Bind(out cards)
            .Subscribe();

        SaveCommand = new AsyncRelayCommand(saveCallback);
        CancelCommand = new RelayCommand(cancelCallback);

        disposables = Disposable.Create(connection.Dispose);
    }

    /// <inheritdoc />
    public ReadOnlyObservableCollection<ICardViewModel> Cards => cards;

    /// <inheritdoc />
    public string Name
    {
        get => entity.Name ?? string.Empty;
        set
        {
            if (entity.Name != value)
            {
                entity.Name = value;
                OnPropertyChanged();
            }
        }
    }

    /// <inheritdoc />
    public string Description
    {
        get => entity.Description ?? string.Empty;
        set
        {
            if (entity.Description != value)
            {
                entity.Description = value;
                OnPropertyChanged();
            }
        }
    }

    /// <inheritdoc />
    public string FilePath
    {
        get => entity.Image?.FilePath ?? string.Empty;
        set
        {
            if (entity.Image?.FilePath != value)
            {
                UpdateImageData(value);
                OnPropertyChanged();
            }
        }
    }

    /// <inheritdoc />
    public byte[]? ImageThumb => entity.Image?.ThumbBytes;

    /// <inheritdoc />
    public bool IsModified { get; private set; }

    /// <inheritdoc />
    public IAsyncRelayCommand AddCardCommand => new AsyncRelayCommand(AddCard);

    /// <inheritdoc />
    public IAsyncRelayCommand<ICardViewModel> EditCardCommand => new AsyncRelayCommand<ICardViewModel>(EditCard);

    /// <inheritdoc />
    public IRelayCommand<ICardViewModel> DeleteCardCommand => new RelayCommand<ICardViewModel>(DeleteCard);

    /// <inheritdoc />
    public IAsyncRelayCommand SaveCommand { get; }

    /// <inheritdoc />
    public IRelayCommand CancelCommand { get; }

    /// <inheritdoc />
    public IRelayCommand SelectFileCommand => new RelayCommand(SelectFile);

    private void SelectFile()
    {
        var dialog = new OpenFileDialog() { Multiselect = false };

        if (dialog.ShowDialog() is true)
        {
            UpdateImageData(dialog.FileName);
        }
    }

    private void UpdateImageData(string filePath)
    {
        if (!File.Exists(filePath)) return;
        using var image = Image.FromFile(filePath);
        using var thumb = image.GetThumbnailImage(128, 128, null, 0);

        entity.Image = new ImageData
        {
            FilePath = filePath,
            Bytes = ImageHelpers.GetImageBytes(image),
            ThumbBytes = ImageHelpers.GetImageBytes(thumb)
        };

        OnPropertyChanged(nameof(FilePath));
        OnPropertyChanged(nameof(ImageThumb));
    }

    private async Task AddCard() => await AddOrUpdateCard(genericFactory.Create<ICardViewModel>(), true);

    private async Task EditCard(ICardViewModel? card)
    {
        ArgumentNullException.ThrowIfNull(card);
        await AddOrUpdateCard((ICardViewModel)card.Clone(), false);
    }

    private void DeleteCard(ICardViewModel? card)
    {
        ArgumentNullException.ThrowIfNull(card);
        cardsCache.RemoveKey(card.Id);
        OnPropertyChanged(nameof(Cards));
    }

    private async Task AddOrUpdateCard(ICardViewModel card, bool add)
    {
        var context = genericFactory.Create<IDialogViewModel<IModifyCardViewModel>>();
        context.Result.Card = card;
        context.ConfirmLabel = add ? "Add" : "Save";
        var content = new DialogControl { DataContext = context };

        var result = await DialogHost.Show(content, "RootDialog") as IModifyCardViewModel;
        if (result is not null)
        {
            if (add)
            {
                result.Card.Id = cardsCache.Count + 1;
            }

            cardsCache.AddOrUpdate(result.Card.CreateCard());
        }
    }

    /// <inheritdoc />
    public void Dispose() => disposables.Dispose();
}
