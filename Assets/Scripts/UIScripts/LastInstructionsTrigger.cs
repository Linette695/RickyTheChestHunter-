using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LastInstructionsTrigger : MonoBehaviour
{
    public Text bannerText;     //To hold text object we will be changing
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Character")
        {
           
                bannerText.text = "Remember: as the GEM HUNTER your objective is to collect all of the keys to unlock the gem chests." +
                    "\n GOOD LUCK!";

        }


    }//End of OnTriggerEnter

    private void OnTriggerExit(Collider col)
    {
        bannerText.text = "   ";
    }

}//End of LastInstructionsTrigger class
