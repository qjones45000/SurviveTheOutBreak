using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour{

    public Camera cam;
    public float MaxLength;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    public Texture2D crosshair;

    public Vector3 aimPivotOffset = new Vector3(0.5f, 1.2f, 0f);         // Offset to repoint the camera when aiming.
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(cam != null)
        {
            RaycastHit Hit;
            var mousepos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousepos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out Hit, MaxLength))
            {
                RotateToMouseDirection(gameObject, Hit.point); 
            }
            else
            {
                var pos = rayMouse.GetPoint(MaxLength);
                RotateToMouseDirection(gameObject, pos);
            }
           

        }
		
	}

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);  
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }


   

}
