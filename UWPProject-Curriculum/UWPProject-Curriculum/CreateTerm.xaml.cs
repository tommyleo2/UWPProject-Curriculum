﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
            if (WeekLast.Text == "")
            {
                var i = new MessageDialog("请输入当前学期持续周数").ShowAsync();
            } else
            {
                var composite = ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] as ApplicationDataCompositeValue;
                int _grade = 0, _semester = 0, _weekNum;
                string ss = "semester";


                switch ((string)Grade.Content)
                {
                    case "大一":
                        _grade = 1;
                        ss += '1';
                        break;
                    case "大二":
                        _grade = 2;
                        ss += '2';
                        break;
                    case "大三":
                        _grade = 3;
                        ss += '3';
                        break;
                    case "大四":
                        _grade = 4;
                        ss += '4';
                        break;
                }
                switch ((string)Term.Content)
                {
                    case "第一学期":
                        _semester = 1;
                        ss += "1";
                        break;
                    case "第二学期":
                        _semester = 1;
                        ss += "2";
                        break;
                    case "第三学期":
                        _semester = 1;
                        ss += "3";
                        break;
                }
                if (composite[ss] == null)
                {
                    composite[ss] = true;
                    composite["recentterm"] = ss;
                    _weekNum = Convert.ToInt32(WeekLast.Text);
                    Term term = new Term(_grade, _semester, _weekNum);
                    ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] = composite;
                    Frame.Navigate(typeof(CurrentCurriculum), term);
                }
                else
                {
                    var i = new MessageDialog("该年级当前学期已存在").ShowAsync();
                };
            }
            
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
        
    }
}
