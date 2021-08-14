using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Equipment_Shop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShoppingCart : Page
    {
        private static List<Merchandise> merchandises = new List<Merchandise>();
        int shipping = 5;

        public ShoppingCart()
        {
            this.InitializeComponent();
            
            cartlist.ItemsSource = merchandises;

            PaymentDetails.SubTotal += PaymentDetails.SingleTotal;
            subtotal.Text = "RM " + PaymentDetails.SubTotal.ToString();
            shippingfee.Text = "RM 5";
            
            PaymentDetails.Total = PaymentDetails.SubTotal + shipping;
            total.Text = "RM " + PaymentDetails.Total.ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var merch = (Merchandise)e.Parameter;
            merch.Quantity = PaymentDetails.Quantity;
            merchandises.Add(merch);
        }

        //Back Button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(QRPayment));
        }
    }
}
