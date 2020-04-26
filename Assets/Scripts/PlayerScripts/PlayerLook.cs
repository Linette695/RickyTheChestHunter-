using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerLook : MonoBehaviour
{

    //Creating the variables to hold the x and y axis inputs:
    [SerializeField] private string xMouseInput;
    [SerializeField] private string yMouseInput;


    //Create the variable for the mouse sensitivity:
    [SerializeField] private float mouseSensitivity;

    //Create variables to limit the rotation of the camera 
    private float xClamp; 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    private void Awake()
    {
        LockCursor();
        xClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }//End of lockCursor

    private void CameraRotation() {
        //Obtain the x and y mouse input of player, apply the sensitivity and time delay factors
        float mX = Input.GetAxis(xMouseInput) * mouseSensitivity * Time.deltaTime;
        float mY = Input.GetAxis(yMouseInput) * mouseSensitivity * Time.deltaTime;

        //Check the limits of rotation to be able keep the rotation no more or less than 90 degrees
        xClamp += mY;

        if (xClamp < -90.0f)
        {
            xClamp = -90.0f;
            mY = 0.0f;
            ClampXRotationToValue(90.0f);
        }
        else if (xClamp > 90.0f) {
            xClamp = 90.0f;
            mY = 0.0f;
            ClampXRotationToValue(270.0f);
        }

        //Now rotate the camera
        transform.Rotate(-transform.right * mY);


    }//End of CameraRotation


    private void ClampXRotationToValue(float x) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = x;
        transform.eulerAngles = eulerRotation;

    }//End of ClampXRotationToValue
}//End of PlayerLook class
