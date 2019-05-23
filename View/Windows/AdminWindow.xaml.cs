using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CourseWork_SAIPIS.View.Pages;
using CourseWork_SAIPIS.Windows;

namespace CourseWork_SAIPIS
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //Debug
            ClientServerController.Connect();
        }

        private void UserListButton_OnClick(object sender, RoutedEventArgs e)
        {
           Page1 page1 = new Page1();
           Frame.Navigate(page1);
        }

        private void EventListButton_OnClick(object sender, RoutedEventArgs e)
        {
            Page2 page2 = new Page2();
            Frame.Navigate(page2);
        }

        //private void Window1_OnSizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    Frame.Width = this.Width;
        //}


        private void ExpertsListButton_OnClick(object sender, RoutedEventArgs e)
        {
            ExpertsListPage page = new ExpertsListPage();
            Frame.Navigate(page);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }

        private void CurrentPoints_ButtonClick(object sender, RoutedEventArgs e)
        {
            PointsPage page = new PointsPage();
            Frame.Navigate(page);
        }

        private void MethodButton_OnClick(object sender, RoutedEventArgs e)
        {
            MethodPage page = new MethodPage();
            Frame.Navigate(page);
        }
    }
}
