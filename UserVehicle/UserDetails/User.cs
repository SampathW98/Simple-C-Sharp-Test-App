using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace UserVehicle.UserDetails
{
    class User
    {
        private String name;
        private int age;

        public User() {}

        public User(String name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public String Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public static void addNewRoom(User user)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = "INSERT INTO Users(uname,uage) VALUES (@uname,@uage)";

                command.Parameters.AddWithValue("@uname", user.Name);
                command.Parameters.AddWithValue("@uage", user.Age);

                var t = command.ExecuteNonQuery();

                MessageBox.Show("Success");

            }
        }

        public static List<User> getUsers()
        {
            List<User> userList = new List<User>();

            using (SQLiteConnection conn = new SQLiteConnection(App.connString))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(conn);
                command.CommandText = @"SELECT uname,uage FROM Users";
                SQLiteDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    User user = new User();
                    user.Name = reader["uname"].ToString();
                    user.Age = int.Parse(reader["uage"].ToString());

                    userList.Add(user);
                }
            }

            return userList;
        }

    }
}
