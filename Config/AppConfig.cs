using System;
using System.IO;

namespace Exercise {

    public class Config {

        public static string TableTeacher() {
            return Directory.GetCurrentDirectory() + "/Database/data-teacher.xml";
        }

    }

}