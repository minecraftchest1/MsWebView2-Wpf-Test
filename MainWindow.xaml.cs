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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Core;

namespace WebView2_Mattermost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            webView_NavigateTo();
        }

        private void addressBar_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                webView_NavigateTo();
            }
            if (e.Key == Key.Enter)
            {
             webView_NavigateTo();
            }
        }

        private void webView_NavigateTo()
        {
            try
            {
                if (webView3 != null && webView3.CoreWebView2 != null)
                {
                    webView3.CoreWebView2.Navigate(addressBar.Text);
                }
            }
            catch (ArgumentException)
            {
                if (webView3 != null && webView3.CoreWebView2 != null)
                {
                    webView3.CoreWebView2.Navigate("https://" + addressBar.Text);
                }
            }
        }

        private void webView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            addressBar.Text = uri;
        }
    }
}
