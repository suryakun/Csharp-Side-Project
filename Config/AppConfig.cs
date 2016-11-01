using System;
using System.IO;

namespace Exercise {

    public class Config {

        public static string TableTeacher() {
            return Directory.GetCurrentDirectory() + "/Database/data-teacher.xml";
        }

        public static string TableSchool() {
            return Directory.GetCurrentDirectory() + "/Database/data-school.xml";
        }

        public static string TableStudent() {
            return Directory.GetCurrentDirectory() + "/Database/data-student.xml";
        }

    }

}