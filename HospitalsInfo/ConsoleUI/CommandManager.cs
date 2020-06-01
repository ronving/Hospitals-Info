using HospitalsInfo.ConsoleIO;
using System;

namespace HospitalsInfo.ConsoleUI
{
    public abstract class CommandManager
    {
        protected CommandInfo[] commandsInfo;

        protected abstract void IniCommandsInfo();

        protected abstract void PrepareScreen();

        public CommandManager() {
            IniCommandsInfo();
        }

        protected virtual void PrepareRunning() { }

        public void Run() {
            PrepareRunning();
            while (true) {
                PrepareScreen();
                ShowCommandsMenu();
                Command command = EnterCommand();
                if (command == null) {
                    return;
                }
                command();
            }
        }

        private void ShowCommandsMenu() {
            Console.WriteLine("  Список команд меню:");
            for (int i = 0; i < commandsInfo.Length; i++) {
                Console.WriteLine("\t{0,2} - {1}",
                    i, commandsInfo[i].name);
            }
        }

        private Command EnterCommand() {
            Console.WriteLine();
            int number = Entering.EnterInt32(
                "Введіть номер команди меню");
            return commandsInfo[number].command;
        }

        protected virtual void RequestForContinuation() {
            Console.Write("\nДля продовження роботи програми "
                + "натисніть довільну клавішу...");
            Console.ReadKey(true);
        }
    }
}
