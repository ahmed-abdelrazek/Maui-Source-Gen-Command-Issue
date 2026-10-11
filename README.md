# Maui-Source-Gen-Command-Issue
With XAML SourceGen enabled, a compiled RelativeSource AncestorType command binding can receive a null ancestor model. Its generated getter dereferences that null source and this throws a NullReferenceException
