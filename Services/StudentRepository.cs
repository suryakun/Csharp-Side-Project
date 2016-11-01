using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using Exercise;

namespace Exercise.Repository 
{
    public class StudentRepository 
    {
        private List<Student> allStudents;
        private XDocument studentData;

        public StudentRepository() {
            try
            {
                allStudents = new List<Student>();
                string path = Config.TableStudent();
                studentData = XDocument.Load(path);
                var students = studentData.Root.Descendants("student");
                
                foreach(var student in students)
                {
                    allStudents.Add(new Student{id = student.Element("id").Value, name = student.Element("name").Value});
                }    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public IEnumerable<Student> GetStudents()
        {
            return allStudents;
        }

        public void InsertStudent(Student student)
        {
            var newStudent =  new XElement("student", 
                      new XElement("id", student.id),
                      new XElement("name", student.name));
            studentData.Root.Add(newStudent);
            FlushingData(studentData);
        }

        public void DeleteStudent(string id)
        {
            studentData.Root.Elements("student").Where(n => (string)n.Element("id") == id).Remove();
            FlushingData(studentData);
        }

        public void UpdateStudent(Student student)
        {
            XElement node = studentData.Root.Elements("student").Where(i => (string)i.Element("id") == student.id).FirstOrDefault();
            node.SetElementValue("name", student.name);
            FlushingData(studentData);
        }

        public void TruncateStudent()
        {
            studentData.Root.Descendants("student").Remove();
            FlushingData(studentData);
        }

        public XElement getStudentById(string id)
        {
            XElement node = studentData.Root.Elements("student").Where(i => (string)i.Element("id") == id).First();
            return node;
        }

        public int countStudentByName(string name)
        {
            int node = studentData.Root.Elements("student").Where(i => (string)i.Element("name") == name).Count();
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