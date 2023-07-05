using StudPractice.View;
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
using StudPractice.ViewModels;

namespace StudPractice.Veiw
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        public string CurrentUser { get; set; }

        public LoginView()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
      
           // Запись данных, введенных в txtUser, в переменную CurrentUser
            CurrentUser = txtUser.Text;
            
            // Передача данных в MainView
            PassDataToMainView();
        }

        private void Create_Click(object sender, MouseButtonEventArgs e)
        {
            Registration register = new Registration();
            register.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private void PassDataToMainView()
        {
            // Создание экземпляра MainView
            MainView mainView = new MainView();

            // Передача данных из переменной CurrentUser в свойство MainView.CurrentUser
            mainView.CurrentUser = CurrentUser;

            // Открытие окна MainView
            

            // Закрытие текущего окна LoginView
           
        }
    }
}