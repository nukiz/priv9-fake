using Priv9.Cheat.Screen;
using Priv9.Cheat.Utils.Logging;
using System.Diagnostics;
using Priv9.Cheat.Utils.Objects;
using Priv9.Cheat.Utils;
using Priv9.Cheat.Core.Managers;

namespace Priv9
{
    internal static class EntryPoint
    {
        internal static bool Debug = false;
        internal static IntPtr HANDLE;
        

        [STAThread]
        static void Main()
        {
            HANDLE = Process.GetCurrentProcess().MainWindowHandle;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Title = "fake9.net";
            Console.WriteLine(
            "\n\n     o888o          oooo                    ooooooo   \r\n" +
                "   o888oo ooooooo    888  ooooo ooooooooo8 888    88o \r\n" +
                "    888   ooooo888   888o888   888oooooo8   888oo8888 \r\n" +
                "    888 888    888   8888 88o  888               888  \r\n" +
                "   o888o 88ooo88 8o o888o o888o  88oooo888    o888    \r\n\n\n                                                   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            TryInject();
        }

        private static void TryInject()
        {
            bool HasInjected = false, Found = false;
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName.Contains("cs2"))
                {
                    Instances.CS2_PID = proc.Id;
                    Instances.CS2_HANDLE = proc.MainWindowHandle;
                    Found = true;
                    if (!Debugger.IsAttached)
                    {
                        try
                        {
                            MemoryUtil.Attach(proc);
                            HasInjected = true;
                        }
                        catch (FileNotFoundException)
                        {
                            Logger.Log("failed to deploy payload ->" +
                                " no memory module loaded", LogLevel.Error);
                        }
                    } 
                    else
                    {
                        Logger.Log("payload was not deployed -> debug mode is enabled", LogLevel.Warning);
                        Debug = true;
                        HasInjected = true;
                    }
                    break;
                }
            }

            if (HasInjected)
                LoadCheat();
            else if (!Found)
                Logger.Log("can't deploy payload, open CS2.", LogLevel.Error);

            Logger.Log("press any key to continue . . .");
            Console.ReadKey();
        }

        private static void LoadCheat()
        {
            Natives.ShowWindow(HANDLE, 6); // SW_MINIMIZE
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new Priv9Screen());
        }
    }
}