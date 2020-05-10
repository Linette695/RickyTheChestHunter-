using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2FrontDoors : MonoBehaviour
{
    public Animator animator;
    public GameObject squareTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Character")
        {
            
            doors("openFrontDoor");


        }

    }

    private void doors(string direction)
    {
        animator.SetTrigger(direction);
        
    }


}//End of L2FrontDoors class

