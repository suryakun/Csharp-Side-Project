using System;

namespace Exercise {
    public class Student : Person {
        public string id { get; set; }
        public string name { get; set; }
        public string goToClass() {
            string result = this.GetStatemenGo();
            return result;
        }
    } 
}