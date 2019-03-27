using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    public Transform Player;
    public Transform Enemy;

    public Slider energyDrain;

    public ParticleSystem Drain;

    public float ViewDistance = 10f;
    public float Wander = 3;
    private Vector3 WanderPoint;
    private bool isAware = false;
    private NavMeshAgent agent;
    public float fov = 120f;

    static Animator AlienAnim;
    private Animator anim;

    public bool dead;

    public bool enemy;

    static AnimatorStateInfo CurrentBaseState;

    static int Attack = Animator.StringToHash("BaseLayer.Attacking");


	// Use this for initialization
	void Start ()
    {
        AlienAnim = GetComponent<Animator>();

        anim = this.GetComponent<Animator>();

       
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemy == true)
        {
            CurrentBaseState = anim.GetCurrentAnimatorStateInfo(0);

            Vector3 direction = Player.position - this.transform.position;
            float angle = Vector3.Angle(direction, this.transform.forward);

        
            if (Vector3.Distance(Player.position, this.transform.position) < 20 && angle < 90)
            {


                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("Idle", false);

                if (direction.magnitude < 15 && direction.magnitude > 0.96f)
                {

                    this.transform.Translate(0, 0, 0.1f);

                    anim.SetBool("Walking", true);
                    anim.SetBool("Attacking", false);

                }

                if (direction.magnitude <= 0.96f)
                {

                    this.transform.Translate(0, 0, 0);

                    anim.SetBool("Attacking", true);
                    anim.SetBool("Walking", false);



                }
            }

            else
            {
                anim.SetBool("Idle", true);
                anim.SetBool("Walking", false);
                anim.SetBool("Attacking", false);
            }

        }
        else if (enemy == false)
        {
            var Death = GetComponent<EnemyHealth>().Health_Min;

          


            Vector3 direction = Player.position - this.transform.position;
                float angle = Vector3.Angle(direction, this.transform.forward);
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

           

                if (Vector3.Distance(Player.position, this.transform.position) < 20 && angle < 90)
                {
                

                    anim.SetBool("EnemyIdle", false);

                    if (direction.magnitude < 15 && direction.magnitude > 0.96f)
                    {
                        this.transform.Translate(0, 0, 0.1f);

                        anim.SetBool("EnemyMove", true);
                        anim.SetBool("EnemyIdle", false);
                    anim.SetBool("Attack1", false);
                    
                    }

                    if (direction.magnitude <= 0.96f)
                    {

                    

                    anim.SetBool("EnemyMove", false);
                        anim.SetBool("Attack1", true);
                     anim.SetBool("EnemyIdle", false);

                        if(Death <= 0)
                    {
                        energyDrain.value -= 0.2f;

                        Drain.Emit(1);

                    }
           
                    
                    
                    }
             



                }
            else
            {

                
                anim.SetBool("EnemyIdle", true);
                anim.SetBool("EnemyMove", false);
                anim.SetBool("Attack1", false);
                


            }




        }
       
    

    }





}
