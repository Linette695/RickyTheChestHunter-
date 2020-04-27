using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float distAway;        //Distance that camera will stay away from player
    [SerializeField] private float distUp;          //Distance that camera will stay up away from player (the angle)
    [SerializeField] private float smoothness;      //How smooth the camera will follow 
    [SerializeField] private Transform follow;      //What the camera will be following 
    private Vector3 targetPosit;                    //The target position camera will be aiming for

    //******
    [SerializeField] private string xMouseInput;
    //Create the variable for the mouse sensitivity:
    [SerializeField] private float mouseSensitivity;
    //Create variables to limit the rotation of the camera 
    private float xClamp;
    [SerializeField] private Transform playerBody;



    //**************

    // Start is called before the first frame update
    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;        //Obtain the transform to follow (character has a transform child tagged Player)
    }

    // Update is called once per frame
    void Update()
    {
        //****
        CameraRotation();
        //****
    }
    private void CameraRotation()
    {
        //Obtain the x and y mouse input of player, apply the sensitivity and time delay factors
        float mX = Input.GetAxis(xMouseInput) * mouseSensitivity * Time.deltaTime;
       // float mY = Input.GetAxis(yMouseInput) * mouseSensitivity * Time.deltaTime;

        //Check the limits of rotation to be able keep the rotation no more or less than 90 degrees
       // xClamp += mY;

     /*   if (xClamp < -90.0f)
        {
            xClamp = -90.0f;
            mY = 0.0f;
            ClampXRotationToValue(90.0f);
        }
        else if (xClamp > 90.0f)
        {
            xClamp = 90.0f;
            mY = 0.0f;
            ClampXRotationToValue(270.0f);
        }*/

        //Now rotate the camera //MIGHT GET RIDOFF THIS FOR YAXIS LOOKING
       // transform.Rotate(Vector3.left * mY);

        //Rotate the player body
        playerBody.Rotate(Vector3.up * mX);


    }//End of CameraRotation

    //***********
    private void Awake()
    {
        LockCursor();
        xClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }//End of lockCursor
 


    //********
    private void LateUpdate()
    {
        //Set the target position
        targetPosit = follow.position + follow.up * distUp - follow.forward * distAway; //Using the follow transform calculate the target position
        //For Debugging so we can see it
        Debug.DrawRay(follow.position, Vector3.up * distUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distAway, Color.blue);
        Debug.DrawLine(follow.position, targetPosit, Color.magenta);

        //Transition to target position applying the smoothness
        transform.position = Vector3.Lerp(transform.position, targetPosit, Time.deltaTime * smoothness);

        //Make sure camera is facing the right way
        transform.LookAt(follow);

    }

}//End of FollowCamera class
