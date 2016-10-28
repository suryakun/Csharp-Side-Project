using System;
using Exercise.Service;

namespace Exercise {

    public class Teacher : Person {
        public string id { get; set; }
        public string name { get; set; }
        public string school_id {get; set; }

        public void goToClass() {
            string result = this.GetStatemenGo();
            Printer.Log(result);
        }
    }

}