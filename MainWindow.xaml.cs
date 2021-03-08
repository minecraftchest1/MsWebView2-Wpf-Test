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
            //webView2.CoreWebView2.PermissionRequested += webView_PermissionRequested;
        }

        private void webView_PermissionRequested(object sender, CoreWebView2PermissionRequestedEventArgs args)
        {
            //MessageBox.Show(args.Uri + " requested permission " + args.PermissionKind, "Permission Requested", MessageBoxButton.YesNo, MessageBoxImage.None);
            args.State=CoreWebView2PermissionState.Allow;
            MessageBox.Show("Permission " + args.PermissionKind + " Requested by " + args.Uri + ".", "Permission Requested.", MessageBoxButton.OK, MessageBoxImage.Information);
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


        private void ButtonGoGC_Click(object sender, RoutedEventArgs e)
        {
            webViewGC_NavigateTo();
        }
        private void webViewGC_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            addressBarGC.Text = uri;
        }

         private void addressBarGC_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                webViewGC_NavigateTo();
            }
            if (e.Key == Key.Enter)
            {
             webViewGC_NavigateTo();
            }
        }

        private void webViewGC_NavigateTo()
        {
            try
            {
                if (webViewGoogleCalendar != null && webViewGoogleCalendar.CoreWebView2 != null)
                {
                    webViewGoogleCalendar.CoreWebView2.Navigate(addressBarGC.Text);
                }
            }
            catch (ArgumentException)
            {
                if (webViewGoogleCalendar != null && webViewGoogleCalendar.CoreWebView2 != null)
                {
                    webViewGoogleCalendar.CoreWebView2.Navigate("https://" + addressBarGC.Text);
                }
            }
        }

        private void webView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            addressBar.Text = uri;
        }

        private void webView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            //String[] Args = args.
            //webView3.CoreWebView2.ExecuteScriptAsync($"alert('Navigation Completed. {Args}')");
            //webView3.CoreWebView2.DocumentTitle;
            //this.Title = webView3.CoreWebView2.DocumentTitle;
            tabGeneric.Text = webView3.CoreWebView2.DocumentTitle;
        }
    }
}
