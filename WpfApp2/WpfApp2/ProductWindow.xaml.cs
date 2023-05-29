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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public class Product {
            public string Art { get; set; }
            public string Photo { get; set; }
            public string Description { get; set; }
            public decimal Number { get; set; }
            public int Discount { get; set; }
        }

        DataSet1 dt = new DataSet1();
        ProductTableAdapter productTA = new ProductTableAdapter();
        public List<Product> items = new List<Product>();
        public static List<Product> order = new List<Product>();
        public static string productId = "";

        public ProductWindow()
        {
            InitializeComponent();
            productTA.Fill(dt.Product);

            orderShow.Visibility = Visibility.Hidden;

            name.Content = SignIn.namePerson;
            if (name.Content.ToString() == "") {
                name.Content = "Гость";
            }

            string namePicture = "";
            string descriptionProduct = "";
            decimal costProduct = 0;
            int discountProduct = 0;
            string artProduct = "";
            

            for (int i = 0; i < dt.Product.Rows.Count; i++)
            {
                namePicture = "/Images/" + dt.Product.Rows[i][11].ToString().ToLower();
                if (dt.Product.Rows[i][11].ToString() == "")
                {
                    namePicture = "/Images/picture.png";
                }

                descriptionProduct = dt.Product.Rows[i][10].ToString();
                costProduct = Convert.ToDecimal(dt.Product.Rows[i][3]);
                discountProduct = Convert.ToInt32(dt.Product.Rows[i][8]);
                artProduct = dt.Product.Rows[i][0].ToString();


                items.Add(new Product { Art = artProduct, Photo = namePicture, Description = descriptionProduct, Number = costProduct, Discount = discountProduct });
            }
            

            lvProduct.ItemsSource = items;


        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            this.Hide();
            signIn.Show();
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            orderShow.Visibility = Visibility.Visible;

            if (lvProduct.SelectedItem != null) {
                order.Add(items[lvProduct.Items.IndexOf(lvProduct.SelectedItem)]);
            }
           
        }

        private void orderShow_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.ShowDialog();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                productId = items[lvProduct.Items.IndexOf(lvProduct.SelectedItem)].Art;
            }

            editProduct editProduct = new editProduct();
            editProduct.ShowDialog();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem != null)
            {
                items.RemoveAt(lvProduct.Items.IndexOf(lvProduct.SelectedItem));
                productTA.DeleteQuery(productId);
                lvProduct.Items.Refresh();
            }
            
        }
    }
}
