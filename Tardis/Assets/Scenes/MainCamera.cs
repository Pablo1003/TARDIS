using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Gyroscope gyro;
    public float speed = 4f;

    private Quaternion rot;

    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        Screen.orientation = ScreenOrientation.Portrait; // Empieza en modo portrait (pantalla vertical) - no ayuda precisamente
        //transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));

        
        //rot = new Quaternion(0, 0, 1, 0);
        //transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        //transform.Rotate(0, Input.acceleration.y / 10, 0, Space.Self);
        //transform.rotation = GyroToUnity(Input.gyro.attitude);
        //transform.localRotation = gyro.attitude * rot;
        transform.rotation = Input.gyro.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self);
        transform.Rotate(90f, 180f, 0f, Space.World);
    }
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, q.z, -q.w);
    }
}
