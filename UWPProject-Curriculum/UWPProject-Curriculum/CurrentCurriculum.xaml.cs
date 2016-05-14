using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
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
            Current_Week.Content = "第 " + term.nowWeek.ToString() + " 周";
            var width = 150;
            var height = 100;
            foreach (Course course in term.courseList) {
                for (int i = 0; i < 105; i++) {
                    int timeLast = 0;
                    int day;
                    int startTime;
                    if (course.lesson[i] == '1') {
                        Button courseBlock = new Button();
                        courseBlock.Click += toModify;
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
                        Color color = Colors.LightSkyBlue;
                        courseBlock.Background = new SolidColorBrush(color);
                        container.Children.Add(courseBlock);
                    }
                }
            }
        }

        private void toModify(object sender, RoutedEventArgs e) {
            Course course = new Course();
            Button currentButton = (Button)sender;
            string content = (string)currentButton.Content;
            int div = content.IndexOf("\n课室： ");
            course.name = content.Substring(0, div);
            course.room = content.Substring(div + 5);
            CourseAndTerm ct = new CourseAndTerm(course, term);
            Frame.Navigate(typeof(ClassContent), ct);
        }

        private void ChangeCurrentWeek(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem item = sender as MenuFlyoutItem;
            int currentWeek = Convert.ToInt32(item.Text.Substring(2, 2));

            var localsetting = ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] as ApplicationDataCompositeValue;
            localsetting["nowWeek"] = currentWeek;
            ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] = localsetting;
            Current_Week.Content = "第 " + item.Text.Substring(2, 2);
            if (currentWeek > 9) {
                Current_Week.Content += " 周";
            } else {
                Current_Week.Content += "周";
            }
            foreach (Course course in term.courseList) {
                if (currentWeek < course.startWeek || currentWeek > course.startWeek + course.weeksLast) {
                    string query = course.name + "\n课室： " + course.room;
                    foreach (Button button in container.Children) {
                        if ((string)(button.Content) == query) {
                            Color color = Colors.DarkGray;
                            button.Background = new SolidColorBrush(color);
                        }
                        break;
                    }
                } else {
                    string query = course.name + "\n课室： " + course.room;
                    foreach (Button button in container.Children) {
                        if ((string)(button.Content) == query) {
                            Color color = Colors.LightSkyBlue;
                            button.Background = new SolidColorBrush(color);
                        }
                        break;
                    }
                }
            }
        }

        private void Select_Term(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectTerm), term);
        }

        private void Add_Class(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddClass), term);
        }

        private async void deleteTerm(object sender, RoutedEventArgs e)
        {
            var confirm = new MessageDialog("是否删除当前学期?");
            confirm.Commands.Add(new UICommand("否"));
            confirm.Commands.Add(new UICommand("是", new UICommandInvokedHandler(this.Select_Term_After_Delete)));
            confirm.DefaultCommandIndex = 1;
            confirm.CancelCommandIndex = 0;
            await confirm.ShowAsync();
        }

        private void Select_Term_After_Delete(IUICommand command)
        {
            term.deleteTerm();
            string str = "semester" + term.grade + term.semester;
            var composite = ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] as ApplicationDataCompositeValue;
            composite[str] = null;
            ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] = composite;
            Frame.Navigate(typeof(SelectTerm));
        }

        private Term term { get; set; }
        private int currentWeek { get; set; }
    }
    class CourseAndTerm {
        public CourseAndTerm(Course c, Term t) {
            course = c;
            term = t;
        }
        public Course course { set; get; }
        public Term term { set; get; }
    }
}
