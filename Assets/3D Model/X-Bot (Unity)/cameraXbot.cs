using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraXbot : MonoBehaviour
{
  public Vector3 camOffset = new Vector3(0,1.2f,-2.6f);
  private Transform target;

    // Start is called before the first frame update
    void Start()
    {


      target = GameObject.Find("xbot@Standing Idle").transform;

    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);

        this.transform.LookAt(target);

    }
}
