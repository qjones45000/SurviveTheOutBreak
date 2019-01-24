﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : GenericBehaviour
{
    public CapsuleCollider ArialBlast;
    public CapsuleCollider ShieldBlock;
    public Transform Ball;


    public Slider BlastTime;

    public Slider AiHealth;

    private Animator anim;

    public float speed;

    public ParticleSystem ancienttxt;
    public ParticleSystem Flame;
    public ParticleSystem Blast;
    public ParticleSystem ShieldEffect;

    public float damage = 10f;
    public float Range = 100f;

    public Camera SpellCast;

    public GameObject SpellThing;

    public GameObject MagicSign;
    private ParticleSystem Sign;

    private float BlastCalc;
    private const float BlastCalcLoad = 1f;


    public Slider FlameTho;




    private AnimatorStateInfo currentBaseState;
    private AnimatorStateInfo MagicAimsCurrentState;
    private AnimatorStateInfo LayerPunchState;
    private AnimatorStateInfo MagicStrikeCurrentState;
    private AnimatorStateInfo ShieldState;
    private AnimatorStateInfo React;

    static int idle = Animator.StringToHash("Base Layer.Idle");
    static int Aim = Animator.StringToHash("MagicAim.MagicShot");
    static int LocoMove = Animator.StringToHash("Base Layer.Locomotion");
    static int Punching = Animator.StringToHash("LayerPunchState.Punching");
    static int MagicStance = Animator.StringToHash("Base Layer.Standing Idle");
    static int MagicMove = Animator.StringToHash("Base Layer.magic movement");
    static int Strike = Animator.StringToHash("MagicStrikeCurrentState.magic strike");
    static int ActualStrike = Animator.StringToHash("MagicStrikeCurrentState.strike");
    static int Shield = Animator.StringToHash("ShieldState.Shield");
    static int Reaction = Animator.StringToHash("Base Layer.No Energy React");
   

    // Use this for initialization
    void Start()
    {

        

        anim = GetComponent<Animator>();

        if (anim.layerCount == 4)
            anim.SetLayerWeight(1, 1);

        ArialBlast.enabled = false;


        

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
        if (anim.layerCount == 8)
            ShieldState = anim.GetCurrentAnimatorStateInfo(4);

        

        if (currentBaseState.nameHash == idle || currentBaseState.nameHash == LocoMove)
        {
            if (Input.GetKey("c"))
            {
                anim.SetBool("Shield", true);
                ShieldEffect.Emit(1);
            }
             if (Input.GetKeyUp("c"))
            {
                anim.SetBool("Shield", false);
                
            }

 


            if (Input.GetKeyDown("p"))
            {
                anim.SetBool("Punching", true);
            }
            else
            {
                anim.SetBool("Punching", false);
            }


            if (Input.GetButton("SquareButton"))
            {
                anim.SetBool("Standing Idle", true);
                ancienttxt.Play();

            }

    


        }


        if (currentBaseState.nameHash == LocoMove)
        {
            if (Input.GetButton("SquareButton"))
            {
                anim.Play("magic movement");
            }
        }

        if (currentBaseState.nameHash == MagicStance)
        {
            

            if (Input.GetButtonDown("SquareButton"))
            {
                anim.SetBool("Standing Idle", false);
                ancienttxt.Stop();
            }


            if (Input.GetKey("c"))
            {
                anim.SetBool("Shield", true);
                ShieldEffect.Emit(1);

                
            }
            if (Input.GetKeyUp("c"))
            {
                anim.SetBool("Shield", false);
             
            }




            if (Input.GetButton("R1"))
            {
                anim.SetBool("MagicStrike", true);
                

              
            }

          

            else
            {
                anim.SetBool("MagicStrike", false);
                
            }

            if (Input.GetButtonUp("R1"))
            {
                anim.Play("strike");

                SpellTho();
            }

            
            if (Input.GetButtonDown("Triangle") && FlameTho.value != 0)
            {
                StartCoroutine(WaitAtFirst());
                anim.Play("AreaAttack");
                Blast.Play();

                FlameTho.value -= 0.09f;

                Blast.maxParticles = 1;

                


            }

         

            if (FlameTho.value == 0)
            {
                Blast.maxParticles = 0;
            }

            if ( FlameTho.value <= 0)
            {
              



                ArialBlast.enabled = false;
                
                StartCoroutine(WaitBlastThing());

              

            }
    




        }

      

        if (currentBaseState.nameHash == MagicMove)
        {
            if (Input.GetButtonDown("SquareButton"))
            {
                anim.Play("Idle");
                anim.SetBool("Standing Idle", false);
                ancienttxt.Stop();
            }

            if (Input.GetButton("R1"))
            {
                anim.SetBool("MagicStrike", true);
            }
            else
            {
                anim.SetBool("MagicStrike", false);
            }

            if (Input.GetButtonUp("R1"))
            {
                anim.Play("strike");
                SpellTho();

            }

            if (Input.GetButtonDown("Triangle"))
            {
                StartCoroutine(WaitAtFirst());
                anim.Play("AreaAttack");

                Blast.Play();
               
            }

            if (Input.GetKey("c"))
            {
                anim.SetBool("Shield", true);
                ShieldEffect.Emit(1);
            }
            if (Input.GetKeyUp("c"))
            {
                anim.SetBool("Shield", false);
                
            }



        }



    }

    float CalcBlast()
    {
        return ( BlastCalcLoad+BlastCalc );
    }

    IEnumerator WaitBlastThing()
    {
        yield return new WaitForSeconds(5);
        FlameTho.value = CalcBlast();
        BlastCalc -= Time.deltaTime;
    }

    void SpellTho()
    {


        RaycastHit Hit;

        if (Physics.Raycast(SpellCast.transform.position, SpellCast.transform.forward, out Hit, Range))
        {


            Debug.Log(Hit.transform.name);

         GameObject  blast = Instantiate(SpellThing, Hit.point, Quaternion.LookRotation(Hit.normal));
            Destroy(blast, 2f);

            
             var target = Hit.transform.GetComponent<AIHealth>();
               
            if (target != null)
            {
                AiHealth.value -= 0.01f;
            }
            
        }


    }



    IEnumerator WaitAtFirst()
    {
        if (ArialBlast.enabled == false)

        {
            yield return new WaitForSeconds(1.8f);

        }

        ArialBlast.enabled = true;

        if (ArialBlast.enabled == true)
        {
            yield return new WaitForSeconds(0.05f);

        }

        ArialBlast.enabled = false;

    }

   

    IEnumerator WaitForBlast()
    {
        yield return new WaitForSeconds(5f);

    }

}




















 


    
           
        
       
 

