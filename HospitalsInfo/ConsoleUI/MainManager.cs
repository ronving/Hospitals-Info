using HospitalsInfo.Data;
using HospitalsInfo.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalsInfo.ConsoleUI
{
    public class MainManager : CommandManager
    {
        protected override void IniCommandsInfo() {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("завершити роботу", null),
                new CommandInfo("створити тестові дані",
                    CreateTestingData),
                new CommandInfo("показати як текст",
                    ShowAsText),
                new CommandInfo("видалити всі дані", Clear),
                new CommandInfo(
                    "редагування даних про відділення ►",
                    RunDepartmentNameEditing),
                new CommandInfo(
                    "редагування даних про пацієнтів ►",
                    RunSurnameEditing),
                new CommandInfo("зберегти дані", Save),
                new CommandInfo("завантажити дані", Load),
            };
        }

        protected override void PrepareScreen() {
            Console.Clear();
            OutStatistics();
        }

        private DataContext dataContext;
        private DepartmentNameEditor _departmentNameEditor;
        private SurnameEditor _surnameEditor;

        public MainManager(DataContext dataContext) {
            this.dataContext = dataContext;
            _departmentNameEditor = new DepartmentNameEditor(dataContext);
            _surnameEditor = new SurnameEditor(dataContext);
        }

        private void OutStatistics() {
            Console.WriteLine(
                "Інформація про об'єкти ПО \"Госпіталізація\"");
            Console.WriteLine("\n  Представлено:\n"
                + "{0,7} відділення\n"
                + "{1,7} пацієнтів\n",
                dataContext.DepartmentNames.Count,
                dataContext.Surnames.Count
                );
        }

        protected override void PrepareRunning() {
            Console.WriteLine("\nЗасоби збереження і завантаження "
                + "даних у даній версії програми не реалізовані.");
            RequestForContinuation();
        }


        private void CreateTestingData() {
            dataContext.CreateTestingData();
        }

        private void ShowAsText() {
            Console.WriteLine();
            Console.Write(dataContext);
            RequestForContinuation();
        }

        private void Clear() {
            dataContext.Clear();
        }

        private void RunDepartmentNameEditing() {
            _departmentNameEditor.Run();
        }
        private void RunSurnameEditing() {
            _surnameEditor.Run();
        }
        
        private void Save() {
            dataContext.Save();
            Console.WriteLine("\n  Дані збережено.");
            RequestForContinuation();
        }
        
        private void Load() {
            dataContext.Load();
            Console.WriteLine("\n  Дані завантажено.");
            RequestForContinuation();
        }
    }
}
