using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0,1.2f,-2.6f);
    private Vector3 velocity = Vector3.zero;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
          target = GameObject.Find("Player").transform;

    }

    void LateUpdate()
    {
        this.transform.position = Vector3.SmoothDamp(this.transform.position, target.TransformPoint(camOffset),ref velocity , 0.26f,15f);
        this.transform.LookAt(target);


    }
}
