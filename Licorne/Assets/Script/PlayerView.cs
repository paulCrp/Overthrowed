using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the Camera on the character on axis of the mouse
/// </summary>
public class PlayerView : MonoBehaviour
{
    public float speedH = 3.5f;
    public float speedV = 3.5f;


    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedH * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
