using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Gyro : MonoBehaviour
{
    
    Gyroscope m_Gyro;
    private Quaternion attitude;
    private Vector3 gravity;
    [SerializeField]
    private int attitudeMultiplier;

    void Start()
    {
        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        Debug.Log(m_Gyro);
        attitude = m_Gyro.attitude;
        gravity = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("attitude");
        attitude = m_Gyro.attitude;
        Debug.Log(attitude);
        Vector3 a = new Vector3(0f, attitude.z, 0);
        Debug.Log("a");
        Debug.Log(a);
        float yVal = -(a.y * attitudeMultiplier);
        gravity = new Vector3(0f, (yVal), 0);
        Debug.Log("gravity");
        Debug.Log(gravity);
        Physics.gravity = gravity;

    }
}
