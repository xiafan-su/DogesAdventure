using UnityEngine;
using System.Collections;

public class MouseAimCamera : MonoBehaviour {
	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;
	//float horizontal;
	//float lastHor;

	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
		// = Input.GetAxis("Mouse X");
		//lastHor = horizontal;
	}
	
	// Update is called once per frame
	void Update () {
		//horizontal = Input.GetAxis("Mouse X");
	}

	void LateUpdate () {
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		//float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
		//horizontal = (Input.GetAxis("Mouse X") - lastHor) * rotateSpeed ;
		//lastHor = horizontal;
		target.transform.Rotate(0, horizontal, 0);
		Vector3 lookAt = target.transform.position;
		//lookAt.y = target.transform.position.y + vertical;
		lookAt.y = target.transform.position.y + 3.5f;
		//cam.Rotate(0, 0, 45);
		
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);

		transform.LookAt(lookAt);
		//transform.LookAt(target.transform);
	}
}
