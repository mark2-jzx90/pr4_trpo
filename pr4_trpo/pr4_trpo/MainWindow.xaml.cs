using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.IO;

namespace pr4_trpo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Car CurrentCar = new Car();
        public MainWindow()
        {
            InitializeComponent();
            CurrentCar.Id = new Random().Next(1,99);
            DataContext = CurrentCar;
        }
        private void Find_Click (object sender, RoutedEventArgs e)
        {
            if(int.TryParse(Search.Text,out int searchId))
            {
                string filename = $"{searchId}.json";
                if (File.Exists(filename))
                {
                    try
                    {
                        string json = File.ReadAllText(filename);
                        Car loadedCar = JsonSerializer.Deserialize<Car>(json);
                        CurrentCar.Id = loadedCar.Id;
                        CurrentCar.Brand = loadedCar.Brand;
                        CurrentCar.Model = loadedCar.Model;
                        CurrentCar.Year = loadedCar.Year;
                        CurrentCar.Km = loadedCar.Km;
                        DataContext = null;
                        DataContext = CurrentCar;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Ошибка : {ex.Message}", "Ошибка");
                    }
                } else
                {
                    MessageBox.Show("Введи корректный ID (только цифры)", "Ошибка");
                }
            }
        }

        private void Save_Click (object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = $"{CurrentCar.Id}.json";
                string jsonString = JsonSerializer.Serialize(CurrentCar, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, jsonString);
                MessageBox.Show($"Сохранено: {fileName}", "Успех");
            } catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка");
            }
        }

        private void New_Click (object sender, RoutedEventArgs e)
        {
            CurrentCar = new Car();
            CurrentCar.Id = new Random().Next(1,100);
            DataContext = CurrentCar ;
            Search.Text = "";
        }

        private void Delete_Click (object sender, RoutedEventArgs e)
        {
            CurrentCar = new Car();
            CurrentCar.Id = new Random().Next(1, 100);
            DataContext = CurrentCar;
            Search.Text = "";
            MessageBox.Show("ВСё сброшено.");
        }
    }
}