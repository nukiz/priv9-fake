using Priv9.API.Module;
using Priv9.Cheat.Screen.Builder.Models.Tabs;
using Priv9.Cheat.Screen.Builder.Models.Util;
using Priv9.Cheat.Utils.Logging;

namespace Priv9.Cheat.Screen.Builder
{
    /// <summary>
    /// Builds the Cheat GUI.
    /// </summary>
    internal class ScreenBuilder
    {
        private static ScreenBuilder? INSTANCE;
        public List<AbstractTab> Tabs = [];
        public List<IGenericComponent> Components = [];
        public List<Panel> ComponentPanels = [];

        private ScreenBuilder() { }

        /// <summary>
        /// Sets up the cheat GUI automatically, 
        /// so no manual FormDesigning is necessary.
        /// </summary>
        internal void Build(Priv9Screen scr)
        {
            Logger.Log("building gui");
            scr.SuspendLayout();
            HandleLabels(scr);
            Logger.Log("labels handled");
            HandleTabs();
            Logger.Log("tabs handled");
            FinishDrawing();
            Logger.Log("all done");
            scr.ResumeLayout();
            scr.Update();
        }

        private void FinishDrawing()
        {
            if (Tabs.Count <= 0)
                Logger.Log("no tabs found, skipping", true);

            foreach (AbstractTab tab in Tabs)
            {
                tab.Draw();
            }

            if (Components.Count <= 0)
                Logger.Log("no components found, skipping", true);

            foreach (IGenericComponent component in Components)
            {
                component.Draw();
            }
        }

        private void HandleTabs()
        {
            if (Category.Values().Length <= 0)
                Logger.Log("no categories found, ur cheat is fucked i think", true);
            foreach (Category cat in Category.Values())
            {
                CategoryTab tab = new(cat.GetLabel(), cat);
                cat.GetLabel().MouseDown += tab.OnClick;
                Tabs.Add(tab);
            }
        }

        private static void HandleLabels(Priv9Screen scr)
        {
            scr.LogoLabel.Location = new(scr.Width / 2 - (scr.LogoLabel.Width / 2),
                scr.LogoLabel.Location.Y);
            scr.AimbotTabLabel.Location = new(scr.Width / 3 - (int) (scr.VisualTabLabel.Width * 1.5f),
                scr.AimbotTabLabel.Location.Y);
            scr.VisualTabLabel.Location = new(scr.Width / 2 - (scr.VisualTabLabel.Width / 2),
                scr.VisualTabLabel.Location.Y);
            scr.MiscTabLabel.Location = new(scr.Width / 3 * 2 + (int) (scr.VisualTabLabel.Width / 1.4f),
                scr.MiscTabLabel.Location.Y);
        }

        internal static ScreenBuilder GetInstance() => INSTANCE ??= INSTANCE = new();
    }
}
