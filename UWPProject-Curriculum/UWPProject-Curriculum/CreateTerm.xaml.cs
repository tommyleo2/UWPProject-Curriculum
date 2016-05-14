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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace UWPProject_Curriculum
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CreateTerm : Page
    {
        public CreateTerm()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Grade.Content = "大一";
            Term.Content = "第一学期";
            WeekLast.Text = "";
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            int _grade = 0, _semester = 0, _weekNum;
            switch((string)Grade.Content)
            {
                case "大一":
                    _grade = 1;
                    break;
                case "大二":
                    _grade = 2;
                    break;
                case "大三":
                    _grade = 3;
                    break;
                case "大四":
                    _grade = 4;
                    break;
            }
            switch((string)Term.Content)
            {
                case "第一学期":
                    _semester = 1;
                    break;
                case "第二学期":
                    _semester = 2;
                    break;
                case "第三学期":
                    _semester = 3;
                    break;
                case "第四学期":
                    _semester = 4;
                    break;
            }
            _weekNum = Convert.ToInt32(WeekLast.Text);
            Term term = new Term(_grade, _semester, _weekNum);
            Frame.Navigate(typeof(CurrentCurriculum), term);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Grade.Content = "大一";
            Term.Content = "第一学期";
            WeekLast.Text = "";
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            Grade.Content = "大一";
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            Grade.Content = "大二";
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            Grade.Content = "大三";
        }

        private void MenuFlyoutItem_Click_3(object sender, RoutedEventArgs e)
        {
            Grade.Content = "大四";
        }

        private void change_term1(object sender, RoutedEventArgs e)
        {
            Term.Content = "第一学期";
        }

        private void change_term2(object sender, RoutedEventArgs e)
        {
            Term.Content = "第二学期";
        }

        private void change_term3(object sender, RoutedEventArgs e)
        {
            Term.Content = "第三学期";
        }

        private void change_term4(object sender, RoutedEventArgs e)
        {
            Term.Content = "第四学期";
        }
    }
}
