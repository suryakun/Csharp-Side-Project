using System;
using Exercise.Service;
using System.Xml.Linq;
using System.IO;
using Exercise.Repository;

namespace Exercise {

    public class Teacher : Person {
        public string id { get; set; }
        public string name { get; set; }
        public string school_id {get; set; }

        public string goToClass() {
            string result = this.GetStatemenGo();
            return result;
        }
        
    }

}