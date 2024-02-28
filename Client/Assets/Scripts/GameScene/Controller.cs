using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = this.transform.position;
        Vector3 forward = camera.transform.forward.normalized;
        Vector3 right = camera.transform.right.normalized;

        if(Input.GetKey(KeyCode.W))
        {
            pos += forward * speed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            pos -= forward * speed;
        }
        else if( Input.GetKey(KeyCode.D))
        {
            pos += right * speed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            pos -= right * speed;
        }

        this.transform.position = pos;
    }
}
