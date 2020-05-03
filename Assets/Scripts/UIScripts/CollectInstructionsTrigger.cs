using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectInstructionsTrigger : MonoBehaviour
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
           
                bannerText.text = "Collect items by walking through them";

        }


    }//End of OnTriggerEnter

    private void OnTriggerExit(Collider col)
    {
        bannerText.text = "   ";
    }

}//End of CollectInstructionsTrigger class

