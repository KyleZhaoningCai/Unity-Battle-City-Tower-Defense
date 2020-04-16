using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerButton : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void OnMouseDown()
    {
        gameController.pushToCheatString("H");
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            gameController.playerTankPlaceholders[i].SetActive(false);
        }
        gameController.tankToPlace = 0;
        if (gameController.isHammering)
        {
            gameController.isHammering = false;
        }
        else
        {
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
