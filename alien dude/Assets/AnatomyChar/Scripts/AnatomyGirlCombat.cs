﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyGirlCombat : MonoBehaviour {

    private Animator anim;
    public Collider WeaponCol;

    public GameObject EffectToSpawn;
    public Transform FirePoint;

    public bool Hit;
    public bool Power;

    private AnimatorStateInfo currentBaseState;
    private AnimatorStateInfo UnsheathState;

    static int Move = Animator.StringToHash("Base Layer.Locomotion");
    static int unsheath = Animator.StringToHash("unsheath.unsheath");
    static int Swing1 = Animator.StringToHash("unsheath.Swing1");
    static int Swing2 = Animator.StringToHash("unsheath.Swing2");
    static int Combat = Animator.StringToHash("unsheath.Combat");
    static int Fight = Animator.StringToHash("unsheath.Fight");

    // Use this for initialization
    void Start ()
    {
        anim = this.GetComponent<Animator>();
        WeaponCol.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        AnatomyCombat();

        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        UnsheathState = anim.GetCurrentAnimatorStateInfo(1);

        if (Hit == true)
        {
            WeaponCol.enabled = true;
        }
        else
        {
            WeaponCol.enabled = false;
        }
       
    }

    void AnatomyCombat()
    {

       var Dash =  GetComponent<AnatomyMovement>();

     
    
    

        if ( UnsheathState.nameHash == Fight && Input.GetButton("SquareButton"))
        {
           
            anim.SetBool("Combo1", true);
            

        }
        else
        {
           
            anim.SetBool("Combo1", false);
        }

        if (UnsheathState.nameHash == Swing1 && Input.GetButton("SquareButton"))
        {
           
            anim.SetBool("Combo2", true);
            anim.SetBool("Combo1", false);
        }
        else
        {
           
            anim.SetBool("Combo2", false);
        }

        if (UnsheathState.nameHash == Swing2 && Input.GetButton("SquareButton"))
        {
           
            anim.SetBool("Combo3", true);
            anim.SetBool("Combo2", false);
        }
        else
        {
            
            anim.SetBool("Combo3", false);
        }

        if (Input.GetKeyDown("m"))
        {
            anim.SetTrigger("PowerStrike");
        }


    }

    void WeaponHit()
    {
        Hit = true;
    }

    void Weapon_Not_Hit()
    {
        Hit = false;
    }

    void IsPower()
    {
        Power = true;

        GameObject vfx;

        vfx = Instantiate(EffectToSpawn, FirePoint.transform.position, Quaternion.identity);
    }

}
