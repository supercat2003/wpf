using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApp2.DataSet1TableAdapters;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet1 dt = new DataSet1();
        UserTableAdapter userTA = new UserTableAdapter();
        RoleTableAdapter roleTA = new RoleTableAdapter();

        public static string FIO = "";

        public MainWindow()
        {
            InitializeComponent();

            userTA.Fill(dt.User);
            roleTA.Fill(dt.Role);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < dt.User.Rows.Count; i++)
            {
                if (login.Text == dt.User.Rows[i][4].ToString() && pass.Text == dt.User.Rows[i][5].ToString())
                {
                    if (Convert.ToInt32(dt.User.Rows[i][6]) == 1)
                    {
                        string surname = dt.User.Rows[i][1].ToString();
                        string name = dt.User.Rows[i][2].ToString();
                        string middle = dt.User.Rows[i][3].ToString();

                        FIO = surname + ' ' + name + ' ' + middle;

                        Window1 window1 = new Window1();
                        this.Hide();
                        window1.Show();

                    }
                    else if (Convert.ToInt32(dt.User.Rows[i][6]) == 2)
                    {

                    }

                    else if (Convert.ToInt32(dt.User.Rows[i][6]) == 3)
                    {

                    }
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            this.Hide();
            window1.Show();
        }
    }
}


