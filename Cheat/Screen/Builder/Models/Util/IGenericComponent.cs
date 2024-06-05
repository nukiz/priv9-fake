namespace Priv9.Cheat.Screen.Builder.Models.Util
{
    internal interface IGenericComponent
    {
        public abstract void OnClick(object sender, MouseEventArgs e);
        public abstract void Draw();
    }
}
