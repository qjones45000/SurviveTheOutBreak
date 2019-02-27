using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour {

    public Slider AiHealth;
    public GameObject Alien;


    void Start()
    {
        RigidBodyState(true);
        Colliderstate(false);
    }

    private void FixedUpdate()
    {
        if (AiHealth.value == 0)
        {
            GetComponent<Animator>().enabled = false;
            RigidBodyState(false);
            Colliderstate(true);
        }
      


        
    }

   
 

    //Ragdoll

        void RigidBodyState (bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidBody in rigidbodies)
        {
            rigidBody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void Colliderstate (bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider Collider in colliders)
        {
            Collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }
    //


   // enemy Damage
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ParticleFuck")
        {
            AiHealth.value -= 1f;
            Debug.Log("particle hit");

          
        }
    }


    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "ParticleFuck")
        {
            AiHealth.value -= 0.01f;
            Debug.Log("particle hit");

          
         
        }

        if (other.tag == "BlastFucked")
        {
            AiHealth.value -= 0.02f;
            Debug.Log("Blast hit");
        }
        
    }
    //
    
}
