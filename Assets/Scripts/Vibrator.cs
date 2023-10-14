using UnityEngine;

public static class Vibrator
{
   public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
   public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
   public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
   
    public static void Vibrate(long milliseconds = 250) 
    {
        if (IsAndroid()) 
        {
            vibrator.Call("vibrate", milliseconds);
        } else
        {
            Handheld.Vibrate();
        }
    }

    public static void Cancel() 
    {
        if (IsAndroid()) 
        {
            vibrator.Call("cancel");
        }
    }

    public static bool IsAndroid() 
    {
        return true;
    }
}
