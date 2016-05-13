using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace UWPProject_Curriculum
{
    class Database
    {
        private int Semester;
        private int Grade;
        private int Week;
        public SQLiteConnection conn;
        public Database(int grade, int semester, int week)
        {
            Semester = semester;
            Grade = grade;
            Week = week;
            conn = new SQLiteConnection("Curriculum.db");
            string sql = @"CREATE TABLE IF NOT EXISTS
                                Course(Name VARCHAR(140) NOT NULL,
                                       Room VARCHAR(140),
                                       StartWeek INTEGER,
                                       WeekLast INTEGER,
                                       Grade INTEGER,
                                       Semester INTEGER,
                                       WeekNum INTEGER,
                                       Day VARCHAR(106));";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
        }

        public void deleteCourse(Course course)
        {
            using (var statement = conn.Prepare("DELETE FROM Course WHERE Name = ? AND Room = ? AND Semester = ? AND Grade = ?"))
            {
                statement.Bind(1, course.name);
                statement.Bind(2, course.room);
                statement.Bind(3, Semester);
                statement.Bind(4, Grade);
                statement.Step();
            }
        }

        public void deleteSemester()
        {
            using (var statement = conn.Prepare("DELETE FROM Course WHERE Semester = ? AND Grade = ?"))
            {
                statement.Bind(1, Semester);
                statement.Bind(2, Grade);
                statement.Step();
            }
        }

        public void addCourse(Course course)
        {
            using (var statement = conn.Prepare("INSERT INTO Course (Name, Room, StartWeek, WeekLast, Grade, Semester, WeekNum, Day) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"))
            {
                string day = new string(course.lesson);
                statement.Bind(1, course.name);
                statement.Bind(2, course.room);
                statement.Bind(3, course.startWeek);
                statement.Bind(4, course.weeksLast);
                statement.Bind(5, Grade);
                statement.Bind(6, Semester);
                statement.Bind(7, Week);
                statement.Bind(8, day);
                statement.Step();
            }
        }

        public void updateCourse(Course course, Course newCourse) {
            using (var statement = conn.Prepare(@"UPDATE Course SET Name = ?, Room = ?, StartWeek = ?, WeekLast = ?, Day = ?
                                                  WHERE Name = ? AND Room = ? AND StartWeek = ? AND WeekLast = ? AND Day = ?")) {
                string courseLesson = new string(course.lesson);
                string newCourseLesson = new string(newCourse.lesson);
                statement.Bind(1, newCourse.name);
                statement.Bind(2, newCourse.room);
                statement.Bind(3, newCourse.startWeek);
                statement.Bind(4, newCourse.weeksLast);
                statement.Bind(5, newCourseLesson);

                statement.Bind(6, course.name);
                statement.Bind(7, course.room);
                statement.Bind(8, course.startWeek);
                statement.Bind(9, course.weeksLast);
                statement.Bind(10, courseLesson);
                statement.Step();
            }
        }

        public List<Course> selectCourse()
        {
            List<Course> list = new List<Course>();
            using (var statement = conn.Prepare("SELECT * FROM Course WHERE Semester = ? AND Grade = ?"))
            {
                statement.Bind(1, Semester);
                statement.Bind(2, Grade);
                while (statement.Step() != SQLiteResult.DONE)
                {
                    Course course = new Course();
                    course.name = (string)statement[0];
                    course.room = (string)statement[1];
                    course.startWeek = (Int64)statement[2];
                    course.weeksLast = (Int64)statement[3];
                    string str = (string)statement[7];
                    course.lesson = str.ToCharArray();
                    list.Add(course);
                }
                return list;
            }
        }
    }
}
