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

    //Create variables for jumping
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float multiplier;
    [SerializeField] private KeyCode jumpKey;
    private bool isJumping; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        jumpInput();
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

    private void jumpInput() {

        if (Input.GetKeyDown(jumpKey) && !isJumping) {
            isJumping = true;
            StartCoroutine(jumpEvent());

        }
    }//End of jumpInput method

    private IEnumerator jumpEvent() {
        charContr.slopeLimit = 90.0f;
        float timeOnAir = 0.0f; //Will hold the time the character has been on the air

        do {
            float force = jumpFallOff.Evaluate(timeOnAir);
            charContr.Move(Vector3.up * force * multiplier * Time.deltaTime);
            timeOnAir += Time.deltaTime;
            yield return null;
        } while (!charContr.isGrounded && charContr.collisionFlags != CollisionFlags.Above);

        charContr.slopeLimit = 45.0f;
        isJumping = false;
    }//End of jumpEvent
}//End of PlayerMove Class
