using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This classes were based on the ideas of the following videos:
 * 1) https://www.youtube.com/watch?v=PO5_aqapZXY&list=PLKFvhfT4QOqlEReJ2lSZJk_APVq5sxZ-x&index=7
 * 2) https://www.youtube.com/watch?v=n-KX8AeGK7E
 * 3)https://www.youtube.com/watch?v=MOoiezkQZmk
 */

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float distAway;        //Distance that camera will stay away from player
    [SerializeField] private float distUp;          //Distance that camera will stay up away from player (the angle)
    [SerializeField] private float smoothness;      //How smooth the camera will follow 
    [SerializeField] private Transform follow;      //What the camera will be following 
    private Vector3 targetPosit;                    //The target position camera will be aiming for

    //***
    [SerializeField] private string xMouseInput;    //To obtain the x-axis camera input
    [SerializeField] private float mouseSensitivity;    //Create the variable for the mouse sensitivity:
    [SerializeField] private Transform playerBody;  //What will be rotating
    //***



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

    //*****
    private void Awake()
    {
        LockCursor();
    }

    private void CameraRotation()
    {
        //Obtain the x and y mouse input of player, apply the sensitivity and time delay factors
        float mX = Input.GetAxis(xMouseInput) * mouseSensitivity * Time.deltaTime;
   
        //Rotate the player body
        playerBody.Rotate(Vector3.up * mX);
    }//End of CameraRotation

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }//End of lockCursor
    //*****


    private void LateUpdate()
    {
        //*
        Vector3 charactOffset = follow.position + new Vector3(0f, distUp, 0f);

        //Set the target position
        targetPosit = charactOffset + follow.up * distUp - follow.forward * distAway; //Using the follow transform calculate the target position
        //For Debugging so we can see it
        //Debug.DrawRay(follow.position, Vector3.up * distUp, Color.red);
        //Debug.DrawRay(follow.position, -1f * follow.forward * distAway, Color.blue);
        //Debug.DrawLine(follow.position, targetPosit, Color.magenta);

        //Compensate for wall bumping
        compensationForWalls(charactOffset, ref targetPosit);

        //Transition to target position applying the smoothness
        transform.position = Vector3.Lerp(transform.position, targetPosit, Time.deltaTime * smoothness);

        //Make sure camera is facing the right way
        transform.LookAt(charactOffset);

    }


    private void compensationForWalls(Vector3 fromObj, ref Vector3 toTarget) {
       // Debug.DrawLine(fromObj, toTarget, Color.cyan);

        
        RaycastHit wallHit = new RaycastHit();

        //IF wall is hit
        if (Physics.Linecast(fromObj, toTarget, out wallHit)) {
            //Debug.DrawRay(wallHit.point, Vector3.left, Color.red);
            toTarget = new Vector3(wallHit.point.x, toTarget.y, wallHit.point.z);
        }

    }//End of compensationForWalls


}//End of FollowCamera class
