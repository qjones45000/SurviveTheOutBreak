using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : MonoBehaviour {

    private Animator anim;

    private AnimatorStateInfo currentBaseState;
    private AnimatorStateInfo MagicAimsCurrentState;
    private AnimatorStateInfo LayerPunchState;

    static int idle = Animator.StringToHash("Base Layer.Idle");
    static int Aim = Animator.StringToHash("MagicAim.MagicShot");
    static int LocoMove = Animator.StringToHash("Base Layer.Locomotion");
    static int Punching = Animator.StringToHash("LayerPunchState.Punching");

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();

        if (anim.layerCount == 4)
            anim.SetLayerWeight(1, 1);
		
	}

    private void FixedUpdate()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        if (anim.layerCount == 4)
            MagicAimsCurrentState = anim.GetCurrentAnimatorStateInfo(1);

        if (anim.layerCount == 5)
            LayerPunchState = anim.GetCurrentAnimatorStateInfo(2);

        if (currentBaseState.nameHash == idle || currentBaseState.nameHash == LocoMove)
        {
            if (Input.GetKey("k"))
            {
                anim.SetBool("MagicShot", true);
            }
            else
            {
                anim.SetBool("MagicShot", false);
            }
            if (Input.GetKeyDown("p"))
            {
                anim.SetBool("Punching", true);
            }
            else
            {
                anim.SetBool("Punching", false);
            }
        
        }
     
        




    }

    // Update is called once per frame
    void Update () {
		
	}
}
