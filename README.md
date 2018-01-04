# MvxScaffolding (Preview)

[![NuGet](https://img.shields.io/nuget/v/MvxScaffolding.Templates.svg?style=flat-square)](https://www.nuget.org/packages/MvxScaffolding.Templates/)

A customizable template used to scaffold a cross platform MvvmCross application. Includes a .NET Standard class library. Supports Xamarin Android, Xamarin iOS and UWP project types for Xamarin Native and Xamarin Forms.

__Templates features__

 Features | mvxnative            |  mvxforms
:-------------------------:|:-------------------------:|:-------------------------:
.NET Standard class library |* |*
Package references |* |*
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
 * Xamarin iOS _(Recommanded version 11.0+)_
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

For details on the available customisation options for the template use the `--help`/`-h` command

```text
dotnet new mvxnative --help
```

### Template directory layout

    .
    ├── src
    │   ├── <NAME>.Core             # Core .NET Standard library
    │   ├── <NAME>.Droid            # Android project (Optional)
    │   ├── <NAME>.iOS              # iOS Project (Optional)
    │   └── <NAME>.UWP              # UWP Project (Optional)
    ├── test
    │   ├── <NAME>.Core.Test        # Core .NET Standard library (Optional)
    │   ├── <NAME>.Droid.Test       # Android unit test project (Optional)
    │   ├── <NAME>.Droid.UI.Test    # Android UI test project (Optional)
    │   ├── <NAME>.iOS.Test         # iOS unit test Project (Optional)
    │   ├── <NAME>.iOS.UI.Test      # iOS UI test Project (Optional)
    │   ├── <NAME>.UWP.Test         # UWP unit test Project (Optional)
    │   └── <NAME>.UWP.UI.Test      # UWP UI test Project (Optional)
    └── .editorconfig               # Root editor config (Optional)

## MvxForms - Xamarin Forms Template

To scaffold a new MvvmCross Xamarin Forms application you must use the `mvxforms` command. To specify the name of the application you can use the `--name`/`-n` options.

___Example command___ to create an application named `MyXamarinFormsApp`

```text
dotnet new mvxforms --name MyXamarinFormsApp
```

For details on the available customisation options for the template use the `--help`/`-h` command

```text
dotnet new mvxforms --help
```

### Template directory layout

    .
    ├── src
    │   ├── <NAME>.Core             # Core .NET Standard library
    │   ├── <NAME>.Droid            # Android project (Optional)
    │   ├── <NAME>.iOS              # iOS Project (Optional)
    │   └── <NAME>.UWP              # UWP Project (Optional)
    ├── test
    │   ├── <NAME>.Core.Test        # Core .NET Standard library (Optional)
    │   ├── <NAME>.UI.Test          # Android and iOS UI test project (Optional)
    │   ├── <NAME>.Droid.Test       # Android unit test project (Optional)
    │   ├── <NAME>.iOS.Test         # iOS unit test Project (Optional)
    │   ├── <NAME>.UWP.Test         # UWP unit test Project (Optional)
    │   └── <NAME>.UWP.UI.Test      # UWP UI test Project (Optional)
    └── .editorconfig               # Root editor config (Optional)

## Additional commands options

```text
  -ha|--has-android        Whether to include Xamarin Android Project.
                           bool - Optional
                           Default: true

  -hi|--has-ios            Whether to include Xamarin iOS Project.
                           bool - Optional
                           Default: true

  -hu|--has-uwp            Whether to include UWP Project.
                           bool - Optional
                           Default: true

  -ed|--has-editor-config  Whether to include an editor config in the root directory.
                           bool - Optional
                           Default: true

  -id|--app-id             The Android package name or iOS bundle Id <com.company.appname>.
                           string - Optional
                           Default: com.mvxscaffolding.app

  -app-n|--app-name        The application display name.
                           string - Optional
                           Default: Mvx Scaffolding

  --no-restore             If specified, skips the automatic restore of the project on create.
                           bool - Optional
                           Default: false

  -f|--framework           The version of .NET Standard to use in the Core project.
                               2.0    - .NET Standard 2.0
                               1.6    - .NET Standard 1.6
                               1.5    - .NET Standard 1.5
                               1.4    - .NET Standard 1.4
                           Default: 2.0

  -asdk|--android-min-sdk  Minimum Android SDK version.
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

  -isdk|--ios-min-sdk      Minimum iOS SDK version.
                               11.2    - iOS 11.2
                               11.1    - iOS 11.1
                               11.0    - iOS 11
                               10.3    - iOS 10.3
                               10.2    - iOS 10.2
                               10.1    - iOS 10.1
                               10.0    - iOS 10
                               9.3     - iOS 9.3
                               9.2     - iOS 9.2
                               9.1     - iOS 9.1
                               9.0     - iOS 9
                           Default: 10.0

  --uwp-app-description    The UWP application description.
                           string - Optional
                           Default: Laying the foundation with Mvx Scaffolding

  -usdk|--uwp-min-sdk      Minimum UWP target SDK version.
                               10.0.16299.0    - Fall Creators Update - build 16299
                               10.0.15063.0    - Creators Update - build 15063
                               10.0.14393.0    - Anniversary Update - build 14393
                               10.0.10586.0    - November Update - build 10586
                               10.0.10240.0    - RTM - build 10240
                           Default: 10.0.16299.0
```

## Licensing

MvxScaffolding is licensed under [MIT](https://github.com/Plac3hold3r/MvxScaffolding/blob/master/LICENSE)
