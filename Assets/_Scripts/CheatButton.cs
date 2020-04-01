using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatButton : MonoBehaviour
{

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Megidolaon()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().ReduceHp(9999);
        }
    }
}
