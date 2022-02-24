project "spdlog"
	kind "StaticLib"
	language "C++"
	cppdialect "C++17"
	staticruntime "On"
	
	targetdir ("bin/" .. outputdir .. "/%{prj.name}")
	objdir ("bin-int/" .. outputdir .. "/%{prj.name}")

	files
	{
		"src/**.h",
		"src/**.cpp",

		"include/spdlog/**.h",
		"include/spdlog/**.cpp",
	}

	sysincludedirs
	{
		"include"
	}

	defines 
	{
		"SPDLOG_COMPILED_LIB",
	}
	
	filter "system:windows"
		systemversion "latest"

	filter "configurations:Debug"
		runtime "Debug"
		symbols "On"	-- debug version --

	filter "configurations:Release"
		runtime "Release"
		optimize "Full"	-- release version --
		inlining "Auto"
		floatingpoint "Fast"
