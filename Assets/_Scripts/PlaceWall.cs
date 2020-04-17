/*
 File Name: PlaceWall.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the placing wall action
public class PlaceWall : MonoBehaviour
{
    private GameController gameController;
    private WallButton wallButton;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        wallButton = FindObjectOfType<WallButton>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        // Add the placeholder button letter to the cheat string
        gameController.pushToCheatString("P");

        // Check if the player has enough coins
        if (gameController.coins >= 300)
        {
            for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
            {
                // Check which placeholder in the array is the clicked placeholder
                if (transform.position == gameController.wallPlaceholders[i].transform.position)
                {
                    // Set wall existence to true, deactivate the clicked placeholder, spawn a wall,
                    // turn off all wall placeholders, and reduce the player's coin
                    gameController.hasWall[i] = true;
                    gameController.wallPlaceholders[i].SetActive(false);
                    Instantiate(gameController.wall, new Vector2(gameController.wallPlaceholders[i].transform.position.x, gameController.wallPlaceholders[i].transform.position.y), Quaternion.identity);
                    wallButton.ShowWallPlaceholders();
                    gameController.coins -= 300;
                    break;
                }
            }
        }
        // If the player does not have enough coins, display insufficient coins message
        else
        {
            gameController.showMessage("INSUFFICIENT COINS");
        }
    }
}
