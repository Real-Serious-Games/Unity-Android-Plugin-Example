using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BatteryMonitor : MonoBehaviour 
{
    public Text batteryLevelText;
    public Text batteryLevelIcon; // We're using fonticons so even though this looks like a picture, it's actually a text widget.

    // Character codes to use for the Font Awesome icons to use.
    static readonly string BATTERY_LEVEL_100 = Char.ConvertFromUtf32(0xf240);
    static readonly string BATTERY_LEVEL_75  = Char.ConvertFromUtf32(0xf241);
    static readonly string BATTERY_LEVEL_50  = Char.ConvertFromUtf32(0xf242);
    static readonly string BATTERY_LEVEL_25  = Char.ConvertFromUtf32(0xf243);
    static readonly string BATTERY_LEVEL_0   = Char.ConvertFromUtf32(0xf244);
	
	// Update is called once per frame
	void Update () 
    {
	   UpdateStatusIndicators();
	}
    
    /// <summary>
    /// Find the current device battery level and update indicators in the 
    /// UI accordingly.
    /// </summary>
    void UpdateStatusIndicators()
    {
        var currentBatteryLevel = BatteryLevelPlugin.GetBatteryLevel() * 100f;
        batteryLevelText.text = String.Format("{0}%", currentBatteryLevel);

        // Show the icon that matches the current level most closely.
        if (currentBatteryLevel >= 88)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_100;
        }
        else if (currentBatteryLevel >= 63)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_75;
        }
        else if (currentBatteryLevel >= 38)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_50;
        }
        else if (currentBatteryLevel >= 13)
        {
            batteryLevelIcon.text = BATTERY_LEVEL_25;
        }
        else 
        {
            batteryLevelIcon.text = BATTERY_LEVEL_0;
        }
    }
}
