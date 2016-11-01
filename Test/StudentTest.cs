using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;
using Exercise.Repository;
using Exercise.Service;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Exercise {

    // as a student, I want to log something when go to class. so people will know it
    public class TestStudentGoToClass {
        [Fact]
        public void TestGoToClass() {
            Student _student = new Student{id="001", name = "student one"};
            string result = _student.goToClass();
            Assert.Equal(result, "I am going to class");
        }
    }
    // Add new school 
    public class TestAddNewStudent 
    {
        StudentRepository repo;
        public TestAddNewStudent()
        {
             repo = new StudentRepository();
             repo.TruncateStudent();
        }
        
        [Fact]
        public void AddValidStudent()
        {
            Student student = new Student{name = "mike", id="001"};
            repo.InsertStudent(student);
            XElement doc = repo.getStudentById(student.id);
            Assert.Equal((string)doc.Element("name"), student.name);
        }
    }

    public class TestDeleteStudent
    {
        StudentRepository repo;
        public TestDeleteStudent()
        {
             repo = new StudentRepository();
             repo.TruncateStudent();
        }
        [Fact]
        public void DeleteValidStudent()
        {
            Student student = new Student{name = "mike", id="001"};
            repo.InsertStudent(student);
            repo.DeleteStudent(student.id);
            int doc = repo.countStudentByName(student.name);
            Assert.Equal(doc, 0);
        }
    }

    public class TestUpdateStudent
    {
        StudentRepository repo;
        public TestUpdateStudent()
        {
             repo = new StudentRepository();
             repo.TruncateStudent();
        }

        [Fact]
        public void TestUpdateValidStudent()
        {
            Student student = new Student{name = "HEI", id="001"};
            repo.InsertStudent(student);
            student.name = "Nub";
            repo.UpdateStudent(student);
            XElement t = repo.getStudentById(student.id);
            Assert.Equal((string)t.Element("name"), "Nub");
        }
    }

    public class TestGetAllStudents{
        StudentRepository repo;
        public TestGetAllStudents()
        {
             repo = new StudentRepository();
             repo.TruncateStudent();
        }

        [Fact]
        public void TestGetAllValidStudent()
        {
            List<Student> studentCollection = new List<Student>();
            studentCollection.Add(new Student{name="one", id="001"});
            studentCollection.Add(new Student{name="two", id="002"});
            studentCollection.Add(new Student{name="three", id="003"});
            foreach (var item in studentCollection)
            {
                repo.InsertStudent(item);
            }
            IEnumerable<Student> students = repo.GetStudents();
            foreach (var t in students)
            {
                Assert.NotEmpty(t.name);
            }
        }
    }
    
}

