using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    // Global Variables
    public int baseWallHp;
    public string gameState;
    public GameObject[] waypoints;
    public GameObject[] finalWaypoints;
    public float waveInterval;
    public float spawnInterval;
    public GameObject[] enemyTypes;
    public GameObject spawnLocation;
    public GameObject baseObject;
    public bool[] hasWall;
    public GameObject[] wallPlaceholders;

    public GameObject[] tankPlaceholders;
    public GameObject player;
    public GameObject uiSystemMessage;
    public GameObject uiMessage;

    private int enemiesPerWave;
    private int waveNumber;
    private float originalWaveInterval;
    private float originalSpawnInterval;
    private int spawnIndex;
    private float messageDuration;
    private float originalMessageDuration;

    // Start is called before the first frame update
    void Start()
    {
        hasWall = new bool[] { false, false, false, false, false };

        enemiesPerWave = 7;
        waveNumber = 0;
        originalWaveInterval = waveInterval;
        originalSpawnInterval = spawnInterval;
        spawnInterval = 0;
        spawnIndex = 0;
        FindObjectOfType<Wall>().GetComponent<Wall>().SetHp(baseWallHp);
        messageDuration = 3f;
        originalMessageDuration = messageDuration;
    }

    // Update is called once per frame
    void Update()
    {
        waveInterval -= Time.deltaTime;
        if (waveInterval <= 0)
        {
            uiSystemMessage.GetComponent<Text>().text = "";
            if (player.GetComponent<Player>().GetTask() == "PlaceWall")
            {
                player.GetComponent<Player>().SetTask("Idle", new Vector2(0, 0));
            }
            for (int i = 0; i < wallPlaceholders.Length; i++)
            {
                wallPlaceholders[i].SetActive(false);
            }
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0 && spawnIndex < enemiesPerWave && waveNumber < enemyTypes.Length)
            {
                if (waveNumber == enemyTypes.Length - 1)
                {
                    spawnIndex = enemiesPerWave - 1;
                }
                GameObject enemy = Instantiate(enemyTypes[waveNumber], new Vector2(spawnLocation.transform.position.x, spawnLocation.transform.position.y), Quaternion.identity);
                enemy.GetComponent<Enemy>().SetFinalWaypoint(finalWaypoints[spawnIndex]);
                spawnIndex++;
                spawnInterval = originalSpawnInterval;
            }
            if (GameObject.FindWithTag("Enemy") == null && spawnIndex == enemiesPerWave)
            {
                spawnInterval = 0;
                spawnIndex = 0;
                waveInterval = originalWaveInterval;
                waveNumber++;
                if (waveNumber == enemyTypes.Length)
                {
                    gameState = "victory";
                }
            }
        }
        else
        {
            uiSystemMessage.GetComponent<Text>().text = "Next Wave In " + Mathf.RoundToInt(waveInterval) + " Seconds";
        }
        messageDuration -= Time.deltaTime;
        if (messageDuration <= 0)
        {
            uiMessage.GetComponent<Text>().text = "";
        }

    }

    public void showMessage(string message)
    {
        uiMessage.GetComponent<Text>().text = message;
        messageDuration = originalMessageDuration;
    }
}
