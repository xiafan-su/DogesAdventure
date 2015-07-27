using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	Animator anim;
	public EnemyManager manager;
	public PlayerHealth health;

    public static int score;
	Text text;
	void Awake () {
		anim = GetComponent<Animator>();
		score = 0;
		text = GetComponent <Text> ();
	}

	
	void Update ()
	{
		if (manager.enemyCount == 0 && manager.final) {
			health.Win();
			anim.SetTrigger("Win");
		}
		if (text!=null)
		text.text = "Score: " + score;
		//if (!isTrigger) {
		//	anim.SetTrigger("Win");
		//	isTrigger = true;
		//	Debug.Log("Win");
		//}

	}
}
