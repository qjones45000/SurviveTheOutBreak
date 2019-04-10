using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharCombat : MonoBehaviour {

    private Animator anim;

    private AnimatorStateInfo CombatState;

    static int Slash1 = Animator.StringToHash("Combat. Swing1");
    static int Fight = Animator.StringToHash("Combat.isFighting");

	// Use this for initialization
	void Start ()
    {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CombatState = anim.GetCurrentAnimatorStateInfo(1);

     

        charCombat();
	}

    void charCombat()
    {
        if (Input.GetButtonDown("R1"))
        {
            Debug.Log("R1 is working");
        }


        if (CombatState.nameHash == Fight && Input.GetButtonDown("R1"))
        {
            anim.SetBool("Combo1", true);

        }
        else
        {
            anim.SetBool("Combo1", false);
        }

        
    }
}
