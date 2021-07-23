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
using Microsoft.Web.WebView2.Wpf;

namespace WPFSample
{
    public partial class MainWindow : Window
    {
        WebviewMrk webViewMrk= new WebviewMrk();
        public MainWindow()
        {
            InitializeComponent();


            var TabGridMrk = new TabGridMrk();

            var webView = webViewMrk.webView;           
            TabGridMrk.grid2.Children.Add(webView);
           Tab1.Content = TabGridMrk.grid;

            Tab1.Content = TabGridMrk.grid2;

        }




    }

}

