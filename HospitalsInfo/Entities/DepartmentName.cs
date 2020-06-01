using System;

namespace HospitalsInfo.Entities
{
    public class DepartmentName : Entity, IComparable<DepartmentName>
    {
        private string name;
        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Потрібно вказати назву.", "Name");
                }
                value = value.Trim();
                if (value.Length < 4 || value.Length > 30) {
                    throw new FormatException("Назва регіону повинна містити від 4 до 30 символів.");
                }
                name = value;
            }
        }

        public DepartmentName(string name) {
            Name = name;
        }

        protected override string ToDataString() {
            return Name;
        }

        public int CompareTo(DepartmentName other) {
            if (other == null)
                return 1;
            return this.Name.CompareTo(other.Name);
        }
    }
}
