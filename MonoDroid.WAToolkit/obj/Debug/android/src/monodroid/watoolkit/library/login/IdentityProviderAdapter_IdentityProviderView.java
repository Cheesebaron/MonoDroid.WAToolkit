package monodroid.watoolkit.library.login;


public class IdentityProviderAdapter_IdentityProviderView
	extends android.widget.TextView
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MonoDroid.WAToolkit.Library.Login.IdentityProviderAdapter/IdentityProviderView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", IdentityProviderAdapter_IdentityProviderView.class, __md_methods);
	}

	public IdentityProviderAdapter_IdentityProviderView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == IdentityProviderAdapter_IdentityProviderView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.IdentityProviderAdapter/IdentityProviderView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}

	public IdentityProviderAdapter_IdentityProviderView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == IdentityProviderAdapter_IdentityProviderView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.IdentityProviderAdapter/IdentityProviderView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	public IdentityProviderAdapter_IdentityProviderView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == IdentityProviderAdapter_IdentityProviderView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.IdentityProviderAdapter/IdentityProviderView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
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
