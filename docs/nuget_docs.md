## System Requirements

In order to make use of the these templates you will need to have the following installed for Windows or macOS

__Required__

 * .NET Core SDK 2.1.4+ ([Download SDK](https://www.microsoft.com/net/download))

 __Optional__ 

 * Xamarin Android SDK _(Recommanded version 8.2+)_
 * Xamarin iOS SDK _(Recommanded version 11.8+)_
 * UWP SDK _(__Windows Only__, recommanded version 10.0.16299+)_

## Installation

To install the template run the `-i|--install` command

```text
dotnet new --install MvxScaffolding.Templates::*
```
## MvxNative - Xamarin Native Template

To scaffold a new MvvmCross Xamarin application you must use the `mvxnative` command. To specify a name for the solution you can use the `-n|--name` option.

___Example command___ to create a solution named `MyXamarinApp`

```text
dotnet new mvxnative --name MyXamarinApp
```

For details on the available customisation options for the template use the `-h|--help` option

```text
dotnet new mvxnative --help
```

## MvxForms - Xamarin Forms Template

To scaffold a new MvvmCross Xamarin Forms application you must use the `mvxforms` command. To specify a name for the solution you can use the `-n|--name` option.

___Example command___ to create a solution named `MyXamarinFormsApp`

```text
dotnet new mvxforms --name MyXamarinFormsApp
```

For details on the available customisation options for the template use the `-h|--help` option

```text
dotnet new mvxforms --help
```
