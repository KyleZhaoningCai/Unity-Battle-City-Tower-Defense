/*
 File Name: HammerButton.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the hammer button click
public class HammerButton : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnMouseDown()
    {
        // Push the hammer button letter to the cheat string
        gameController.pushToCheatString("H");

        // Turn off all player tank placeholders first
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            gameController.playerTankPlaceholders[i].SetActive(false);
        }

        // Set tank to place to none
        gameController.tankToPlace = 0;
        if (gameController.isHammering)
        {
            gameController.isHammering = false;
        }

        // If the hammer is not activated
        else
        {
            // Activate the player tank placeholders where a tank is there
            for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
            {
                if (gameController.hasTank[i])
                {
                    gameController.playerTankPlaceholders[i].SetActive(true);
                }
            }
            gameController.isHammering = true;
        }
        
    }
}
