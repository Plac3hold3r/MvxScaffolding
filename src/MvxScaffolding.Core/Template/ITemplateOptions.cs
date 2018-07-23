//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using MvxScaffolding.Core.ViewModels;

namespace MvxScaffolding.Core.Template
{
    public interface ITemplateOptions
    {
        bool HasAndroid { get; set; }

        bool HasIos { get; set; }

        bool HasUwp { get; set; }

        bool HasCoreUnitTestProject { get; set; }

        bool HasAndroidUnitTestProject { get; set; }

        bool HasIosUnitTestProject { get; set; }

        bool HasUwpUnitTestProject { get; set; }

        bool HasUwpUiTestProject { get; set; }

        bool HasEditorConfig { get; set; }

        ScaffoldTemplateOptionViewModel SelectedScaffoldType { get; set; }

        string SelectedProjectGrouping { get; set; }

        string AppId { get; set; }

        string AppName { get; set; }

        string SolutionName { get; set; }

        string SelectedNetStandard { get; set; }

        string SelectedMinAndroidSDK { get; set; }

        string SelectedMinIosSDK { get; set; }

        string SelectedMinUwpSDK { get; set; }

        string UwpDescription { get; set; }

        bool HasAndroidUiTestProject { get; set; }

        bool HasIosUiTestProject { get; set; }

        string SelectedAndroidLayoutType { get; set; }

        string SelectedIosLayoutType { get; set; }
    }
}
