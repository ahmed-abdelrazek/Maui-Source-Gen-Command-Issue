# MAUI SourceGen command binding issue

A Windows reproduction sample for [MAUI issue #38667](https://github.com/dotnet/maui/issues/38667):
a SourceGen compiled `RelativeSource AncestorType` command getter throws
`NullReferenceException` when its source is null.

**Scrolling a `CollectionView` is enough to trigger the failure.** No button
click, swipe action, or resource replacement is required.

## Reproduction environment

| Setting | Value |
| --- | --- |
| Platform | Windows |
| Target framework | `net10.0-windows10.0.19041.0` |
| MAUI Controls package | `Microsoft.Maui.Controls` **10.0.110** |
| XAML inflator | `MauiXamlInflator=SourceGen` (project default) |
| Configuration | Debug |

## Sample structure

The startup page contains 100 items in a `CollectionView`. Its binding context
comes from an application `DynamicResource`, and each item contains a `SwipeView`
with a `SwipeItem` and an `ImageButton`. Both commands bind to the ancestor page
model using compiled bindings. The resource is initialized once; there are no
resource replacement or stress controls.

The app contains only the reproduction page and its model inside a minimal Shell.
The original template pages, database, and Syncfusion controls have been removed.
Dependencies are MAUI Controls, CommunityToolkit.Mvvm (for the model and command),
and debug logging.

## How to reproduce

Use a .NET 10 SDK with the MAUI Windows workload installed. Open
`MauiSourceGenCommands.slnx` and select the Windows target.

1. Run the app on Windows in Debug with SourceGen enabled (the project default).
2. On the **Issue #38667** startup page, scroll down and back up through the list.
3. Observe a `NullReferenceException` in the generated command getter. No button
   clicks, swipes, or resource replacements are required.

Scrolling alone reproduced the failure in the original version of this sample
using `Microsoft.Maui.Controls` **10.0.110**, targeting
`net10.0-windows10.0.19041.0`. The simplified version retains the item template
and initial dynamic-resource binding from that reproduction.

## Captured exception

The captured exception points to the `SwipeItem` command binding:

```text
Object reference not set to an instance of an object.
at MauiSourceGenCommands.Pages.AncestorBindingReproPage.<>c.<InitializeComponent>b__11_14(AncestorBindingReproPageModel source)
in Pages_AncestorBindingReproPage.xaml.xsg.cs:line 304
```

The corresponding generated getter is:

```csharp
getter: source => (source.UseCommand, true),
```

When `source == null`, accessing `source.UseCommand` throws.

Generated method names and line numbers may change after simplification or a
rebuild. The debugger caught the supplied exception with its default settings;
no additional exception configuration was needed in that session.
