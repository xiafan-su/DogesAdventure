using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.

	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	Collider playerCollide;
	bool grounded = true;				// Whether player is on the ground
	public float jumpPower = 500;			// The jumpPower
	public bool running = false;
	
	void Awake ()
	{
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");
		
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		playerCollide = GetComponent <CapsuleCollider> ();
	}
	
	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift))
			running = true;
		if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift))
			running = false;

		// Move the player around the scene.
		Move (h, v);
		
		// Turn the player to face the mouse cursor.
		//Turning ();
		
		// Animate the player.
		Animating (h, v);

		Jump ();

		HighJump ();
	}
	
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		movement.Set (h, 0f, v);
		movement = transform.TransformDirection(movement);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		float tmpSpeed = speed;
		if (running)
			tmpSpeed = speed * 3;
		movement = movement.normalized * tmpSpeed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}
	
	void Turning ()
	{/*
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			playerToMouse.y = 0f;
			
			// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			
			// Set the player's rotation to this new rotation.
			playerRigidbody.MoveRotation (newRotation);
		}*/
	}
	
	void Jump ()
	{
		if (playerCollide.isTrigger) {
			grounded = true;
		}
		if (Input.GetKeyDown ("space") && grounded == true) {
			//if (Input.GetButtonDown("Jump") && grounded == true) {
			//playerRigidbody.AddForce (transform.up * jumpPower);
			playerRigidbody.AddForce (transform.up * jumpPower);
			//playerRigidbody.MovePosition (transform.up * jumpPower);
			grounded = false;
			playerCollide.isTrigger = true;
		}
	}

	void HighJump ()
	{
		if (playerCollide.isTrigger) {
			grounded = true;

		}
		if (Input.GetKeyDown ("f") && grounded == true) {
			//if (Input.GetButtonDown("Jump") && grounded == true) {
			//playerRigidbody.AddForce (transform.up * jumpPower);
			playerRigidbody.AddForce (transform.up * 10000);
			//playerRigidbody.MovePosition (transform.up * jumpPower);
			grounded = false;
			playerCollide.isTrigger = true;
		}


	}

	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}
}