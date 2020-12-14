using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody rigidbodyComponet;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    private bool sprint = false;
    Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        rigidbodyComponet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        sprint = (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift));
        bool forwardPressed = Input.GetKey("w");
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        if (!isWalking  && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }else if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

         if (!isRunning  && (forwardPressed && sprint))
        { 
            animator.SetBool(isRunningHash, true);
        }else if (isRunning && (!forwardPressed || !sprint))
        {
            animator.SetBool(isRunningHash, false);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        float speed = sprint ? 10 : 5;
        rigidbodyComponet.velocity = new Vector3(horizontalInput* speed, rigidbodyComponet.velocity.y, verticalInput* speed);
        Debug.Log("speed " + sprint);
    }
}
