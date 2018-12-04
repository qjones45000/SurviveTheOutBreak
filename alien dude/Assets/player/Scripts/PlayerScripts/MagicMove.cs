using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMove : MonoBehaviour {

    public float speed;
    public float FireRte;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        


         transform.position += transform.forward * (speed * Time.deltaTime);

        // the object is already going in that forward direction, so when instantiated it doesnt matter where the player is facing since its already moving int that foward direction.
        // make raycast along camera and instatiate along the raycast.
        
        
		
	}
}
