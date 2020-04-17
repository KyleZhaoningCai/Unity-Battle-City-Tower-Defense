/*
 File Name: WallButton.cs
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

// This class handles the wall button click
public class WallButton : MonoBehaviour
{
	private GameController gameController;

    void Start () {
        gameController = FindObjectOfType<GameController>();
    }

    void OnMouseDown()
    {
        gameController.pushToCheatString("W");
        ShowWallPlaceholders();
    }

    // Show or hide wall placeholders
    public void ShowWallPlaceholders()
    {
        // If still counting down to next wave of enemies
        if (gameController.waveInterval > 0)
        {
            bool hasActive = false; // Check if there is any active wall placeholder
            for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
            {
                // Check if this wall placeholder is active
                if (gameController.wallPlaceholders[i].activeSelf)
                {
                    hasActive = true;
                    break;
                }
            }
            // If there is at least one active placeholder
            if (hasActive)
            {
                // Turn off all wall placeholders
                for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
                {
                    gameController.wallPlaceholders[i].SetActive(false);
                }
            }
            else
            {
                // Turn on the wall placeholders where there is no wall there
                for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
                {
                    if (!gameController.hasWall[i])
                    {
                        gameController.wallPlaceholders[i].SetActive(true);
                    }
                }
            }
        }
        // If enemies have begun spawning
        else
        {
            gameController.showMessage("Cannot Place Wall Now");
        }
    }
}
