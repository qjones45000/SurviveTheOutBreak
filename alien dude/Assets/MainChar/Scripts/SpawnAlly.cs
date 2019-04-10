using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAlly : MonoBehaviour {

    public Transform AllyPos;
    public GameObject Companion;
    public bool SpawnAbility = true;
    public Slider SpawnBar;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject Ally;

  

        if(SpawnBar.value >= 1)
        {
          

            if (Input.GetButtonDown("R1"))
            {
                Ally = Instantiate(Companion, AllyPos.transform.position, AllyPos.transform.rotation) as GameObject;
               

                SpawnBar.value -= 1;
            }
        }
       
       
	}
}
