using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnatomyDash : MonoBehaviour {

    public BoxCollider TeleStart;
    public GameObject Player;
    public Transform TeleportTarget;
    public ParticleSystem TeleEffect;
    public ParticleSystem TeleBlast;

    public Slider Dash;

    // Use this for initialization
    void Start ()
    {
        TeleStart.enabled = false;
        TeleStart.isTrigger = false;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Circle"))
        {
            TeleStart.enabled = true;
            TeleStart.isTrigger = true;
            TeleBlast.Play();
            TeleEffect.Play();

            Dash.value -= 0.02f;
        }
        if (Input.GetButtonUp("Circle") || Dash.value == 0)
        {
            TeleStart.enabled = false;
            TeleStart.isTrigger = false;
        }

        if(Dash.value >= 0)
        {
            StartCoroutine(DashWait());
        }

    }

    IEnumerator DashWait()
    {
        
            yield return new WaitForSeconds(3);
            Dash.value += 0.001f;
        
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dash")
        {
            Player.transform.position = TeleportTarget.transform.position;
        }
      
    }
}
