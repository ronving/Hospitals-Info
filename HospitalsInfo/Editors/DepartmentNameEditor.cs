using HospitalsInfo.ConsoleUI;
using HospitalsInfo.Data;
using HospitalsInfo.Entities;
using HospitalsInfo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalsInfo.Editors
{
    public class DepartmentNameEditor : CommandManager
    {
        protected override void IniCommandsInfo() {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("вийти", null),
                new CommandInfo("сортувати", Sort),
           };
        }

        protected override void PrepareScreen() {
            Console.Clear();
            Console.WriteLine(sortingCollection
                .ToLineList("Географічні регіони"));
        }

        private DataContext dataContext;
        private IEnumerable<DepartmentName> sortingCollection;

        public DepartmentNameEditor(DataContext dataContext) {
            this.dataContext = dataContext;
            sortingCollection = dataContext.DepartmentNames;
        }

        private void Sort() {
            sortingCollection = sortingCollection.OrderBy(e => e);
        }

    }
}
