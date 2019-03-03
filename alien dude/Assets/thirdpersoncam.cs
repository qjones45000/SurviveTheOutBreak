using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersoncam : MonoBehaviour {

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform LookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float Currentx = 0.0f;
    private float Currenty = 0.0f;
  

	// Use this for initialization
	void Start () {

        camTransform = transform;
        cam = Camera.main;

		
	}

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(Currenty, Currentx, 0);
        camTransform.position = LookAt.position + rotation * dir;
        camTransform.LookAt(LookAt.position);
    }

    // Update is called once per frame
    void Update ()
    {

        Currentx += Input.GetAxis("LeftJoystickHorizontal");
        Currenty += Input.GetAxis("LeftJoystickVertical");

        Currenty = Mathf.Clamp(Currenty,Y_ANGLE_MIN, Y_ANGLE_MAX);
	}
}
