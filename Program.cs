using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using Exercise.Repository;
using Exercise.Service;

namespace Exercise {

    public class Program {

        static void Main(string[] args)
        {
            TeacherRepository repo = new TeacherRepository();
            repo.TruncateTeacher();

            Teacher teacher = new Teacher{name ="hola", id="004", school_id="123"};
            repo.InsertTeacher(teacher);

            Teacher updatedTeacher = new Teacher{name = "hallo", id="004", school_id="123"};
            repo.UpdateTeacher(updatedTeacher);
            
            IEnumerable<Teacher> teachers = repo.GetTeachers();
            foreach(var teacherPerson in teachers)
            {
                Console.WriteLine("{0}, {1}, {2}", teacherPerson.id, teacherPerson.name, teacherPerson.school_id);
            }

            repo.DeleteTeacher("004");
        }

    }

}