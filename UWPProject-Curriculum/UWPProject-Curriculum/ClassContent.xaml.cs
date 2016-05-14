using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace UWPProject_Curriculum
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ClassContent : Page
    {
        private Course course { get; set; }

        private Term term { get; set; }

        public ClassContent()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CourseAndTerm ct = e.Parameter as CourseAndTerm;
            course = ct.course;
            term = ct.term;
            name.Text = course.name;
            room.Text = course.room;
            startWeek.Text = course.startWeek.ToString();
            weeksLast.Text = course.weeksLast.ToString();
            int count = 0;
            int last = 0;
            for (int i = 0; i < 105; i++) {
                if (course.lesson[i] == '1') {
                    last++;
                }
                count++;
            }
            switch (count / 15) {
                case 0:
                    WeekDay.Content = "星期一";
                    break;
                case 1:
                    WeekDay.Content = "星期二";
                    break;
                case 2:
                    WeekDay.Content = "星期三";
                    break;
                case 3:
                    WeekDay.Content = "星期四";
                    break;
                case 4:
                    WeekDay.Content = "星期五";
                    break;
                case 5:
                    WeekDay.Content = "星期六";
                    break;
                case 6:
                    WeekDay.Content = "星期天";
                    break;
            }
            startTime.Text = (count % 15 + 1).ToString();
            endTime.Text = last.ToString();
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            name.IsReadOnly = false;
            room.IsReadOnly = false;
            startWeek.IsReadOnly = false;
            weeksLast.IsReadOnly = false;
            WeekDay.IsEnabled = true;
            startTime.IsReadOnly = false;
            endTime.IsReadOnly = false;
            deleteButton.IsEnabled = true;
            updateButton.IsEnabled = true;
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var confirm = new MessageDialog("是否删除当前课程?");
            confirm.Commands.Add(new UICommand("No"));
            confirm.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.Term_After_Delete)));
            confirm.DefaultCommandIndex = 1;
            confirm.CancelCommandIndex = 0;
            await confirm.ShowAsync();
        }

        private void Term_After_Delete(IUICommand command)
        {
            term.deleteCourse(course);
            Frame.Navigate(typeof(CurrentCurriculum), term);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Course newcourse = new Course();
            newcourse.name = name.Text;
            newcourse.room = room.Text;
            int start = Convert.ToInt32(startWeek.Text);
            newcourse.startWeek = start;
            int last = Convert.ToInt32(weeksLast.Text);
            newcourse.weeksLast = last;
            int weekday = 0;
            switch ((string)WeekDay.Content)
            {
                case "星期一":
                    weekday = 0;
                    break;
                case "星期二":
                    weekday = 1;
                    break;
                case "星期三":
                    weekday = 2;
                    break;
                case "星期四":
                    weekday = 3;
                    break;
                case "星期五":
                    weekday = 4;
                    break;
                case "星期六":
                    weekday = 5;
                    break;
                case "星期天":
                    weekday = 6;
                    break;
            }
            int st = Convert.ToInt32(startTime.Text);
            int et = Convert.ToInt32(endTime.Text);
            for (int i = st; i <= et; i++)
            {
                newcourse.lesson[weekday * 15 + i - 1] = '1';
            }
            term.deleteCourse(course);
            term.addCourse(newcourse);

        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期二";
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期三";
        }

        private void MenuFlyoutItem_Click_3(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期四";
        }

        private void MenuFlyoutItem_Click_4(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期五";
        }

        private void MenuFlyoutItem_Click_5(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期六";
        }

        private void MenuFlyoutItem_Click_6(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期天";
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期一";
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CurrentCurriculum), term);
        }
    }
}
