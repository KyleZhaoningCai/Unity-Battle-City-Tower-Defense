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
        gameController.pushToCheatString("P");
        for (int i = 0; i < gameController.playerTankPlaceholders.Length; i++)
        {
            if (transform.position == gameController.playerTankPlaceholders[i].transform.position)
            {
                if (gameController.hasTank[i] && gameController.isHammering)
                {
                    for (int j = 0; j < gameController.playerTanks.Length; j++)
                    {
                        if (gameController.playerTanks[j] != null && gameController.playerTanks[j].transform.position.x == gameController.playerTankPlaceholders[i].transform.position.x && gameController.playerTanks[j].transform.position.y == gameController.playerTankPlaceholders[i].transform.position.y)
                        {
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
                else
                {
                    bool placed = false;
                    switch (gameController.tankToPlace)
                    {
                        case 1:
                            if (gameController.coins >= 100)
                            {
                                GameObject newTank = Instantiate(gameController.playerTank, new Vector2(gameController.playerTankPlaceholders[i].transform.position.x, gameController.playerTankPlaceholders[i].transform.position.y), Quaternion.identity);
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
                    if (placed)
                    {
                        gameController.hasTank[i] = true;
                        gameController.playerTankPlaceholders[i].SetActive(false);
                        for (int j = 0; j < gameController.playerTankPlaceholders.Length; j++)
                        {
                            gameController.playerTankPlaceholders[j].SetActive(false);
                        }
                        gameController.tankToPlace = 0;
                    }
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
