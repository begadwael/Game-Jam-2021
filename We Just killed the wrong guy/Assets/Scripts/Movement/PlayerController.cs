using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control{
public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform cam;
    [Header("Movement Variables")]
    [SerializeField] float walkSpeed=5f;
    [SerializeField] float sprintMultiplier=1.5f;
    [SerializeField]float crouchMultiplier=.7f;
    [SerializeField] float airControlMultiplier=.6f;
    [SerializeField] float jumpForce=10f;
    [SerializeField] float smoothing = 2;
    [SerializeField] bool useSlope=true;
    InputHandler iHandler;
    Rigidbody rBody;
    float currentSpeed;
    float lookBounds=85f;
    float slopeAngle;
    float disToGround;
    Vector3 velocity;
    Vector3 movementDir;
    RaycastHit groundHit;
    //Movement bools
    bool isGrounded;
    Vector2 apliedMouseDelta;
    Vector2 mouseLook;

    void Start()
    {
        iHandler=GetComponent<InputHandler>();
        rBody=GetComponent<Rigidbody>();
        disToGround=groundCheck.position.y+0.1f;
        Cursor.lockState=CursorLockMode.Locked;
        currentSpeed=walkSpeed;
    }
    void Update()
    {
        CalculateLook();
    }
    private void FixedUpdate()
    {
        CalculateMovement();
        GroundCheck();
    }
    void CalculateLook(){
        Vector2 delta=iHandler.GetCameraInput()*smoothing;
        apliedMouseDelta=Vector2.Lerp(apliedMouseDelta,delta,1/smoothing);
        mouseLook+=apliedMouseDelta;
        mouseLook.y=Mathf.Clamp(mouseLook.y,-90,90);

        cam.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
    }

    void CalculateMovement(){
        movementDir=((transform.forward*iHandler.GetMovement().y)+(transform.right*iHandler.GetMovement().x));

        UpdateSpeed();
        velocity=movementDir*Time.fixedDeltaTime*currentSpeed;

        if(useSlope){
            float normalizedSlopeAngle= (slopeAngle / 90f) * -1f;
            velocity+=normalizedSlopeAngle*velocity;
        }
        rBody.MovePosition(rBody.position+velocity);

        if(isGrounded){
            if(iHandler.IsJumping){
                   rBody.AddForce(Vector3.up * 100 * jumpForce);
            }
        }
    }
    void UpdateSpeed(){
        currentSpeed=walkSpeed;
        if(isGrounded){
            if(iHandler.IsRunning){
                currentSpeed*=sprintMultiplier;
            }else if(iHandler.IsCrouching){
                currentSpeed*=crouchMultiplier;
            }
        }else{
            currentSpeed*=airControlMultiplier;
        }
    }
    void GroundCheck(){
        if (Physics.Raycast(groundCheck.transform.position, Vector3.down, out groundHit, disToGround,ground)) {
            slopeAngle=Vector3.Angle(groundHit.normal,movementDir.normalized)-90f;
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
    
}
}