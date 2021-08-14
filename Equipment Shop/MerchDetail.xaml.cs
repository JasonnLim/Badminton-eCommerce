using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class MerchDetail : Page
    {
        FirebaseHelper FirebaseHelper = new FirebaseHelper();

        Merchandise merch;
        int prices = 0;

        public MerchDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            merch = (Merchandise)e.Parameter;

            Uri uri = new Uri(merch.ImageURL, UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            image.Source = imgSource;

            name.Text = merch.Name.ToString();
            type.Text = merch.Type.ToString();
            price.Text = merch.Price.ToString();

            prices = int.Parse(merch.Price.Replace("RM",""));
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            PaymentDetails.SingleTotal = PaymentDetails.Quantity * prices;
            
            this.Frame.Navigate(typeof(ShoppingCart), merch);
        }

        //Back Button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void quantity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBoxItem)quantity.SelectedItem).Content.ToString();

            PaymentDetails.Quantity = int.Parse(item);
        }
    }
}
