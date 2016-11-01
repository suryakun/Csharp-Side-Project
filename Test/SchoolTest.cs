using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;
using Exercise.Repository;
using Exercise.Service;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Exercise {

    // Add new school 
    public class TestAddNewSchool
    {
        SchoolRepository repo;
        public TestAddNewSchool()
        {
             repo = new SchoolRepository();
             repo.TruncateSchool();
        }
        
        [Fact]
        public void AddValidSchool()
        {
            School school = new School{name = "SMK", id="001"};
            repo.InsertSchool(school);
            XElement doc = repo.getSchoolById(school.id);
            Assert.Equal((string)doc.Element("name"), school.name);
        }
    }

    public class TestDeleteSchool
    {
        SchoolRepository repo;
        public TestDeleteSchool()
        {
             repo = new SchoolRepository();
             repo.TruncateSchool();
        }
        [Fact]
        public void DeleteValidSchool()
        {
            School school = new School{name = "SMK", id="001"};
            repo.InsertSchool(school);
            repo.DeleteSchool(school.id);
            int doc = repo.countSchoolByName(school.name);
            Assert.Equal(doc, 0);
        }
    }

    public class TestUpdateSchool
    {
        SchoolRepository repo;
        public TestUpdateSchool()
        {
             repo = new SchoolRepository();
             repo.TruncateSchool();
        }

        [Fact]
        public void TestUpdateValidTeacher()
        {
            School school = new School{name = "HEI", id="001"};
            repo.InsertSchool(school);
            school.name = "SMK";
            repo.UpdateSchool(school);
            XElement t = repo.getSchoolById(school.id);
            Assert.Equal((string)t.Element("name"), "SMK");
        }
    }

    public class TestGetAllSchools
    {
        SchoolRepository repo;
        public TestGetAllSchools()
        {
             repo = new SchoolRepository();
             repo.TruncateSchool();
        }

        [Fact]
        public void TestGetAllValidSchool()
        {
            List<School> schoolCollection = new List<School>();
            schoolCollection.Add(new School{name="one", id="001"});
            schoolCollection.Add(new School{name="two", id="002"});
            schoolCollection.Add(new School{name="three", id="003"});
            foreach (var item in schoolCollection)
            {
                repo.InsertSchool(item);
            }
            IEnumerable<School> schools = repo.GetSchools();
            foreach (var t in schools)
            {
                Assert.NotEmpty(t.name);
            }
        }
    }
    
}

