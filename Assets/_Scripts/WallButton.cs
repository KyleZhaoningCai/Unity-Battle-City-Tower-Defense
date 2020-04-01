using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallButton : MonoBehaviour
{
	private GameController gameController;

    void Start () {
        gameController = FindObjectOfType<GameController>();
    }

    public void ShowWallPlaceholders()
    {
        if (gameController.waveInterval > 0)
        {
            bool hasActive = false;
            for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
            {
                if (gameController.wallPlaceholders[i].activeSelf)
                {
                    hasActive = true;
                    break;
                }
            }
            if (hasActive)
            {
                for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
                {
                    gameController.wallPlaceholders[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
                {
                    if (!gameController.hasWall[i])
                    {
                        gameController.wallPlaceholders[i].SetActive(true);
                    }
                }
            }
        }
        else
        {
            gameController.showMessage("Cannot Place Wall Now");
        }
    }
}
