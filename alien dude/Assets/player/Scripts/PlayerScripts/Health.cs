using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float currenthealth = 0;
    public float Max_health = 100f;
 

    private Animator anim;


	public Slider healthbar;




	void Start ()
	{
		currenthealth = Max_health;
        healthbar.value = calc_health();
        anim = GetComponent<Animator>();
      
	}

    private void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            Damagedelt(10);
        }
    }



    float calc_health()
	{
		return currenthealth / Max_health;
	}


	



	public void Damagedelt (float damage)
	{
        

		currenthealth -= damage;

        healthbar.value = calc_health();

		if (currenthealth <= 0) 
		
		Die ();

        
		
	}



		void Die ()
		{
			currenthealth = 0;
        Max_health = 0;
			Debug.Log("you died");

         anim.Play("Death");
		}

    void OnCollisionEnter(Collision collision)
    {
        
       
            if (collision.gameObject.tag == "Hand")
            {
                Damagedelt(6);
                Debug.Log("you have been hit");
                calc_health();
            }

            healthbar.value = calc_health();
        

        
        }
    }
        
    


