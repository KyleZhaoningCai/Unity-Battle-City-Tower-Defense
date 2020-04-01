using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWall : MonoBehaviour
{

    public GameObject wall;
    public GameObject[] wallPlaceholders;

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
                    gameObject.SetActive(false);
                    Instantiate(wall, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    wallButton.ShowWallPlaceholders();
                    break;
                }
            }
        }
    }
}
