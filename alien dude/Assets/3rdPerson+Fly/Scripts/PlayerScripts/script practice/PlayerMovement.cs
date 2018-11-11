using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   public float MoveSpeed;
    private Rigidbody rb;
 
    private Animator anim;
  

   private Vector3 Movement;
    private Vector3 MoveVelocity;


    // Use this for initialization
    void Start ()
    {

        rb = GetComponent<Rigidbody>();
       
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");

        Movement = new Vector3(MoveH, 0f, MoveV);

    

        MoveVelocity = transform.forward * MoveSpeed * Movement.sqrMagnitude;
        animating();
    }

   void FixedUpdate()
    {

       
        rb.velocity = MoveVelocity;
    }

    void animating()
    {
        anim.SetFloat("Blend", rb.velocity.magnitude);
    }
}
