using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

	public HighScoreManager highscore;
    Animator anim;
	float time;
	bool pushed;
    void Awake()
    {
        anim = GetComponent<Animator>();
		time = 0;
		pushed = false;
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
			if (!pushed){
				highscore.addscores(ScoreManager.score);
				pushed=true;
			}
            anim.SetTrigger("GameOver");
			time += Time.deltaTime;
			if (time >4){
				Application.LoadLevel (2);
			}
        }
    }
}
