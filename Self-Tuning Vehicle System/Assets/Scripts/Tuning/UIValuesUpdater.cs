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

    [SerializeField] VehicleBehaviour vh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accelerationAdjusterText.text = "Acceleration Ajuster: " + vh.accelerationAdjuster;
        speedUpIncrementText.text = "Speed Up Increment: " + vh.speedUpIncrement;
        MinimumSteeringPowerText.text = "Minimum Steering Power: " + vh.minimumSteeringPower;
        SteeringEnhancerText.text = "Steering Enhancer: " + vh.steeringEnhancer;
        SideDetectDistanceText.text = "Side Detect Distance: " + vh.sideDetectDistance;
        AngledDetectDistanceText.text = "Angled Detect Distance: " + vh.angledDetectDistance;
        StraightDetectDistanceText.text = "Straight Detect Distance: " + vh.straightDetectDistance;
    }
}
