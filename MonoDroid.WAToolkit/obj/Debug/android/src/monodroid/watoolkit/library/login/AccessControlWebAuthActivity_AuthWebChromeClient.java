package monodroid.watoolkit.library.login;


public class AccessControlWebAuthActivity_AuthWebChromeClient
	extends android.webkit.WebChromeClient
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onProgressChanged:(Landroid/webkit/WebView;I)V:GetOnProgressChanged_Landroid_webkit_WebView_IHandler\n" +
			"";
		mono.android.Runtime.register ("MonoDroid.WAToolkit.Library.Login.AccessControlWebAuthActivity/AuthWebChromeClient, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AccessControlWebAuthActivity_AuthWebChromeClient.class, __md_methods);
	}

	public AccessControlWebAuthActivity_AuthWebChromeClient ()
	{
		super ();
		if (getClass () == AccessControlWebAuthActivity_AuthWebChromeClient.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlWebAuthActivity/AuthWebChromeClient, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public AccessControlWebAuthActivity_AuthWebChromeClient (android.app.Activity p0)
	{
		super ();
		if (getClass () == AccessControlWebAuthActivity_AuthWebChromeClient.class)
			mono.android.TypeManager.Activate ("MonoDroid.WAToolkit.Library.Login.AccessControlWebAuthActivity/AuthWebChromeClient, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.App.Activity, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}

	@Override
	public void onProgressChanged (android.webkit.WebView p0, int p1)
	{
		n_onProgressChanged (p0, p1);
	}

	private native void n_onProgressChanged (android.webkit.WebView p0, int p1);

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
