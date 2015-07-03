using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;

	void Awake ()
	{
		player = GameObject.Find("Player").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <NavMeshAgent> ();
	}

	void Update ()
	{
		if (nav != null)
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
				nav.SetDestination (player.position);
		} else {
			nav.enabled = false;
		}

	}
}
