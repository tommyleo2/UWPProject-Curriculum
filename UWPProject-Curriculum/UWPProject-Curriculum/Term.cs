using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProject_Curriculum {
    class Term {
        public Term() {
            db = new Database(grade, semester, weekNum);
            courseList = new List<Course>();
        }
        public void addCourse(Course course) {
            courseList.Add(course);
            db.addCourse(course);
        }
        public void deleteCourse(Course course) {
            courseList.Remove(course);
            db.deleteCourse(course, semester);
        }
        public void modifyCourse(Course course, Course newCourse) {
            courseList.Remove(course);
            courseList.Add(newCourse);
            db.modifyCourse(course, newCourse);
        }
        public int grade { set; get; }
        public int semester { set; get; }  //  semester in a year
        public int weekNum { set; get; }
        public List<Course> courseList { set; get; }
        private Database db;
    }
}
