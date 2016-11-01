using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;

namespace Exercise.Repository 
{
    public class TeacherRepository 
    {
        private List<Teacher> allTeachers;
        private XDocument teacherData;

        public TeacherRepository() {
            try
            {
                allTeachers = new List<Teacher>();
                string path = Config.TableTeacher();
                teacherData = XDocument.Load(path);
                var teachers = teacherData.Root.Descendants("teacher");
                
                foreach(var teacher in teachers)
                {
                    allTeachers.Add(new Teacher{id = teacher.Element("id").Value, name = teacher.Element("name").Value, school_id = teacher.Element("school_id").Value });
                }    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return allTeachers;
        }

        public void InsertTeacher(Teacher teacher)
        {
            var newTeacher =  new XElement("teacher", 
                      new XElement("id", teacher.id),
                      new XElement("name", teacher.name),
                      new XElement("school_id",teacher.school_id));
            teacherData.Root.Add(newTeacher);
            FlushingData(teacherData);
        }

        public void DeleteTeacher(string id)
        {
            // teacherData.Root.Descendants("teacher").Elements("id").Where(o => (string)o.Element("id") == id).Remove();
            teacherData.Root.Elements("teacher").Where(n => (string)n.Element("id") == id).Remove();
            FlushingData(teacherData);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            XElement node = teacherData.Root.Elements("teacher").Where(i => (string)i.Element("id") == teacher.id).FirstOrDefault();
            node.SetElementValue("name", teacher.name);
            node.SetElementValue("school_id", teacher.school_id);
            FlushingData(teacherData);
        }

        public void TruncateTeacher()
        {
            teacherData.Root.Descendants("teacher").Remove();
            FlushingData(teacherData);
        }

        public XElement getTeacherById(string id)
        {
            XElement node = teacherData.Root.Elements("teacher").Where(i => (string)i.Element("id") == id).First();
            return node;
        }

        public int countTeacherById(string name)
        {
            int node = teacherData.Root.Elements("teacher").Where(i => (string)i.Element("name") == name).Count();
            return node;
        }

        public static void FlushingData(XDocument data)
        {
            using(FileStream fs =  new FileStream(Config.TableTeacher(), FileMode.Create))
            {
                data.Save(fs);
                fs.Flush();
            }
        }
        
    }

}