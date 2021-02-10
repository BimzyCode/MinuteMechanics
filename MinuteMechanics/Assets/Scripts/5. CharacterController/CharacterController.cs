using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Animator animator;
    private Rigidbody rigid;
    private Vector3 inputs;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer, QueryTriggerInteraction.Ignore);

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");
    
        if (inputs != Vector3.zero)
        {
            transform.forward = inputs;
        }

        animator.SetFloat("Forward", inputs.magnitude);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            rigid.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + inputs * speed * Time.fixedDeltaTime);
    }
}
