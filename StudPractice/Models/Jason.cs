using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudPractice.Models
{
    internal class Jason
    {
        public List<AviaPereleti> jason = null;
        public void Load_data_from_Json()
        {
            string file_name = "C:\\Users\\LYon2\\Desktop\\Джейсон\\avia1.json";

            if (File.Exists(file_name) == true)
            {
                var list = JsonConvert.DeserializeObject < List < AviaPereleti>>(File.ReadAllText(file_name));
                if (list != null)
                    jason = list;
                else
                    MessageBox.Show("Файл пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public List<JasonModel> Get_all_display_data()
        {
            Load_data_from_Json();
            if (jason != null)
            {
                List<JasonModel> all = new List<JasonModel>();
                for (int i = 0; i < jason.Count; i++)
                {
                    JasonModel record = new JasonModel
                    {
                        Departure_city = jason[i].StartCity,
                        Departure_city_code = jason[i].StartCityCode,
                        City_of_arrival = jason[i].EndCity,
                        City_of_arrival_code = jason[i].EndCityCode,
                        Arrival_time = jason[i].EndDate.ToLocalTime(),
                        Dparture_time = jason[i].StartDate.ToLocalTime(),
                        Price = jason[i].Price,
                        
                    };
                    all.Add(record);
                }
                return all;
            }
            return null;
        }

    }
}
