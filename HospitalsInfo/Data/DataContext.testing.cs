using HospitalsInfo.Entities;
using System.Linq;

namespace HospitalsInfo.Data
{
    partial class DataContext
    {
        public void CreateTestingData() {
            CreateDepartments();
            CreateSurnames();
        }

        private void CreateDepartments() {
            DepartmentNames.Add(new DepartmentName("Реабілітаційне") { Id = 1 });
            DepartmentNames.Add(new DepartmentName("Інфекційне") { Id = 2 });
        }

        private void CreateSurnames() {
            Surnames.Add(new Surname("Валєра",
                DepartmentNames.First(e => e.Name == "Інфекційне"), "10.10.2010", 10) {
                Id = 1,
            });
            Surnames.Add(new Surname("Владімір",
                DepartmentNames.First(e => e.Name == "Інфекційне")) {
                Id = 2,
                data = "12.10.2010",
            });
            Surnames.Add(new Surname("Алєксєй",
                DepartmentNames.First(e => e.Name == "Реабілітаційне")) {
                Id = 3,
                daysInBed = 15,
            });
        }
    }
}
