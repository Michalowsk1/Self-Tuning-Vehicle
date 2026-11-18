using System;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestTime = float.MaxValue;
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

        if(bestTime > FinalTime(milli, sec, min))
        {
            bestTime = FinalTime(milli, sec, min);
            bestTimeText.text = String.Format("{0:00}:{1:00}:{2:00}", min, sec, milli);
        }

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
