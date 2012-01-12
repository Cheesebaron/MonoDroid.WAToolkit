package monodroid.watoolkit.library.login;


public class AccessControlLoginView
	extends android.widget.LinearLayout
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MonoDroid.WAToolkit.Library.Login.AccessControlLoginView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AccessControlLoginView.class, __md_methods);
	}

	public AccessControlLoginView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == AccessControlLoginView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlLoginView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0, p1 });
	}

	public AccessControlLoginView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AccessControlLoginView.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlLoginView, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
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
