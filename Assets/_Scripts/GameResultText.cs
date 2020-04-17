/*
 File Name: GameResultText.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class handles the game result text content
public class GameResultText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the game text base on the game state
        if (GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<DontDestroyObject>().gameState == "gameOver")
        {
            GetComponent<Text>().text = "Game Over";
        }
        else
        {
            GetComponent<Text>().text = "Victory!!!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
