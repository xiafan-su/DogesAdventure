using UnityEngine;
using System.Collections;

public class AddAttack : MonoBehaviour {
	
	public int coefficient = 2;
	public int enhangceTime = 15;

	GameObject gun;
	GameObject player;
	ParticleSystem bullet;
	LineRenderer bulletLine;

	PlayerShooting playerShooting;

	bool playerIsStrong;
	bool playerInRange;

	float timer;

	Color yellow;
	Color lineYellow;

	//ParticleSystem.Particle[] particles;

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){

		gun = GameObject.FindGameObjectWithTag ("GunBarrelEnd");
		playerShooting = gun.GetComponent <PlayerShooting> ();

		bullet = gun.GetComponent<ParticleSystem> ();
		yellow = bullet.startColor;
		bulletLine = gun.GetComponent<LineRenderer> ();
		lineYellow = bulletLine.material.GetColor ("_TintColor");

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

				bullet.startColor = Color.red;
				bulletLine.material.SetColor("_TintColor", Color.red);

				/*particles = new ParticleSystem.Particle[8];
				bullet.GetParticles(particles);

				print("len:"+bullet.particleCount);

				for (int i=0; i<particles.Length; i++){
					float LifePercentage = (particles[i].lifetime / particles[i].startLifetime);
					particles[i].color = Color.Lerp(Color.clear, Color.red, LifePercentage);
					particles[i].color = Color.red;

				}
				bullet.SetParticles(particles, particles.Length);*/

				//print("Attack!!"+playerShooting.damagePerShot);
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
					bullet.startColor = yellow;
					bulletLine.material.SetColor("_TintColor", lineYellow);

					print("Back to normal");
				}
			}
	
		}
	}
}
