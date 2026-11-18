using System;
using TMPro;
using UnityEngine;

public class UIValuesUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI accelerationAdjusterText;
    [SerializeField] TextMeshProUGUI speedUpIncrementText;
    [SerializeField] TextMeshProUGUI MinimumSteeringPowerText;
    [SerializeField] TextMeshProUGUI SteeringEnhancerText;
    [SerializeField] TextMeshProUGUI SideDetectDistanceText;
    [SerializeField] TextMeshProUGUI AngledDetectDistanceText;
    [SerializeField] TextMeshProUGUI StraightDetectDistanceText;

    [SerializeField] TuningSystem ts;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accelerationAdjusterText.text = "Acceleration Ajustter: " + ts.variablesInfo["accelerationAdjuster"].currentValue;
        speedUpIncrementText.text = "Speed Up Increment: " + ts.variablesInfo["speedUpIncrement"].currentValue;
        MinimumSteeringPowerText.text = "Minimum Steering Power: " + ts.variablesInfo["minimumSteeringPower"].currentValue;
        SteeringEnhancerText.text = "Steering Enhancer: " + ts.variablesInfo["steeringEnhancer"].currentValue;
        SideDetectDistanceText.text = "Side Detect Distance: " + ts.variablesInfo["sideDetectDistance"].currentValue;
        AngledDetectDistanceText.text = "Angled Detect Distance: " + ts.variablesInfo["angledDetectDistance"].currentValue;
        StraightDetectDistanceText.text = "Straight Detect Distance: " + ts.variablesInfo["straightDetectDistance"].currentValue;
    }
}
