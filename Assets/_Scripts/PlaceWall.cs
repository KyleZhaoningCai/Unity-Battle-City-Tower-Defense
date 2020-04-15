using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
            {
                if (transform.position == gameController.wallPlaceholders[i].transform.position)
                {
                    gameController.hasWall[i] = true;
                    gameController.wallPlaceholders[i].SetActive(false);
                    Instantiate(gameController.wall, new Vector2(gameController.wallPlaceholders[i].transform.position.x, gameController.wallPlaceholders[i].transform.position.y), Quaternion.identity);
                    wallButton.ShowWallPlaceholders();
                    break;
                }
            }
        }
    }
}
