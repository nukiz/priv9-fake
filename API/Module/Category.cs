using Priv9.Cheat.Screen;

namespace Priv9.API.Module
{
    /// <summary>
    /// Weird pseudoclass that represents an enum constructor ?????
    /// Maybe this could be better
    /// </summary>
    public class Category(Label Linked)
    {
        public static Category Aimbot = null!;
        public static Category Visuals = null!;
        public static Category Misc = null!;

        private readonly Label Linked = Linked;

        public Label GetLabel() => Linked;
        public static Category[] Values() => [ Aimbot, Visuals, Misc ];

        public static void HandleRegistries(Priv9Screen scr)
        {
            Aimbot = new(scr.AimbotTabLabel);
            Visuals = new(scr.VisualTabLabel);
            Misc = new(scr.MiscTabLabel);
        }
    }

    public enum CategoryImpl
    {
        Aimbot,
        Visuals,
        Misc
    }
}
