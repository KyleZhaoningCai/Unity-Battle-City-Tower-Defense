using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    // Global Variables
    public int baseWallHp;
    public string gameState;
    public GameObject[] waypoints;
    public GameObject[] finalWaypoints;
    public float waveInterval;
    public float spawnInterval;
    public GameObject[] EnemyTypes;
    public GameObject spawnLocation;
    public GameObject baseObject;

    private int enemiesPerWave;
    private int waveNumber;
    private float originalWaveInterval;
    private float originalSpawnInterval;
    private int spawnIndex;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemiesPerWave = 7;
        waveNumber = 0;
        originalWaveInterval = waveInterval;
        originalSpawnInterval = spawnInterval;
        spawnInterval = 0;
        spawnIndex = 0;
        FindObjectOfType<Wall>().GetComponent<Wall>().SetHp(baseWallHp);
    }

    // Update is called once per frame
    void Update()
    {
        waveInterval -= Time.deltaTime;
        if (waveInterval <= 0)
        {
            enemies = new GameObject [enemiesPerWave];
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0 && spawnIndex < enemiesPerWave)
            {
                GameObject enemy = Instantiate(EnemyTypes[waveNumber], new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y), Quaternion.identity);
                enemy.GetComponent<Enemy>().SetFinalWaypoint(finalWaypoints[spawnIndex]);
                enemies[spawnIndex] = enemy;
                spawnIndex++;
                spawnInterval = originalSpawnInterval;
            }
        }
    }
}
