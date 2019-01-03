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
            AiHealth.value -= 30;
            Debug.Log("hit");
        }
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "ParticleFuck")
        {
            AiHealth.value -= 30;
            Debug.Log("particle hit");
        }
        
    }
}
