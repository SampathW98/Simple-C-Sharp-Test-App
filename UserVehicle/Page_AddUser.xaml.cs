using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using UserVehicle.UserDetails;

namespace UserVehicle
{
    /// <summary>
    /// Interaction logic for Page_AddUser.xaml
    /// </summary>
    public partial class Page_AddUser : Page
    {
        public Page_AddUser()
        {
            InitializeComponent();
            clearBtnUser();
            FillUserTable(User.getUsers());
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();

            user.Name = nameTxt.Text;
            user.Age = int.Parse(ageTxt.Text);

            User.addNewRoom(user);

            FillUserTable(User.getUsers());

            clearBtnUser();

        }

        private void FillUserTable(List<User> list)
        {
            var userList = new ObservableCollection<User>();
            list.ForEach(x => userList.Add(x));

            listviewUser.ItemsSource = userList;
        }




        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTxt.Text = "";
            ageTxt.Text = "";
        }

        private void clearBtnUser()
        {
            nameTxt.Text = "";
            ageTxt.Text = "";
        }
    }
}
