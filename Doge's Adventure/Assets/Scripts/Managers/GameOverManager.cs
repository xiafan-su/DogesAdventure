using UnityEngine;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

	public HighScoreManager highscore;
	public Sprite SadSprite;
	public Image DogeHead;
    Animator anim;
	float time;
	bool pushed;
	Vector3[] size;
	int status;
    void Awake()
    {
        anim = GetComponent<Animator>();
		time = 0;
		pushed = false;
		status = 0;
		size =new Vector3[7];
		size[0] = new Vector3 (2,2,2);
		size[1] = new Vector3 (4,4,4);
		size[2] = new Vector3 (6,6,6);
		//size[3] = new Vector3 (3.5f,3.5f,3.5f);
		//size[4] = new Vector3 (4,4,4);
		//size[5] = new Vector3 (4.5f,4.5f,4.5f);
		//size[6] = new Vector3 (5,5,5);
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
			if (!pushed){
				highscore.addscores(ScoreManager.score);
				pushed=true;
				DogeHead.sprite = SadSprite;
				//DogeHead.transform.localScale =size[0];
				//DogeHead.transform.position = new Vector3(5,-5,0);
			}
			if (time>3)
				DogeHead.transform.localScale = size[(status++)%size.Length];

            anim.SetTrigger("GameOver");
			time += Time.deltaTime;
			if (time >5){
				Application.LoadLevel (2);
			}
        }
    }
}
