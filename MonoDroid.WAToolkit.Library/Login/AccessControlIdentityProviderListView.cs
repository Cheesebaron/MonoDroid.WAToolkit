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
using System.Linq;
using System.Web;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;

using MonoDroid.WAToolkit.Library.Utilities;
using MonoDroid.WAToolkit.Library.EventArguments;

namespace MonoDroid.WAToolkit.Library.Login
{
    public class AccessControlIdentityProviderListView : LinearLayout
    {
        private Uri _identityProviderDiscoveryService = null;
        private string _realm = null;
        private string _serviceNamespace = null;

        private ListView IdentityProviderList;
        private IdentityProviderAdapter _identityProviderAdapter;

        #region AlertDialog
        private AlertDialog alertDialog;
        private void ShowAlertDialog(string title, string message)
        {
            if (alertDialog != null && alertDialog.IsShowing) return;
            alertDialog = new AlertDialog.Builder(Context).Create();
            alertDialog.SetTitle(title);
            alertDialog.SetMessage(message);
            alertDialog.SetButton("OK", (alertsender, args) => { });
            alertDialog.Show();
        }
        #endregion

        #region ProgressDialog
        private ProgressDialog progressDialog;
        public void ShowProgressDialog(string title, string message)
        {
            if (!progressDialog.IsShowing)
            {
                progressDialog.SetTitle(title);
                progressDialog.SetMessage(message);
                progressDialog.Show();
            }
        }

        public void HideProgressDialog()
        {
            if (progressDialog.IsShowing)
                progressDialog.Dismiss();
        }
        #endregion

        /// <summary>
        /// Occurs when the user selects an identity provider to log in with.
        /// </summary>
        public event EventHandler<IdentityProviderInformationEventArgs> NavigateToIdentityProvider;

        public AccessControlIdentityProviderListView(Context context) :
            base(context)
        {
            Initialize();
        }

        private void Initialize()
        {
            progressDialog = new ProgressDialog(Context);
            ShowProgressDialog("Please wait...", "Loading Identity Providers...");
        }

        void IdentityProviderList_ItemClick(object sender, ItemEventArgs e)
        {
            if (null != NavigateToIdentityProvider)
                NavigateToIdentityProvider(this, new IdentityProviderInformationEventArgs(_identityProviderAdapter.IdentityProviders.ElementAtOrDefault(e.Position)));
        }

        public string Realm
        {
            get { return _realm; }
            set { _realm = value; }
        }

        public string ServiceNamespace
        {
            get { return _serviceNamespace; }
            set { _serviceNamespace = value; }
        }

        /// <summary>
        /// Initiates an asynchronous request which prompts user to sign into an identity provider, from the list returned by the
        /// call to the discover service returns a security token via the RequestSecurityTokenResponseCompleted event handler. 
        /// </summary>
        /// 
        /// <remarks>
        /// Initiates a token request from ACS following these steps:
        /// 1) Get the list of configured Identity Providers from ACS by calling the discovery service
        /// 2) Once the user selects their identity provider, navigate to the sign in page of the provider
        /// 3) Using the WebBrowser control to complete the passive token request complete
        /// 4) Get the token
        /// 5) If a RequestSecurityTokenResponseStore is specified, set the token.
        /// 6) return the token using the RequestSecurityTokenResponseCompleted callback
        /// </remarks>
        /// <param name="identityProviderDiscoveryService">The Identity provider discovery service from the ACS managment portal.</param>
        public void GetSecurityToken(Uri identityProviderDiscoveryService)
        {
            _identityProviderDiscoveryService = identityProviderDiscoveryService;
            IdentityProviderList_Refresh(_identityProviderDiscoveryService);
        }

        public void GetSecurityToken()
        {
            if (null == _realm)
            {
                throw new InvalidOperationException("Realm was not set");
            }

            if (null == _serviceNamespace)
            {
                throw new InvalidOperationException("ServiceNamespace was not set");
            }

            Uri identityProviderDiscovery = new Uri(
                string.Format(
                    "https://{0}.accesscontrol.windows.net/v2/metadata/IdentityProviders.js?protocol=javascriptnotify&realm={1}&version=1.0",
                    _serviceNamespace,
                    HttpUtility.UrlEncode(_realm)),
                UriKind.Absolute
                );

            GetSecurityToken(identityProviderDiscovery);
        }

        private void IdentityProviderList_Refresh(Uri identityProviderDiscoveryService)
        {
            System.Diagnostics.Debug.WriteLine("Refreshing Identity Provider List");
            JSONIdentityProviderDiscoveryClient jsonClient = new JSONIdentityProviderDiscoveryClient();
            jsonClient.GetIdentityProviderListCompleted += new EventHandler<GetIdentityProviderListEventArgs>(IdentityProviderList_RefreshCompleted);
            jsonClient.GetIdentityProviderListAsync(identityProviderDiscoveryService);
        }

        private void IdentityProviderList_RefreshCompleted(object sender, GetIdentityProviderListEventArgs e)
        {
            Handler handler = new Android.OS.Handler(Context.MainLooper); //We need to update on UI thread.
            handler.Post(() =>
            {
                if (null == e.Error)
                {
                    IdentityProviderList = new ListView(this.Context);
                    IdentityProviderList.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
                    IdentityProviderList.SetPadding(10, 0, 0, 0);
                    IdentityProviderList.ItemClick += new EventHandler<ItemEventArgs>(IdentityProviderList_ItemClick);
                    IdentityProviderList.Divider = null;

                    AddView(IdentityProviderList);

                    if (_identityProviderAdapter == null)
                        _identityProviderAdapter = new IdentityProviderAdapter(this.Context);
                
                    IdentityProviderList.Adapter = _identityProviderAdapter;
                    _identityProviderAdapter.IdentityProviders = e.Result;

                    PostInvalidate();
                    HideProgressDialog();
                }
                else
                {
                    HideProgressDialog();
                    ShowAlertDialog("Oh no!", "An error occured with the message:\n" + e.Error.Message);
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (progressDialog != null)
                progressDialog.Dispose();
            if (alertDialog != null)
                alertDialog.Dispose();
            if (IdentityProviderList != null)
                IdentityProviderList.Dispose();
            if (_identityProviderAdapter != null)
                _identityProviderAdapter.Dispose();

            base.Dispose(disposing);
        }
    }
}