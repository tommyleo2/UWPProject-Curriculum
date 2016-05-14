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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

<<<<<<< HEAD
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
        private void Change_Now_Week1(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 1 周";
        }
        private void Change_Now_Week2(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 2 周";
        }
        private void Change_Now_Week3(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 3 周";
        }
        private void Change_Now_Week4(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 4 周";
        }
        private void Change_Now_Week5(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 5 周";
        }
        private void Change_Now_Week6(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 6 周";
        }
        private void Change_Now_Week7(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 7 周";
        }
        private void Change_Now_Week8(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 8 周";
        }
        private void Change_Now_Week9(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 9 周";
        }
        private void Change_Now_Week10(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 10 周";
        }
        private void Change_Now_Week11(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 11 周";
        }
        private void Change_Now_Week12(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 12 周";
        }
        private void Change_Now_Week13(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 13 周";
        }
        private void Change_Now_Week14(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 14 周";
        }
        private void Change_Now_Week15(object sender, RoutedEventArgs e)
        {
            Current_Week.Content = "第 15 周";
        }

        private void Select_Term(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SelectTerm));
        }

        private void Add_Class(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddClass), term);
        }

        private async void deleteTerm(object sender, RoutedEventArgs e)
        {
            var confirm = new MessageDialog("Delete current term?");
            confirm.Commands.Add(new UICommand("No"));
            confirm.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(this.Select_Term_After_Delete)));
            confirm.DefaultCommandIndex = 1;
            confirm.CancelCommandIndex = 0;
            await confirm.ShowAsync();
        }

        private void Select_Term_After_Delete(IUICommand command)
        {
            term.deleteTerm();
            Frame.Navigate(typeof(CreateTerm));
        }

        private Term term { get; set; }
        private int currentWeek { get; set; }
    }
}
