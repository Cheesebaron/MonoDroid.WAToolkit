package monodroid.watoolkit.library.login;


public class AccessControlWebAuthActivity_AccessControlJavascriptNotify
	extends monodroid.watoolkit.library.login.AccessControlJavascriptNotify
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_notify:(Ljava/lang/String;)V:GetNotifyHandler\n" +
			"";
		mono.android.Runtime.register ("MonoDroid.WAToolkit.Library.Login.AccessControlWebAuthActivity/AccessControlJavascriptNotify, MonoDroid.WAToolkit.Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AccessControlWebAuthActivity_AccessControlJavascriptNotify.class, __md_methods);
	}

	@Override
	public void notify (java.lang.String p0)
	{
		n_notify (p0);
	}

	private native void n_notify (java.lang.String p0);

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
