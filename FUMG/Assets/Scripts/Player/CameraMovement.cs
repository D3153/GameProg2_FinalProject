using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minAngle = -30;
    public float maxAngle = 30;
    float camRotation = 0;
    // public Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        camRotation += mouseY;
        camRotation = Mathf.Clamp(camRotation,minAngle,maxAngle);
        transform.localEulerAngles = new Vector3(camRotation,0,0);
        // turn.x += Input.GetAxis("Mouse X");
        // turn.y += Input.GetAxis("Mouse Y");
        // transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }
}
