using Priv9.API.Module;
using Priv9.Cheat.Core.Managers.Models;
using Priv9.Cheat.Core.Managers.Usage;
using Priv9.Cheat.Utils.Logging;
using System.Reflection;

namespace Priv9.Cheat.Core.Managers
{
    internal class Managers
    {
        public static readonly ModuleManager MODULES = new();
        // public static readonly ThreadManager THREADS = ThreadManager.GetInstance();
        private static readonly List<IRegistry<ModuleImpl>> Registeries = [];

        public static void Init()
        {
            long Time = DateTimeOffset.Now.ToUnixTimeSeconds();
            Logger.Log("loading managers");
            MODULES.Init();
            Logger.Log($"all done, took {DateTimeOffset.Now.ToUnixTimeSeconds() - Time}ms");
        }

        public static void Uninit()
        {
            foreach(IRegistry<dynamic> registry in Registeries)
            {
                registry.Close();
            }
        }
    }
}
