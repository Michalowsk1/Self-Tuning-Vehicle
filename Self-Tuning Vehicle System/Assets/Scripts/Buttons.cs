using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button startRaceButton;
    [SerializeField] private Button ConfigurationButton;
    [SerializeField] private GameObject configScreen;

    [SerializeField] private VehicleBehaviour vh;
    [SerializeField] private TuningSystem ts;

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

    public void ResetToDefault()
    {
        ts.variablesInfo["accelerationAdjuster"] = (true, 1.5f, 0.075f, true, true); vh.accelerationAdjuster = 1.5f;
        ts.variablesInfo["speedUpIncrement"] = (true, 0.015f, 0.0075f, true, true); vh.speedUpIncrement = 0.015f;
        ts.variablesInfo["minimumSteeringPower"] = (true, 2.75f, 0.1375f, true, true); vh.minimumSteeringPower = 2.75f;
        ts.variablesInfo["steeringEnhancer"] = (true, 2.0f, 0.1f, true, true); vh.steeringEnhancer = 2.0f;
        ts.variablesInfo["sideDetectDistance"] = (false, 3.0f, 0.15f, true, true); vh.sideDetectDistance = 3.0f;
        ts.variablesInfo["angledDetectDistance"] = (true, 4.0f, 0.2f, true, true); vh.angledDetectDistance = 4.0f;
        ts.variablesInfo["straightDetectDistance"] = (true, 3.0f, 0.15f, true, true); vh.straightDetectDistance = 3.0f;
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
