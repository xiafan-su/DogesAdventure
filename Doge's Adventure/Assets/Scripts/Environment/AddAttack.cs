using UnityEngine;
using System.Collections;

public class AddAttack : MonoBehaviour {
	
	public int coefficient = 2;
	public int enhangceTime = 15;

	GameObject gun;
	GameObject player;
	PlayerShooting playerShooting;
	bool playerIsStrong;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){

		gun = GameObject.FindGameObjectWithTag ("GunBarrelEnd");
		playerShooting = gun.GetComponent <PlayerShooting> ();

		playerIsStrong = false;
		playerInRange = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
			if (!playerIsStrong)
			{
				playerIsStrong = true;
				playerShooting.damagePerShot *= coefficient;
				print("Attack!!"+playerShooting.damagePerShot);
			}
			//print ("oo");
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			timer = enhangceTime;
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		
		if (playerIsStrong) {
			if (!playerInRange){
				if (timer > 0) timer -= Time.deltaTime;
				else {
					playerIsStrong = false;
					playerShooting.damagePerShot /= coefficient;
					print("Back to normal");
				}
			}
	
		}
	}
}
