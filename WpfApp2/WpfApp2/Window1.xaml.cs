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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        class Product { 
            public string Photo { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Manufacturer { get; set; }
            public decimal Cost { get; set; }
            public int QuantityInStock { get; set; }
        }

        DataSet1 dt = new DataSet1();
        ProductTableAdapter productTA = new ProductTableAdapter();


        public Window1()
        {
            InitializeComponent();

            name.Content = MainWindow.FIO;
            List<Product> item = new List<Product>();

            productTA.Fill(dt.Product);

            string pictureValue = "";
            

            for (int i = 0; i < dt.Product.Rows.Count; i++) {

                pictureValue = "C:/Users/Ангелина/Source/Repos/WpfApp2/WpfApp2/Images/" + dt.Product.Rows[i][11].ToString().ToLower();

                if (dt.Product.Rows[i][11].ToString() == "")
                {
                    pictureValue = "C:/Users/Ангелина/Source/Repos/WpfApp2/WpfApp2/Images/picture.png";
                }

                //item.Add(new Product() { Photo = "logo.png", Name = dt.Product.Rows[i][1].ToString(), Description = dt.Product.Rows[i][10].ToString(), Manufacturer = dt.Product.Rows[i][5].ToString(), Cost = (double)dt.Product.Rows[i][3], QuantityInStock = Convert.ToInt32(dt.Product.Rows[i][9])});
                item.Add(new Product() { Photo = pictureValue, Name = dt.Product.Rows[i][1].ToString(), Description = dt.Product.Rows[i][10].ToString(), Manufacturer = dt.Product.Rows[i][5].ToString(), Cost = (decimal)dt.Product.Rows[i][3], QuantityInStock = Convert.ToInt32(dt.Product.Rows[i][9]) });

            }

            lbProduct.ItemsSource = item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
