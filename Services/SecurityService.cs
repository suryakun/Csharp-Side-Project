using System;
using Exercise.Repository;
using System.Xml.Linq;

namespace Exercise.Service {
    public class SecurityService 
    {
        public static Boolean CheckStudent(Student student, School school)
        {
            SchoolRepository repo = new SchoolRepository();
            var sch = repo.getSchoolById(school.id);
            
            StudentRepository strepo = new StudentRepository();
            var std = strepo.getStudentById(student.id);

            return ((string)sch.Element("id") == (string)std.Element("school_id") );
        }

        public static Boolean CheckTeacher(Teacher teacher, School school)
        {
            SchoolRepository repo = new SchoolRepository();
            XElement sch = repo.getSchoolById(school.id);
            
            TeacherRepository tcrepo = new TeacherRepository();
            XElement tcr = tcrepo.getTeacherById(teacher.id);

            return ((string)sch.Element("id") == (string)tcr.Element("school_id") );
        }
    }
}