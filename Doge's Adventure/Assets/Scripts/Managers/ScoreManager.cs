using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
	public int waves;

    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
		waves = 1;
    }

	public void addWave() {
		if(waves <=5)
			waves++;
	}

    void Update ()
    {
        text.text = "Waves: " + waves + "/5";
    }
}
