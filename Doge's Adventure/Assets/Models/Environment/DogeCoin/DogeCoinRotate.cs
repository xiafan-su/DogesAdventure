using UnityEngine;
using System.Collections;

public class DogeCoinRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			transform.Rotate (new Vector3 (0, 160, 0) * Time.deltaTime);
		
	}
}
