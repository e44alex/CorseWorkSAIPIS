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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page       
    {
        CourseWorkDBEntities3 db = new CourseWorkDBEntities3();
        List<EventsList> list = new List<EventsList>();
        public Page2()
        {
            InitializeComponent();

            list = ClientServerController.eventsLists();
            db.EventsList.LoadAsync();
            DataGrid.ItemsSource = db.EventsList.Local;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            ClientServerController.SaveChangesEvents(list);
            db.EventsList.Remove((EventsList)DataGrid.SelectedItem);
            db.SaveChangesAsync();
            DataGrid.ItemsSource = db.EventsList.Local;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientServerController.SaveChangesEvents(list);
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    exception.Message + "\n" +
                    "Can't add data. Hint:\n \"UserId\" and \"Username\" fields must be unique and not empty\n \"Status\" field must be filled",
                    "Error");
                return;
            }

            MessageBox.Show("Data was added!");
        }
    }
}
