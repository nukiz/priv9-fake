namespace Priv9.Cheat.Core.Managers.Usage
{
    internal class ThreadManager
    {
        private static ThreadManager INSTANCE = null!;
        private static int Count = 0;

        /// <summary>
        /// Singleton for ThreadManager.
        /// </summary>
        private ThreadManager() { }

        public static ThreadManager GetInstance() => INSTANCE ??= INSTANCE = new();
    }
}
