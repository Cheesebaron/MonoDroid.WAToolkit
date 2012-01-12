package monodroid.watoolkit.library.login;


public class AccessControlIdentityProviderListView
	extends android.widget.LinearLayout
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MonoDroid.WAToolkit.Library.Login.AccessControlIdentityProviderListView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AccessControlIdentityProviderListView.class, __md_methods);
	}

	public AccessControlIdentityProviderListView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == AccessControlIdentityProviderListView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlIdentityProviderListView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}

	public AccessControlIdentityProviderListView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AccessControlIdentityProviderListView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlIdentityProviderListView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
