using StudPractice.Veiw;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;

namespace StudPractice.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

           




        }







            

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text.Length > 0) // проверяем логин
            {
            }
            else
            {
                MessageBox.Show("Укажите логин");
                return; // прекращение выполнения программы
            }

            if (txtPass.Password.Length > 0)
            {
            }
            else
            {
                MessageBox.Show("Укажите пароль");
                return; // прекращение выполнения программы
            }

            if (txtUser_Copy.Text.Length > 0)
            {
            }
            else
            {
                MessageBox.Show("Укажите ваше имя");
                return; // прекращение выполнения программы
            }

            if (txtUser_Copy1.Text.Length > 0)
            {
            }
            else
            {
                MessageBox.Show("Укажите вашу фамилию");
                return; // прекращение выполнения программы
            }

            if (txtUser_Copy2.Text.Length > 0)
            {
            }
            else
            {
                MessageBox.Show("Укажите ваше отчество");
                return; // прекращение выполнения программы
            }

            if (txtPass.Password.Length >= 3)
            {
                bool en = true; // английская раскладка
                bool symbol = false; // символ
                bool number = false; // цифра

               
            for (int i = 0; i < txtPass.Password.Length; i++) // перебираем символы
                {
                    if (txtPass.Password[i] >= 'А' && txtPass.Password[i] <= 'Я') en = false; // если русская раскладка
                    if (txtPass.Password[i] >= '0' && txtPass.Password[i] <= '9') number = true; // если цифры
                    if (txtPass.Password[i] == '_' || txtPass.Password[i] == '-' || txtPass.Password[i] == '!') symbol = true; // если символ
                }

                if (!en)
                {
                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                    return; // прекращение выполнения программы
                }
                else if (!symbol)
                {
                    MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                    return; // прекращение выполнения программы
                }
                else if (!number)
                {
                    MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                    return; // прекращение выполнения программы
                }
            }
            else
            {
                MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                return; // прекращение выполнения программы
            }



            try
            {
                string connectionString = "Data Source=DESKTOP-FQ47L6A\\SQLEXPRESS;Initial Catalog=Aviasales;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                        // Создание SQL-запроса для добавления данных
        string query = "INSERT INTO Login (Username, Password, Name, Surname, [MiddleName]) " +
                       "VALUES (@Username, @Password, @Name, @Surname, @MiddleName)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Параметры для передачи значений из TextBox в SQL-запрос
                        command.Parameters.AddWithValue("@Username", txtUser.Text);
                        command.Parameters.AddWithValue("@Password", txtPass.Password);
                        command.Parameters.AddWithValue("@Name", txtUser_Copy.Text);
                        command.Parameters.AddWithValue("@Surname", txtUser_Copy1.Text);
                        command.Parameters.AddWithValue("@MiddleName", txtUser_Copy2.Text);

                        // Выполнение SQL-запроса
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Данные успешно добавлены");
            
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }


        private void Create_Click(object sender, MouseButtonEventArgs e)
        {
            
            this.Hide();
        }
    }
}
