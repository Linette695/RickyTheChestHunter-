using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Animator animator;
    private  bool turqDoorOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        turqDoorOpen = false;
        

    }



    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Character" ){
            Debug.Log("Have encounter door");
            turqDoorOpen = true;
            doors("TurqOpen");

        
        }
        
    }

    private void doors(string direction) {
        animator.SetTrigger(direction);
    }


}
