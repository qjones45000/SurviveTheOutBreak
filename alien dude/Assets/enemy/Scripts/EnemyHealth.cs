using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public float Health_Min = 0;
    public float Health_Max = 100f;

    private Animator anim;

    public Collider[] Damager;


 
    public GameObject[] Enemy;


    // Use this for initialization
    void Start ()
    {
        Health_Min = Health_Max;

        RigidBodyState(true);
        Colliderstate(false);

        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Health_Min <= 0)
        {
            Debug.Log("EnemeyDead");
            GetComponent<Animator>().enabled = false;
            RigidBodyState(false);
            Colliderstate(true);
           
            
        }

    }

    void RigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }

    void Colliderstate(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider Collider in colliders)
        {
            Collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

        foreach (Collider Damager in Damager)
        {
            Damager.enabled = true;
        }


    }



    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown("j"))
        {
            Debug.Log("getting hit");
            DamageEnemy(40);
        }

    }

    float Calc()
    {
        return Health_Min / Health_Max;
    }

    void DamageEnemy (float Damage)
    {
        Health_Min -= Damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("ParticleFuck"))
        {
            DamageEnemy(30);
            Debug.Log("Hit");
            Calc();
            anim.SetTrigger("Move");
          
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == ("FireDamage"))
        {
            DamageEnemy(30);
            Debug.Log("Hes on fire");
            Calc();
        }
    }

    private void OnParticleTrigger()
    {
        DamageEnemy(30);
        Debug.Log("Fired");
        Calc();
    }
}
