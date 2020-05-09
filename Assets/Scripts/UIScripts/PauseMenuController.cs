using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    //Obtain the pause panel
    public GameObject pauseMenu;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            player.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            pauseMenu.SetActive(true);

        }

        
    }
    public void unpause() {
        player.GetComponent<CharacterController>().enabled = true;
        EventSystem.current.SetSelectedGameObject(null);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
       /* Cursor.lockState = CursorLockMode.None;*/
    }

    public void switchScenes(int x)
    {
        EventSystem.current.SetSelectedGameObject(null);
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



}//End of PauseMenu Controller


