using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animations : MonoBehaviour {

   private Animator _anim;
    public float MaxSpeed = 50f;

	// Use this for initialization
	void Start ()
    {
        _anim = GetComponent<Animator>();	

	}
	
	// Update is called once per frame
	void Update ()
    {

        var x = Input.GetAxis("Vertical");
        var y = Input.GetAxis("Horizontal");
       

        Move(x, y);

      

	}

    public void Move(float x, float y)
    {
        _anim.SetFloat("Vy", y);
        _anim.SetFloat("Vx" , x);

        transform.position += Vector3.forward *MaxSpeed * x * Time.deltaTime;
        transform.position += Vector3.right * MaxSpeed * y * Time.deltaTime;
    }

}
