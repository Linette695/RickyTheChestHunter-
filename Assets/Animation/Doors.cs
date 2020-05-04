using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Doors : MonoBehaviour
{
   
    public Animator animator;
    public Material openDoorMaterial;
    public GameObject squareTrigger;
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
        if (col.gameObject.tag == "Character"){    
            turqDoorOpen = true;
            doors("openChestTrigger");
           

        }
        
    }

    private void doors(string direction) {
        animator.SetTrigger(direction);
        squareTrigger.GetComponent<MeshRenderer>().material = openDoorMaterial;
    }


}
