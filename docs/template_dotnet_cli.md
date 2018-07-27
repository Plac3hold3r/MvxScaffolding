# Template - dotnet CLI

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

## Solution project grouping

MvxScaffolding provides three choices for structuring projects inside of the generate solution: `flat`, `test-group` or `platform`. To select a solution project grouping preference you can use the `-sln-gp|--solution-project-grouping` option. The default is `flat`.

#### Flat

___Example command___ to create a solution named `MyXamarinApp` and solution project grouping of flat

```text
dotnet new mvxnative -n MyXamarinApp -sln MyXamarinApp --solution-project-grouping `flat` 
```
or
```text
dotnet new mvxnative -n MyXamarinApp -sln MyXamarinApp
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

___Example command___ to create a solution named `MyXamarinApp` and solution project grouping of `test-group`

```text
dotnet new mvxnative -n MyXamarinApp -sln MyXamarinApp --solution-project-grouping test-group
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

___Example command___ to create a solution named `MyXamarinApp` and solution project grouping of `platform`

```text
dotnet new mvxnative -n MyXamarinApp -sln MyXamarinApp --solution-project-grouping platform
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

## Additional commands options

**MvxNative** and **MvxForms** options

```text
 -droid|--include-android                Whether to include Xamarin Android project.
                                         bool - Optional
                                         Default: true

  -ios|--include-ios                     Whether to include Xamarin iOS project.
                                         bool - Optional
                                         Default: true

  -uwp|--include-uwp                     Whether to include UWP project.
                                         bool - Optional
                                         Default: false

  -core-t|--include-core-test            Whether to include Core unit test project.
                                         bool - Optional
                                         Default: false

  -droid-t|--include-android-test        Whether to include Xamarin Android unit test project.
                                         bool - Optional
                                         Default: false

  -ios-t|--include-ios-test              Whether to include Xamarin iOS unit test project.
                                         bool - Optional
                                         Default: false

  -uwp-t|--include-uwp-test              Whether to include UWP unit test project.
                                         bool - Optional
                                         Default: false

  -uwp-ui-t|--include-uwp-ui-test        Whether to include UWP UI test project.
                                         bool - Optional
                                         Default: false

  -ed|--include-editor-config            Whether to include an EditorConfig in the root directory.
                                         bool - Optional
                                         Default: true

  -sln-gp|--solution-project-grouping    The grouping for projects into folders inside of the solution.
                                             flat          - All projects are placed at the root of the solution
                                             test-group    - All test projects are placed in a test folder,
                                                                other projects are placed at the root of the solution
                                             platform      - Projects are grouped based on their target platform
                                         Default: flat

  -id|--app-id                           The Android package name or iOS bundle Id <com.company.appname>.
                                         string - Optional
                                         Default: com.mvxscaffolding.app

  -app-n|--app-name                      The application display name.
                                         string - Optional
                                         Default: Mvx Scaffolding

  -sln|--solution-name                   The solution name.
                                         string - Required

  -f|--framework                         The version of .NET Standard to use in the Core project.
                                             2.0    - .NET Standard 2.0
                                         Default: 2.0

  -droid-sdk|--android-min-sdk           Minimum Android SDK version.
                                             27    - Android 8.1 - Oreo v27
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

  -ios-sdk|--ios-min-sdk                 Minimum iOS SDK version.
                                             11.4    - iOS 11.4
                                             11.3    - iOS 11.3
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

  -uwp-desc|--uwp-app-description        The UWP application description.
                                         string - Optional
                                         Default: Laying the foundation with Mvx Scaffolding

  -uwp-sdk|--uwp-min-sdk                 Minimum UWP target SDK version.
                                             17134    - 1803 - April 2018 Update
                                             16299    - 1709 - Fall Creators Update
                                         Default: 16299
```

**MvxNative** only options

```Text
  -droid-ui-t|--include-android-ui-test  Whether to include Xamarin Android UI test project.
                                         bool - Optional
                                         Default: false

  -ios-ui-t|--include-ios-ui-test        Whether to include Xamarin iOS UI test project.
                                         bool - Optional
                                         Default: false

  -droid-l|--android-layout-type         The Android project layout pattern to use.
                                             axml    - axml, Android layout format compatible with Visual Studio tooling.
                                             xml     - xml, Android layout format compatible with Android Studio tooling.
                                         Default: axml

  -ios-l|--ios-layout-type               The iOS project layout pattern to use.
                                             fluent        - FluentLayout, a fluent API for creating constraint-based layouts.
                                             storyboard    - Storyboard, iOS layout format compatible with Xcode interface builder.
                                         Default: fluent

  -st|--scaffold-type                    The view pattern to scaffold the solution with.
                                             single-view        - Scaffold an app with a single starting view and view model.
                                             navigation-menu    - Scaffold an app with a slide out menu. Template contains two starting views with view models.
                                         Default: single-view
```

**MvxForms** only options

```Text
  -ui-t|--include-ui-test              Whether to include Xamarin Android and iOS UI test project.
                                       bool - Optional
                                       Default: false
```
