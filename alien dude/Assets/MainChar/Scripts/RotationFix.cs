using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour {

    public GameObject holster;
    public GameObject unequip;
   

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
       
      

    }

    private void FixedUpdate()
    {
        unequip.transform.rotation = holster.transform.rotation;
    }
}
