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
using WpfApp2.DataSet1TableAdapters;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {

        DataSet1 dt = new DataSet1();
        UserTableAdapter userTA = new UserTableAdapter();

        public static string namePerson = "";

        public SignIn()
        {
            InitializeComponent();

            userTA.Fill(dt.User);
        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dt.User.Rows.Count; i++) {
                namePerson = dt.User.Rows[i][1].ToString() + ' ' + dt.User.Rows[i][2].ToString() + ' ' + dt.User.Rows[i][3].ToString();

                if (login.Text == dt.User.Rows[i][4].ToString())
                {
                    if (pass.Text == dt.User.Rows[i][5].ToString()) {

                        if (Convert.ToInt32(dt.User.Rows[i][6]) == 1) {

                            ProductWindow productWindow = new ProductWindow();
                            this.Hide();
                            productWindow.Show();

                            //MessageBox.Show("Админ");
                        }
                        else if (Convert.ToInt32(dt.User.Rows[i][6]) == 2)
                        {

                            ProductWindow productWindow = new ProductWindow();
                            this.Hide();
                            productWindow.Show();

                            //MessageBox.Show("Менеджер");
                        }
                        else if (Convert.ToInt32(dt.User.Rows[i][6]) == 3)
                        {

                            ProductWindow productWindow = new ProductWindow();
                            this.Hide();
                            productWindow.Show();

                            //MessageBox.Show("Клиент");
                        }
                    }
                }
            }
            
        }

        private void guest_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            this.Hide();
            productWindow.Show();
        }
    }
}
