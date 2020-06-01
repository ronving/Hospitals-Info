using HospitalsInfo.ConsoleIO;
using HospitalsInfo.ConsoleUI;
using HospitalsInfo.Data;
using HospitalsInfo.Entities;
using HospitalsInfo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalsInfo.Editors
{
    public class SurnameEditor : CommandManager
    {

        protected override void IniCommandsInfo() {
            commandsInfo = new CommandInfo[] {
                new CommandInfo("вийти", null),
                new CommandInfo("додати запис ...", Add),
                new CommandInfo("видалити запис ...", Remove),
                new CommandInfo("сортувати за ім'ям", SortByName),
                new CommandInfo("сортувати за назвою відділення", SortByDepartmentName),
                new CommandInfo("сортувати за датою", SortByData),
                new CommandInfo("сортувати за днями в ліжку", SortByDaysInBed),
            };
        }

        private DataContext dataContext;
        IEnumerable<Surname> sortingCollection;

        public SurnameEditor(DataContext dataContext) {
            this.dataContext = dataContext;
            sortingCollection = dataContext.Surnames;
        }

        protected override void PrepareScreen() {
            Console.Clear();
            Console.WriteLine(sortingCollection
                .ToLineList("ПІБ Пацієнтів"));
        }

        public void Add() {
            Surname inst = new Surname();
            inst.Name = Entering.EnterString("ПІБ Пацієнта");
            inst.departmentName = SelectDepartmentName();
            inst.data = Entering.EnterStringOrNull("Дата");
            inst.daysInBed = Entering.EnterDouble("Ліжко-днів");
            inst.Id = dataContext.Surnames.Select(e => e.Id).Max() + 1;
            dataContext.Surnames.Add(inst);
        }

        private DepartmentName SelectDepartmentName() {
            string departmentName = Entering.EnterString(
                "Назва відділення");
            DepartmentName inst = dataContext.DepartmentNames
                .FirstOrDefault(e => e.Name == departmentName);
            return inst;
        }

        public void Remove() {
            int id = Entering.EnterInt32("Введіть ІД об'єкта");
            Surname inst = dataContext.Surnames.FirstOrDefault(
                e => e.Id == id);
            dataContext.Surnames.Remove(inst);
        }

        //private void Sort() {
        //    sortingCollection = sortingCollection.OrderBy(e => e);
        //}

        private void SortByName() {
            sortingCollection = sortingCollection
                .OrderBy(e => e.Name);
        }

        private void SortByDepartmentName() {
            sortingCollection = sortingCollection
                .OrderBy(e => e.departmentName.Name);
        }

        private void SortByData() {
            sortingCollection = sortingCollection
                .OrderBy(e => e.data);
        }

        private void SortByDaysInBed() {
            sortingCollection = sortingCollection
                .OrderBy(e => e.daysInBed);
        }

    }
}
