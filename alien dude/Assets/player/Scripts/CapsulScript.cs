using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulScript : MonoBehaviour {

    public CapsuleCollider Blast;

	// Use this for initialization
	void Start ()
    {

        Blast.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update ()

    {

        if (Input.GetKeyDown("m"))
        {
            StartCoroutine(WaitAtFirst());
        }
        
        
            
        
		
	}


    IEnumerator WaitAtFirst()
    {
     if (Blast.enabled == false)

        {
            yield return new WaitForSeconds(1.8f);
            
        }

        Blast.enabled = true;

        if (Blast.enabled == true)
        {
            yield return new WaitForSeconds(0.05f);
            
        }

        Blast.enabled = false;
        
    }

}



  


