using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyGirlCombat : MonoBehaviour {

    private Animator anim;

    

    private AnimatorStateInfo currentBaseState;

    static int punch1 = Animator.StringToHash("Base Layer.punch1");
    static int punch2 = Animator.StringToHash("Base Layer.punch2");
    static int punch3 = Animator.StringToHash("Base Layer.punch3");
    static int uppercut = Animator.StringToHash("Base Layer.uppercut");

    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        AnatomyCombat();

        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }

    void AnatomyCombat()
    {
        if (Input.GetButton("SquareButton"))
        {
            anim.SetBool("Combo1", true);


        }
        else
        {
            anim.SetBool("Combo1", false);
        }

        if (currentBaseState.nameHash == punch1 && Input.GetButton("SquareButton"))
        {
            anim.SetBool("Combo2", true);
            anim.SetBool("Combo1", false);
        }
        else
        {
            anim.SetBool("Combo2", false);
        }
        if (currentBaseState.nameHash == punch2 && Input.GetButton("SquareButton"))
        {
            anim.SetBool("Combo3", true);
            anim.SetBool("Combo2", false);
        }
        else
        {
            anim.SetBool("Combo3", false);
        }
        if (currentBaseState.nameHash == punch3 && Input.GetButton("SquareButton"))
        {
            anim.SetBool("Combo4", true);
            anim.SetBool("Combo3", false);
        }
        else
        {
            anim.SetBool("Combo4", false);
        }
    }
}
