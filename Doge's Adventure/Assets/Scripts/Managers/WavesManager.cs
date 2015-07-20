using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WavesManager : MonoBehaviour {
	
	public int waves;
	
	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
		waves = 1;
	}
	
	public void addWave() {
		if(waves < 5)
			waves++;
	}
	
	void Update ()
	{
		text.text = "Waves: " + waves + "/5";
	}
}
