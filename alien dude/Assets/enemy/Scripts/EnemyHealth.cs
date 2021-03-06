﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float Health_Min = 0;
    public float Health_Max = 100f;

    private Animator anim;

    public ParticleSystem Blood;

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

            Destroy(gameObject, 5f);

            
        }

    

    }

    private void OnDestroy()
    {
        Score.score++;
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
            Blood.Play();
          
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

        if (other.tag == ("BlastBack"))
        {

          
            DamageEnemy(10);
            Debug.Log("He got blasted");
            Calc();
            GetComponent<Animator>().enabled = false;
            RigidBodyState(false);
            Colliderstate(true);

            StartCoroutine(WaitToGetUp());

        



        }

             
    }

    

    private void OnParticleTrigger()
    {
        DamageEnemy(30);
        Debug.Log("Fired");
        Calc();
    }

    IEnumerator WaitToGetUp()
    {
        yield return new WaitForSeconds(5);

        if (Health_Min > 0)
        {

            anim.Play("GetUp");
            RigidBodyState(true);
            Colliderstate(false);
            GetComponent<Animator>().enabled = true;


        }
    }
}
