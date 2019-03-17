using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCompanion : MonoBehaviour {

    private Animator anim;
    
     public Transform Player;

    public GameObject[] Enemy;

    public ParticleSystem Fire;

    public Collider Enemycol;

    public float ViewDistance = 10f;

    public float fov = 120f;

    private bool FireAct;

    public bool seen;

    public float Distance;

    private AnimatorStateInfo currentBaseState;

    static int NoBlast = Animator.StringToHash("Base Layer.DummyRun");

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        if (FireAct == true)
        {
            Fire.Emit(1);
        }

        if (FireAct == false)
        {
            Fire.Emit(0);
        }

        if (seen == true)
        {
            Vector3 direction = Player.position - this.transform.position;
            float angle = Vector3.Angle(direction, this.transform.forward);
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);







            if (direction.magnitude < 15 && direction.magnitude > 0.96f)
            {
                this.transform.Translate(0, 0, 0.1f);

                anim.SetBool("DummyRun", true);
                anim.SetBool("DummyIdle", false);


            }

            if (direction.magnitude <= 1f)
            {
                anim.SetBool("DummyRun", false);

                anim.SetBool("DummyIdle", true);


            }

          
     
            
        }

        

        if (Enemy != null)
        {
            DetectDist();
        }

    
        if (Input.GetKeyDown("c"))
        {
            seen = true;
        }

      
     


    }

   void DetectDist()
    {

        

       
            foreach (GameObject Guys in Enemy)
            {
                Enemy = GameObject.FindGameObjectsWithTag("Enemy");

                Distance = Vector3.Distance(this.transform.position, Guys.transform.position);

                if (Distance <= 7)
                {
                    seen = false;

                    Vector3 direction = Guys.transform.position - this.transform.position;
                    float angle = Vector3.Angle(direction, this.transform.forward);
                    direction.y = 0;
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                    this.transform.Translate(0, 0, 0.1f);

                    anim.SetBool("DummyRun", true);
                    anim.SetBool("DummyIdle", false);
                    anim.SetBool("MagicBlast", false);
                }

                if (Distance < 4 && Distance > 2)
                {
                    Vector3 direction = Guys.transform.position - this.transform.position;
                    float angle = Vector3.Angle(direction, this.transform.forward);
                    direction.y = 0;
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                    this.transform.Translate(0, 0, 0);

                    anim.SetBool("MagicBlast", true);
                    anim.SetBool("DummyRun", false);
                    anim.SetBool("DummyIdle", false);
                }


                if (Distance < 2)
                {
                    this.transform.Translate(0, 0, -0.1f);
                    anim.SetBool("DummyRun", false);
                }

                if (currentBaseState.nameHash == NoBlast)
                {
                    Is_Not_Fire();
                }




            }


            if (Distance > 7)
            {
                seen = true;
            }








    }

    void IsFire()
    {
        FireAct = true;
    }

    void Is_Not_Fire()
    {
        FireAct = false;
    }

}

