using System;
using HospitalsInfo.Entities;
using HospitalsInfo.Extensions;
using System.Collections.Generic;
using HospitalsInfo.IOXml;

namespace HospitalsInfo.Data
{
    public partial class DataContext
    {
        protected readonly DataSet dataSet = new DataSet();
        
        protected XmlFileController xmlFileIoController = new XmlFileController();
        // readonly List<DepartmentName> _departmentNames = new List<DepartmentName>();
        // readonly List<Surname> _surnames = new List<Surname>();

        public ICollection<DepartmentName> DepartmentNames {
            get { return dataSet.DepartmentNames; }
        }

        public ICollection<Surname> Surnames {
            get { return dataSet.Surnames; }
        }
        
        public static string fileName = "HospitalsInfo.xml";
        
        public void Save() {
            xmlFileIoController.Save(dataSet, fileName);
        }

        public void Load() {
            xmlFileIoController.Load(dataSet, fileName);
            OnDataChanged();
        }

        public override string ToString() {
            return string.Concat(
                "Інформація про об'єкти ПО \"Країни\"\n",
                DepartmentNames.ToLineList("Географічні регіони"),
                Surnames.ToLineList("Країни"));
        }

        public void Clear() {
            Surnames.Clear();
            DepartmentNames.Clear();
        }

        public event EventHandler DataChanged;
        
        protected void OnDataChanged() {
            if(DataChanged != null) {
                DataChanged.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
