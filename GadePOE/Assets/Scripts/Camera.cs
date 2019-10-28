using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove();
        cameraZoom();
    }

    protected void cameraZoom()
    {
        //Camera Zoom
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
    protected void cameraMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(speed * Time.deltaTime * horizontal, 0, speed * Time.deltaTime * vertical);
    }
}
