using Priv9.Cheat.Utils.Logging;
using System.Diagnostics;

namespace Priv9.Cheat.Utils.Objects
{
    internal class MemoryUtil
    {
        public static void Attach(Process Proc)
        {
            try
            {
                // hijack some other handle to read memory
                // -> sure VAC bypass, I believe it logs opened
                // handles to the game so we're better off hijacking
                // some other system handle for example
                HijackExisting();
                Logger.Log("payload deployed succesfully");
            }
            catch (Exception)
            {
                Logger.Log("failed to deploy payload", LogLevel.Error);
            }
        }

        /// <summary>
        ///             Hijacks a system handle so we can use it to read/write(?) CS2's Memory.
        /// </summary>
        private static void HijackExisting()
        {
            if (Instances.CS2_PID == default 
                || Instances.CS2_HANDLE == IntPtr.Zero) return;
            
        }
    }
}
