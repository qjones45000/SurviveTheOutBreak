using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlast : MonoBehaviour {

    public float speed;
    public Vector3 desiredMoveDirection;
    public float inputX;
    public float inputZ;

    public Camera cam;

    // Use this for initialization
    void Start ()
    {
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        inputX = Input.GetAxis("LeftJoystickHorizontal");
        inputZ = Input.GetAxis("LeftJoystickVertical");

        var forward = cam.transform.forward;
     

        forward.y = 0f;
       

        forward.Normalize();
       

        desiredMoveDirection = forward * inputZ;

        if (speed != 0)
        {
            transform.position += forward * (speed * Time.deltaTime);
       
        }

       
            
        
    }

    private void OnParticleCollision(GameObject other)
    {
        
    }
}
