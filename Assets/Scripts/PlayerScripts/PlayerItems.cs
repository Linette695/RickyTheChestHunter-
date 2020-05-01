using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public Rigidbody playerRB;     //To hold the player's rigid body

    //Items to keep track of
    private int currentTurqGems = 0;
    private



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("TurqBall"))
        {
            currentTurqGems += 1;
            Destroy(col.gameObject);


        }

    }//End of OnCollisionEnter





    //Getters and setters


    }//End of PlayerItems class
