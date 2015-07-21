using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemyBunny;
	public GameObject enemyBear;
	public GameObject enemyEphant;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public WavesManager manager;
	public int enemyCount;


    void Start ()
    {
		enemyCount = 0;
		generateEnemy (manager.waves);
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

	void Update() {
		if (enemyCount == 0 && manager.waves < 5) {
			manager.addWave();
			generateEnemy(manager.waves);
		}

	}

	public void generateEnemy(int wave)
	{
		for (int i = 0; i < wave; i++) {
			Invoke ("Spawn", 0);
		}
	
	}

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (enemyBunny, spawnPoints[0].position, spawnPoints[0].rotation);
		enemyCount++;
		Instantiate (enemyBear, spawnPoints [1].position, spawnPoints [1].rotation);
		enemyCount++;
		Instantiate (enemyEphant, spawnPoints [2].position, spawnPoints [2].rotation);
		enemyCount++;
    }
}
