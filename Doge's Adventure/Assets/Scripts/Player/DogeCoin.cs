using UnityEngine;
using System.Collections;

public class DogeCoin : MonoBehaviour {

	//AudioSource coinAudio;
	//public AudioClip coinClip;

	// Use this for initialization
	void Start () {

	}

	void Awake ()
	{
		//coinAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
			transform.Rotate (new Vector3 (0, 160, 0) * Time.deltaTime);
		
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
