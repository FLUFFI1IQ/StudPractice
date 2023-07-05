using StudPractice.Models;
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

namespace StudPractice.View
{
    /// <summary>
    /// Логика взаимодействия для InfoBilet.xaml
    /// </summary>
    public partial class InfoBilet : Window
    {
        Jason jason = new Jason();
        public InfoBilet()
        {
            InitializeComponent();
            Load_data();
        }

        private void Load_data()
        {
            var all_data = jason.Get_all_display_data();
            grid1.ItemsSource = all_data;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
