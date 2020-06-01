using System;

namespace HospitalsInfo.Entities
{
    public class Surname : Entity
    {
        
            
        private string name;

        public DepartmentName departmentName;
        public string data;
        public double? daysInBed;

        public string Name {
            get { return name ; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Потрібно вказати назву.", "Name");
                }
                value = value.Trim();
                if (value.Length < 2 || value.Length > 50) {
                    throw new FormatException("ПІБ повинно містити від 2 до 50 символів.");
                }
                name = value;
            }
        }

        protected override string ToDataString() {
            return string.Format("{0,-17} відділення: {1,-17}  дата: {2,2};  ліжко-днів: {3,7}",
                Name, departmentName, data, daysInBed);
        }

        public Surname(string name, DepartmentName departmentName,
                    string data, double? daysInBed) {
            Name = name;
            this.departmentName = departmentName;
            this.data = data;
            this.daysInBed = daysInBed;
        }

        public Surname(string name, DepartmentName departmentName)
            : this(name, departmentName, null, null) { }

        public Surname() { }
    }
}
