using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIngameCamera : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Transform>().position += Vector3.forward;
        }
    }
}
