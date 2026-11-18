using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class TuningSystem : MonoBehaviour
{
    [SerializeField] private VehicleBehaviour vh;
    [SerializeField] public Dictionary<string, (bool wantsToChange, float currentValue, float variance, bool lastChangedHelped, bool lastValueWasPositive)> variablesInfo =
                         new Dictionary<string, (bool wantsToChange, float currentValue,  float variance, bool lastChangedHelped, bool lastValueWasPositive)>();
    /*
    Each entry into this dictionary will include the variable as the key
    The tuple stores 4 sets of information, if the data wants to be changed, the spread of the variable/randomness, if the last changed helped and if the last action was adding a positive or a negative number
    i.e. Acceleration, Tuple< wants to change(bool set to true) +- 0.25, helped(bool set to true), added a positive(bool set to true)>
    */

    void Start()
    {
        variablesInfo.Add("accelerationAdjuster", (true, vh.accelerationAdjuster, 0.075f, true, true));
        variablesInfo.Add("speedUpIncrement", (true, vh.speedUpIncrement, 0.0075f, true, true));
        variablesInfo.Add("minimumSteeringPower", (true, vh.minimumSteeringPower, 0.1375f, true, true));
        variablesInfo.Add("steeringEnhancer", (true, vh.steeringEnhancer, 0.1f, true, true));
        variablesInfo.Add("sideDetectDistance", (true, vh.sideDetectDistance, 0.15f, true, true));
        variablesInfo.Add("angledDetectDistance", (true, vh.angledDetectDistance, 0.2f, true, true));
        variablesInfo.Add("straightDetectDistance", (true, vh.straightDetectDistance, 0.15f, true, true));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TuningAcceleration()
    {
        foreach (KeyValuePair<string, (bool wantsToChange, float currentValue, float variance,
            bool lastChangedHelped, bool lastValuePositive)> var in variablesInfo)
        {
            if (!var.Value.wantsToChange)
                continue;
            else
            {
                float rand = UnityEngine.Random.Range(-var.Value.variance, var.Value.variance);
                bool lastValueHelped = var.Value.lastChangedHelped;
                bool lastValuePositive = var.Value.lastValuePositive;

                
                float direction = lastValueHelped == lastValuePositive ? 1f : -1f;

                float changedValue = var.Value.currentValue + (rand * direction);

                Switch(var.Key, changedValue);
            }
        }
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
}
