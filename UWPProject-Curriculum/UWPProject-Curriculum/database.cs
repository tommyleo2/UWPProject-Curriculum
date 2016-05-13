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
        public static SQLiteConnection conn;
        public Database(int grade, int semester, int weekNum)
        {
            conn = new SQLiteConnection("Curriculum.db");
            string sql = @"CREATE TABLE IF NOT EXISTS
                                Course(Name VARCHAR(140) NOT NULL,
                                       Room VARCHAR(140),
                                       StartWeek INTEGER,
                                       WeekLast INTEGER,
                                       Grade INTEGER,
                                       Semester INTEGER,
                                       WeekNum INTEGER,
                                       Day VARCHAR(120));";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
        }
        public void addCourse(Course course) {

        }
        public void deleteCourse(Course course, int Semester) {

        }
        public void modifyCourse(Course course, Course newCourse) {

        }
        public Term getTerm(int grade, int semester) {
            Term term = new Term();

            return term;
        }

    }
}
