namespace MauiSourceGenCommands.Pages;

public partial class AncestorBindingReproPage : ContentPage
{
    public AncestorBindingReproPage()
    {
        Application.Current!.Resources["AncestorBindingReproModel"] = new AncestorBindingReproPageModel();
        InitializeComponent();
    }
}
