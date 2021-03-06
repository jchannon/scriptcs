﻿using ScriptCs.Contracts;

namespace ScriptCs.Engine.Roslyn
{
    [Module(ModuleName)]
    public class RoslynModule : IModule
    {
        public const string ModuleName = "roslyn";

        public void Initialize(IModuleConfiguration config)
        {
            Guard.AgainstNullArgument("config", config);

            if (!config.Overrides.ContainsKey(typeof(IScriptEngine)))
            {
                var engineType = config.Cache ? typeof(RoslynScriptPersistentEngine) : typeof(RoslynScriptEngine);
                engineType = config.Debug ? typeof(RoslynScriptInMemoryEngine) : engineType;
                engineType = config.Repl ? typeof(RoslynScriptEngine) : engineType;
                config.Overrides[typeof(IScriptEngine)] = engineType;
            }
        }
    }
}
