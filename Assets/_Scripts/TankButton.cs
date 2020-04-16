using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            gameController.playerTankPlaceholders[i].SetActive(false);
        }
        gameController.isHammering = false;
        if (gameController.tankToPlace == tankToPlace)
        {
            gameController.tankToPlace = 0;
        }
        else
        {
            for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
            {
                if (!gameController.hasTank[i])
                {
                    gameController.playerTankPlaceholders[i].SetActive(true);
                }
            }
            gameController.tankToPlace = tankToPlace;
        }
    }
}
