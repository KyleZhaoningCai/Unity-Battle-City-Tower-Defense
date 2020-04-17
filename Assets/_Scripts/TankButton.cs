/*
 File Name: TankButton.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the tank button click
public class TankButton : MonoBehaviour
{
    public int tankToPlace;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnMouseDown()
    {
        // Deactivate all player tank placeholders first
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            gameController.playerTankPlaceholders[i].SetActive(false);
        }
        // Deactivate hammer
        gameController.isHammering = false;

        // If tank type to place is same as the clicked tank type
        if (gameController.tankToPlace == tankToPlace)
        {
            // Set the tank type to none
            gameController.tankToPlace = 0;
        }
        else
        {
            for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
            {
                // Activate the player tank placeholders where there is no tank there
                if (!gameController.hasTank[i])
                {
                    gameController.playerTankPlaceholders[i].SetActive(true);
                }
            }
            // Set the type of tank to place to the clicked tank type
            gameController.tankToPlace = tankToPlace;
        }
    }
}
