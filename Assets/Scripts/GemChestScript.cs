using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GemChestScript : MonoBehaviour
{
   
    public Animation impAnimation;
    

    public Text numKeys;    //Displayed integer on canvas (the count the player can see)
    public Text message;    //Use to tell player messages
    public int keysNeeded;  //To hold the number of keys needed for this level's chest
    public int nextScene;   //To indicate the next scene loaded after the chest is opened
    public GameObject instrPanel; //To hold the panel to display messages
    private int numOfKeys;  //Will hold the number of keys player has collected in int form
    private bool chestOpen; //To keep track if chest has been opened
   

    // Start is called before the first frame update
    void Start()
    {
        chestOpen = false;
    }
    private void OnTriggerEnter(Collider col)
    {
        numOfKeys = int.Parse(numKeys.text);    //Convert to integer to get number of keys collected
        if (col.gameObject.tag == "Character" && numOfKeys == keysNeeded)
        {
            chestOpen = true;
            openChest("chestOpen");

        }
        else if(col.gameObject.tag == "Character"  && numOfKeys != keysNeeded) {
            message.text = "LOCKED \n " + keysNeeded + "  key(s) needed";
        
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Character" && numOfKeys != keysNeeded)
        {
            message.text = " ";

        }
    }

    private void openChest(string trig)
    {
        impAnimation.Play(trig);
       

        StartCoroutine(Helper());
    }

   IEnumerator Helper() {
        yield return new WaitForSeconds(3.0f);
        switchScenes(nextScene);


    }


    public void switchScenes(int x)
    {
        
        Debug.Log("You've changed scenes to: " + x);
        SceneManager.LoadScene(x);
    }//End of switchScenes

}//End of GemChestScript class
