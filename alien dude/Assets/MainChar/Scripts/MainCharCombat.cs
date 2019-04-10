using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharCombat : MonoBehaviour {

    private Animator anim;

    public float measureCombo;

    private AnimatorStateInfo CombatState;
    private AnimatorStateInfo HeavyState;

    static int Slash1 = Animator.StringToHash("Combat.isSwinging1");
    static int slash2 = Animator.StringToHash("Combat.isSwinging2");
    static int Fight = Animator.StringToHash("Combat.isFighting");
    static int heavy1 = Animator.StringToHash("HeavyAttack.Heavy1");
	// Use this for initialization
	void Start ()
    {
        anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CombatState = anim.GetCurrentAnimatorStateInfo(1);
        HeavyState = anim.GetCurrentAnimatorStateInfo(2);
     

        charCombat();

        BigCombos();
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

        if (CombatState.nameHash == Slash1 && Input.GetButtonDown("R1"))
        {
            anim.SetBool("Combo2", true);
            anim.SetBool("Combo1", false);

            Debug.Log("In slash state");
        }
        else
        {
            anim.SetBool("Combo2", false);
        }
        if(CombatState.nameHash == slash2 && Input.GetButtonDown("R1"))
        {
            anim.SetBool("Combo3", true);
            anim.SetBool("Combo2", false);
        }
        else
        {
            anim.SetBool("Combo3", false);
        }


        
    }

    void BigCombos()
    {
        if (Input.GetButton("R1"))
        {
            measureCombo += 0.1f;
            Debug.Log(measureCombo);
          
        }
        else if (Input.GetButtonUp("R1"))
        {
            measureCombo = 0;
            Debug.Log(measureCombo);
        }

        if(CombatState.nameHash == Fight && measureCombo >= 1)
        {
            anim.SetBool("LargeCombo1",true);
        }
        else
        {
            anim.SetBool("LargeCombo1", false);
        }

        if( measureCombo > 4.50)
        {
            anim.SetBool("LargeCombo2", true);
        }
        else
        {
            anim.SetBool("LargeCombo2", false);
        }

    }
}
