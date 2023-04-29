using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
    "VisualStudioMac.CreateGuid",
    Namespace = "VisualStudioMac.CreateGuid",
    Version = "0.0.1"
)]

[assembly: AddinName("Create Guid Addin")]
[assembly: AddinCategory("Utility")]
[assembly: AddinDescription("Create Guid Addin for Visual Studio for Mac")]
[assembly: AddinAuthor("Adam Mitchell")]
[assembly: AddinUrl("https://github.com/itadam/VS4Mac-CreateGuid")]

[assembly: AddinDependency("::MonoDevelop.Core", BuildInfo.Version)]
[assembly: AddinDependency("::MonoDevelop.Ide", BuildInfo.Version)]
