using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GemChestScript : MonoBehaviour
{
   
    public Animation impAnimation;
    

    public Text numKeys;    //Displayed integer on canvas (the count the player can see)
    public int keysNeeded;  //To hold the number of keys needed for this level's chest
    public int nextScene;   //To indicate the next scene loaded after the chest is opened

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
        if (col.gameObject.tag == "Character" &&  numOfKeys == keysNeeded)
        {
            chestOpen = true;
            openChest("ChestOpen");
           


        }

    }

    private void openChest(string trig)
    {
        impAnimation.Play("ChestOpen");
       

        StartCoroutine(Helper());
    }

   IEnumerator Helper() {
        yield return new WaitForSeconds(2.0f);
        switchScenes(nextScene);


    }


    public void switchScenes(int x)
    {
        
        Debug.Log("You've changed scenes to: " + x);
        SceneManager.LoadScene(x);
    }//End of switchScenes

}//End of GemChestScript class
