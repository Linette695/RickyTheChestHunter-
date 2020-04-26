using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Create variables for the horizontal and vertical movement input
    [SerializeField] private string horizInputName;
    [SerializeField] private string verInputName;

    //Create reference to the character controller
    private CharacterController charContr;

    //Create variable for the character speed
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Awake()
    {
        charContr = GetComponent<CharacterController>();    //Get the character controller directly
    }

    private void Movement()
    {
        //Obtain the input values for the movement in veritcal and horizontal axis 
        float verticalInput = Input.GetAxis(verInputName) * speed;
        float horizontalInput = Input.GetAxis(horizInputName) * speed;

        Vector3 fowardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;

        //Actually move the character 
        charContr.SimpleMove(fowardMovement + rightMovement);
    }//End of Movement method



}//End of PlayerMove Class
