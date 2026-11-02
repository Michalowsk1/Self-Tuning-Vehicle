using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Sensortext;
    [SerializeField] TextMeshProUGUI Statstext;
    public VehicleBehaviour vehicleBehaviour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sensortext.text = "LeftRay(4):" + vehicleBehaviour.RayInfo[4] +
                    "\r\n\r\nLeftUpRay(3):" + vehicleBehaviour.RayInfo[3] +
                    "\r\n\r\nUpRay(2):" + vehicleBehaviour.RayInfo[2] +
                    "\r\n\r\nRightUpRay(1):" + vehicleBehaviour.RayInfo[1] +
                    "\r\n\r\nRightRay(0):" + vehicleBehaviour.RayInfo[0];

        Statstext.text = "Speed: " + EaseInOutFunctions.EaseInOutCubic(vehicleBehaviour.RayInfo[2]) * (vehicleBehaviour.MoveDirection * vehicleBehaviour.accelerationAdjuster);
    }
}
