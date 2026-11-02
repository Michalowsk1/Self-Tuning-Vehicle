using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleBehaviour : MonoBehaviour
{
    [SerializeField] GameObject VehicleBody;
    [SerializeField] GameObject VehicleFront;
    [SerializeField] Rigidbody2D rb;
    public Vector2 MoveDirection;
    public float accelerationAdjuster = 2.5f;
    public float speedUpPower = 0.0f;
    public float speedUpIncrement = 0.0f;
    public float minimumSteeringPower = 0.35f;
    public float minimumSpeedForSteering = 0.5f;
    public float steeringEnhancer = 2.0f;
    public float sideDetectDistance = 3.0f;
    public float angledDetectDistance = 4.0f;
    public float straightDetectDistance = 5.0f;
    float raycastDetectDistance = 0.0f;

    public bool[] sensorStatus = { false, false, false, false, false };

    public Dictionary<int, float> RayInfo = new Dictionary<int, float>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawSensors();

        MoveDirection = VehicleFront.transform.position - VehicleBody.transform.position;
        Controls();

        

    }

    void Controls()
    {
        Acceleration();



        //0 = left, 4 == right
        if (!sensorStatus[0]) // if nothing on left side turn left
        {
            SteerLeft();
        }
        if (!sensorStatus[4]) // if nothing on right side turn right
        {
            SteerRight();
        }
    }

    float GetMagnitude()
    {
        return Mathf.Sqrt((rb.linearVelocityX * rb.linearVelocityX) + (rb.linearVelocityY * rb.linearVelocityY));
    }

    float SteeringPower(int rayNum)
    {
        if (GetMagnitude() < minimumSpeedForSteering)
        {
            return EaseInOutFunctions.EaseOutCubic(RayInfo[rayNum]);
        }
        return Mathf.Max(1.0f / GetMagnitude(), minimumSteeringPower);
    }

    void Acceleration()
    {
        rb.linearVelocity = EaseInOutFunctions.EaseInOutCubic(RayInfo[2]) * (MoveDirection * (accelerationAdjuster + IncreasedPower()));
    }

    float IncreasedPower()
    {
        if (sensorStatus[2]) //front clear
            speedUpPower = speedUpPower + speedUpIncrement;
        else
            speedUpPower = 0;

        return speedUpPower;
    }
    void SteerLeft()
    {
        if (!sensorStatus[0] && sensorStatus[1])
        {
            gameObject.transform.localEulerAngles = new Vector3(0, 0, gameObject.transform.localEulerAngles.z + SteeringPower(4));
        }
        else if (!sensorStatus[0] && !sensorStatus[1])
        {
            gameObject.transform.localEulerAngles = new Vector3(0, 0, gameObject.transform.localEulerAngles.z + (SteeringPower(3) * steeringEnhancer));
        }

    }

    void SteerRight()
    {
        if (!sensorStatus[4] && sensorStatus[3])
        {
            gameObject.transform.localEulerAngles = new Vector3(0, 0, gameObject.transform.localEulerAngles.z - SteeringPower(0));
        }
        else if (!sensorStatus[4] && !sensorStatus[3])
        {
            gameObject.transform.localEulerAngles = new Vector3(0, 0, gameObject.transform.localEulerAngles.z - (SteeringPower(1) * steeringEnhancer));
        }
    }


   void DrawSensors()
    {
        int mask = LayerMask.GetMask("TrackWall");
        for (int i = 0; i <= 4; i++)
        {

            Vector2 direction = Quaternion.Euler(0, 0, -60.0f + (i * 30.0f)) * MoveDirection.normalized;

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, RayDistance(i), mask);

            float distance = hitInfo.collider != null ? hitInfo.distance : RayDistance(i);

            UpdateDictionaryVales(i, Mathf.Round(distance * 100.0f) / 100.0f);


            Debug.DrawRay(transform.position, direction * distance, hitInfo.collider != null ? Color.red : Color.green);
        }
        UpdateSensorStatus();

    }

    float RayDistance(float i)
    {
        if (i == 0 || i == 4) return sideDetectDistance;
        else if (i == 1 || i == 3) return angledDetectDistance;
        else return straightDetectDistance;

    }


    void UpdateDictionaryVales(int key, float distance)
    {
        if (RayInfo.ContainsKey(key))
            RayInfo[key] = distance;
        else
            RayInfo.Add(key, distance);
    }

    void UpdateSensorStatus()
    {
        for (int i = 0; i < 5; i++)
        {
            if (RayInfo[i] == RayDistance(i))
                sensorStatus[i] = true;
            else
                sensorStatus[i] = false;
        }
    }


}
