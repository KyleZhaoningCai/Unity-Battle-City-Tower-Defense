using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTank : MonoBehaviour
{
	private GameController gameController;

    void Start () {
        gameController = FindObjectOfType<GameController>();
    }

    public void ShowTankPlaceholders()
    {

            bool hasActive = false;
            for (int i = 0; i < gameController.tankPlaceholders.Length; i++)
            {
                if (gameController.tankPlaceholders[i].activeSelf)
                {
                    hasActive = true;
                    break;
                }
            }
            if (hasActive)
            {
                for (int i = 0; i < gameController.tankPlaceholders.Length; i++)
                {
                    gameController.tankPlaceholders[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < gameController.tankPlaceholders.Length; i++)
                {
                    if (!gameController.hasWall[i])
                    {
                        gameController.tankPlaceholders[i].SetActive(true);
                    }
                }
            }
    }
}
