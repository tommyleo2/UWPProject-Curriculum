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
    public sealed partial class AddClass : Page
    {
        private Term term;

        public AddClass()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            term = (Term)e.Parameter;
            name.Text = "";
            room.Text = "";
            startTime.Text = "";
            weeksLast.Text = "";
            WeekDay.Content = "星期一";
            startTime.Text = "";
            endTime.Text = "";

        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            Course newcourse = new Course();
            newcourse.name = name.Text;
            newcourse.room = room.Text;

            term.addCourse(newcourse);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            name.Text = "";
            room.Text = "";
            startTime.Text = "";
            weeksLast.Text = "";
            WeekDay.Content = "星期一";
            startTime.Text = "";
            endTime.Text = "";
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
            WeekDay.Content = "星期日";
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            WeekDay.Content = "星期一";
        }
    }
}
