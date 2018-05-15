//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System.Collections.Generic;
using MvxScaffolding.Localization.Resources;

namespace MvxScaffolding.Core.Template
{
    public static class TemplateChoices
    {
        public static Dictionary<string, string> ProjectGroupingOptions => new Dictionary<string, string>
        {
            ["flat"] = LocalResources.Template_Choice_ProjectGroup_Flat,
            ["test-group"] = LocalResources.Template_Choice_ProjectGroup_TestGroup,
            ["platform"] = LocalResources.Template_Choice_ProjectGroup_Platform
        };

        public static string ProjectGroupingOptionDefault => "flat";

        public static Dictionary<string, string> NetStandardOptions => new Dictionary<string, string>
        {
            ["2.0"] = ".NET Standard 2.0"
        };

        public static string NetStandardOptionDefault => "2.0";

        public static Dictionary<string, string> MinAndroidSDKOptions => new Dictionary<string, string>
        {
            ["27"] = "Android 8.1 - Oreo v27",
            ["26"] = "Android 8 - Oreo v26",
            ["25"] = "Android 7.1 - Nougat v25",
            ["24"] = "Android 7 - Nougat v24",
            ["23"] = "Android 6 - Marshmallow v23",
            ["22"] = "Android 5.1 - Lollipop v22",
            ["21"] = "Android 5 - Lollipop v21",
            ["19"] = "Android 4 - KitKat v19",
            ["18"] = "Android 4.3 - Jelly Bean v18",
            ["17"] = "Android 4.2 - Jelly Bean v17",
            ["16"] = "Android 4.1 - Jelly Bean v16",
            ["15"] = "Android 4.0.3 - Ice Cream Sandwich v15",
            ["14"] = "Android 4 - Ice Cream Sandwich v14",
        };

        public static string MinAndroidSDKOptionDefault => "19";

        public static Dictionary<string, string> MinIosSDKOptions => new Dictionary<string, string>
        {
            ["11.3"] = "iOS 11.3",
            ["11.2"] = "iOS 11.2",
            ["11.1"] = "iOS 11.1",
            ["11.0"] = "iOS 11",
            ["10.3"] = "iOS 10.3",
            ["10.2"] = "iOS 10.2",
            ["10.1"] = "iOS 10.1",
            ["10.0"] = "iOS 10",
            ["9.3"] = "iOS 9.3",
            ["9.2"] = "iOS 9.2",
            ["9.1"] = "iOS 9.1",
            ["9.0"] = "iOS 9.0",
        };

        public static string MinIosSDKOptionDefault => "10.0";

        public static Dictionary<string, string> MinUwpSDKOptions => new Dictionary<string, string>
        {
            ["17134"] = "1803 - April 2018 Update",
            ["16299"] = "1709 - Fall Creators Update"
        };

        public static string MinUwpSDKOptionDefault => "16299";
    }
}
