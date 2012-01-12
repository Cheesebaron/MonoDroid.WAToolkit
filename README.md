MonoDroid.WAToolkit
===================
This is a project attempting to port the [Windows Phone 7 Windows Azure toolkit](http://watwp.codeplex.com/) to [Mono for Android](http://android.xamarin.com/). 
So far it supports authenticating against Windows Azure and obtain the token from the response.

How does it work?
-----------------
I have supplied a sample that shows how it works. But what it basically does is:

1. By passing realm and a namespace as an intent to the AccessControlLoginActivity it creates a list of Identity Providers
2. Clicking one of these will start a new activity passing an URL to it though an intent. This activity contains a WebView which registers a JavaScript Interface.
3. Logging in will trigger the method in the Javascript Interface which retrieves a JSON result from the Identity Provider.
4. This gets given back to the parent activity, where it gets parsed and saved in the RequestSecurityTokenResponseStore. Now we have our token!
5. The AccessControlLoginActivity returns and now you can do anything you want with that token.

Usage checklist
---------------
Pass the strings:

+ **monodroid.watoolkit.library.login.realm** with the realm you are trying to reach (usually in the format uri://blablabla.com
+ **monodroid.watoolkit.library.login.acsNamespace** with your desired namespace
to the AccessControlLoginActivity.

Like so:

	Intent intent = new Intent(this, typeof(AccessControlLoginActivity));
    intent.PutExtra("monodroid.watoolkit.library.login.realm", "uri://myAwesomeRealm.com");
    intent.PutExtra("monodroid.watoolkit.library.login.acsNamespace", "MyAwesomeNamespace");

Your token will be stored in `RequestSecurityTokenResponseStore` which stores it on the phone in an XML file.

**NOTICE**

>You have to either link or copy the file `AccessControlJavascriptNotify.java` into you main project and mark it **AndroidJavaSource**,
otherwise you *will* encounter problems. This is due to WebView's Javascript Interface only take Java Objects and require methods being registered
in the Android Wrappers. Usually only overridden native methods get registered, so we have to do it this way for now. Look at `ManagedAccessControlJavascriptNotify.cs`
for how it is implemented.


License
-------
This project is licensed under [Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0).