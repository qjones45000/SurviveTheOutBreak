﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStike : MonoBehaviour {

    private Animator anim;

    private int MagicBool;
    private bool Magic;
    private float speed;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        Magic = false;

        MagicBool = Animator.StringToHash("Magic");
        speed = Animator.StringToHash("Speed");
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown("j"))
        {
            Magic = true;
            anim.SetBool(MagicBool, true);

            StartCoroutine(HoldAnim());

        }


     

       
        
           
           
            
        

  

        if(Input.GetKeyDown("j") && speed <=0 )
        {
            anim.Play("magic movement");
        }
   
     
    
 
     

    }

    private IEnumerator HoldAnim()
    {
      if(Magic == true)
        {
            yield return new WaitForSeconds(5);
            Magic = false;
            anim.SetBool(MagicBool, false);
        }  
    }

   
}
