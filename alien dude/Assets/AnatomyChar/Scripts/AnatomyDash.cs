using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyDash : MonoBehaviour {

    public BoxCollider TeleStart;
    public GameObject Player;
    public Transform TeleportTarget;
    public ParticleSystem TeleEffect;
    public ParticleSystem TeleBlast;

    // Use this for initialization
    void Start ()
    {
        TeleStart.enabled = false;
        TeleStart.isTrigger = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Circle"))
        {
            TeleStart.enabled = true;
            TeleStart.isTrigger = true;
            TeleBlast.Play();
            TeleEffect.Play();
        }
        if (Input.GetButtonUp("Circle"))
        {
            TeleStart.enabled = false;
            TeleStart.isTrigger = false;
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = TeleportTarget.transform.position;
    }
}
