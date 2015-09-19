using UnityEngine;
using System;
using System.Collections;

public class BatteryLevelPlugin 
{
    public BatteryLevelPlugin()
    {
        
    }
    
    public static float GetBatteryLevel()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (var androidPlugin = new AndroidJavaObject("com.RSG.AndroidPlugin.AndroidPlugin", currentActivity))
                    {
                        return androidPlugin.Call<float>("GetBatteryPct");
                    }
                }
            }
        }

        return 100f;
    }
}
