using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
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
using StudPractice.ImageClass;
using System.Data.SqlTypes;
using System.Data.Entity;
using StudPractice.SQL;
using StudPractice.View;
using StudPractice.Veiw;
using static StudPractice.Veiw.LoginView;
using Microsoft.SqlServer.Management.Smo;
using StudPractice.ViewModels;
using System.Net.NetworkInformation;
using System.Security.Policy;
using StudPractice.Themes;

namespace StudPractice.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
         AdvertismentModel inf = new AdvertismentModel();

        public string CurrentUser { get; set; }
        public MainView()
        {
            InitializeComponent(); 
            // Получаем размеры экрана
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            // Устанавливаем позицию окна в центре экрана
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = (screenHeight - this.Height) / 2;

            Random random = new Random();


            int r = random.Next(0, 3);
            Photo_of_the_city.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LCD.Content = inf.cities[r];
            TBCD.Text = inf.short_description_cities[r];


            r = random.Next(0, 3);
            Photo_of_the_city_s_attraction.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LCA.Content = inf.cities[r];
            TBCA.Text = inf.description_attractions[r];



            r = random.Next(0, 3);
            Photo_of_the_city2.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LCD2.Content = inf.cities[r];
            TBCD2.Text = inf.description_festivals[r];



            r = random.Next(0, 3);
            Photo_of_the_local_festival2.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LFD2.Content = inf.cities[r];
            TBFD2.Text = inf.short_description_hotels[r];



            r = random.Next(0, 2);
            Photo_of_the_local_festival.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LFD.Content = inf.cities[r];
            TBFD.Text = inf.description_discounts[r];



            r = random.Next(0, 3);
            Photo_of_the_hotels2.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LHD2.Content = inf.cities[r];
            TBHD2.Text = inf.short_description_cities[r];



            r = random.Next(0, 3);
            Photo_of_the_discounts.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LCD.Content = inf.cities[r];
            TBDD.Text = inf.description_attractions[r];


            r = random.Next(0, 3);
            Photo_of_the_hotels.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LHD.Content = inf.cities[r];
            TBHD.Text = inf.description_festivals[r];
        }

        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

       







        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {



            Folder.Visibility = Visibility.Hidden;
            btnSavePicture.Visibility = Visibility.Visible;
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == true)
            {
                // Получаем путь к выбранному файлу
                string imagePath = openFileDialog1.FileName;

                // Загружаем изображение из файла в BitmapImage
                BitmapImage bitmap = new BitmapImage(new Uri(imagePath));

                // Устанавливаем BitmapImage в свойство Source элемента Image
                Avka.Source = bitmap;
            }
        }

        private void Avka_Loaded(object sender, RoutedEventArgs e)
        {
           
           
        }
       
        private void SavePicture_Click(object sender, RoutedEventArgs e)
        {


            Folder.Visibility = Visibility.Visible;
            btnSavePicture.Visibility = Visibility.Hidden;
        }

    
       
        

       

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            TBstatus.IsHitTestVisible = true ;
            TBstatus.Focusable = true;
            TBstatus.Width = 624;
            TBstatus.Background = Brushes.Purple;
            TBstatus.IsReadOnly = false;
            Bchange_status.Visibility = Visibility.Hidden;
            Bsave_status.Visibility = Visibility.Visible;
        }
    

        private void SaveStatus_Click(object sender, RoutedEventArgs e)
        {
            TBstatus.Width = Double.NaN;
            TBstatus.Background = Brushes.Transparent;
            TBstatus.IsReadOnly = true;
            Bsave_status.Visibility = Visibility.Hidden;
            Bchange_status.Visibility = Visibility.Visible;
            TBstatus.IsHitTestVisible = false;
        }

        

        private void Raspisanie_Click(object sender, RoutedEventArgs e)
        {
            InfoBilet info = new InfoBilet();
            info.Show();
        }

       

        

        

        private void LightThemeClick(object sender, RoutedEventArgs e)
        {
            Themes.AppTheme.ChangeTheme(new Uri("/Themes/LightTheme.xaml", UriKind.Relative));
        }

        private void DarkThemeClick(object sender, RoutedEventArgs e)
        {
            Themes.AppTheme.ChangeTheme(new Uri("/Themes/DarkTheme.xaml", UriKind.Relative));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            InfoBilet info = new InfoBilet();
            info.Show();
        }
    }
}





















