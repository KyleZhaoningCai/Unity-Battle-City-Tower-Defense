using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public GameObject victoryMusic;
    public GameObject gameOverMusic;
    public GameObject goodBase;
    public GameObject badBase;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<DontDestroyObject>().gameState == "gameOver")
        {
            gameOverMusic.SetActive(true);
            badBase.SetActive(true);
        }
        else
        {
            victoryMusic.SetActive(true);
            goodBase.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
