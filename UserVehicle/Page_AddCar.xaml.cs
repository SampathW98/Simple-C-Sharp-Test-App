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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using UserVehicle.UserDetails;
using System.Collections.ObjectModel;

namespace UserVehicle
{
    /// <summary>
    /// Interaction logic for Page_AddCar.xaml
    /// </summary>
    public partial class Page_AddCar : Page
    {
        public Page_AddCar()
        {
            InitializeComponent();
            loadUserCombo();
            FillCarsTable(Car.getAll());
        }

        public void loadUserCombo()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);

                command.CommandText = @"SELECT uname FROM Users";
                SQLiteDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string u_name = reader["uname"].ToString();
                    nameCmb.Items.Add(u_name);
                }
            }
        }

        private void addBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            Car car = new Car();

            car.UserName = nameCmb.Text;
            car.CarName = brandTxt.Text;

            Car.addNewCar(car);

            FillCarsTable(Car.getAll());

        }

        private void FillCarsTable(List<Car> list)
        {
            var carlist = new ObservableCollection<Car>();
            list.ForEach(x => carlist.Add(x));

            listviewCars.ItemsSource = carlist;
        }
    }

}
