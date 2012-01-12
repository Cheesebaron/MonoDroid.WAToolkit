package monodroid.watoolkit.library.login;


public class AccessControlWebAuthActivity_AuthWebViewClient
	extends android.webkit.WebViewClient
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MonoDroid.WAToolkit.Library.Login.AccessControlWebAuthActivity/AuthWebViewClient, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AccessControlWebAuthActivity_AuthWebViewClient.class, __md_methods);
	}

	public AccessControlWebAuthActivity_AuthWebViewClient ()
	{
		super ();
		if (getClass () == AccessControlWebAuthActivity_AuthWebViewClient.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlWebAuthActivity/AuthWebViewClient, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
