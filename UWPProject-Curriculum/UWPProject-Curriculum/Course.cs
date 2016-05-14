using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProject_Curriculum {
    class Course {
        public Course() {
            lesson = new char[120];
            for (int i = 0; i < 105; i++)
                lesson[i] = '0';
            lesson[105] = '\0';
        }
        public string name { set; get; }
        public string room { set; get; }
        public Int64 startWeek { set; get; }
        public Int64 weeksLast { set; get; }
        public char[] lesson { set; get; }
    }
}
