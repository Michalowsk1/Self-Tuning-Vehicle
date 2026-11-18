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

    private float milli, sec, min;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        FormatTime();
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
}
