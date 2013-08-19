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

using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;

using MonoDroid.WAToolkit.Library.Login;
using MonoDroid.WAToolkit.Library.Utilities;

namespace MonoDroid.WAToolkit
{
    [Activity(Label = "MonoDroid WAToolkit Sample", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]
    public class GetTokenSampleActivity : Activity
    {
        TextView _tokenText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            _tokenText = FindViewById<TextView>(Resource.Id.Token);

            UpdateTokenText();
        }

        private void LogIn()
        {
            var intent = new Intent(this, typeof(AccessControlLoginActivity));
            intent.PutExtra("monodroid.watoolkit.library.login.realm", Resources.GetString(Resource.String.realm));
            intent.PutExtra("monodroid.watoolkit.library.login.acsNamespace", Resources.GetString(Resource.String.acsNamespace));

            StartActivityForResult(intent, 0);
        }

        private void RemoveToken()
        {
            RequestSecurityTokenResponseStore.Instance.RequestSecurityTokenResponse = null;
            UpdateTokenText();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add(1, 1, 0, Resource.String.LogIn);
            menu.Add(1, 2, 1, Resource.String.RemoveToken);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case 1:
                    LogIn(); return true;
                case 2:
                    RemoveToken(); return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void UpdateTokenText()
        {
            var token = RequestSecurityTokenResponseStore.Instance.RequestSecurityTokenResponse;
            _tokenText.Text = null != token ? token.ToString() : "Token not present!";
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (Result.Ok == resultCode && 0 == requestCode)
            {
                UpdateTokenText();
            }
        }
    }
}

