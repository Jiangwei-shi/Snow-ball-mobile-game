using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    private void Awake()
    {
        SwipeDetection.OnSwipe += SwipeDetection_OnSwipe;
    }

    private void SwipeDetection_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Dirction: " + data.Direction);
    }
}
