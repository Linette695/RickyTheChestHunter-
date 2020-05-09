using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*switchScenes method changes the scene to the scene corresponding to the passed integer*/
    public void switchScenes(int x)
    {
        Debug.Log("You've changed scenes to: " + x);
        SceneManager.LoadScene(x);
    }//End of switchScenes

    /*end method quits the game when called*/
    public void end()
    {
        Debug.Log("You've clicked the quit button! ");
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }//End of End


}//End of ButtonsController class
