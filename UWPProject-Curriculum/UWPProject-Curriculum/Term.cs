using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPProject_Curriculum {
    class Term {
        public Term() {
            courseList = new List<Course>();
        }
        public int grade { set; get; }
        public int semester { set; get; }  //  semester in a year
        public int weekNum { set; get; }
        public List<Course> courseList { set; get; }
    }
}
