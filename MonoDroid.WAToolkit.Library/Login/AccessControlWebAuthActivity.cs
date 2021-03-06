//---------------------------------------------------------------------------------
// Copyright 2012 Tomasz Cielecki (tomasz@ostebaronen.dk)
// Licensed under the Apache License, Version 2.0 (the "License"); 
// You may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR 
// CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, 
// MERCHANTABLITY OR NON-INFRINGEMENT. 

// See the Apache 2 License for the specific language governing 
// permissions and limitations under the License.
//---------------------------------------------------------------------------------

using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Webkit;
using MonoDroid.WAToolkit.Library.EventArguments;

namespace MonoDroid.WAToolkit.Library.Login
{
    [Activity(Label = "Web Log In")]
    public class AccessControlWebAuthActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var url = Intent.GetStringExtra("monodroid.watoolkit.library.login.url");

            System.Diagnostics.Debug.WriteLine(url);

            Window.RequestFeature(WindowFeatures.Progress);

            var webView = new WebView(this);

            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.SetSupportZoom(true);
            webView.Settings.BuiltInZoomControls = true;
            webView.Settings.LoadWithOverviewMode = true; //Load 100% zoomed out
            webView.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            webView.ScrollbarFadingEnabled = true;

            webView.VerticalScrollBarEnabled = true;
            webView.HorizontalScrollBarEnabled = true;

            var notify = new AccessControlJavascriptNotify();
            notify.GotSecurityTokenResponse += GotSecurityTokenResponse;

            webView.AddJavascriptInterface(notify, "external");
            webView.SetWebViewClient(new AuthWebViewClient());
            webView.SetWebChromeClient(new AuthWebChromeClient(this));
            
            webView.LoadUrl(url);

            AddContentView(webView, new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent));
        }

        private void GotSecurityTokenResponse(object sender, RequestSecurityTokenResponseEventArgs e)
        {
            if (e.Error == null)
            {
                var data = new Intent();
                data.PutExtra("monodroid.watoolkit.library.login.RequestSecurityTokenResponse", e.Response);

                if (Parent == null)
                    SetResult(Result.Ok, data);
                else
                    Parent.SetResult(Result.Ok, data);
            }
            else
            {
                if (Parent == null)
                    SetResult(Result.Canceled);
                else
                    Parent.SetResult(Result.Canceled);
            }
            Finish();
        }

        public class AccessControlJavascriptNotify : ManagedAccessControlJavascriptNotify
        {
            public event EventHandler<RequestSecurityTokenResponseEventArgs> GotSecurityTokenResponse;

            public override void Notify(Java.Lang.String securityTokenResponse)
            {
                Exception ex = null;
                var response = "";

                if (securityTokenResponse == null || securityTokenResponse.IsEmpty)
                    ex = new ArgumentNullException("securityTokenResponse", "Did not recieve a Token Response");
                else
                    response = securityTokenResponse.ToString();

                if (GotSecurityTokenResponse != null)
                    GotSecurityTokenResponse(this, new RequestSecurityTokenResponseEventArgs(response, ex));
            }
        }

        private class AuthWebViewClient : WebViewClient { }

        private class AuthWebChromeClient : WebChromeClient
        {
            private readonly Activity _parentActivity;
            private readonly string _title;

            public AuthWebChromeClient(Activity parentActivity)
            {
                _parentActivity = parentActivity;
                _title = parentActivity.Title;
            }

            public override void OnProgressChanged(WebView view, int newProgress)
            {
                _parentActivity.Title = string.Format("Loading {0}%", newProgress);
                _parentActivity.SetProgress(newProgress * 100);

                if (newProgress == 100) _parentActivity.Title = _title;
            }
        }
    }
}