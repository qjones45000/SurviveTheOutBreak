using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : GenericBehaviour
{

    private Animator anim;

    public float speed;

    public ParticleSystem ancienttxt;
    public ParticleSystem Flame;


    public float damage = 10f;
    public float Range = 100f;

    public Camera SpellCast;

    public GameObject SpellThing;









    private AnimatorStateInfo currentBaseState;
    private AnimatorStateInfo MagicAimsCurrentState;
    private AnimatorStateInfo LayerPunchState;
    private AnimatorStateInfo MagicStrikeCurrentState;

    static int idle = Animator.StringToHash("Base Layer.Idle");
    static int Aim = Animator.StringToHash("MagicAim.MagicShot");
    static int LocoMove = Animator.StringToHash("Base Layer.Locomotion");
    static int Punching = Animator.StringToHash("LayerPunchState.Punching");
    static int MagicStance = Animator.StringToHash("Base Layer.Standing Idle");
    static int MagicMove = Animator.StringToHash("Base Layer.magic movement");
    static int Strike = Animator.StringToHash("MagicStrikeCurrentState.magic strike");
    static int ActualStrike = Animator.StringToHash("MagicStrikeCurrentState.strike");

    // Use this for initialization
    void Start()
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

        if (anim.layerCount == 6)
            MagicStrikeCurrentState = anim.GetCurrentAnimatorStateInfo(3);


        if (currentBaseState.nameHash == idle || currentBaseState.nameHash == LocoMove)
        {

            

 


            if (Input.GetKeyDown("p"))
            {
                anim.SetBool("Punching", true);
            }
            else
            {
                anim.SetBool("Punching", false);
            }


            if (Input.GetKeyDown("j"))
            {
                anim.SetBool("Standing Idle", true);
                ancienttxt.Play();

            }

    


        }


        if (currentBaseState.nameHash == LocoMove)
        {
            if (Input.GetKeyDown("j"))
            {
                anim.Play("magic movement");
            }
        }

        if (currentBaseState.nameHash == MagicStance)
        {
            

            if (Input.GetKeyDown("j"))
            {
                anim.SetBool("Standing Idle", false);
                ancienttxt.Stop();
            }

            


            if (Input.GetKey("l"))
            {
                anim.SetBool("MagicStrike", true);
                

              
            }

          

            else
            {
                anim.SetBool("MagicStrike", false);
                
            }

            if (Input.GetKeyUp("l"))
            {
                anim.Play("strike");

                SpellTho();
            }

            if (Input.GetKeyDown("m"))
            {
                anim.Play("AreaAttack");
            }
        }

        if (currentBaseState.nameHash == MagicMove)
        {
            if (Input.GetKeyDown("j"))
            {
                anim.Play("Idle");
                anim.SetBool("Standing Idle", false);
                ancienttxt.Stop();
            }

            if (Input.GetKey("l"))
            {
                anim.SetBool("MagicStrike", true);
            }
            else
            {
                anim.SetBool("MagicStrike", false);
            }

            if (Input.GetKeyUp("l"))
            {
                anim.Play("strike");
                SpellTho();

            }

            if (Input.GetKeyDown("m"))
            {
                anim.Play("AreaAttack");
            }

        }

       if (MagicAimsCurrentState.nameHash == Aim)
        {
            if (Input.GetKey("v"))
            {
                Flame.Emit(1); 
            }
        }


    }




    void SpellTho()
    {


        RaycastHit Hit;

        if (Physics.Raycast(SpellCast.transform.position, SpellCast.transform.forward, out Hit, Range))
        {
            Debug.Log(Hit.transform.name);

         GameObject  blast = Instantiate(SpellThing, Hit.point, Quaternion.LookRotation(Hit.normal));
            Destroy(blast, 2f);
        }


    }








}




















 


    
           
        
       
 

