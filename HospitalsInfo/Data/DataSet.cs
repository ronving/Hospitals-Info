using System.Collections.Generic;
using HospitalsInfo.Entities;

namespace HospitalsInfo.Data
{
    public class DataSet
    {
        public List<DepartmentName> DepartmentNames { get; set; }
        public List<Surname> Surnames { get; private set; }

        public DataSet()
        {
            DepartmentNames = new List<DepartmentName>();
            Surnames = new List<Surname>();
        }
    }
}