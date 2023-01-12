using System.Windows;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;

namespace GuiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRepository<Car> _carManager;
        public MainWindow()
        {
            InitializeComponent();
            _carManager = new CarManager();
            UpdateCarsView();
        }

        private void Cars_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Cars.SelectedItem is Car car)
            {
                Make.Text = car.Make.Name;
                Model.Text = car.Model;
                Colour.Text = car.Colour.Name;
                Horse.Text = $"{car.Horse}";
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            _carManager.AddColour(new Colour { Name = Colour.Text });
            _carManager.AddMake(new Make { Name = Make.Text });
            var colour = _carManager.GetColour(Colour.Text);
            var make = _carManager.GetMake(Make.Text);
            var car = new Car()
            {
                Make = make,
                Model = Model.Text,
                Colour = colour,
                Horse = int.Parse(Horse.Text)
            };
            _carManager.Add(car);
            UpdateCarsView();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedItem is Car car)
            {
                if (!string.IsNullOrEmpty(Make.Text) && !string.IsNullOrEmpty(Model.Text) && !string.IsNullOrEmpty(Colour.Text) && !string.IsNullOrEmpty(Horse.Text))
                {
                    _carManager.AddColour(new Colour { Name = Colour.Text });
                    _carManager.AddMake(new Make { Name = Make.Text });
                    var make = _carManager.GetMake(Make.Text);
                    var colour = _carManager.GetColour(Colour.Text);
                    var newCar = new Car()
                    {
                        Make = make,
                        Model = Model.Text,
                        Colour = colour,
                        Horse = int.Parse(Horse.Text)
                    };
                    _carManager.Replace(car.Id, newCar);
                }

                UpdateCarsView();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedItem is Car car)
            {
                _carManager.Delete(car.Id);
            }

            UpdateCarsView();
        }

        private void UpdateCarsView()
        {
            var cars = _carManager.GetAll();
            Cars.Items.Clear();
            foreach (var car in cars)
            {
                Cars.Items.Add(car);
            }

            ClearFields();
        }

        private void ClearFields()
        {
            Make.Text = string.Empty;
            Colour.Text = string.Empty;
            Model.Text = string.Empty;
            Horse.Text = string.Empty;
        }
    }
}
