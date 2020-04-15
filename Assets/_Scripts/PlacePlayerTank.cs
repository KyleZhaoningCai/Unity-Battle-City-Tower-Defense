using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlayerTank : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
    }

    void OnMouseDown()
    {
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            if (transform.position == gameController.playerTankPlaceholders[i].transform.position)
            {
                gameController.hasTank[i] = true;
                gameController.playerTankPlaceholders[i].SetActive(false);
                switch (gameController.tankToPlace)
                {
                    case 1:
                        Instantiate(gameController.playerTank, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(gameController.playerTankCannon, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(gameController.playerTankFast, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(gameController.playerTankHeavy, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
                        break;
                    default:
                        break;
                }
                for (int j = 0; j < gameController.playerTankPlaceholders.Length; j++)
                {
                    gameController.playerTankPlaceholders[j].SetActive(false);
                }
                gameController.tankToPlace = 0;
                break;
            }
        }
    }
}
