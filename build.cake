///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var verbosityArg = Argument("verbosity", "Minimal");
var verbosity = Verbosity.Minimal;

//////////////////////////////////////////////////////////////////////
// TOOLS / ADDINS
//////////////////////////////////////////////////////////////////////

#addin nuget:?package=Cake.Figlet&version=1.2.0
#addin nuget:?package=Cake.Npx&version=1.3.0
#addin nuget:?package=SemanticVersioning&version=1.2.0

//////////////////////////////////////////////////////////////////////
// EXTERNAL SCRIPTS
//////////////////////////////////////////////////////////////////////

#load "./build/parameters.cake"

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////

using System.Text.RegularExpressions;

var solutionName = "MvxScaffolding";
var solutionPathVsix = File("./MvxScaffolding.Vsix.sln");
var outputDirVsix = new DirectoryPath("./artifacts/Vsix");
var outputDirNuGet = new DirectoryPath("./artifacts/NuGet");
var nuspecFile = new FilePath("./nuspec/MvxScaffolding.Templates.nuspec");

var isRunningOnAzurePipelines = BuildSystem.IsRunningOnAzurePipelines ;
SemVer.Version versionInfo = null;

Information(Figlet(solutionName));

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context => 
{
    var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();

    string[] redirectedStandardOutput = null;

    Npx("standard-version",
        args => args.Append("--dry-run"),
        out redirectedStandardOutput);
        
    Regex regex = new Regex(@"(?<=\[).+?(?=\])");
    Match match = regex.Match(redirectedStandardOutput[3]);

    if (!match.Success)
        throw new InvalidOperationException ("Can not parse a build version number.");

    versionInfo = new SemVer.Version(match.Value);

    Information("Building version {0}, ({1}, {2}) using version {3} of Cake.",
        versionInfo.ToString(),
        configuration,
        target,
        cakeVersion);

    verbosity = (Verbosity) Enum.Parse(typeof(Verbosity), verbosityArg, true);
});

Teardown(ctx =>
{
    Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean").Does(() =>
{
    Information("Cleaning common files...");
    CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
    CleanDirectories(outputDirVsix.FullPath);
    CleanDirectories(outputDirNuGet.FullPath);

    EnsureDirectoryExists(outputDirVsix);
    EnsureDirectoryExists(outputDirNuGet);
});

Task("Build-NuGet-Package").Does(() =>
{
    var nuGetPackSettings = new NuGetPackSettings
      {
          OutputDirectory = outputDirNuGet,
          Version = versionInfo.ToString()
      };

    NuGetPack(nuspecFile, nuGetPackSettings);
});

Task("Restore-NuGet-Packages").Does(() =>
{
    Information("Restoring solution...");
    NuGetRestore("./MvxScaffolding.Vsix.sln");
});

Task("Update-Manifest-Version").Does(() =>
{
    var settings = new XmlPokeSettings
    {
        Namespaces = new Dictionary<string, string> 
        {
            {"vsx", "http://schemas.microsoft.com/developer/vsx-schema/2011"}
        }
    };

    XmlPoke("./src/MvxScaffolding.Vsix/source.extension.vsixmanifest", "/vsx:PackageManifest/vsx:Metadata/vsx:Identity/@Version", 
        versionInfo.ToString(), settings);
});

Task("Build-VSIX").Does(() => 
{
    Information("Building solution...");

    MSBuild(solutionPathVsix, settings =>
        settings.SetPlatformTarget(PlatformTarget.MSIL)
            .SetMSBuildPlatform(MSBuildPlatform.x86)
            .UseToolVersion(MSBuildToolVersion.VS2019)
            .WithProperty("TreatWarningsAsErrors","true")
            .SetVerbosity(Verbosity.Quiet)
            .WithTarget("Build")
            .SetConfiguration(configuration));
});

Task("Post-Build").Does(() => 
{
  Information("Moving to artifact directory...");

  CopyFileToDirectory("./src/MvxScaffolding.Vsix/bin/Release/MvxScaffolding.Vsix.vsix", outputDirVsix);
  MoveFile("./artifacts/Vsix/MvxScaffolding.Vsix.vsix", "./artifacts/Vsix/MvxScaffolding.vsix");
});

Task("Build-Release").Does(() => 
{
    Information("Bumping version and updating changelog...");
    Npx("standard-version");
});

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Build-NuGet-Package")
    .IsDependentOn("Update-Manifest-Version")
    .IsDependentOn("Build-VSIX")
    .IsDependentOn("Post-Build")
  .Does(() =>
{
  
});

Task("Release")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Build-NuGet-Package")
    .IsDependentOn("Update-Manifest-Version")
    .IsDependentOn("Build-VSIX")
    .IsDependentOn("Post-Build")
    .IsDependentOn("Build-Release")
  .Does(() =>
{
  
});

RunTarget(target);
