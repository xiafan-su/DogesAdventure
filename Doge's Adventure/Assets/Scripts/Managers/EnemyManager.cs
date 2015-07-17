using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public ScoreManager manager;
	private float time = 0;


    void Start ()
    {
		generateEnemy (manager.waves);
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

	void Update() {

		/*while (manager.waves < 3) {
			generateEnemy(manager.waves);
			manager.waves++;
		}*/
		time += Time.deltaTime;
		if (time >= 10) {
			manager.addWave();
			generateEnemy (manager.waves);
			time = 0;
		}

	}

	public void generateEnemy(int wave)
	{
		for(int i = 0; i < wave; i++)
			Invoke ("Spawn", spawnTime);	
	}

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[0].position, spawnPoints[0].rotation);
    }
}
