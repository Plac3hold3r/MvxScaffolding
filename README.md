# MvxScaffolding (Preview)

[![NuGet](https://img.shields.io/nuget/v/MvxScaffolding.Templates.svg?style=flat-square)](https://www.nuget.org/packages/MvxScaffolding.Templates/)
[![Visual Studio Marketplace](https://img.shields.io/vscode-marketplace/v/ritwickdey.LiveServer.svg?style=flat-square)]()

A customizable template used to scaffold a cross platform MvvmCross application. Includes a .NET Standard class library. Supports Xamarin Android, Xamarin iOS and UWP project types for Xamarin Native and Xamarin Forms.

![MvxScaffolding screenshot](docs/resources/vs_template_banner.png)

__Templates features__

 Features    | mvxnative            |  mvxforms
:-------------------------:|:-------------------------:|:-------------------------:
[.NET Standard class library](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) |* |*
[Package references](https://docs.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files) |* |*
Unit test projects |* |*
UI test projects |* |*
Solution [EditorConfig](https://docs.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options) |* |*
Android Nougat round icons |* |*
Android Oreo adaptive icons |* |*
Android support constraint layout |* |
Android AXML or XML layout |* |
iOS storyboard launch screen |* | *
iOS [Hyperion](https://github.com/willowtreeapps/Hyperion-iOS) |* | *
iOS storyboard or [FluentLayouts](https://github.com/FluentLayout/Cirrious.FluentLayout) |* |

## Installation

 Platform  |  Installation and System Requirements | Documentation           | Download           |
:-------------------------:|:-------------------------:|:-------------------------:|:-------------------------:
dotnet CLI | [Installation Guide](#dotnet-CLI) | [Documentation](docs/template_dotnet_cli.md) | [NuGet](https://www.nuget.org/packages/MvxScaffolding.Templates/)
Visual Studio Extension | [Installation Guide](#visual-studio-extension) | [Documentation](docs/template_vs.md) | [Visual Studio Marketplace]()

## dotnet CLI

### System Requirements

In order to make use of the these templates you will need to have the following installed for Windows or macOS

__Required__

 * .NET Core SDK 2.1.4+ ([Download SDK](https://www.microsoft.com/net/download))

 __Optional__ 

 * Xamarin Android _(Recommanded version 8.0+)_
 * Xamarin iOS _(Recommanded version 10.14+)_
 * UWP SDK _(__Windows Only__, recommanded version 10.0.16299+)_

### Installation

To install the template run the `-i|--install` command

```text
dotnet new --install MvxScaffolding.Templates::*
```

### Usage

See [documentation](docs/template_vs.md) for how to generate a solution.

## Visual Studio Extension

### System Requirements

In order to make use of the these templates you will need to have the following installed for Windows

__Required__

 * Visual Studio 2017 15.5+ ([Download Visual Studio](https://www.visualstudio.com/downloads/))
 * .NET Framework 4.7+ ([Download .NET Framework](https://www.microsoft.com/net/download/windows))

 __Optional__ 

 * Xamarin Android _(Recommanded version 8.0+)_
 * Xamarin iOS _(Recommanded version 10.14+)_
 * UWP SDK _(__Windows Only__, recommanded version 10.0.16299+)_

### Installation

Download and install the VSIX from [Visual Studio Marketplace]() or search in Visual Studio extensions for `MvxScaffolding`.

### Usage

See [documentation](docs/template_dotnet_cli.md) for how to generate a solution.

## Known issues

- __Incorrect project type GUIDs__ - There is currently a [bug in Visual Studio 2017](https://github.com/dotnet/project-system/issues/1821) where Visual Studio will what to convert the new `csproj` project type GUID to `9A19103F-16F7-4668-BE54-9A1E7A4F7556`. However, Visual Studio for Mac will then want to convert `csproj` project type GUID back to the correct `FAE04EC0-301F-11d3-BF4B-00C04F79EFBC`. Both GUID's are currently valid but `FAE04EC0-301F-11d3-BF4B-00C04F79EFBC` is preferred going forward.

## Thanks

- To [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio) community
- To [.NET Template Engine](https://github.com/dotnet/templating) community
- To [SideWaffle Template Creator](https://github.com/ligershark/sidewafflev2) community
- To [MvvmCross](https://github.com/MvvmCross/MvvmCross) community

## License

##### Third party libraries
- [MvvmCross](https://github.com/MvvmCross/MvvmCross) is licensed under [MS-PL](https://github.com/MvvmCross/MvvmCross/blob/master/LICENSE)
- [Hyperion](https://github.com/willowtreeapps/Hyperion-iOS) is licensed under [MIT](https://github.com/willowtreeapps/Hyperion-iOS/blob/master/LICENSE)
- [FluentLayout](https://github.com/FluentLayout/Cirrious.FluentLayout) is licensed under [MS-PL](https://github.com/FluentLayout/Cirrious.FluentLayout/blob/master/LICENSE)
- [Xamarin Android Support Library](https://github.com/xamarin/AndroidSupportComponents/) is licensed under [MIT](https://github.com/xamarin/AndroidSupportComponents/blob/master/LICENSE.md)

MvxScaffolding is licensed under [MIT](https://github.com/Plac3hold3r/MvxScaffolding/blob/master/LICENSE)

## Privacy Policy

The MvxScaffolding Visual Studio extension makes use of 3rd party crash and analytics reporting. See the [privacy policy](docs/privacy_policy.md) for more information.
