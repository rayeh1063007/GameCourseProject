using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float x;
    public float y;
    public float xSpeed = 1;
    public float ySpeed = 1;
    public Transform target;
    public float distence;
    private Vector3 cameraPos;
    private Quaternion rotationEuler;

    public void Start()
    {
        
    }
    public void Update()
    {
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

        if(x>360)
        {
            x -= 360;
        }
        else if(x<0)
        {
            x += 360;
        }
        if (y > 60)
        {
            y = 60;
        }
        else if (y < -60)
        {
            y = -60;
        }

        rotationEuler = Quaternion.Euler(y, x, 0);
        cameraPos = rotationEuler * new Vector3(0, 0.75f, -distence) + target.position;

        transform.rotation = rotationEuler;
        transform.position = cameraPos;
    }

}
