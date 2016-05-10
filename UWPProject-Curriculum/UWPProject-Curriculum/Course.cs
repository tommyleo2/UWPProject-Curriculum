using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProject_Curriculum {
    class Course {
        public Course() {
            day = new ArrayList();
            day.Capacity = 8;
            for (var i = 0; i < 8; i++) {
                List<CourseTime> courseTimeList = new List<CourseTime>();
                day.Add(courseTimeList);
            }
        }
        public string name { set; get; }
        public string room { set; get; }
        public int startWeek { set; get; }
        public int weeksLast { set; get; }
        public ArrayList day { set; get; }

    }
    struct CourseTime {
        public int start { set; get; }
        public int lastTime { set; get; }
    }
}
