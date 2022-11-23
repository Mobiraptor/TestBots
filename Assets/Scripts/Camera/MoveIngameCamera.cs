using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIngameCamera : MonoBehaviour
{
    private float axisX;
    private float axisY;
    private float maxX = 90;
    //private float minX = -40;
    private float cameraSpeed = 1.4f;


    private void RotateCamera()
    {
        if (Input.GetAxis("Mouse X") != 0)
        {
            axisY += Input.GetAxis("Mouse X") * cameraSpeed;
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            axisX += Input.GetAxis("Mouse Y") * cameraSpeed;
        }
        if (axisX > maxX)
        {
            axisX = maxX;
        }
        if (axisX < -maxX)
        {
            axisX = -maxX;
        }

        GetComponent<Camera>().transform.rotation = Quaternion.Euler(-axisX, axisY, 0);


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().position += gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().position -= gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position -= gameObject.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += gameObject.transform.right;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RotateCamera();
        }
    }
}
