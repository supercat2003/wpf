using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        DataSet1 dt = new DataSet1();
        PickUpPointTableAdapter pickUpPointTA = new PickUpPointTableAdapter();
        OrderTableAdapter orderTA = new OrderTableAdapter();

        public decimal finalCost = 0;
        public int finalDiscount = 0;

        public Order()
        {
            InitializeComponent();

            pickUpPointTA.Fill(dt.PickUpPoint);
            orderTA.Fill(dt.Order);

            cmbPickUp.ItemsSource = dt.PickUpPoint.DefaultView;
            cmbPickUp.SelectedValuePath = "PickupPointID";
            cmbPickUp.DisplayMemberPath = "PickupPointAddress";

            lvProduct.ItemsSource = ProductWindow.order;


            for (int i = 0; i < ProductWindow.order.Count; i++)
            {
                finalCost += ProductWindow.order[i].Number;
            }
            cost.Content = "Суммарная стоимость: " + finalCost;

            for (int i = 0; i < ProductWindow.order.Count; i++) {
                finalDiscount += ProductWindow.order[i].Discount;
            }
            discount.Content = "Скидка: " + finalDiscount + "%";

            

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (lvProduct.SelectedItem != null){
                ProductWindow.order.RemoveAt(lvProduct.Items.IndexOf(lvProduct.SelectedItem));
            }
            lvProduct.Items.Refresh();

            finalDiscount = 0;
            finalCost = 0;

            for (int i = 0; i < ProductWindow.order.Count; i++)
            {
                finalCost += ProductWindow.order[i].Number;
            }
            cost.Content = "Суммарная стоимость: " + finalCost;


            for (int i = 0; i < ProductWindow.order.Count; i++)
            {
                finalDiscount += ProductWindow.order[i].Discount;
            }
            discount.Content = "Скидка: " + finalDiscount + "%";

        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            var orderCode = random.Next(100, 999);

            DateTime date = DateTime.Now;
            DateTime dateDelivery = date.AddDays(7);

            try {
                orderTA.InsertQuery(date.ToString(), dateDelivery.ToString(), (int)cmbPickUp.SelectedValue, orderCode, "Новый");
                MessageBox.Show("Заказ " + orderCode + " оформлен");
            } catch {
                MessageBox.Show("Произошла ошибка");
            }
            


        }
    }
}
