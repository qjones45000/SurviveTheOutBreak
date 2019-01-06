using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour {

    public Slider AiHealth;
    public GameObject Alien;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AlienFuck")
        {
            AiHealth.value -= 1;
            Debug.Log("hit");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collided")
        {
            AiHealth.value -= 0.03f;
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

    private void OnParticleTrigger()
    {
        if (tag == "BlastFucked")
        {
            AiHealth.value -= 30;
            Debug.Log("Blast");
        }

       
    }
}
