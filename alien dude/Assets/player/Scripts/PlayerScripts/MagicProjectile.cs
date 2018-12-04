using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicProjectile : MonoBehaviour {

    public GameObject spawn;
    private GameObject spell;
    public List<GameObject> vfx = new List<GameObject>();


    // Use this for initialization
    void Start()
    {

        spell = vfx[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("l"))
        {
            spawnfx();
        }
    }

    void spawnfx()
    {
        GameObject vfx;
        if (spawn != null)
        {
            vfx = Instantiate(spell, spawn.transform.position, Quaternion.identity);
        }
    }
}

