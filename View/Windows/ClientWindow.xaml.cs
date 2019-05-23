using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using CourseWork_SAIPIS.Database;

namespace CourseWork_SAIPIS
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private CourseWorkDBEntities3 dbEntities = new CourseWorkDBEntities3();
        public ClientWindow()
        {
            InitializeComponent();
            dbEntities.Invoice.Load();
            InvoiceGrid.ItemsSource = dbEntities.Invoice.Local;
           
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            InvoiceWindow invoiceWindow = new InvoiceWindow();
            invoiceWindow.Show();
            InvoiceGrid.ItemsSource = dbEntities.Invoice.Local;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            dbEntities.Invoice.Load();
            InvoiceGrid.ItemsSource = dbEntities.Invoice.Local;
        }
    }
}
