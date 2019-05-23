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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseWork_SAIPIS.Database;

namespace CourseWork_SAIPIS
{
    /// <summary>
    /// Логика взаимодействия для ExpertsListPage.xaml
    /// </summary>
    public partial class ExpertsListPage : Page
    {
        CourseWorkDBEntities3 dbEntities = new CourseWorkDBEntities3();
        List<Experts> list = new List<Experts>();
        public ExpertsListPage()
        {
            InitializeComponent();
            

            List<Experts> experts = ClientServerController.expertsList();
            DataGrid.ItemsSource = experts;

            dbEntities.Experts.Load();
            DataGrid.ItemsSource = dbEntities.Experts.Local;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientServerController.SaveChangesExperts(list);
                dbEntities.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                //throw;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Experts item = (Experts)DataGrid.SelectedItem;
            if (item != null)
            {
                dbEntities.Experts.Remove(item);
            }

            try
            {
                ClientServerController.SaveChangesExperts(list);
                dbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
        }
    }
}
