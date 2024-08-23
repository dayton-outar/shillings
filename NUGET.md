# Qarab

An intelligent task and roster management system


# Using Nuget

To add a nuget feed to Visual Studio Nuget Browser. Do the following:

1. Navigate to _Manage Nuget Packages..._ option from the project context menu
2. Click on the cog beside the _Package source_ dropdown list
3. When the dialog opens the _Package Sources_ section under Nuget Package Manager, click on the green plus button.
4. Enter the source as, http://{url}/nuget/
5. You can enter any name to reference the package source.

## Creating Nuget Package

When publishing your packages for a Nuget feed,

1. Install dotnet and nuget command line applications on your machine
2. Create a `.nuspec` file
3. Build `.nupkg` file from the `.nuspec` file

To generate a `.nuspec` file,

> nuget spec {Project Filename}.csproj

An example of filling out the `.nuspec` file can be seen below,

```xml
<?xml version="1.0" encoding="utf-8"?>
<package>
    <metadata>
        <id>Krisys.Qarab.Communication</id>
        <version>1.1.0</version>
        <title>Krisys Communication API</title>
        <authors>Gentle Ingenuity</authors>
        <owners>Krisys Limited</owners>
        <requireLicenseAcceptance>false</requireLicenseAcceptance>
        <license type="expression">MIT</license>
        <projectUrl>https://github.com/dayton-outar/qarab</projectUrl>
        <description>A library of functions for To-Do List applications</description>
        <releaseNotes>Fixed 2 bugs. New feature to add item in list.</releaseNotes>
        <copyright>© Krisys Limited 2022</copyright>
        <tags>krisys communication</tags>
    </metadata>
</package>
```
Sometimes, it is important to set the reference to the DLL in a folder entitled `\lib` that is a sibling to the `\bin` folder, where the DLL can be found. This is needed if several versions of the DLL need to be organized for targeting each version of .NET. So, the lib folder would contain the DLL that is being packaged and a reference made to the DLL in the nuspec file.

After you have completed filling in the details for the `.nuspec` file, generate the .nupkg file by running a command like below,

> nuget pack {Nuspec File Name}.nuspec

When the package file is generated, then the `.nupkg` file can be pushed to the Package Repository using the command below,

> nuget push {package file}.nupkg {apikey} -Source http://{url}/nuget

In the event that you need to remove an entry from the Nuget server, you can execute the following command,

> nuget delete {packageId} {version} {apiKey} -Source http://{url}/gkpm/nuget

## Further Reading

1. [MailKit](https://github.com/jstedfast/MailKit)
2. [How to generate documentation with DocFX using XML documentation file?](https://stackoverflow.com/questions/53965517/how-to-generate-documentation-with-docfx-using-xml-documentation-file)
3. [Create a package using the nuget.exe CLI](https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package)
4. [How to Use NuGet Packages: The Ultimate Guide](https://www.syncfusion.com/blogs/post/how-to-use-nuget-packages.aspx)
5. [Nuget CLI Reference](https://docs.microsoft.com/en-us/nuget/reference/nuget-exe-cli-reference)
6. [Creating and Publishing the Package in a Local NuGet Server](https://www.syncfusion.com/succinctly-free-ebooks/nuget-in-house-succinctly/creating-and-publishing-the-package-in-a-local-nuget-server)
7. [How to create a multi architecture NuGet Package from a UWP class library](https://msicc.net/how-to-create-a-multi-architecture-nuget-package-from-a-uwp-class-library/)