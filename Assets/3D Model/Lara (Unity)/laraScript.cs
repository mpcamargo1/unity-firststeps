using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laraScript : MonoBehaviour
{
  float rot=0f;
  float rotSpeed=80;
  float rawVertical;
  static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

      rawVertical = Input.GetAxis("Vertical");
      //Debug.LogFormat("Raw {0}",rawVertical);

      if(rawVertical - 0.23f >= 0f)
        anim.SetFloat("Velocidade",rawVertical - 0.23f);
      else{
        anim.SetFloat("Velocidade",0f);
        rot += Input.GetAxis("Horizontal")*rotSpeed*Time.deltaTime;
        transform.eulerAngles = new Vector3(0,rot,0);
      }
    }



}
