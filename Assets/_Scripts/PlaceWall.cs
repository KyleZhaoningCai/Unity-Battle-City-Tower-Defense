using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWall : MonoBehaviour
{

    public GameObject[] wallPlaceholders;
    public GameObject wall;

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
            for (int i = 0; i < wallPlaceholders.Length; i++)
            {
                if (transform.position == wallPlaceholders[i].transform.position)
                {
                    gameController.hasWall[i] = true;
                    wallPlaceholders[i].SetActive(false);
                    Instantiate(wall, new Vector2(wallPlaceholders[i].transform.position.x, wallPlaceholders[i].transform.position.y), Quaternion.identity);
                    wallButton.ShowWallPlaceholders();
                    break;
                }
            }
        }
    }
}
