//---------------------------------------------------------------------------------
// Copyright © 2018, Jonathan Froon, Plac3hold3r+github@outlook.com
// MvxScaffolding is licensed using the MIT License
//---------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MvxScaffolding.Core.Configuration
{
    public class Config
    {
        public string RemoteTelemetryKey { get; set; }

        public string PrivacyPolicyUri { get; set; }

        public string GitHubUri { get; set; }

        public TraceEventType DiagnosticsTraceLevel { get; set; } = TraceEventType.Verbose;

        public string AuthorGitHubUri { get; set; }

        public string EditorConfigUri { get; set; }

        public string MarketShareAndroidUri { get; set; }

        public string MarketShareiOSUri { get; set; }

        public string MarketShareWindowsUri { get; set; }

        public string HelpTranslateUri { get; set; }

        public string ChangelogUri { get; set; }

        const string DefaultJsonConfigFileName = "MvxScaffolding.config.json";

        static Config _current;

        public static Config Current
        {
            get
            {
                if (_current == null)
                {
                    var currentConfigFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DefaultJsonConfigFileName);

                    if (File.Exists(currentConfigFile))
                    {
                        _current = LoadFromFile(currentConfigFile);
                        TraceUsingDefault($"Using configuration file {currentConfigFile}");
                    }
                    else
                    {
                        _current = new Config();
                        TraceUsingDefault($"Tried to use the configuration file located at {currentConfigFile}, but not found. Using default configuration.");
                    }
                }

                return _current;
            }
        }

        public static Config LoadFromFile(string jsonFilePath)
        {
            Config loadedConfig = null;

            if (!string.IsNullOrWhiteSpace(jsonFilePath) && File.Exists(jsonFilePath))
            {
                loadedConfig = DeserializeConfiguration(jsonFilePath);
            }
            else
            {
                throw new FileNotFoundException($"The file '{jsonFilePath}' does not exists. Can't load the configuration.");
            }

            return loadedConfig;
        }

        static Config DeserializeConfiguration(string path)
        {
            try
            {
                var serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.Converters.Add(new StringEnumConverter());
                var jsonData = File.ReadAllText(path, Encoding.UTF8);
                return JsonConvert.DeserializeObject<Config>(jsonData);
            }
            catch (Exception ex)
            {
                TraceUsingDefault($"Error deserializing configuration from file '{path}'. Exception:\n\r{ex.ToString()}");
                throw new ConfigurationErrorsException($"Error deserializing configuration data from file '{path}'.", ex);
                throw;
            }
        }

        static void TraceUsingDefault(string info)
        {
            Debug.Write(info);
            Trace.TraceWarning(info);
        }
    }
}
