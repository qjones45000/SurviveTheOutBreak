using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuff : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("k"))
        {
            anim.SetBool("sleep kick", true);
        }

        else
        {
            anim.SetBool("sleep kick", false);
        }
    }
}
