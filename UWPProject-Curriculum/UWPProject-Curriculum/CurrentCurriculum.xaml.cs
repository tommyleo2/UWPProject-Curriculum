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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPProject_Curriculum {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrentCurriculum : Page {
        public CurrentCurriculum() {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            term = (Term)e.Parameter;
            var width = 150;
            var height = 100;
            foreach (Course course in term.courseList) {
                for (int i = 0; i < 105; i++) {
                    int timeLast = 0;
                    int day;
                    int startTime;
                    if (course.lesson[i] == '1') {
                        Button courseBlock = new Button();
                        courseBlock.Content += course.name + "\n课室： " + course.room;
                        day = i / 15;
                        startTime = i % 15;
                        while (course.lesson[i] == '1') {
                            i++;
                            timeLast++;
                            if (i == 105) {
                                break;
                            }
                        }
                        courseBlock.RenderTransformOrigin = new Point(0, 0);
                        courseBlock.Width = width;
                        courseBlock.Height = height * timeLast;
                        courseBlock.Margin = new Thickness(day * width, (startTime) * height, 0, 0);
                        courseBlock.VerticalAlignment = VerticalAlignment.Top;
                        courseBlock.HorizontalAlignment = HorizontalAlignment.Left;
                        container.Children.Add(courseBlock);
                    }
                }
            }
        }
        private void Change_Now_Week1(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 1";
        }
        private void Change_Now_Week2(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 2";
        }
        private void Change_Now_Week3(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 3";
        }
        private void Change_Now_Week4(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 4";
        }
        private void Change_Now_Week5(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 5";
        }
        private void Change_Now_Week6(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 6";
        }
        private void Change_Now_Week7(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 7";
        }
        private void Change_Now_Week8(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 8";
        }
        private void Change_Now_Week9(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 9";
        }
        private void Change_Now_Week10(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 10";
        }
        private void Change_Now_Week11(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 11";
        }
        private void Change_Now_Week12(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 12";
        }
        private void Change_Now_Week13(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 13";
        }
        private void Change_Now_Week14(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 14";
        }
        private void Change_Now_Week15(object sender, RoutedEventArgs e) {
            Current_Week.Content = "Week 15";
        }
        private void Select_Term(object sender, RoutedEventArgs e) {

        }
        private void Add_Class(object sender, RoutedEventArgs e) {

        }
        private void deleteTerm(object sender, RoutedEventArgs e) {

        }
        private Term term { get; set; }
        private int currentWeek { get; set; }
    }
}
