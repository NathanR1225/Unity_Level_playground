using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody rigidbodyComponet;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    private bool sprint = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        sprint = (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift));
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
