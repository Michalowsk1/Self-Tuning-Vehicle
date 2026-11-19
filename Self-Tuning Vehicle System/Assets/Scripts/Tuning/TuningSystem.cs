using System.Collections.Generic;
using UnityEngine;

public class TuningSystem : MonoBehaviour
{
    [SerializeField] private VehicleBehaviour vh;
    [SerializeField] public Dictionary<string, (bool wantsToChange, float currentValue, float variance, bool lastChangedHelped, bool lastValueWasPositive)> variablesInfo =
                         new Dictionary<string, (bool wantsToChange, float currentValue,  float variance, bool lastChangedHelped, bool lastValueWasPositive)>();

    [SerializeField] private Dictionary<string, (float, bool)> savedChanges = new Dictionary<string, (float, bool)> ();

    public static bool alreadyTunedUp;
    /*
    Each entry into this dictionary will include the variable as the key
    The tuple stores 4 sets of information, if the data wants to be changed, the spread of the variable/randomness, if the last changed helped and if the last action was adding a positive or a negative number
    i.e. Acceleration, Tuple< wants to change(bool set to true) +- 0.25, helped(bool set to true), added a positive(bool set to true)>
    */

    void Start()
    {
        alreadyTunedUp = false;

        variablesInfo.Add("accelerationAdjuster", (true, vh.accelerationAdjuster, 0.075f, true, true));
        variablesInfo.Add("speedUpIncrement", (true, vh.speedUpIncrement, 0.0075f, true, true));
        variablesInfo.Add("minimumSteeringPower", (true, vh.minimumSteeringPower, 0.1375f, true, true));
        variablesInfo.Add("steeringEnhancer", (true, vh.steeringEnhancer, 0.1f, true, true));
        variablesInfo.Add("sideDetectDistance", (false, vh.sideDetectDistance, 0.15f, true, true));
        variablesInfo.Add("angledDetectDistance", (true, vh.angledDetectDistance, 0.2f, true, true));
        variablesInfo.Add("straightDetectDistance", (true, vh.straightDetectDistance, 0.15f, true, true));

    }

    // Update is called once per frame
    void Update()
    {

        if (LapChecker.lapFinished && !alreadyTunedUp && !SystemManager.RaceReset)
            Tuning();
    }

    void Tuning()
    {
        alreadyTunedUp = true;

        foreach (KeyValuePair<string, (bool wantsToChange, float currentValue, float variance,
            bool lastChangedHelped, bool lastValuePositive)> var in variablesInfo)
        {
            if (!var.Value.wantsToChange)
                continue;
            else
            {
                float rand = UnityEngine.Random.Range(-var.Value.variance, var.Value.variance);
                float roundedRand = Mathf.Floor(rand * 1000) / 1000;
                bool lastValueHelped = var.Value.lastChangedHelped;
                bool lastValuePositive = var.Value.lastValuePositive;

                
                float direction = lastValueHelped == lastValuePositive ? 1f : -1f;

                float changedValue = var.Value.currentValue + (roundedRand * direction);

                bool wasLastValuePositive = (roundedRand * direction) > 0;

                savedChanges.Add(var.Key, (changedValue, wasLastValuePositive));

                Switch(var.Key, changedValue);
            }
        }
        VisualAndLogicalSync();
    }

    void Switch(string varName, float changedValue)
    {
        switch(varName)
        {
            case "accelerationAdjuster":
                vh.accelerationAdjuster = changedValue;
                break;

            case "speedUpIncrement":
                vh.speedUpIncrement = changedValue;
                break;

            case "minimumSteeringPower":
                vh.minimumSteeringPower = changedValue;
                break;

            case "steeringEnhancer":
                vh.steeringEnhancer = changedValue;
                break;

            case "sideDetectDistance":
                vh.sideDetectDistance = changedValue;
                break;

            case "angledDetectDistance":
                vh.angledDetectDistance = changedValue;
                break;

            case "straightDetectDistance":
                vh.straightDetectDistance = changedValue;
                break;
        }
    }

    void VisualAndLogicalSync()
    {
        foreach(KeyValuePair<string, (float, bool)> var in savedChanges)
        {
            bool helped = false;

            if(Timer.timeImproved)
                helped = true;

            variablesInfo[var.Key] = (variablesInfo[var.Key].wantsToChange, var.Value.Item1, variablesInfo[var.Key].variance, helped, var.Value.Item2);


        }
        savedChanges.Clear();
    }
}
