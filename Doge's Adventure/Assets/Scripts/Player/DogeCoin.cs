using UnityEngine;
using System.Collections;

public class DogeCoin : MonoBehaviour {

	AudioSource playerAudio;
	GameObject player;
	public AudioClip coinClip;

	// Use this for initialization
	void Start () {

	}

	void Awake ()
	{
		//coinAudio = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
			transform.Rotate (new Vector3 (0, 160, 0) * Time.deltaTime);
		
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerAudio = player.GetComponent<AudioSource>();
			playerAudio.clip = coinClip;
			playerAudio.Play ();
			Destroy(this.gameObject);
		}
	}

	/*void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Player")
		{
			Destroy(this.gameObject);

			coinAudio.clip = coinClip;
			coinAudio.Play ();
		}
	}*/

}
