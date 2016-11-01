using System;
using Xunit;
using Exercise.Service;
using Exercise.Repository;

namespace Exercise {
    public class TestSecurity
    {
        StudentRepository studentRepo;
        TeacherRepository teacherRepo;
        SchoolRepository schoolRepo;
        public TestSecurity()
        {
             studentRepo = new StudentRepository();
             teacherRepo = new TeacherRepository();
             schoolRepo = new SchoolRepository();

             studentRepo.TruncateStudent();
             teacherRepo.TruncateTeacher();
             schoolRepo.TruncateSchool();
        }

        [Fact]
        public void TestSecurityValidStudent()
        {
            Student student = new Student{name="one", id="001", school_id="001"};
            School school = new School{name="SMK", id="001"};
            studentRepo.InsertStudent(student);
            schoolRepo.InsertSchool(school);

            bool check = SecurityService.CheckStudent(student, school);
            Assert.Equal(check, true);
        }

        [Fact]
        public void TestSecurityValidTeacher()
        {
            Teacher teacher = new Teacher{name="one", id="001", school_id="001"};
            School school = new School{name="SMK", id="001"};
            teacherRepo.InsertTeacher(teacher);
            schoolRepo.InsertSchool(school);

            bool check = SecurityService.CheckTeacher(teacher, school);
            Assert.Equal(check, true);
        }
    }
}