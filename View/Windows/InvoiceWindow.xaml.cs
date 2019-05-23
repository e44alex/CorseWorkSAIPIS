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
using CourseWork_SAIPIS.Database;

namespace CourseWork_SAIPIS
{
    /// <summary>
    /// Логика взаимодействия для InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow()
        {
            InitializeComponent();
        }

        //Кнопка "добавить ТТН" 
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            using (CourseWorkDBEntities3 dbEntities = new CourseWorkDBEntities3())
            {
                Invoice addInvoice = new Invoice();
                if (NumberField.Text == "")
                {
                    MessageBox.Show("Поле \"Номер ТТН\" не может быть пустым", "Error");
                    return;
                }
                try
                {
                    addInvoice.InvoiceNumber = Convert.ToInt32(NumberField.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Номер ТТН: поле должно быть числом", "Error");
                    return;
                }

                if (FromField.Text == "")
                {
                    MessageBox.Show("Поле \"Пункт отправления\" не может быть пустым", "Error");
                    return;

                }
                addInvoice.SendPoint = FromField.Text;

                if (ToField.Text == "")
                {
                    MessageBox.Show("Поле \"Пункт назначения\" не может быть пустым", "Error");
                    return;
                }
                addInvoice.RecievePoint = FromField.Text;

                if (WeightField.Text == "")
                {
                    MessageBox.Show("Поле \"Масса груза\" не может быть пустым", "Error");
                    return;
                }

                try
                {
                    addInvoice.CargoWeight = Convert.ToInt32(WeightField.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Масса груза: поле должно быть числом", "Error");
                    return;
                }

                //TODO current client
               
                addInvoice.ClientId = Program.CurrUserId;

                try
                {
                    dbEntities.Invoice.Local.Add(addInvoice);
                    dbEntities.SaveChangesAsync();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error adding item");
                    return;

                }

                MessageBox.Show("Накладная добавлена");
            }
            
        }
    }
}
