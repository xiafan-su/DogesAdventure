using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	Animator anim;
	public EnemyManager manager;
	public PlayerHealth health;
	public HighScoreManager highscore;
    public static int score;
	bool pushed;
	float time;
	Text text;
	void Awake () {
		anim = GetComponent<Animator>();
		score = 0;
		text = GetComponent <Text> ();
		time=0;
		pushed = false;
	}

	
	void Update ()
	{
		if (manager.enemyCount == 0 && manager.final) {
			health.Win();
			anim.SetTrigger("Win");
			if (!pushed){
				highscore.addscores(score);
				pushed=true;
			}
			time += Time.deltaTime;
			if (time >4){
				Application.LoadLevel (2);
			}
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
