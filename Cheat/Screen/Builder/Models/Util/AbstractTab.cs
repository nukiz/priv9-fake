namespace Priv9.Cheat.Screen.Builder.Models.Util
{
    internal abstract class AbstractTab(Control Linked)
    {
        private readonly Control LinkedControl = Linked;

        public abstract void OnClick(object sender, EventArgs e);
        public abstract void Draw();

        public Control GetLinked() => LinkedControl;
    }
}
