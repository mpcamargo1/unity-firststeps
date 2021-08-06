using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbot : MonoBehaviour
{
    float rawVertical;
    float rawHorizontal;
    static Animator anim;
    public Transform cam;
    public float targetAnglebefore = 0;
    float smooth = 8.0f;

    // Start is called before the first frame update
    void Start()
    {

          anim = GetComponent<Animator>();
          Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

          rawVertical = Input.GetAxis("Vertical");
          rawHorizontal = Input.GetAxis("Horizontal");
          Vector3 direction = new Vector3(rawHorizontal,0f,rawVertical).normalized;
          float targetAngleActual = cam.eulerAngles.y;

          if(direction.magnitude >=0.1f){

              anim.SetFloat("X",rawHorizontal);
              anim.SetFloat("Y",rawVertical);
          }

          if(targetAnglebefore != targetAngleActual){
            Quaternion target = Quaternion.Euler(0f,targetAngleActual,0f);
            transform.rotation =  Quaternion.Slerp(transform.rotation, target,Time.deltaTime * smooth);


            targetAnglebefore = targetAngleActual;
          }

    }

    void Awake(){
          Application.targetFrameRate = 60;
    }


}
