# MvxScaffolding (Preview)

[![NuGet](https://img.shields.io/nuget/v/MvxScaffolding.Templates.svg)](https://www.nuget.org/packages/MvxScaffolding.Templates/)
[![Visual Studio Marketplace](https://img.shields.io/vscode-marketplace/v/Plac3Hold3r.MvxScaffolding.svg)](https://marketplace.visualstudio.com/items?itemName=Plac3Hold3r.MvxScaffolding)
[![Build status](https://ci.appveyor.com/api/projects/status/lo18p4h64kul1u2v/branch/master?svg=true)](https://ci.appveyor.com/project/Plac3hold3r/mvxscaffolding/branch/master)
[![Crowdin](https://d322cqt584bo4o.cloudfront.net/mvxscaffolding/localized.svg)](https://crowdin.com/project/mvxscaffolding)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FPlac3hold3r%2FMvxScaffolding.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2FPlac3hold3r%2FMvxScaffolding?ref=badge_shield)

A customizable template used to scaffold a cross-platform MvvmCross application. Includes a .NET Standard class library. Supports Xamarin Android, Xamarin iOS and UWP project types for Xamarin Native and Xamarin Forms. Supports MvvmCross 6.1.2.

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
iOS storyboard or [FluentLayouts](https://github.com/FluentLayout/Cirrious.FluentLayout) |* |

See [Release Notes](docs/release_notes.md)

See [Changelog](/CHANGELOG.md)

## Installation

 Platform  |  Installation and System Requirements | Documentation           | Download           |
:-------------------------:|:-------------------------:|:-------------------------:|:-------------------------:
dotnet CLI | [Installation Guide](#dotnet-cli) | [Documentation](docs/template_dotnet_cli.md) | [NuGet](https://www.nuget.org/packages/MvxScaffolding.Templates/)
Visual Studio Extension | [Installation Guide](#visual-studio-extension) | [Documentation](docs/template_vs.md) | [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=Plac3Hold3r.MvxScaffolding)

## Help Translate

If you want to help translate MvxScaffolding into your native language. Please check out our [Crowdin project](https://crowdin.com/project/mvxscaffolding) page.

### Translators

Thank you to the following translators

Language | Code | Translators |
:-------------------------:|:-------------------------:|:-------------------------:
Chinese Simplified | zh-CN | [Forbidden (cptbl00dra1n)](https://crowdin.com/profile/cptbl00dra1n)
French | fr-FR | [Antoine Bichon (Chapelin)](https://crowdin.com/profile/Chapelin)
Spanish | es-ES | [Agustin Jose Wawrzyk (elpitufo)](https://crowdin.com/profile/elpitufo)
Danish | da-DK | [Tomasz Cielecki (Cheesebaron)](https://crowdin.com/profile/Cheesebaron)

## dotnet CLI

### System Requirements

In order to make use of these templates you will need to have the following installed for Windows or macOS

__Required__

 * .NET Core SDK 2.1.4+ ([Download SDK](https://www.microsoft.com/net/download))

 __Optional__ 

 * Xamarin Android SDK _(Recommended version 9.0+)_
 * Xamarin iOS SDK _(Recommended version 11.14+)_
 * UWP SDK _(__Windows Only__, recommended  version 10.0.17134+)_

### Installation

To install the template run the `-i|--install` command

```text
dotnet new --install MvxScaffolding.Templates
```

### Usage

See [documentation](docs/template_dotnet_cli.md) for how to generate a solution.

## Visual Studio 2017 Extension

### System Requirements

In order to make use of these templates you will need to have the following installed for Windows

__Required__

 * Visual Studio 2017 15.8+ ([Download Visual Studio](https://www.visualstudio.com/downloads/))
 * .NET Framework 4.7+ ([Download .NET Framework](https://www.microsoft.com/net/download/windows))

 __Optional__ 

 * Xamarin Android SDK _(Recommended version 9.0+)_
 * Xamarin iOS SDK _(Recommended version 11.14+)_
 * UWP SDK _(__Windows Only__, recommended version 10.0.17134+)_

### Installation

Download and install the VSIX from [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=Plac3Hold3r.MvxScaffolding) or search in Visual Studio extensions for `MvxScaffolding`.

### Usage

See [documentation](docs/template_vs.md) for how to generate a solution.

## Thanks

- To [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio) community
- To [.NET Template Engine](https://github.com/dotnet/templating) community
- To [SideWaffle Template Creator](https://github.com/ligershark/sidewafflev2) community
- To [MvvmCross](https://github.com/MvvmCross/MvvmCross) community
- To [Crowdin](https://crowdin.com) for supporting localization for MvxScaffolding

## License


[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2FPlac3hold3r%2FMvxScaffolding.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2FPlac3hold3r%2FMvxScaffolding?ref=badge_large)

##### Third party libraries
- [MvvmCross](https://github.com/MvvmCross/MvvmCross) is licensed under [MS-PL](https://github.com/MvvmCross/MvvmCross/blob/master/LICENSE)
- [FluentLayout](https://github.com/FluentLayout/Cirrious.FluentLayout) is licensed under [MS-PL](https://github.com/FluentLayout/Cirrious.FluentLayout/blob/master/LICENSE)
- [Xamarin Android Support Library](https://github.com/xamarin/AndroidSupportComponents/) is licensed under [MIT](https://github.com/xamarin/AndroidSupportComponents/blob/master/LICENSE.md)

MvxScaffolding is licensed under [MIT](https://github.com/Plac3hold3r/MvxScaffolding/blob/master/LICENSE)

## Privacy Policy

The MvxScaffolding Visual Studio extension makes use of 3rd party crash and analytics reporting. See the [privacy policy](docs/privacy_policy.md) for more information.
