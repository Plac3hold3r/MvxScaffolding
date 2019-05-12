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

#tool nuget:?package=GitVersion.CommandLine&version=4.0.0
#addin nuget:?package=Cake.Figlet&version=1.2.0
#addin nuget:?package=Newtonsoft.Json&version=12.0.2

//////////////////////////////////////////////////////////////////////
// EXTERNAL SCRIPTS
//////////////////////////////////////////////////////////////////////

#load "./build/parameters.cake"

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////

var solutionName = "MvxScaffolding";
var solutionPathVsix = File("./MvxScaffolding.Vsix.sln");
var outputDir = new DirectoryPath("./artifacts");
var gitVersionLog = new FilePath("./artifacts/gitversion.log");
var nuspecFile = new FilePath("./nuspec/MvxScaffolding.Templates.nuspec");

var isRunningOnAzurePipelines = BuildSystem.IsRunningOnAzurePipelines ;
GitVersion versionInfo = null;

Information(Figlet(solutionName));

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(context => 
{
    versionInfo = context.GitVersion(new GitVersionSettings 
    {
        OutputType = GitVersionOutput.Json,
        LogFilePath = gitVersionLog.MakeAbsolute(context.Environment)
    });

    var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();

    Information(Newtonsoft.Json.JsonConvert.SerializeObject(versionInfo));

    Information("Building version {0}, ({1}, {2}) using version {3} of Cake.",
        versionInfo.SemVer,
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
    CleanDirectories(outputDir.FullPath);

    EnsureDirectoryExists(outputDir);
});

Task("Build-NuGet-Package")
  .Does(() =>
{
    var nuGetPackSettings = new NuGetPackSettings
	  {
		  OutputDirectory = outputDir,
		  Version = versionInfo.NuGetVersion
	  };

    NuGetPack(nuspecFile, nuGetPackSettings);
});

Task("Restore-NuGet-Packages")
	.Does(() =>
{
	Information("Restoring solution...");
	NuGetRestore("./MvxScaffolding.Vsix.sln");
});

Task("Update-Manifest-Version")
    .Does(() =>
{
    var settings = new XmlPokeSettings
    {
        Namespaces = new Dictionary<string, string> 
        {
            {"vsx", "http://schemas.microsoft.com/developer/vsx-schema/2011"}
        }
    };

    XmlPoke("./src/MvxScaffolding.Vsix/source.extension.vsixmanifest", "/vsx:PackageManifest/vsx:Metadata/vsx:Identity/@Version", 
        versionInfo.MajorMinorPatch, settings);
});

Task("Build-VSIX")
.Does(() => {
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

Task("Post-Build")
.Does(() => {
  Information("Moving to artifact directory...");
  CopyFileToDirectory("./src/MvxScaffolding.Vsix/bin/Release/MvxScaffolding.Vsix.vsix", outputDir);
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

RunTarget(target);
