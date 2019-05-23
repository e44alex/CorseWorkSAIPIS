using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CourseWork_SAIPIS.Windows
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        List<Users> users = ClientServerController.userList();
        private CourseWorkDBEntities3 db = new CourseWorkDBEntities3();
        public Page1()
        {
            InitializeComponent();
            DataGrid.ItemsSource = users;
            
                db.Users.Load();
                DataGrid.ItemsSource = db.Users.Local;
            

        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ClientServerController.SaveChangesUsers(users);
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            Users item = (Users)DataGrid.SelectedItem;
            foreach (var VARIABLE in users)
            {
                if (VARIABLE.UserId == item.UserId && VARIABLE.Password == item.Password)
                    users.Remove(VARIABLE);
                break;
            }
            DataGrid.ItemsSource = users;

                ClientServerController.SaveChangesUsers(users);
                    db.Users.Remove((Users) DataGrid.SelectedItem);
                    db.SaveChangesAsync();
                    DataGrid.ItemsSource = db.Users.Local;
        }

    }
}
