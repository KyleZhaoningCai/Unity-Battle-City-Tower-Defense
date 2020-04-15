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
    public GameObject[] playerTankPlaceholders;
    public bool[] hasTank;
    public GameObject playerTank;
    public GameObject playerTankCannon;
    public GameObject playerTankFast;
    public GameObject playerTankHeavy;
    public GameObject wall;
    public GameObject uiSystemMessage;
    public GameObject uiMessage;
    public int tankToPlace;

    private int enemiesPerWave;
    private int waveNumber;
    private float originalWaveInterval;
    private float originalSpawnInterval;
    private int spawnIndex;
    private float messageDuration;
    private float originalMessageDuration;
    private string cheatString;

    // Start is called before the first frame update
    void Start()
    {
        hasWall = new bool[5];
        hasTank = new bool[30];
        for (int i = 0; i < hasTank.Length; i++)
        {
            if (i < hasWall.Length)
            {
                hasWall[i] = false;
            }
            hasTank[i] = false;
        }
        enemiesPerWave = 7;
        waveNumber = 0;
        originalWaveInterval = waveInterval;
        originalSpawnInterval = spawnInterval;
        spawnInterval = 0;
        spawnIndex = 0;
        FindObjectOfType<Wall>().GetComponent<Wall>().SetHp(baseWallHp);
        messageDuration = 3f;
        originalMessageDuration = messageDuration;
        cheatString = "";
    }

    // Update is called once per frame
    void Update()
    {
        waveInterval -= Time.deltaTime;
        if (waveInterval <= 0)
        {
            uiSystemMessage.GetComponent<Text>().text = "";
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

    public void pushToCheatString(string button)
    { 
        cheatString += button;
        if (cheatString.Length > 7)
        {
            cheatString = cheatString.Substring(1);
        }
        if (cheatString == "WWHHWHW")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy>().ReduceHp(9999);
            }
        }
    }
}
