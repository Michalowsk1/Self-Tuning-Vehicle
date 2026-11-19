using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button startRaceButton;
    [SerializeField] private Button ConfigurationButton;
    [SerializeField] private GameObject configScreen;

    public void CloseProgram()
    {
        Application.Quit();
    }

    void Start()
    {
        configScreen.SetActive(false);
    }
    void FixedUpdate()
    {
        ManageButtons();
    }

    public void StartRace()
    {
        TuningSystem.alreadyTunedUp = false;
        LapChecker.lapFinished = false;

        SystemManager.StartRace = true;
        SystemManager.RaceReset = false;

        Timer.StartTimer = true;
        Timer.ResetTimer = false;
        Timer.ResetTimeValues();
    }

    public void ResetRace()
    {
        SystemManager.StartRace = false;
        SystemManager.RaceReset = true;
        Timer.StartTimer = false;
        Timer.ResetTimeValues();
    }

    public void OpenConfiq()
    {
        configScreen.SetActive(!configScreen.activeSelf);
    }

    void ManageButtons()
    {
        if (SystemManager.RaceRunning)
        {
            startRaceButton.enabled = false;
            ConfigurationButton.enabled = false;
        }
        else
        {
            startRaceButton.enabled = true;
            ConfigurationButton.enabled = true;
        }
    }
}
