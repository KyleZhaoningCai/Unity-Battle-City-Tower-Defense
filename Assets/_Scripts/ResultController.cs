/*
 File Name: ResultController.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the overall result scene logic
public class ResultController : MonoBehaviour
{
    public GameObject victoryMusic;
    public GameObject gameOverMusic;
    public GameObject goodBase;
    public GameObject badBase;

    // Start is called before the first frame update
    void Start()
    {
        // Display the right image and play the right background music base on the game state
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
