using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpInstructionsTrigger : MonoBehaviour
{
    public Text bannerText;     //To hold text object we will be changing
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Character")
        {


            bannerText.text = "Use SPACE BAR to jump";
        }


    }//End of OnTriggerEnter

    private void OnTriggerExit(Collider col)
    {
        bannerText.text = "   ";
    }
}//End of JumpInstructionsTrigger class
