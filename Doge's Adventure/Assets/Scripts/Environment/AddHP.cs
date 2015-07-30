using UnityEngine;
using System.Collections;

public class AddHP : MonoBehaviour {

	public float timeBetweenHealings = 0.5f;
	public int deltaHP = 2;

	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= timeBetweenHealings && playerInRange)
		{
			if(playerHealth.currentHealth < 100)
			{
				playerHealth.currentHealth += deltaHP;
				playerHealth.healthSlider.value = playerHealth.currentHealth;
				//playerHealth.TakeDamage (-deltaHP);
			}
			timer = 0f;
		}
	}
}
