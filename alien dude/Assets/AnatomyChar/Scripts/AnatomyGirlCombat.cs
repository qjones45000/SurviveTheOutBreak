using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnatomyGirlCombat : MonoBehaviour {

    private Animator anim;
    public Collider WeaponCol;

    public GameObject EffectToSpawn;
    public Transform SpawnLoca;
   

    public ParticleSystem Blaster;
    public ParticleSystem afterBlast;

    public bool Hit;
    public bool Power;
    public bool PowerStop;

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

    private void FixedUpdate()
    {
        var powerBar = GetComponent<AnatomyMovement>().DashBar;

        if (Power == true)
        {


            GameObject vfx;

            vfx = Instantiate(EffectToSpawn, SpawnLoca.transform.position, Quaternion.identity);

            Destroy(vfx, 3);

            Blaster.Play();
            Debug.Log("Blasting");
            

        }
    }

    // Update is called once per frame
    void Update ()
    {

        var PowerEnd = GetComponent<AnatomyMovement>().DashBar;


   

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

       var PowerEnder =  GetComponent<AnatomyMovement>().DashBar;

        if (PowerEnder.value <= 0)
        {
            PowerStop = false;
        }
        if (PowerEnder.value >= 0.23f)
        {
            PowerStop = true;
        }
     
    
    

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

        if(PowerStop == true)
        {
            if (Input.GetButtonDown("R1"))
            {
                anim.SetBool("PowerStrike", true);

               
            }
            else
            {
                anim.SetBool("PowerStrike", false);
            }
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
        var PowerEnder = GetComponent<AnatomyMovement>().DashBar;
        Power = true;
        PowerEnder.value -= 0.1f;
    }

    void Is_Not_Power()
    {
        Power = false;
    }



}
