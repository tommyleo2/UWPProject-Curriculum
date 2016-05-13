using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProject_Curriculum {
    class Course {
        public Course() {
            lesson = new char[120];
            for (int i = 0; i < 119; i++)
                lesson[i] = '0';
            lesson[119] = '\0';
        }
        public string name { set; get; }
        public string room { set; get; }
        public int startWeek { set; get; }
        public int weeksLast { set; get; }
        public char[] lesson { set; get; }
    }
}
