## System Requirements

In order to make use of these templates you will need to have the following installed for Windows or macOS

__Required__

 * .NET Core SDK 2.1.4+ ([Download SDK](https://www.microsoft.com/net/download))

 __Optional__ 

 * Xamarin Android SDK _(Recommended version 8.3+)_
 * Xamarin iOS SDK _(Recommended version 11.12+)_
 * UWP SDK _(__Windows Only__, recommended version 10.0.17134+)_

## Installation

To install the template run the `-i|--install` command

```text
dotnet new --install MvxScaffolding.Templates::*
```
## MvxNative - Xamarin Native Template

To scaffold a new MvvmCross Xamarin application you must use the `mvxnative` command. To specify a name for the projects you can use the `-n|--name` option and `-sln|--solution-name` for the solution name.

___Example command___ to create a projects prefixed with `MyXamarinApp` and a solution file named `MyXamarinApp`

```text
dotnet new mvxnative --name MyXamarinApp --solution-name MyXamarinApp
```

For details on the available customisation options for the template use the `-h|--help` option

```text
dotnet new mvxnative --help
```

## MvxForms - Xamarin Forms Template

To scaffold a new MvvmCross Xamarin Forms application you must use the `mvxforms` command. To specify a name for the projects you can use the `-n|--name` option and `-sln|--solution-name` for the solution name.

___Example command___ to create a projects prefixed with `MyXamarinFormsApp` and a solution file named `MyXamarinApp`

```text
dotnet new mvxforms --name MyXamarinFormsApp --solution-name MyXamarinFormsApp
```

For details on the available customisation options for the template use the `-h|--help` option

```text
dotnet new mvxforms --help
```
