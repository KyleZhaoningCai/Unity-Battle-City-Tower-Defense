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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameController.pushToCheatString("H");
        }
    }
}
