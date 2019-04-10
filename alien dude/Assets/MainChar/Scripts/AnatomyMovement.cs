using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnatomyMovement : MonoBehaviour {

    private float min = 0;
    private float max = 50;
    public float inputX;
    public float inputZ;
    private float jumpMultiplier = 1f;
    private float jumpDist = 1f;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    private float verticalVel;
    private Vector3 moveVector;
    public float Dash = 0.01f;
    public Slider DashBar;
    public ParticleSystem TeleEffect;
    public ParticleSystem TeleBlast;
    public CharacterController charController;
    private float capsulHeight;


    private AnimatorStateInfo currentBaseState;

    static int jump = Animator.StringToHash("Base Layer.jump");

    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update()
    {

        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);


        InputMagnitude();

        // Dash
        if (Input.GetButton("R2"))
        {
            var forward = cam.transform.forward;
            var right = cam.transform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();
            desiredMoveDirection = forward * inputZ + right * inputX;

            this.transform.position += desiredMoveDirection * Dash;
           
            TeleBlast.Play();
            TeleEffect.Play();

            DashBar.value -= 0.02f;

            anim.Play("run");
         
        }

        if (DashBar.value > 0)
        {
            Dash = 5;
        }

        if (DashBar.value == 0)
        {
            Dash = 0;
        }

        if (DashBar.value >= 0)
        {
            
            StartCoroutine(DashWait());

        }
        //

  

        // keeps the character grounded
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 2;
        }

        moveVector = new Vector3(0, verticalVel, 0);
        controller.Move(moveVector);

     
    }



    void PlayerMoveRotation()
    {
        inputX = Input.GetAxis("LeftJoystickHorizontal");
        inputZ = Input.GetAxis("LeftJoystickVertical");

        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * inputZ + right * inputX;

        // allows player to look in the correct direction

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    private void FixedUpdate()
    {
       if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Jump", true);

            
        }
        else
        {
            anim.SetBool("Jump", false);
        }

      
    }

    void InputMagnitude()
    {
        // calculates input vector
        inputX = Input.GetAxis("LeftJoystickHorizontal");
        inputZ = Input.GetAxis("LeftJoystickVertical");

        anim.SetFloat("inputZ", inputZ, 0.0f, Time.deltaTime * 2);
        anim.SetFloat("inputX", inputX, 0.0f, Time.deltaTime * 2);

        // calculate the player input or input magnitude

        speed = new Vector2(inputX, inputZ).sqrMagnitude;

        // physically move player
        if (speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
            PlayerMoveRotation();
        }
        else if (speed < allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", speed, 0.0f, Time.deltaTime);
        }
    }

    IEnumerator DashWait()
    {

        yield return new WaitForSeconds(3);
        DashBar.value += 0.001f;


    }

}
