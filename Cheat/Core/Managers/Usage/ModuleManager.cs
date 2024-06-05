using Priv9.Cheat.Core.Managers.Models;
using Priv9.Cheat.Core.Managers.Models.Exceptions;
using Priv9.Cheat.Hacks.Other.Debug;
using Priv9.API.Module;
using Priv9.Cheat.Utils.Logging;
using Priv9.Cheat.Hacks.Other.Test;

namespace Priv9.Cheat.Core.Managers.Usage
{
    internal class ModuleManager : IRegistry<ModuleImpl>
    {
        private readonly List<ModuleImpl> ModuleList = [];

        public void Init()
        {
            /* Others */
            Add(new Debug());
            Add(new Debug2());
        }

        public void Add(ModuleImpl item)
        {
            if (!ModuleList.Contains(item))
                ModuleList.Add(item);
            else 
                throw new AlreadyRegisteredException($"Item {item.GetName()} has already been registered!");
        }

        public void Remove(ModuleImpl item, bool IsClosing)
        {
            ModuleList.Remove(item);
            if (!IsClosing)
                throw new UnregisterException($"Cannot unregister {item.GetName()} while running!");
        }

        public List<ModuleImpl> GetAll() => ModuleList;

        public List<ModuleImpl> GetAllFromCategory(Category Category)
        {
            List<ModuleImpl> CategoryMods = [];
            foreach (ModuleImpl Mod in ModuleList)
            {
                if (Mod.GetCategory().Equals(Category))
                    CategoryMods.Add(Mod);
            }
            return CategoryMods;
        }

        public ModuleImpl? GetModuleByType(Type ModType)
        {
            foreach (ModuleImpl mod in ModuleList)
            {
                if (mod.GetType().Equals(ModType))
                {
                    return mod;
                }
            }

            return null;
        }

        public void Close()
        {
            // Remove all non-null modules to free memory if GC didn't do so earlier
            ModuleList.RemoveAll(e => e != null);
        }
    }
}
