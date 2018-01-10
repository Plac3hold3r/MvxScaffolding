# MvxScaffolding (Preview)

[![NuGet](https://img.shields.io/nuget/v/MvxScaffolding.Templates.svg?style=flat-square)](https://www.nuget.org/packages/MvxScaffolding.Templates/)

A customizable template used to scaffold a cross platform MvvmCross application. Includes a .NET Standard class library. Supports Xamarin Android, Xamarin iOS and UWP project types for Xamarin Native and Xamarin Forms.

__Templates features__

 Features | mvxnative            |  mvxforms
:-------------------------:|:-------------------------:|:-------------------------:
[.NET Standard class library](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) |* |*
[Package references](https://docs.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files) |* |*
Unit test projects |* |*
UI test projects |* |*
Android Nougat round icons |* |*
Android Oreo adaptive icons |* |*
Android support constraint layout |* |
Android AXML or XML layout |* |
iOS storyboard launch screen |* | *
iOS [Hyperion](https://github.com/willowtreeapps/Hyperion-iOS) |* | *
iOS storyboard or [FluentLayouts](https://github.com/FluentLayout/Cirrious.FluentLayout) |* |

## System Requirements

In order to make use of these templates you will need to have the following installed for Windows or macOS

__Required__

 * .NET Core SDK 2.0.0+ ([Download SDK](https://www.microsoft.com/net/download))

 __Optional__ 

 * Xamarin Android _(Recommanded version 8.0+)_
 * Xamarin iOS _(Recommanded version 10.14+)_
 * UWP SDK _(__Windows Only__, recommanded version 10.0.16299+)_

## Installation

To install the template run the `--install`/`-i` command

```text
dotnet new --install MvxScaffolding.Templates::*
```

## MvxNative - Xamarin Native Template

To scaffold a new MvvmCross Xamarin application you must use the `mvxnative` command. To specify the name of the application you can use the `--name`/`-n` options.

___Example command___ to create an application named `MyXamarinApp`

```text
dotnet new mvxnative --name MyXamarinApp
```

For details on the available customization options for the template use the `--help`/`-h` command

```text
dotnet new mvxnative --help
```

## MvxForms - Xamarin Forms Template

To scaffold a new MvvmCross Xamarin Forms application you must use the `mvxforms` command. To specify the name of the application you can use the `--name`/`-n` options.

___Example command___ to create an application named `MyXamarinFormsApp`

```text
dotnet new mvxforms --name MyXamarinFormsApp
```

For details on the available customization options for the template use the `--help`/`-h` command

```text
dotnet new mvxforms --help
```

## Solution project grouping

MvxScaffolding provides three choices for structuring projects inside of the generate solution: `flat`, `test-group` or `platform`. To select a solution project grouping preference you can use the `--solution-project-grouping`/`-sln-gp` option. The default is `flat`.

#### Flat

___Example command___ to create an application named `MyXamarinApp` and solution project grouping of flat

```text
dotnet new mvxnative -n MyXamarinApp --solution-project-grouping `flat` 
```
or
```text
dotnet new mvxnative -n MyXamarinApp
```

<pre>
    .
    ├── !Solution Items
    │   └── .editorconfig        # Root editor config (<b>Optional</b>)
    ├── {NAME}.Core              # Core .NET Standard library
    ├── {NAME}.Core.Test         # Core .NET Standard library (<b>Optional</b>)
    ├── {NAME}.Droid             # Android project (<b>Optional</b>)
    ├── {NAME}.Droid.Shared      # Android shared project included for unit testing (<b>Optional</b>)
    ├── {NAME}.Droid.Test        # Android unit test project (<b>Optional</b>)
    ├── {NAME}.Droid.UI.Test     # Android UI test project (<b>MvxNative Optional</b>)
    ├── {NAME}.iOS               # iOS project (<b>Optional</b>)
    ├── {NAME}.iOS.Test          # iOS unit test project (<b>Optional</b>)
    ├── {NAME}.iOS.UI.Test       # iOS UI test project (<b>MvxNative Optional</b>)
    ├── {NAME}.UI                # Forms UI project (<b>MvxForms Optional</b>)
    ├── {NAME}.UI.Test           # Forms UI test project (<b>MvxForms Optional</b>)
    ├── {NAME}.UWP               # UWP project (<b>Optional</b>)
    ├── {NAME}.UWP.Test          # UWP unit test project (<b>Optional</b>)
    └── {NAME}.UWP.UI.Test       # UWP UI test project (<b>Optional</b>)
</pre>

#### Test Group

___Example command___ to create an application named `MyXamarinApp` and solution project grouping of `test-group`

```text
dotnet new mvxnative -n MyXamarinApp --solution-project-grouping test-group
```

<pre>
    .
    ├── !Solution Items
    │   └── .editorconfig           # Root editor config (<b>Optional</b>)
    ├── Tests
    │   ├── {NAME}.Core.Test        # Core .NET Standard library (<b>Optional</b>)
    │   ├── {NAME}.Droid.Test       # Android unit test project (<b>Optional</b>)
    │   ├── {NAME}.Droid.UI.Test    # Android UI test project (<b>MvxNative Optional</b>)
    │   ├── {NAME}.iOS.Test         # iOS unit test project (<b>Optional</b>)
    │   ├── {NAME}.iOS.UI.Test      # iOS UI test project (<b>MvxNative Optional</b>)
    │   ├── {NAME}.UI.Test          # Forms UI test project (<b>MvxForms Optional</b>)
    │   ├── {NAME}.UWP.Test         # UWP unit test project (<b>Optional</b>)
    │   └── {NAME}.UWP.UI.Test      # UWP UI test project (<b>Optional</b>)
    ├── {NAME}.Core                 # Core .NET Standard library
    ├── {NAME}.Droid                # Android project (<b>Optional</b>)
    ├── {NAME}.Droid.Shared         # Android shared project included for unit testing (<b>Optional</b>)
    ├── {NAME}.iOS                  # iOS project (<b>Optional</b>)
    ├── {NAME}.UI                   # Forms UI project (<b>MvxForms Optional</b>)
    └── {NAME}.UWP                  # UWP project (<b>Optional</b>)
</pre>

#### Platform

___Example command___ to create an application named `MyXamarinApp` and solution project grouping of `platform`

```text
dotnet new mvxnative -n MyXamarinApp --solution-project-grouping platform
```

<pre>
    .
    ├── !Solution Items
    │   └── .editorconfig           # Root editor config (<b>Optional</b>)
    ├── Android
    │   ├── {NAME}.Droid            # Android project (<b>Optional</b>)
    │   ├── {NAME}.Droid.Shared     # Android shared project included for unit testing (<b>Optional</b>)
    │   ├── {NAME}.Droid.Test       # Android unit test project (<b>Optional</b>)
    │   └── {NAME}.Droid.UI.Test    # Android UI test project (<b>MvxNative Optional</b>)
    ├── iOS
    │   ├── {NAME}.iOS              # iOS project (<b>Optional</b>)
    │   ├── {NAME}.iOS.Test         # iOS unit test project (<b>Optional</b>)
    │   └── {NAME}.iOS.UI.Test      # iOS UI test project (<b>MvxNative Optional</b>)
    ├── UWP
    │   ├── {NAME}.UWP              # UWP project (<b>Optional</b>)
    │   ├── {NAME}.UWP.Test         # UWP unit test project (<b>Optional</b>)
    │   └── {NAME}.UWP.UI.Test      # UWP UI test project (<b>Optional</b>)
    ├── {NAME}.Core                 # Core .NET Standard library
    ├── {NAME}.Core.Test            # Core .NET Standard library (<b>Optional</b>)
    ├── {NAME}.UI                   # Forms UI project (<b>MvxForms Optional</b>)
    └── {NAME}.UI.Test              # Forms UI test project (<b>MvxForms Optional</b>)
</pre>

## Know issues

- __Incorrect project type GUIDs__ - There is currently a [bug in Visual Studio 2017](https://github.com/dotnet/project-system/issues/1821) where Visual Studio may what to convert the `csproj` project type GUID to `9A19103F-16F7-4668-BE54-9A1E7A4F7556`. However, Visual Studio for Mac may then want to convert `csproj` project type GUID back to the correct `FAE04EC0-301F-11d3-BF4B-00C04F79EFBC`. Both GUID's are currently valid but `FAE04EC0-301F-11d3-BF4B-00C04F79EFBC` is preferred.

## Additional commands options

**MvxNative** and **MvxForms** options

```text
  -droid|--include-android             Whether to include Xamarin Android Project.
                                       bool - Optional
                                       Default: true

  -ios|--include-ios                   Whether to include Xamarin iOS Project.
                                       bool - Optional
                                       Default: true

  -uwp|--include-uwp                   Whether to include UWP Project.
                                       bool - Optional
                                       Default: true

  -core-t|--include-core-test          Whether to include Core unit test project.
                                       bool - Optional
                                       Default: false

  -droid-t|--include-android-test      Whether to include Xamarin Android unit test project.
                                       bool - Optional
                                       Default: false

  -ios-t|--include-ios-test            Whether to include Xamarin iOS unit test project.
                                       bool - Optional
                                       Default: false

  -ui-t|--include-ui-test              Whether to include Xamarin Android and iOS UI test project.
                                       bool - Optional
                                       Default: false

  -uwp-t|--include-uwp-test            Whether to include UWP unit test project.
                                       bool - Optional
                                       Default: false

  -uwp-ui-t|--include-uwp-ui-test      Whether to include UWP UI test project.
                                       bool - Optional
                                       Default: false

  -ed|--has-editor-config              Whether to include an editor config in the root directory.
                                       bool - Optional
                                       Default: true

  -sln-gp|--solution-project-grouping  The grouping for project into folder inside of the solution.
                                           flat          - All projects are placed at the root of the solution
                                           test-group    - All test projects are placed in a test folder, other projects are placed at the root of the solution
                                           platform      - Projects are grouped based on their target platform
                                       Default: flat

  -id|--app-id                         The Android package name or iOS bundle Id <com.company.appname>.
                                       string - Optional
                                       Default: com.mvxscaffolding.app

  -app-n|--app-name                    The application display name.
                                       string - Optional
                                       Default: Mvx Scaffolding

  -f|--framework                       The version of .NET Standard to use in the Core project.
                                           netstandard2.0    - .NET Standard 2.0
                                           netstandard1.6    - .NET Standard 1.6
                                           netstandard1.5    - .NET Standard 1.5
                                           netstandard1.4    - .NET Standard 1.4
                                           netstandard1.3    - .NET Standard 1.3
                                           netstandard1.2    - .NET Standard 1.2
                                           netstandard1.1    - .NET Standard 1.1
                                           netstandard1.0    - .NET Standard 1.0
                                       Default: netstandard2.0

  -droid-sdk|--android-min-sdk         Minimum Android target SDK version.
                                           26    - Android 8 - Oreo v26
                                           25    - Android 7.1 - Nougat v25
                                           24    - Android 7 - Nougat v24
                                           23    - Android 6 - Marshmallow v23
                                           22    - Android 5.1 - Lollipop v22
                                           21    - Android 5 - Lollipop v21
                                           19    - Android 4 - KitKat v19
                                           18    - Android 4.3 - Jelly Bean v18
                                           17    - Android 4.2 - Jelly Bean v17
                                           16    - Android 4.1 - Jelly Bean v16
                                           15    - Android 4.0.3 - Ice Cream Sandwich v15
                                           14    - Android 4 - Ice Cream Sandwich v14
                                       Default: 19

  -ios-sdk|--ios-min-sdk               Minimum iOS target SDK version.
                                           11.2<    - iOS 11.2
                                           11.1<    - iOS 11.1
                                           11.0<    - iOS 11
                                           10.3<    - iOS 10.3
                                           10.2<    - iOS 10.2
                                           10.1<    - iOS 10.1
                                           10.0<    - iOS 10
                                           9.3<     - iOS 9.3
                                           9.2<     - iOS 9.2
                                           9.1<     - iOS 9.1
                                           9.0<     - iOS 9
                                       Default: 10.0<

  -ios-h|--ios-include-hyperion        Whether to include Hyperion, in app design review tool, in the iOS project.
                                       bool - Optional
                                       Default: true

  --uwp-app-description                The UWP application description.
                                       string - Optional
                                       Default: Laying the foundation with Mvx Scaffolding

  -uwp-sdk|--uwp-min-sdk               Minimum UWP target SDK version.
                                           16299    - Fall Creators Update
                                           15063    - Creators Update
                                           14393    - Anniversary Update
                                           10586    - November Update
                                           10240    - RTM
                                       Default: 16299
```

**MvxNative** only options

```Text
  -droid-xml|--android-xml-layouts       Whether to XML layouts instead of AXML for Android.
                                         bool - Optional
                                         Default: false
  -ios-f|--ios-include-fluentlayout      Whether to include FluentLayout, fluent API for creating constraint-based layouts, in the iOS project.
                                         bool - Optional
                                         Default: false
```

## Licensing

##### Third party libraries
- [MvvmCross](https://github.com/MvvmCross/MvvmCross) is licensed under [MS-PL](https://github.com/MvvmCross/MvvmCross/blob/master/LICENSE)
- [Hyperion](https://github.com/willowtreeapps/Hyperion-iOS) is licensed under [MIT](https://github.com/willowtreeapps/Hyperion-iOS/blob/master/LICENSE)
- [FluentLayout](https://github.com/FluentLayout/Cirrious.FluentLayout) is licensed under [MS-PL](https://github.com/FluentLayout/Cirrious.FluentLayout/blob/master/LICENSE)
- [Xamarin Android Support Library](https://github.com/xamarin/AndroidSupportComponents/) is licensed under [MIT](https://github.com/xamarin/AndroidSupportComponents/blob/master/LICENSE.md)

MvxScaffolding is licensed under [MIT](https://github.com/Plac3hold3r/MvxScaffolding/blob/master/LICENSE)
