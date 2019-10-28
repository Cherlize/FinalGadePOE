using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = Time.deltaTime * 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Camera Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed * vertical);  //move up in y axis
        }



        //Camera Zoom
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position += new Vector3(-speed * horizontal, 0, vertical);            
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position += new Vector3(+speed * horizontal, 0, vertical);
        }
    }
}
