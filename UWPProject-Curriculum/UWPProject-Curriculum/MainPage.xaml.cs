using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPProject_Curriculum
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            term = new Term();
            createDebugTerm();
            displayDebugTerm();
        }

        private Term term { set; get; }

        private void displayDebugTerm() {
            string debugInfo = "";
            foreach (Course course in term.courseList) {
                debugInfo += "Name: " + course.name + "\n";
                debugInfo += "Room: " + course.room + "\n";
                debugInfo += "Start Week: " + course.startWeek + "\n";
                debugInfo += "Weeks :" + course.weeksLast + "\n";
                for (var i = 1; i < 8; i++) {
                    if (course.day[i] != null) {
                        debugInfo += "Day " + i + " ";
                        List<CourseTime> list = (List<CourseTime>)course.day[i];
                        foreach (CourseTime courseTime in list) {
                            debugInfo += "start: " + courseTime.start + " last: " + courseTime.lastTime + "\n";
                        }
                    }
                }
            }
            debugTextBlock.Text = debugInfo;
        }
        private void createDebugTerm() {
            term.grade = 2;
            term.semester = 2;
            term.weekNum = 18;
            term.startTime = new DateTime(2016, 2, 23);
            Course course = new Course();
            course.name = "Computer Organization Principle";
            course.room = "C403";
            course.startWeek = 1;
            course.weeksLast = 18;
            CourseTime courseTime = new CourseTime();
            courseTime.start = 3;
            courseTime.lastTime = 3;
            List<CourseTime> list = (List<CourseTime>)(course.day[5]);
            list.Add(courseTime);
            term.courseList.Add(course);
        }

    }
}
