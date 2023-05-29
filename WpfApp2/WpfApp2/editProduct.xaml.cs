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
    /// Логика взаимодействия для editProduct.xaml
    /// </summary>
    public partial class editProduct : Window
    {
        DataSet1 dt = new DataSet1();
        ProductTableAdapter productTA = new ProductTableAdapter();

        public editProduct()
        {
            InitializeComponent();
            productTA.Fill(dt.Product);

            categoryProduct.ItemsSource = dt.Product.DefaultView;
            categoryProduct.SelectedValuePath = "ProductArticleNumber";
            categoryProduct.DisplayMemberPath = "ProductCategory";


            numberProduct.Text = ProductWindow.productId;

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            try {
                productTA.UpdateQuery(
                    numberProduct.Text, 
                    titleProduct.Text, 
                    "Рулон", 
                    Convert.ToDecimal(costProduct.Text), 
                    null, 
                    manufacturerProduct.Text, 
                    supplierProduct.Text, 
                    categoryProduct.SelectedValue.ToString(), 
                    Convert.ToByte(discountProduct.Text), 
                    Convert.ToInt32(quantityProduct.Text), 
                    manProduct.Text, 
                    photoProduct.Text,
                    ProductWindow.productId);

                ProductWindow productWindow = new ProductWindow();
                this.Hide();
                productWindow.Show();

            } catch { }
        }
    }
}
