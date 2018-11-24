using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public Rigidbody power;
    public Transform powerform;

   

  

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
       
        
            if (Input.GetKeyDown("b"))
            {
                Rigidbody Pmove;

                Pmove = Instantiate(power, powerform.position, powerform.rotation) as Rigidbody;
                Pmove.AddForce(powerform.forward * 5000);


            }
           
        

   

		
	}
}
