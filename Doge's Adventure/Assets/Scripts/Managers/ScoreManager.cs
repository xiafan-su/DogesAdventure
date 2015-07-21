using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	Animator anim;

    public static int score;
	bool isTrigger = false;

	void Awake () {
		anim = GetComponent<Animator>();
		score = 0;
	}

	
	void Update ()
	{
		if (!isTrigger) {
			anim.SetTrigger("Win");
			isTrigger = true;
			Debug.Log("Win");
		}

	}
}
