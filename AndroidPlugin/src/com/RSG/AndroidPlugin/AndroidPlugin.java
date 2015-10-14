package com.RSG.AndroidPlugin;

import android.os.Environment;
import android.os.BatteryManager;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.Context;

public class AndroidPlugin
{
	// Needed to get the battery level.
	private Context context;

	public AndroidPlugin(Context context)
	{
		this.context = context;
	}

	// Return the battery level as a float between 0 and 1 (1 being fully charged, 0 fulled discharged)
    public float GetBatteryPct()
    {
    	Intent batteryStatus = GetBatteryStatusIntent();

    	int level = batteryStatus.getIntExtra(BatteryManager.EXTRA_LEVEL, -1);
		int scale = batteryStatus.getIntExtra(BatteryManager.EXTRA_SCALE, -1);

		float batteryPct = level / (float)scale;
		return batteryPct;
    }

    // Return whether or not we're currently on charge
    public boolean IsBatteryCharging()
    {
    	Intent batteryStatus = GetBatteryStatusIntent();

    	int status = batteryStatus.getIntExtra(BatteryManager.EXTRA_STATUS, -1);
    	return status == BatteryManager.BATTERY_STATUS_CHARGING || 
    	       status == BatteryManager.BATTERY_STATUS_FULL;
    }

    private Intent GetBatteryStatusIntent()
    {
 		IntentFilter ifilter = new IntentFilter(Intent.ACTION_BATTERY_CHANGED);
		return context.registerReceiver(null, ifilter);
    }
}