// Spdlog Tinfoil build script

using Sharpmake;
using System;
using System.IO;
using System.Collections.Generic;

[Sharpmake.Generate]
public class Spdlog : TinfoilProjectBase
{
	public Spdlog()
	{
		Name = "Spdlog";
		SourceFiles.Add("Spdlog.Build.cs");
	}

	[Sharpmake.Configure]
	public void ConfigureAll(Project.Configuration config, Target target)
	{
		config.Output = Configuration.OutputType.Lib;

		config.Options.Add(Options.Vc.Compiler.CppLanguageStandard.CPP17);
		config.Options.Add(Options.Vc.Compiler.Exceptions.EnableWithSEH);
		config.Options.Add(Options.Vc.General.WindowsTargetPlatformVersion.Latest);
		config.Options.Add(Options.Vc.Librarian.TreatLibWarningAsErrors.Enable);

		config.IncludePaths.Add("/include");
		config.AdditionalCompilerOptions.Add("/utf-8");

		if (config.Output == Configuration.OutputType.Lib)
		{
			config.Defines.Add("SPDLOG_COMPILED_LIB");
		}

		ExcludeFolder(config, target, "tests");
		ExcludeFolder(config, target, "bench");
		ExcludeFolder(config, target, "example");
	}
}
