/*
 File Name: PlacePlayerTank.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles placing a player tank action
public class PlacePlayerTank : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        // Start with inactive state
        gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
    }

    void OnMouseDown()
    {
        // Push the placeholder button letter to the cheat string
        gameController.pushToCheatString("P");
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            // Check which placeholder in the placeholder array is clicked
            if (transform.position == gameController.playerTankPlaceholders[i].transform.position)
            {
                // If there is a player tank there and hammer is active
                if (gameController.hasTank[i] && gameController.isHammering)
                {
                    for (int j = 0; j < gameController.playerTanks.Length; j++)
                    {
                        // Check which tank is in the placeholder position
                        if (gameController.playerTanks[j] != null && gameController.playerTanks[j].transform.position.x == gameController.playerTankPlaceholders[i].transform.position.x && gameController.playerTanks[j].transform.position.y == gameController.playerTankPlaceholders[i].transform.position.y)
                        {
                            // Destroy this tank, set existence to false, spawn an explosion, remove the tank from the
                            // player tanks array and turn off all player tank placeholders, then deactivate hammer
                            gameController.hasTank[i] = false;
                            Destroy(gameController.playerTanks[j].gameObject);
                            Instantiate(gameController.explosion, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                            gameController.playerTanks[j] = null;
                            for (int k = 0; k < gameController.playerTankPlaceholders.Length; k++)
                            {
                                gameController.playerTankPlaceholders[k].SetActive(false);
                            }
                            gameController.isHammering = false;
                            break;
                        }
                    }
                }
                // If there is no player tank there or the hammer is inactive
                else
                {
                    bool placed = false; // Check if a player tank is placed successfully

                    // Check which type of player tank to place
                    switch (gameController.tankToPlace)
                    {
                        case 1:
                            // Check if the player has enough coins
                            if (gameController.coins >= 100)
                            {
                                GameObject newTank = Instantiate(gameController.playerTank, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);

                                // Find an empty slot in the player tank array and assign the tank there
                                for (int j = 0; j < gameController.playerTanks.Length; j++)
                                {
                                    if (gameController.playerTanks[j] == null)
                                    {
                                        gameController.playerTanks[j] = newTank;
                                        break;
                                    }
                                }
                                gameController.coins -= 100;
                                placed = true;
                            }
                            break;
                        case 2:
                            if (gameController.coins >= 300)
                            {
                                GameObject newTank = Instantiate(gameController.playerTankCannon, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                                for (int j = 0; j < gameController.playerTanks.Length; j++)
                                {
                                    if (gameController.playerTanks[j] == null)
                                    {
                                        gameController.playerTanks[j] = newTank;
                                        break;
                                    }
                                }
                                gameController.coins -= 300;
                                placed = true;
                            }
                            break;
                        case 3:
                            if (gameController.coins >= 500)
                            {
                                GameObject newTank = Instantiate(gameController.playerTankFast, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                                for (int j = 0; j < gameController.playerTanks.Length; j++)
                                {
                                    if (gameController.playerTanks[j] == null)
                                    {
                                        gameController.playerTanks[j] = newTank;
                                        break;
                                    }
                                }
                                gameController.coins -= 500;
                                placed = true;
                            }
                            break;
                        case 4:
                            if (gameController.coins >= 700)
                            {
                                GameObject newTank = Instantiate(gameController.playerTankHeavy, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                                for (int j = 0; j < gameController.playerTanks.Length; j++)
                                {
                                    if (gameController.playerTanks[j] == null)
                                    {
                                        gameController.playerTanks[j] = newTank;
                                        break;
                                    }
                                }
                                gameController.coins -= 700;
                                placed = true;
                            }
                            break;
                        default:
                            break;
                    }

                    // If a player tank has been successfully placed
                    if (placed)
                    {
                        // Set tank existence to true and turn off  all player tank placeholders
                        gameController.hasTank[i] = true;
                        for (int j = 0; j < gameController.playerTankPlaceholders.Length; j++)
                        {
                            gameController.playerTankPlaceholders[j].SetActive(false);
                        }

                        // Set the player tank to place type to none
                        gameController.tankToPlace = 0;
                    }

                    // If tank is not placed, display the insufficient coins message
                    else
                    {
                        gameController.showMessage("INSUFFICIENT COINS");
                    }
                }
                break;
            }
        }
    }
}
