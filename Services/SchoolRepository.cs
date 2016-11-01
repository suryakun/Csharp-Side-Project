using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using Exercise;

namespace Exercise.Repository 
{
    public class SchoolRepository 
    {
        private List<School> allSchools;
        private XDocument schoolData;

        public SchoolRepository() {
            try
            {
                allSchools = new List<School>();
                string path = Config.TableSchool();
                schoolData = XDocument.Load(path);
                var schools = schoolData.Root.Descendants("school");
                
                foreach(var school in schools)
                {
                    allSchools.Add(new School{id = school.Element("id").Value, name = school.Element("name").Value});
                }    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<School> GetSchools()
        {
            return allSchools;
        }

        public void InsertSchool(School school)
        {
            var newSchool =  new XElement("school", 
                      new XElement("id", school.id),
                      new XElement("name", school.name));
            schoolData.Root.Add(newSchool);
            FlushingData(schoolData);
        }

        public void DeleteSchool(string id)
        {
            // teacherData.Root.Descendants("teacher").Elements("id").Where(o => (string)o.Element("id") == id).Remove();
            schoolData.Root.Elements("school").Where(n => (string)n.Element("id") == id).Remove();
            FlushingData(schoolData);
        }

        public void UpdateSchool(School school)
        {
            XElement node = schoolData.Root.Elements("school").Where(i => (string)i.Element("id") == school.id).FirstOrDefault();
            node.SetElementValue("name", school.name);
            FlushingData(schoolData);
        }

        public void TruncateSchool()
        {
            schoolData.Root.Elements("school").Remove();
            FlushingData(schoolData);
        }

        public XElement getSchoolById(string id)
        {
            XElement node = schoolData.Root.Elements("school").Where(i => (string)i.Element("id") == id).First();
            return node;
        }

        public int countSchoolByName(string name)
        {
            int node = schoolData.Root.Elements("school").Where(i => (string)i.Element("name") == name).Count();
            return node;
        }

        public int countSchoolById(string id)
        {
            int node = schoolData.Root.Elements("school").Where(i => (string)i.Element("id") == id).Count();
            return node;
        }

        public static void FlushingData(XDocument data)
        {
            using(FileStream fs =  new FileStream(Config.TableSchool(), FileMode.Create))
            {
                data.Save(fs);
                fs.Flush();
            }
        }
        
    }

}