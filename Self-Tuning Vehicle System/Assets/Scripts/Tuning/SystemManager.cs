using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public static bool StartRace;
    public static bool RaceRunning;

    [SerializeField] private GameObject car;
    [SerializeField] private VehicleBehaviour vh;
    [SerializeField] private Transform startLine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        car.transform.position = new Vector3(startLine.position.x, startLine.position.y, car.transform.position.z);
        vh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartRace)
        {
            StartVehicle();
            RaceRunning = true;
        }



        if(LapChecker.lapFinished)
        {
            RaceRunning = false;
            Timer.ResetTimer = true;
            ManageVehicleReset();
        }
    }

    void ManageVehicleReset()
    {
        car.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        car.transform.position = new Vector3(startLine.position.x, startLine.position.y, car.transform.position.z);
        vh.speedUpPower = 0;
        vh.enabled = false;

    }

    void StartVehicle()
    {
        vh.enabled = true;
    }
}
