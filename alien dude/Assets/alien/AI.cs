using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public Transform Player;
    static Animator AlienAnim;

    static AnimatorStateInfo CurrentBaseState;

    static int Attack = Animator.StringToHash("BaseLayer.Attacking");


	// Use this for initialization
	void Start ()
    {
        AlienAnim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        CurrentBaseState = AlienAnim.GetCurrentAnimatorStateInfo(0);

        Vector3 direction = Player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);


        if (Vector3.Distance(Player.position, this.transform.position) < 20 && angle < 90)
        {
            
      
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            AlienAnim.SetBool("Idle", false);

            if (direction.magnitude < 15)
            {
                
                this.transform.Translate(0, 0, 0.1f);
                
                AlienAnim.SetBool("Walking", true);
                AlienAnim.SetBool("Attacking", false);

            }

             if (direction.magnitude < 5)
            {

             

                AlienAnim.SetBool("Attacking", true);
                AlienAnim.SetBool("Walking", false);
               

            }
        }

        else
        {
            AlienAnim.SetBool("Idle", true);
            AlienAnim.SetBool("Walking", false);
            AlienAnim.SetBool("Attacking", false);
        }

        
		
	}
}
