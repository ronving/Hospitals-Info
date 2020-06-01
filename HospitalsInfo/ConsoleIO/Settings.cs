using System;

namespace HospitalsInfo.ConsoleIO
{
    public static class Settings
    {
        public static void SetConsoleParam() {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
        }
    }
}
