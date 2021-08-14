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
    public sealed partial class SellerPanel : Page
    {
        public SellerPanel()
        {
            this.InitializeComponent();

            Uri uri = new Uri("https://firebasestorage.googleapis.com/v0/b/badmintoncourt-48bb4.appspot.com/o/Images%2Fcart.png?alt=media&token=557c6f89-6cf1-43ef-8c5a-6e0ef3a81999", UriKind.Absolute);
            ImageSource imgSource = new BitmapImage(uri);
            carticon.Source = imgSource;
        }

        private async void DisplayDialog(string title, string content)
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noDialog.ShowAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Admin));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(EditPage));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DeletePage));
        }

    }
}
