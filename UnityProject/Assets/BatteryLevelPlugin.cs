using UnityEngine;
using System;
using System.Collections;

public class BatteryLevelPlugin 
{
    public static float GetBatteryLevel()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var androidPlugin = new AndroidJavaClass("com.RSG.AndroidPlugin.AndroidPlugin"))
            {
                using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        return androidPlugin.CallStatic<float>("GetBatteryPct", currentActivity);
                    }
                }
            }
        }

        return 100f;
    }
}
