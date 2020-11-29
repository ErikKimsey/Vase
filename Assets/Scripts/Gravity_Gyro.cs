using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Gyro : MonoBehaviour
{
    
    Gyroscope _mGyro;
    private Quaternion _attitude;
    private Vector3 _gravity;
    [SerializeField]
    private int attitudeMultiplier;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        _mGyro = Input.gyro;
        _mGyro.enabled = true;
        _attitude = _mGyro.attitude;
        _gravity = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        _attitude = _mGyro.attitude;
        Vector3 a = new Vector3(0f, _attitude.z, 0);
        float yVal = -(a.y * attitudeMultiplier);
        _gravity = new Vector3(0f, (yVal), 0);
        Physics.gravity = _gravity;

    }
}
