using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnatomyCam : MonoBehaviour {

    public float RotationSpeed;
    public Transform Target, Player;
    float mouseX, mouseY;

    
	// Use this for initialization
	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
	
	// Update is called once per frame
	void Update ()
    {
        CamControll();
		
	}

    void CamControll()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Player);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(mouseY, mouseX, 0);


    }
}
