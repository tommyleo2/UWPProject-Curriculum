using System;
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
    public sealed partial class SelectTerm : Page
    {
        public SelectTerm()
        {
            this.InitializeComponent();
        }

        private void Grade1_Click(object sender, RoutedEventArgs e)
        {
            if (Grade1.IsChecked == true)
            {
                Grade2.IsChecked = false;
                Grade3.IsChecked = false;
                Grade4.IsChecked = false;
            }
        }

        private void Grade2_Click(object sender, RoutedEventArgs e)
        {
            if (Grade2.IsChecked == true)
            {
                Grade1.IsChecked = false;
                Grade3.IsChecked = false;
                Grade4.IsChecked = false;
            }
        }

        private void Grade3_Click(object sender, RoutedEventArgs e)
        {
            if (Grade3.IsChecked == true)
            {
                Grade2.IsChecked = false;
                Grade1.IsChecked = false;
                Grade4.IsChecked = false;
            }
        }

        private void Grade4_Click(object sender, RoutedEventArgs e)
        {
            if (Grade4.IsChecked == true)
            {
                Grade2.IsChecked = false;
                Grade3.IsChecked = false;
                Grade1.IsChecked = false;
            }
        }

        private void term1_Click(object sender, RoutedEventArgs e)
        {
            if (term1.IsChecked == true)
            {
                term2.IsChecked = false;
                term3.IsChecked = false;
            }
        }

        private void term2_Click(object sender, RoutedEventArgs e)
        {
            if (term2.IsChecked == true)
            {
                term1.IsChecked = false;
                term3.IsChecked = false;
            }
        }

        private void term3_Click(object sender, RoutedEventArgs e)
        {
            if (term3.IsChecked == true)
            {
                term2.IsChecked = false;
                term1.IsChecked = false;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var composite = ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] as ApplicationDataCompositeValue;
            string str = "semester";
            if (Grade1.IsChecked == true) str += "1";
            else if (Grade2.IsChecked == true) str += "2";
            else if (Grade3.IsChecked == true) str += "3";
            else if (Grade4.IsChecked == true) str += "4";
            else
            {
                var i = new MessageDialog("请选择年级").ShowAsync();
            }

            if (term1.IsChecked == true) str += "1";
            else if (term2.IsChecked == true) str += "2";
            else if (term3.IsChecked == true) str += "3";
            else
            {
                var i = new MessageDialog("请选择学期").ShowAsync();
            }


            if (composite[str] == null)
            {
                var i = new MessageDialog("该年级当前学期尚未创建，是否跳转到创建页面?");
                i.Commands.Add(new UICommand("否"));
                i.Commands.Add(new UICommand("是", new UICommandInvokedHandler(this.navigatiTo)));
                i.DefaultCommandIndex = 1;
                i.CancelCommandIndex = 0;
                await i.ShowAsync();
            }
            else
            {
                composite["recnetterm"] = str;
                ApplicationData.Current.LocalSettings.Values["TheWorkInProgress"] = composite;
            }
        }

        private void navigatiTo(IUICommand command)
        {
            Frame.Navigate(typeof(CreateTerm));
        }
    }
}
