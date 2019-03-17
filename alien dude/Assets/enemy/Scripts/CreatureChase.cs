using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatureChase : MonoBehaviour {

    public Transform Player;
    public float ViewDistance = 10f;
    public float Wander = 3;
    private Vector3 WanderPoint;
    private bool isAware = false;
    private NavMeshAgent agent;
    public float fov = 120f;
    private Animator anim;



	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        WanderPoint = RandomWalk();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isAware)
        {
            agent.SetDestination(Player.position);
            Debug.Log("You are caught");
            
        }
        else
        {
            SearchForPlayer();
            wanderer();
            anim.SetBool("EnemyMove", true);
            anim.SetBool("EnemyIdle", false);
        }
	}

    void SearchForPlayer()
    {
        if (Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(Player.position)) < fov/2f)
        {
            if (Vector3.Distance(Player.position, this.transform.position) < ViewDistance)
            {
                RaycastHit hit;

                if (Physics.Linecast(this.transform.position, Player.position, out hit, -1))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                        Debug.Log("I see you");
                    }

                    
                }

            }
        }
    }

    public void wanderer()
    {
        if (Vector3.Distance(transform.position, WanderPoint) < 2)
        {
            WanderPoint = RandomWalk();
        }
        else
        {
            agent.SetDestination(WanderPoint);
        }
    }

    void OnAware()
    {
        isAware = true;
    }

    public Vector3 RandomWalk()
    {
        Vector3 RandomPoint = (Random.insideUnitSphere * Wander) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(RandomPoint, out navHit, Wander, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
}
