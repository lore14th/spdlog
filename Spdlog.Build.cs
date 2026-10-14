// Tinfoil Engine build script

using Sharpmake;
using System.IO;
using TinfoilBuildTool;

using Configuration = Sharpmake.Project.Configuration;

[BuildModule(typeof(TinfoilProject))]
public class spdlog : TinfoilThirdPartyModuleDependency
{
	private bool m_UseFmtUnicode = false;

	public spdlog(ReadOnlyModuleRules rules) : base(rules)
	{
	}

	public override void ConfigureBuild(Configuration config, ITarget target)
	{
		base.ConfigureBuild(config, target);

		config.IncludePaths.Add(Path.Combine("[project.SharpmakeCsPath]", "include"));

		if (config.Output == Configuration.OutputType.Lib)
		{
			config.Defines.Add("SPDLOG_COMPILED_LIB");
		}

		if (m_UseFmtUnicode)
		{
			config.AdditionalCompilerOptions.Add("/utf-8");
		}
		else
		{
			config.Defines.Add("FMT_UNICODE=0");
			config.ExportDefines.Add("FMT_UNICODE=0");
		}

		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "tests")));
		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "bench")));
		config.SourceFilesBuildExclude.AddRange(Directory.EnumerateFiles(Path.Combine(RootDirectory, "example")));
	}
}
