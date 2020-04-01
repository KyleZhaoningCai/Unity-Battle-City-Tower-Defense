using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWall : MonoBehaviour
{

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
            gameController.player.GetComponent<Player>().SetTask("PlaceWall", transform.position);
        }
    }
}
