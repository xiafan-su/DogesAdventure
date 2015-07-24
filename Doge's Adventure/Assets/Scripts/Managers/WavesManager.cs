using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WavesManager : MonoBehaviour {
	
	public int waves;
	
	Text text;
	public  int TOTALWAVES;
	void Awake () {
		TOTALWAVES = 5; 
		text = GetComponent <Text> ();
		waves = 1;
	}
	
	public void addWave() {
		if(waves < TOTALWAVES)
			waves++;
	}
	
	void Update ()
	{
		text.text = "Waves: " + waves + "/" + TOTALWAVES;
	}
}
