using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnInstructionsTrigger : MonoBehaviour
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
           
                bannerText.text = "Use MOUSE to turn";
              

        }


    }//End of OnTriggerEnter

    private void OnTriggerExit(Collider col)
    {
        bannerText.text = "   ";
    }



}
