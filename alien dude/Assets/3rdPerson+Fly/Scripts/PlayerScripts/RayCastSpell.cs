using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSpell : MonoBehaviour {

    public float damage = 10f;
    public float Range = 100f;

    public Camera SpellCast;

    public GameObject SpellThing;

	// Use this for initialization


	void Start ()
    {
		
	}
	


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp("l"))
        {
            SpellTho();
        }

       
    
		
	}

  void SpellTho()
    {
        RaycastHit Hit; 

        if (Physics.Raycast (SpellCast.transform.position, SpellCast.transform.forward, out Hit, Range))
        {
            Debug.Log(Hit.transform.name);

            Instantiate(SpellThing, Hit.point, Quaternion.LookRotation(Hit.normal));
        }

        
    }


}
