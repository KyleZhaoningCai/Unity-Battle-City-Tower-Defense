using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Score: " + GameObject.FindGameObjectWithTag("DontDestroy").GetComponent<DontDestroyObject>().coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
