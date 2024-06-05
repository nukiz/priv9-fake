namespace Priv9.Cheat.Screen.Builder.Models.Util
{
    internal abstract class AbstractComponent<T>(AbstractTab Tab, T Representing) 
        : IGenericComponent
    {
        private readonly AbstractTab Tab = Tab;
        private readonly T Representing = Representing;

        public abstract void OnClick(object sender, MouseEventArgs e);
        public abstract void Draw();

        public T GetRepresenting() => Representing;
        public AbstractTab GetTab() => Tab;
    }
}
