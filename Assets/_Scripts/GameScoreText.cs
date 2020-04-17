/*
 File Name: GameScoreText.cs
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

// This class handles the game score text content
public class GameScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the game score text to the coins value
        GetComponent<Text>().text = "Score: " + GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<DontDestroyObject>().coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
