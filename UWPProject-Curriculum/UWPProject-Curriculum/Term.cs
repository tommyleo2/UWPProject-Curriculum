using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProject_Curriculum {
    class Term {
        public Term(int _grade, int _semester, int _weekNum) {
            grade = _grade;
            semester = _semester;
            weekNum = _weekNum;
            db = new Database(grade, semester, weekNum);
            courseList = db.selectCourse();
            nowWeek = 1;
        }
        public void addCourse(Course course) {
            courseList.Add(course);
            db.addCourse(course);
        }
        public void deleteCourse(Course course) {
            db.deleteCourse(course);
            courseList = db.selectCourse();
        }
        public void updateCourse(Course course, Course newCourse) {
            db.updateCourse(course, newCourse);
            courseList = db.selectCourse();
        }
        public Course getCourse(Course course) {
            return db.getCourse(course);
        }
        public void refreshCourse() {
            db.Grade = grade;
            db.Semester = semester;
            courseList.Clear();
            courseList = db.selectCourse();
        }
        public int grade { set; get; }
        public int semester { set; get; }  //  semester in a year
        public int weekNum { set; get; }
        public int nowWeek { set; get; }
        public ObservableCollection<Course> courseList { set; get; }

        public void deleteTerm() {
            db.deleteSemester();
            courseList.Clear();
        }

        private Database db;
    }
}
