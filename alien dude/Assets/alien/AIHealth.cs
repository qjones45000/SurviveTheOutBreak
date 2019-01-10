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

    

 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collided")
        {
            AiHealth.value -= 0.1f;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "ParticleFuck")
        {
            AiHealth.value -= 0.01f;
            Debug.Log("particle hit");

            if (AiHealth.value <= 0)
            {
                Destroy(Alien, 0.1f);
            }
         
        }

        if (other.tag == "BlastFucked")
        {
            AiHealth.value -= 0.02f;
            Debug.Log("Blast hit");
        }
        
    }

    
}
