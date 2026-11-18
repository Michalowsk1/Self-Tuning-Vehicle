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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (StartTimer)
        {
            OnStart();
        }

        if (TimerStarted)
        {
            FormatTime();
        }
        
    }

    void OnStart()
    {
        TimerStarted = true;
        StartTimer = false;
    }

    void FormatTime()
    {
        float currentTime =+ Time.deltaTime;

        float minutes = Mathf.Floor(currentTime / 60);
        float seconds = currentTime % 60;
        float fraction = (currentTime * 100) % 100;

        currentTimeText.text = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}
