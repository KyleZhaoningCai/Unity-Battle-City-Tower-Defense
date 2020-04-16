using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    // Global Variables
    public GameObject baseWall;
    public int baseWallHp;
    public int coins;
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
    public GameObject baseHpText;
    public GameObject coinText;
    public float coinBagSpawn;
    public GameObject coinBag;
    public float coinBagSpeed;
    public bool isHammering;
    public GameObject[] playerTanks;
    public GameObject explosion;
    public GameObject dontDestroyObject;

    private int enemiesPerWave;
    private int waveNumber;
    private float originalWaveInterval;
    private float originalSpawnInterval;
    private int spawnIndex;
    private float messageDuration;
    private float originalMessageDuration;
    private string cheatString;
    private float originalCoinBagSpawn;
    private GameObject movingCoinBag;
    private Vector2 movingCoinBagFrom;
    private Vector2 movingCoinBagTo;

    // Start is called before the first frame update
    void Start()
    {
        hasWall = new bool[5];
        hasTank = new bool[30];
        playerTanks = new GameObject[30];
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
        baseWall.GetComponent<Wall>().SetHp(baseWallHp);
        messageDuration = 3f;
        originalMessageDuration = messageDuration;
        cheatString = "";
        originalCoinBagSpawn = coinBagSpawn;
        movingCoinBag = null;
        movingCoinBagFrom = new Vector2(0, 0);
        movingCoinBagTo = new Vector2(0, 0);
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
                if (waveNumber == enemyTypes.Length && gameState == "gameOn")
                {
                    gameState = "victory";
                    dontDestroyObject.GetComponent<DontDestroyObject>().gameState = gameState;
                    dontDestroyObject.GetComponent<DontDestroyObject>().coins = coins;
                    SceneManager.LoadScene("Result");
                }
            }
        }
        else
        {
            uiSystemMessage.GetComponent<Text>().text = "Next Wave In " + Mathf.RoundToInt(waveInterval) + " Seconds";
        }
        coinBagSpawn -= Time.deltaTime;
        if (coinBagSpawn <= 0)
        {
            int randomSide = Random.Range(0, 4);
            switch (randomSide)
            {
                case 0:
                    Vector2 pos1 = new Vector2(-2.7f , Random.Range(-3.75f, 3.75f));
                    Vector2 pos2 = new Vector2(2.7f, Random.Range(-3.75f, 3.75f));
                    movingCoinBagFrom = pos1;
                    movingCoinBagTo = pos2;
                    movingCoinBag = Instantiate(coinBag, movingCoinBagFrom, Quaternion.identity);
                    break;
                case 1:
                    Vector2 pos3 = new Vector2(2.7f, Random.Range(-3.75f, 3.75f));
                    Vector2 pos4 = new Vector2(-2.7f, Random.Range(-3.75f, 3.75f));
                    movingCoinBagFrom = pos3;
                    movingCoinBagTo = pos4;
                    movingCoinBag = Instantiate(coinBag, movingCoinBagFrom, Quaternion.identity);
                    break;
                case 2:
                    Vector2 pos5 = new Vector2(Random.Range(-2f, 2f), -5.5f);
                    Vector2 pos6 = new Vector2(Random.Range(-2f, 2f), 5.5f);
                    movingCoinBagFrom = pos5;
                    movingCoinBagTo = pos6;
                    movingCoinBag = Instantiate(coinBag, movingCoinBagFrom, Quaternion.identity);
                    break;
                default:
                    Vector2 pos7 = new Vector2(Random.Range(-2f, 2f), 5.5f);
                    Vector2 pos8 = new Vector2(Random.Range(-2f, 2f), -5.5f);
                    movingCoinBagFrom = pos7;
                    movingCoinBagTo = pos8;
                    movingCoinBag = Instantiate(coinBag, movingCoinBagFrom, Quaternion.identity);
                    break;
            }
            coinBagSpawn = originalCoinBagSpawn;
        }
        if (movingCoinBag != null)
        {
            movingCoinBag.transform.position = Vector2.MoveTowards(movingCoinBag.transform.position, movingCoinBagTo, coinBagSpeed * Time.deltaTime);
            movingCoinBag.transform.position = new Vector3(movingCoinBag.transform.position.x , movingCoinBag.transform.position.y, -9.5f);
        }
        messageDuration -= Time.deltaTime;
        if (messageDuration <= 0)
        {
            uiMessage.GetComponent<Text>().text = "";
        }
        if (baseWall)
        {
            baseHpText.GetComponent<Text>().text = "BASE HP: " + baseWall.GetComponent<Wall>().hp;
        }
        coinText.GetComponent<Text>().text = "" + coins;
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
