using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    public Rigidbody playerRB;     //To hold the player's rigid body
    public Text turqCount;         //The UI Text object to hold curr number of turq gems

    //Items to keep track of
    private int currentTurqGems = 0;
    



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
            turqCount.text = currentTurqGems.ToString();

        }

    }//End of OnCollisionEnter





    //Getters and setters


    }//End of PlayerItems class
