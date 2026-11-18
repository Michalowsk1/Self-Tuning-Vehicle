using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button startRaceButton;
    public void CloseProgram()
    {
        Application.Quit();
    }
    void FixedUpdate()
    {
        ManageStartRaceButton();
    }

    public void StartRace()
    {
        LapChecker.lapFinished = false;

        SystemManager.StartRace = true;

        Timer.StartTimer = true;
        Timer.ResetTimer = false;
        Timer.ResetTimeValues();
    }

    void ManageStartRaceButton()
    {
        if (SystemManager.RaceRunning)
            startRaceButton.enabled = false;
        else
            startRaceButton.enabled = true;
    }
}
