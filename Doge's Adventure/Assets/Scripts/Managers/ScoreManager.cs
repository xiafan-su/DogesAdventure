using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	Animator anim;
	public EnemyManager manager;
	public PlayerHealth health;

    public static int score;

	void Awake () {
		anim = GetComponent<Animator>();
		score = 0;
	}

	
	void Update ()
	{
		if (manager.enemyCount == 0 && manager.final) {
			health.Win();
			anim.SetTrigger("Win");
		}
		//if (!isTrigger) {
		//	anim.SetTrigger("Win");
		//	isTrigger = true;
		//	Debug.Log("Win");
		//}

	}
}
