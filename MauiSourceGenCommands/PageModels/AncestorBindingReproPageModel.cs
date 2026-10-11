using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiSourceGenCommands.PageModels;

public partial class AncestorBindingReproPageModel : ObservableObject
{
    public AncestorBindingReproItem[] Items { get; } = Enumerable.Range(1, 100)
        .Select(index => new AncestorBindingReproItem($"Item {index}"))
        .ToArray();

    [ObservableProperty]
    public partial string LastInvoked { get; set; } = "Use an item to verify its ancestor command binding.";

    [RelayCommand]
    private void Use(AncestorBindingReproItem item) => LastInvoked = $"Used {item.Title}";
}

public record AncestorBindingReproItem(string Title);
