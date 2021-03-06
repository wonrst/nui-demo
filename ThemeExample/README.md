# NUI Styling with Xaml Theme

## Notice

Note that, the NUI xaml styling is for the NUI `View` and derived classes in Tizen.NUI.BaseComponents and Tizen.NUI.Components.

It is supported limitedly according to the device profile.

|Profile|Tizen 6.0|Tizen 6.5|
|---|---|---|
|Mobile/FHub|Draft|O|
|TV|X|O|

<br/>
<br/>


## Basic Styling
The NUI `View` and the derived classes can be decorated with a corresponding `ViewStyle` class.
For example,
* `ViewStyle` decorates `View`
* `TextLabelStyle` decorates `TextLabel`
* `ButtonStyle` decorates `Button`


Here's a simple example that styles a `TextLabel`.

```C#
TextLabelStyle testStyle = new TextLabelStyle()
{
  TextColor = Color.White,
  PointSize = 20,
};

TextLabel textLabel = new TextLabel(testStyle);
```
<br/>
<br/>

## Writing Style in Xaml
In the above example, the TextLabelStyle is written in C#. The same code can be written in xaml like below.

```xml
<TextLabelStyle x:Key="testStyle" TextColor="White" PointSize="20" />
```
This describes a `TextLabelStyle` instance that has white text color and point size 20. Note that, it has a `x:Key` attribute that will be a key to match it to a TextLabel. A TextLabel can specify this key using `StyleName` property.
```C#
TextLabel textLabel = new TextLabel()
{
  StyleName = "testStyle"
};
```

We named a collection of styles `Theme`. One xaml file represents one theme. So the full xaml code of the above example is,

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Theme
  xmlns="http://tizen.org/Tizen.NUI/2018/XAML"
  xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

  <TextLabelStyle x:Key="testStyle" TextColor="White" PointSize="20" />

  <!-- Can list other styles here -->

</Theme>
```

To load a xaml file and apply it to the current NUI application, `Theme` and `ThemeManager` are used.

```C#
// Sample.cs
// Load theme from the xaml file
Theme theme = new Theme("full_path_of_the_xaml_file.xaml");

// Apply it to the current NUI Application
ThemeManager.ApplyTheme(theme);
```

For more xaml information, please visit [NUI Xaml style syntax](./docs/NUIXamlStyleSyntax.md).
<br/>
<br/>

## Event and Callback

Since applying a new theme may reset properties set by user in View to the new properties, users may want to be notified when the theme changed.

For example, suppose a user defines a TextLabel in `blue` and then applies an xaml theme to set point size.

```C#
// TextSample.cs
var textLabel = new TextLabel()
{
  StyleName = "largeText",
  TextColor = Color.Blue,
};
window.Add(textLabel);

ThemeManager.ApplyTheme(new Theme(res + "TextSizeTheme.xaml"));
```

```xml
<!-- TextSizeTheme.xaml -->
<?xml version="1.0" encoding="UTF-8"?>
<Theme
  xmlns="http://tizen.org/Tizen.NUI/2018/XAML"
  xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">

  <TextLabelStyle x:Key="largeText" PointSize="100" TextColor="Black" />
  <TextLabelStyle x:Key="smallText" PointSize="20" TextColor="Black" />

</Theme>
```
Since the xaml defined text color to `black`, applying theme will change text color from `blue` to `black`.
<br/>

For the users who want to re-reset unintentionally overwritten properties, the theme system provides two ways to get notified of theme change.

* `ThemeManager.ThemeChanged`
* `View.OnThemeChanged`
<br/>

### ThemeManager.ThemeChanged
`ThemeManager` provides an event that is raised after theme changed.

```C#
ThemeManager.ThemeChanged += OnThemeChangedHandler;
```
```C#
void OnThemeChangedHandler(object sender, ThemeChangedEventArgs args)
{
  // Theme has changed!
  // Set text color to blue again.
  textLabel.TextColor = Color.Blue;
}
```
<br/>

### View.OnThemeChanged
The other way of getting this is to make a derived class of the View and override `OnThemeChanged` method.

Overriding `OnThemeChanged` enables user to control style changing in View.

```C#
class AlwaysBlueTextLabel : TextLabel
{
  protected override void OnThemeChanged(object sender, ThemeChangedEventArgs e)
  {
    // Theme has changed but the new style is not applied to this view yet.

    // Call base method to apply new style in new theme to this view.
    base.OnThemeChanged(sender, e);

    // Set text color to blue.
    textLabel.TextColor = Color.Blue;
  }
}
```
<br/>
<br/>

## Default Theme

NUI components such as Button, Switch and CheckBox need basic style by default.
For that, the default theme is defined in NUI framework and it may vary depending on device profile.

The common part of the default theme is called `Tizen.NUI.Theme.Common`, you can check the xaml code [Here](https://github.com/Samsung/TizenFX/blob/master/src/Tizen.NUI.Components/res/Theme/Tizen.NUI.Components_Tizen.NUI.Theme.Common.xaml).

In case of fhub, there are additional styles written in C#.
Please refer [here](https://github.sec.samsung.net/Tizen-DA/fhub-nui/tree/tizen_6.0_da_fhub_int/Tizen.FH.NUI/src/PreloadStyle) and note that they will be replaced to the xaml code in the near future.
<br/>
<br/>

## Samples
* Sample: [Basic1](./Basic1)
* Sample: [Basic2](./Basic2)
* Sample: [TodoList](./TodoList)
<br/>
<br/>

## More Information
* [NUI Xaml style syntax](./docs/NUIXamlStyleSyntax.md)