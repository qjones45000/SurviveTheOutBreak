using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    private Animator anim;

    private int PunchBool;
    private bool Punch;

    private float speed;
	// Use this for initialization

	void Start () {
        anim = GetComponent<Animator>();

        PunchBool = Animator.StringToHash("Punch");
        speed = Animator.StringToHash("Speed");



    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("k") )
        {
            anim.Play("MagicShot");
        }

   
	}
}
