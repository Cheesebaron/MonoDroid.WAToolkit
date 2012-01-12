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
using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonoDroid.WAToolkit.Library.Utilities;
using MonoDroid.WAToolkit.Library.EventArguments;

namespace MonoDroid.WAToolkit.Library.Login
{
    [Activity(Label = "Log in", Theme = "@android:style/Theme.NoTitleBar")]
    public class AccessControlLoginActivity : Activity
    {
        private AccessControlIdentityProviderListView loginView;
        private const int WEB_AUTH_ACTIVITY = 213480;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            LinearLayout rootLayout = new LinearLayout(this);
            rootLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
            rootLayout.Orientation = Orientation.Vertical;

            TextView header = new TextView(this);
            header.Text = "Log in";
            header.TextSize = 30;
            header.SetPadding(5, 11, 0, 11);
            header.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);

            rootLayout.AddView(header);

            TextView description = new TextView(this);
            description.Text = "Log in the application with your account of choice.";
            description.TextSize = 15;
            description.SetPadding(5, 11, 5, 11);
            description.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent);

            rootLayout.AddView(description);

            loginView = new AccessControlIdentityProviderListView(this);
            loginView.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
            loginView.Orientation = Orientation.Vertical;

            loginView.NavigateToIdentityProvider += new EventHandler<IdentityProviderInformationEventArgs>(loginView_NavigateToIdentityProvider);

            string realm = Intent.GetStringExtra("monodroid.watoolkit.library.login.realm");
            string acsNamespace = Intent.GetStringExtra("monodroid.watoolkit.library.login.acsNamespace");

            loginView.Realm = realm;
            loginView.ServiceNamespace = acsNamespace;

            rootLayout.AddView(loginView);

            SetContentView(rootLayout);

            loginView.GetSecurityToken();
        }

        private void loginView_NavigateToIdentityProvider(object sender, IdentityProviderInformationEventArgs e)
        {
            Intent intent = new Intent(this, typeof(AccessControlWebAuthActivity));
            intent.PutExtra("monodroid.watoolkit.library.login.url", e.IdentityProviderInformation.LoginUrl);

            StartActivityForResult(intent, WEB_AUTH_ACTIVITY);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            // We've got a result from the webactivity
            if (WEB_AUTH_ACTIVITY == requestCode && Result.Ok == resultCode)
            {
                string requestSecurityTokenResponse = data.GetStringExtra("monodroid.watoolkit.library.login.RequestSecurityTokenResponse");
                // Lets try parse it!
                RequestSecurityTokenResponse token = RequestSecurityTokenResponse.FromJSON(requestSecurityTokenResponse);
                RequestSecurityTokenResponseStore.Instance.RequestSecurityTokenResponse = token;

                if (Parent == null)
                    SetResult(Result.Ok);
                else
                    Parent.SetResult(Result.Ok);
                Finish();
            }
            // Something bad happened (or we pressed back!) and we did not get the Token :-/
            else if (WEB_AUTH_ACTIVITY == requestCode && Result.Canceled == resultCode)
            {
                ShowAlertDialog("An error occured!", "Could not retrieve security token, please try again");
            }
        }

        #region AlertDialog
        private AlertDialog alertDialog;
        private void ShowAlertDialog(string title, string message)
        {
            if (alertDialog != null && alertDialog.IsShowing) return;
            alertDialog = new AlertDialog.Builder(this).Create();
            alertDialog.SetTitle(title);
            alertDialog.SetMessage(message);
            alertDialog.SetButton("OK", (alertsender, args) => { });
            alertDialog.Show();
        }
        #endregion
    }
}