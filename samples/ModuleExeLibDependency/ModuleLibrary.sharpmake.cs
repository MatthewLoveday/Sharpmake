// Copyright (c) Ubisoft. All Rights Reserved.
// Licensed under the Apache 2.0 License. See LICENSE.md in the project root for license information.

using Sharpmake;

namespace ModuleExeLibDependency
{
    [Sharpmake.Generate]
    public class ModuleLibraryProject : Project
    {
        public string BasePath = @"[project.SharpmakeCsPath]/codebase/ModuleLibrary";

        public ModuleLibraryProject()
        {
            Name = "ModuleLibraryProject_ProjectName";

            AddTargets(new Target(
                Platform.win64,
                DevEnv.vs2022,
                Optimization.Debug,
                OutputType.Lib
            ));

            SourceRootPath = "[project.BasePath]";

            IsFileNameToLower = false;
        }

        [Configure()]
        public void Configure(Configuration conf, Target target)
        {
            conf.Output = Configuration.OutputType.Lib;
            conf.ProjectPath = "[project.SharpmakeCsPath]/projects";
            conf.TargetLibraryPath = "[project.BasePath]/lib";
            conf.IntermediatePath = @"[conf.ProjectPath]\obj\[project.Name]\[target.Platform]_[target.Optimization]_[target.DevEnv]";

            conf.Defines.Add("_HAS_EXCEPTIONS=0");

            conf.Options.Add(Options.Vc.Librarian.TreatLibWarningAsErrors.Enable);
            conf.Options.Add(Options.Vc.Compiler.CppLanguageStandard.CPP20);

            conf.Project.ForceReferencesExport = true;

            conf.IncludePaths.Add("[project.BasePath]");
        }
    }
}
