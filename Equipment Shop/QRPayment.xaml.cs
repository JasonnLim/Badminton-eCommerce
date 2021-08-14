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
    public sealed partial class QRPayment : Page
    {
        public QRPayment()
        {
            this.InitializeComponent();

            Uri uri = new Uri("https://firebasestorage.googleapis.com/v0/b/badmintoncourt-48bb4.appspot.com/o/Images%2FQR%20Pay.png?alt=media&token=9f1d5b3f-96ca-4a47-81fb-aaeb79270f86", UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            qrcode.Source = imgSource;

            TotalPayment.Text = "RM " + PaymentDetails.Total.ToString();
        }

        private void Proceed_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Receipt));
        }
    }
}
