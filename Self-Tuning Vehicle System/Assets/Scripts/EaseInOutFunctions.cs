using Unity.VisualScripting;
using UnityEngine;

public static class EaseInOutFunctions
{
    public static float EaseOutCubic(float x) //Super Slowdown at end
    {
        return 1- Mathf.Pow(1 - x, 6);
    }

    public static float EaseInOutCubic(float x) //Super Speed
    {
        return x < 0.5f ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
    }
    public static float EaseOutSine(float x) // doesnt move??
    {
        return Mathf.Sin((x * Mathf.PI) / 2);
    }

    public static float EaseOutExpo(float x)
    {
        return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
    }
}
