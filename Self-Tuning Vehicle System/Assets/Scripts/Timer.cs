using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static bool StartTimer;
    public static bool ResetTimer;

    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    [SerializeField] private bool TimerStarted;
    [SerializeField] private float bestTime;

    private static float milli, sec, min;
    public static bool timeImproved;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestTime = float.MaxValue;
        timeImproved = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (StartTimer)
        {
            FormatTime();
        }

        if(ResetTimer)
        {
            ManageEndOfLapBehaviour();
        }
    }

    void FormatTime()
    {
        milli = milli + (Time.deltaTime * 100f); //multiplied by 100 to simulate milliseconds

        if (milli >= 100)
        {
            sec++;
            milli = 0;
        }
        else if(sec >= 60)
        {
            min++;
            sec = 0;
        }

        currentTimeText.text = String.Format("{0:00}:{1:00}:{2:00}", min, sec, milli);
        
    }

    void ManageEndOfLapBehaviour()
    {
        StartTimer = false;

        if (bestTime > FinalTime(milli, sec, min) && FinalTime(milli, sec, min) > 150) // stops from clipping at the start of the race setting impossibly low values
        {
            bestTime = FinalTime(milli, sec, min);
            bestTimeText.text = String.Format("{0:00}:{1:00}:{2:00}", min, sec, milli);
            timeImproved = true;
        }
        else
            timeImproved = false;

            ResetTimer = true;
    }

    float FinalTime(float milli, float sec, float min)
    {
        return (min * 3600) + (sec * 60) + milli;
    }

    public static void ResetTimeValues()
    {
        milli = 0; sec = 0; min = 0;
    }
}
