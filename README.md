# Unity-Android-Plugin-Example

A simple example showing how to call native Android Java code from Unity. 
http://www.what-could-possibly-go-wrong.com/creating-a-native-android-plugin-for-unity3d/

The UnityProject directory contains the Unity project (set up with Unity 5.2), with everything you need to build 
it for Android.

The AndroidPlugin directory contains the source to the native Android plugin used in the 
Unity project (AndroidPlugin.jar), which has been tested against Android 5.0 (API level 21).

## Building

To build the Unity project, just open it in Unity, connect an Android device and go to *Build 
and Run* in the menu. There is already a compiled version of the Android plugin (AndroidPlugin.jar)
in the Unity project `Assets` folder so there is no need to compile it first just to run the
program.

To build the Android plugin, first make sure you have installed the 
[Android SDK](https://developer.android.com/sdk/index.html) and [Ant](http://ant.apache.org/). 
First, either make sure your `ANDROID_HOME` environment variable is set to your installation
of the Android SDK, or edit the `sdk.dir=...` line in the `local.properties` file inside 
the AndroidPlugin folder.

Once that is all configured, navigate to AndroidPlugin and run
```
ant jar
```
Then copy the compiled `AndroidPlugin.jar` from `AndroidPlugin/bin` to `UnityProject/Assets`.

