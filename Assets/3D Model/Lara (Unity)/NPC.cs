using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public GameObject followLara;
    static Animator anim;
    private RaycastHit hit;

    void Start(){
      anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      followLara.transform.position = player.transform.position + new Vector3(4f,0,0);

      transform.LookAt(followLara.transform);
      if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit)){
          Debug.LogFormat("Distance {0}",hit.distance);
            if(hit.distance > 3 && hit.distance < 10)
                anim.SetFloat("Velocidade",(hit.distance/7) - (3/7));
            else if(hit.distance >= 10)
                anim.SetFloat("Velocidade",1f);
            else
                anim.SetFloat("Velocidade",0f);

          }
    }

}


/*Fórmula Matemática

(3,0)
(10,1)

m = Dy/Dx;
m = 1/7;

y-y0 = m(x - x0); Equação da Reta
y = 1/7(x - 3)
y = x/7 - 3/7;

Velocidade Linear;

*/
