using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace UserVehicle.UserDetails
{
    class Car
    {
        private String name;
        private String car;

        public Car() { }

        public Car(String name, String car) 
        {
            this.name = name;
            this.car = car;
        }

        public String UserName { get => name; set => name = value; }

        public String CarName { get => car; set => car = value; }

        public static void addNewCar(Car car)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = "INSERT INTO Cars(ucname,cname) VALUES (@uname,@cname)";

                command.Parameters.AddWithValue("@uname", car.UserName);
                command.Parameters.AddWithValue("@cname", car.CarName);

                command.ExecuteNonQuery();

                MessageBox.Show("Success");

            }
        }

        public static List<Car> getAll()
        {
            List<Car> carList = new List<Car>();

            using (SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = @"SELECT ucname,cname FROM Cars";
                SQLiteDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Car car = new Car();
                    car.UserName = reader["ucname"].ToString();
                    car.CarName = reader["cname"].ToString();

                    carList.Add(car);
                }

            }

            return carList;
        }

    }
}
