using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button startRaceButton;
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
        ManageStartRaceButton();
    }

    public void StartRace()
    {
        LapChecker.lapFinished = false;

        SystemManager.StartRace = true;

        Timer.StartTimer = true;
        Timer.ResetTimer = false;
        Timer.ResetTimeValues();

        TuningSystem.alreadyTunedUp = false;
    }

    public void OpenConfiq()
    {
        configScreen.SetActive(!configScreen.activeSelf);
    }

    void ManageStartRaceButton()
    {
        if (SystemManager.RaceRunning)
            startRaceButton.enabled = false;
        else
            startRaceButton.enabled = true;
    }
}
