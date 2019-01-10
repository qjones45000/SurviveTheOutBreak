using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour {

    public Collider MainCol;
    public Collider[] AllCol;
    public Rigidbody[] AllRigid;

    private void Awake()
    {
        MainCol = GetComponent<Collider>();
        AllCol = GetComponentsInChildren<Collider>(true);
    
        DoRagdoll(false);
    }

    void DoRagdoll(bool isRagdoll)
    {
        foreach (var col in AllCol)
            col.enabled = isRagdoll;
        MainCol.enabled = !isRagdoll;
        GetComponent<Rigidbody>().useGravity = !isRagdoll;
        GetComponent<Animator>().enabled = !isRagdoll;

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
