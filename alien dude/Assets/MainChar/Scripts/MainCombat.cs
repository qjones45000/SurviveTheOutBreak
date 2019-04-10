using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCombat : MonoBehaviour {

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
    private AnimatorStateInfo CombatState;


    static int unsheath = Animator.StringToHash("Combat.Withdrawing Sword");
    static int Swing1 = Animator.StringToHash("Combat.Swing1");
    static int Swing2 = Animator.StringToHash("Combat.Combo2");
    static int Combat = Animator.StringToHash("Combat.Combat");
    static int Fight = Animator.StringToHash("Combat.Fight");

    // Use this for initialization
    void Start()
    {
        anim = this.GetComponent<Animator>();
        WeaponCol.enabled = false;

    }

    private void FixedUpdate()
    {
        var powerBar = GetComponent<AnatomyMovement>().DashBar;

        MainCharCombat();

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
    void Update()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        CombatState = anim.GetCurrentAnimatorStateInfo(1);

        var PowerEnd = GetComponent<AnatomyMovement>().DashBar;




    



       if (Hit == true)
        {
            WeaponCol.enabled = true;
        }
        else
        {
            WeaponCol.enabled = false;
        }

    }

    void MainCharCombat()
    {
        var PowerEnder = GetComponent<AnatomyMovement>().DashBar;

        if (PowerEnder.value <= 0)
        {
            PowerStop = false;
        }
        if (PowerEnder.value >= 0.23f)
        {
            PowerStop = true;
        }

        if (CombatState.nameHash == Fight)
        {
            Debug.Log("In the assigned state");
        }


        if (CombatState.nameHash == Fight && Input.GetButtonDown("R1"))
        {

            anim.SetBool("Combo1", true);
            Debug.Log("Recieved");

        }
        else
        {

            anim.SetBool("Combo1", false);
        }

        if (CombatState.nameHash == Swing1 && Input.GetButton("R1"))
        {

            anim.SetBool("Combo2", true);
            anim.SetBool("Combo1", false);
        }
        else
        {

            anim.SetBool("Combo2", false);
        }

        if (CombatState.nameHash == Swing2 && Input.GetButton("R1"))
        {

            anim.SetBool("Combo3", true);
            anim.SetBool("Combo2", false);
        }
        else
        {

            anim.SetBool("Combo3", false);
        }

        if (PowerStop == true)
        {
            if (Input.GetButtonDown("L1"))
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
