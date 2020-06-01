using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using HospitalsInfo.Data;
using HospitalsInfo.Entities;

namespace HospitalsInfo.IOXml
{
    public class XmlFileController
    {
        public void Save(DataSet dataSet, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.Unicode;
            XmlWriter writer = null;
            try {
                writer = XmlWriter.Create(fileName, settings);
                WriteData(dataSet, writer);
            }
            catch (Exception) {
                throw;
            }
            finally {
                if (writer != null)
                    writer.Close();
            }
        }
        
        public void Load(DataSet dataSet, string fileName)
        {
            if (!File.Exists(fileName)) return;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(fileName, settings)) {
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element) {
                        switch (reader.Name) {
                            case "DepartmentName":
                                ReadDepartmentName(reader, dataSet.DepartmentNames);
                                break;
                            case "Surname":
                                ReadSurname(reader, dataSet);
                                break;
                        }
                    }
                }
            }
        }

        void WriteData(DataSet dataSet, XmlWriter writer)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("HospitalsInfo");
            WriteDepartmentNames(dataSet.DepartmentNames, writer);
            WriteSurnames(dataSet.Surnames, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        
        void WriteDepartmentNames(IEnumerable<DepartmentName> collection, XmlWriter writer)
        {
            writer.WriteStartElement("DepartmentNamesData");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("DepartmentName");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Name", inst.Name);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        } 
        
        void WriteSurnames(IEnumerable<Surname> collection, XmlWriter writer)
        {
            writer.WriteStartElement("SurnamesData");
            foreach (var inst in collection)
            {
                writer.WriteStartElement("Surname");
                writer.WriteElementString("Id", inst.Id.ToString());
                writer.WriteElementString("Name", inst.Name);
                int departmentNameId = inst.departmentName == null ? 0 : inst.departmentName.Id;
                writer.WriteElementString("DepartmentName", departmentNameId.ToString());
                writer.WriteElementString("Data", inst.data);
                writer.WriteElementString("DaysInBed", inst.daysInBed.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        
        void ReadDepartmentName(XmlReader reader, ICollection<DepartmentName> collection) {
            reader.ReadStartElement("DepartmentName");
            int id = reader.ReadElementContentAsInt();
            string name = reader.ReadElementContentAsString();
            DepartmentName inst = new DepartmentName(name) { Id = id };
            collection.Add(inst);
        }

        void ReadSurname(XmlReader reader, DataSet dataSet) {
            Surname inst = new Surname();
            reader.ReadStartElement("Surname");
            inst.Id = reader.ReadElementContentAsInt();
            inst.Name = reader.ReadElementContentAsString();
            int departmentNameId = reader.ReadElementContentAsInt();
            inst.departmentName = dataSet.DepartmentNames
                .FirstOrDefault(e => e.Id == departmentNameId);
            inst.data = reader.ReadElementContentAsString();
            string dib = reader.ReadElementContentAsString();
            inst.daysInBed = string.IsNullOrEmpty(dib)
                ? (double?)null : double.Parse(dib);
            dataSet.Surnames.Add(inst);
        }
    }
}