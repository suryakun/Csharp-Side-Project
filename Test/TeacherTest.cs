using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;
using Exercise.Repository;
using Exercise.Service;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Exercise {

    // as a teacher, I want to log something when go to class. so people will know it
    public class TestTeacherGoToClass {
        [Fact]
        public void TestGoToClass() {
            Teacher _teacher = new Teacher{id="001", name = "teacher one", school_id = "001"};
            string result = _teacher.GetStatemenGo();
            Assert.Equal(result, "I am going to class");
        }
    }

    // Add new teacher 
    public class TestAddNewTeacher 
    {
        TeacherRepository repo;
        public TestAddNewTeacher()
        {
             repo = new TeacherRepository();
             repo.TruncateTeacher();
        }
        
        [Fact]
        public void AddValidTeacher()
        {
            Teacher teacher = new Teacher{name = "hello", id="001", school_id="001"};
            repo.InsertTeacher(teacher);
            XElement doc = repo.getTeacherById(teacher.id);
            Assert.Equal((string)doc.Element("name"), teacher.name);
        }
    }

    public class TestDeleteTeacher 
    {
        TeacherRepository repo;
        public TestDeleteTeacher()
        {
             repo = new TeacherRepository();
             repo.TruncateTeacher();
        }
        [Fact]
        public void DeleteValidTeacher()
        {
            Teacher teacher = new Teacher{name = "hello", id="001", school_id="001"};
            repo.InsertTeacher(teacher);
            repo.DeleteTeacher(teacher.id);
            int doc = repo.countTeacherById(teacher.id);
            Assert.Equal(doc, 0);
        }
    }

    public class TestUpdateTeacher
    {
        TeacherRepository repo;
        public TestUpdateTeacher()
        {
             repo = new TeacherRepository();
             repo.TruncateTeacher();
        }

        [Fact]
        public void TestUpdateValidTeacher()
        {
            Teacher teacher = new Teacher{name = "hello", id="001", school_id="001"};
            repo.InsertTeacher(teacher);
            teacher.name = "Holla";
            repo.UpdateTeacher(teacher);
            XElement t = repo.getTeacherById(teacher.id);
            Assert.Equal((string)t.Element("name"), "Holla");
        }
    }

    public class TestGetAllTeachers{
        TeacherRepository repo;
        public TestGetAllTeachers()
        {
             repo = new TeacherRepository();
             repo.TruncateTeacher();
        }

        [Fact]
        public void TestGetAllValidTeacher()
        {
            List<Teacher> teacherCollection = new List<Teacher>();
            teacherCollection.Add(new Teacher{name="one", id="001", school_id="001"});
            teacherCollection.Add(new Teacher{name="two", id="002", school_id="001"});
            teacherCollection.Add(new Teacher{name="three", id="003", school_id="001"});
            foreach (var item in teacherCollection)
            {
                repo.InsertTeacher(item);
            }
            IEnumerable<Teacher> teachers = repo.GetTeachers();
            foreach (var t in teachers)
            {
                Assert.NotEmpty(t.name);
            }
        }
    }
    
}

