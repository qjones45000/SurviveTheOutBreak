using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {

	private Animator anim;

	private AnimatorStateInfo currentBaseState;

	static int idle = Animator.StringToHash("Base Layer.Flip 2");
	static int Flippy = Animator.StringToHash("Base Layer.Flip");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);



	

	

		if (currentBaseState.nameHash == Flippy) 
		{
			if (Input.GetKeyDown ("l")) 
			{
				anim.Play ("Flip");
			}

			if (Input.GetKeyDown ("k")) 
			{
				anim.Play ("Other Kick");
			}

			if (Input.GetKeyDown ("j")) 
			{
				anim.Play ("Other Slap");
			}

			if (currentBaseState.nameHash == idle) 
			{
				if (Input.GetKeyDown("l"))
				{
					anim.Play ("Flip2");

				}

				if (Input.GetKeyDown ("k")) 
				{
					anim.Play ("SleepKick");
				}

				if (Input.GetKeyDown ("j")) 
				{

					anim.Play ("Punch");
				}
			}
		} 

			
		
	}
}
