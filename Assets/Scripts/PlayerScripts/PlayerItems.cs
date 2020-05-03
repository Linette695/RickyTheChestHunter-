using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    public Rigidbody playerRB;     //To hold the player's rigid body
    public Text turqCount;         //The UI Text object to hold curr number of turq gems
    public Text goldCount;         //The UI Text object to hold curr number of gold keys
    public Text brownCount;         //The UI Text object to hold curr number of brown keys

    //Items to keep track of
    private int currentTurqGems = 0;
    private int currentGoldKeys = 0;
    private int currentBrownKeys = 0;




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
        else if (col.gameObject.CompareTag("GoldKey")) {
            currentGoldKeys += 1;
            Destroy(col.gameObject);
            goldCount.text = currentGoldKeys.ToString();

        }
        else if (col.gameObject.CompareTag("WoodKey"))
        {
            currentBrownKeys += 1;
            Destroy(col.gameObject);
            brownCount.text = currentBrownKeys.ToString();

        }

    }//End of OnCollisionEnter





    //Getters and setters


    }//End of PlayerItems class
