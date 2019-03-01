using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePort : MonoBehaviour {

    public Transform TeleportTarget;
    public GameObject Player;
    public BoxCollider TeleTriggr;

    public ParticleSystem TeleEffect;
    public ParticleSystem TeleBlast;

    public GameObject boxInstan;
    public Transform BoxLoc;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = TeleportTarget.transform.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown("t") || Input.GetButtonDown("Circle"))
        {
            GameObject InstanThing;
            InstanThing = Instantiate(boxInstan, BoxLoc.transform.position, BoxLoc.transform.rotation);
              TeleBlast.Play();
            TeleEffect.Play();
          
        }

    }

}
