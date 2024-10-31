using System;
using Android.OS;
using Android.Webkit;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Droid = Android;

namespace MauiWebViewIssue.Platforms.Android
{
	public class CustomWebViewHandler : WebViewHandler
    {
        protected override void ConnectHandler(Droid.Webkit.WebView platformView)
        {
            base.ConnectHandler(platformView);
            platformView.Settings.JavaScriptEnabled = true;
            //platformView.Settings.DomStorageEnabled = true;
            //platformView.ClearCache(true);
            //platformView.LoadUrl("about:blank");
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            //{
            //    platformView.SetLayerType(Droid.Views.LayerType.Hardware, null);
            //}
            //else
            //{
            //    platformView.SetLayerType(Droid.Views.LayerType.Software, null);
            //}
            platformView.SetWebViewClient(new CustomWebViewClient(this));
        }

        // Optional: Clean up resources when the handler disconnects
        protected override void DisconnectHandler(Droid.Webkit.WebView platformView)
        {
            base.DisconnectHandler(platformView);
        }
    }

    public class CustomWebViewClient : MauiWebViewClient
    {
        public CustomWebViewClient(WebViewHandler handler) : base(handler)
        {
        }

        public override bool ShouldOverrideUrlLoading(Droid.Webkit.WebView? view, IWebResourceRequest? request)
        {
            Console.WriteLine(request.Url);
            return true; // Returning false allows the WebView to load the URL
        }
    }
}

