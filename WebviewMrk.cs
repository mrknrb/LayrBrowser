using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

public class WebviewMrk
{
   public WebView2 webView;

    public TextBox adressBar;
    public WebviewMrk()
	{
           webView = new WebView2();
        webView.Name = "webView";
        Grid.SetRow(this.webView, 1);
        Grid.SetColumn(this.webView, 1);
        Grid.SetColumnSpan(this.webView, 25);
        Grid.SetRowSpan(this.webView, 25);

        webView.NavigationStarting += EnsureHttps;
        InitializeAsync();
       


    }

    async void InitializeAsync()
    {
        await webView.EnsureCoreWebView2Async(null);

       // webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;

        await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
        // await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");

        webView.Source = new Uri("https://www.youtube.com/feed/subscriptions");

    }
    /*
    void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
    {
        String uri = args.TryGetWebMessageAsString();
        adressBar.Text = uri;
        webView.CoreWebView2.PostWebMessageAsString(uri);
    }*/
    void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
    {
        String uri = args.Uri;
        if (!uri.StartsWith("https://"))
        {
            webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
            args.Cancel = true;
        }
    }
    public void Navigate(string url)
    {
        if (webView != null && webView.CoreWebView2 != null&& url.StartsWith("https://"))
        {
            webView.CoreWebView2.Navigate(url);
        }
    }


}
