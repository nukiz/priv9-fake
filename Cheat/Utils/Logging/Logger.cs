namespace Priv9.Cheat.Utils.Logging
{
    internal static class Logger
    {
        public static void Log(string Message)
        {
            Log(Message, LogLevel.Info);
        }

        public static void Log(string Message, bool Debug)
        {
            if (EntryPoint.Debug && Debug)
                Log("[debug] " + Message, LogLevel.Info);
        }

        public static void Log(string Message, LogLevel Level)
        {
            switch (Level)
            {
                case LogLevel.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine($"[priv9] {Message}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    internal enum LogLevel
    {
        Info,
        Error,
        Warning
    }
}
