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

using System.Collections.Generic;
using System.Linq;

using Android.Content;
using Android.Views;
using Android.Widget;

using MonoDroid.WAToolkit.Library.Utilities;


namespace MonoDroid.WAToolkit.Library.Login
{
    class IdentityProviderAdapter : BaseAdapter
    {
        private IEnumerable<IdentityProviderInformation> _identityProviders;
        private readonly IList<View> _views = new List<View>();
        private readonly Context _context;

        public IdentityProviderAdapter(Context context)
        {
            _context = context;
        }

        public IEnumerable<IdentityProviderInformation> IdentityProviders
        {
            get { return _identityProviders; }
            set
            {
                _identityProviders = value;
                NotifyDataSetChanged();
            }
        }

        public override int Count
        {
            get { return _identityProviders == null ? 0 : _identityProviders.Count(); }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            IdentityProviderView view = null;

            if (convertView == null)
            {
                var identityProvider = _identityProviders.ElementAtOrDefault(position);
                if (identityProvider != null)
                    view = new IdentityProviderView(_context, identityProvider.Name);
            }
            else
            {
                view = (IdentityProviderView)convertView;
                var identityProvider = _identityProviders.ElementAtOrDefault(position);
                if (identityProvider != null)
                    view.Name = identityProvider.Name;
            }

            if (view != null && !_views.Contains(view))
                _views.Add(view);

            return view;
        }

        private void ClearViews()
        {
            foreach (var view in _views)
            {
                view.Dispose();
            }
            _views.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            ClearViews();
            base.Dispose(disposing);
        }

        private sealed class IdentityProviderView : TextView
        {
            private const int DefaultTextSize = 20;
            private const int DefaultPadding = 11;

            public IdentityProviderView(Context context, string name)
                : base(context)
            {
                Text = name;
                TextSize = DefaultTextSize;
                SetPadding(DefaultPadding, DefaultPadding, DefaultPadding, DefaultPadding);
                SetTextColor(Android.Graphics.Color.White);
            }

            public string Name
            {
                set { SetText(value, BufferType.Normal); }
            }
        }
    }
}