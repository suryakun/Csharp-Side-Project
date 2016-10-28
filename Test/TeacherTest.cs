using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;

namespace Exercise {

    // as a teacher, I want to log something when go to class. so people will know it
    public class TestTeacherGoToClass {

        [Fact]
        public void TestGoToClass() {
            Teacher _teacher = new Teacher{id="001", name = "teacher one", school_id = "001"};
            string result = _teacher.GetStatemenGo();
            Assert.Equal("I am going to class", result);            
        }

    }

    // Add new teacher 
    public class TestAddNewTeacher : IDisposable {

        public static string databaseDir = Directory.GetCurrentDirectory() + "/Database/data-test.xml";
        public TestAddNewTeacher(){
            File.Delete(databaseDir);
        }
        public void Dispose() {
            File.Delete(databaseDir);
        }

        [Fact]
        public void TestInsertTeacher() {
            Teacher _teacher = new Teacher{id="001", name = "Teacher one", school_id = "001"};
            
        }

    }
    
}

