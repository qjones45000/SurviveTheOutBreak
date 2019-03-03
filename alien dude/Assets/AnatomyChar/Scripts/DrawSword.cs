using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSword : MonoBehaviour {

    public Transform Sword, Sword_unep, Sword_ep;
    public bool Sword_is_equipped;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Triangle"))
            anim.SetTrigger("Sword i");

     if (Sword_is_equipped)
        {
            Sword.position = Sword_ep.position;
            Sword.rotation = Sword_ep.rotation;
        }
        else
        {
            Sword.position = Sword_unep.position;
            Sword.rotation = Sword_unep.rotation;
        }
      

        

    }

    void Sword_equip()
    {
        Sword_is_equipped = true;
        
    }
    void Sword_Unequipped()
    {
        Sword_is_equipped = false;
       
    }
}
