using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<DontDestroyObject>().gameState == "gameOver")
        {
            GetComponent<Text>().text = "Game Over";
        }
        else
        {
            GetComponent<Text>().text = "Victory!!!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
