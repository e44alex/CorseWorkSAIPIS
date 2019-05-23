using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace CourseWork_SAIPIS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClientServerController.Connect();

            #region Debug!!!

            //Window1 menuWindow = new Window1();
            //menuWindow.Show();
            //this.Close();

            #endregion
        }

        #region Button Clicks

        private void LogInButtonClick(object sender, RoutedEventArgs e)
        {
            int result = ClientServerController.Login(LoginField.Text, PasswordField.Password);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Пользователя не существует", "Ошибка");
                    break;
                case 1:
                    MessageBox.Show("Неправильный пароль", "Ошибка");
                    break;
                case 2:
                    MessageBox.Show("Вход успешен", "Успех");
                    OpenWindow();
                    break;
            }
        }

        private void OpenWindow()
        {
            MessageBox.Show(mySystem.UserStatus);
            //mySystem.UserStatus = "admin";
            switch (mySystem.UserStatus)
            {
                case "regular":
                    {
                        ClientWindow window = new ClientWindow();
                        window.Show();
                        this.Close();
                        break;

                    }

                case "admin":
                    {
                        Window1 window = new Window1();
                        window.Show();
                        this.Close();
                        break;

                    }

                case "expert":
                    {
                        ExpertWindow window = new ExpertWindow();
                        window.Show();
                        this.Close();
                        break;

                    }
            }
        }

        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            int result = ClientServerController.Regitration(LoginField.Text, PasswordField.Password);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Регистрация не произведена", "Ошибка");
                    break;
                case 1:
                    MessageBox.Show("Регистрация прошла успешно", "Успех");
                    break;
            }
        }

        #endregion
    }
}
