/*
 File Name: CoinBag.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the behaviour of the coin bag GameObject
public class CoinBag : MonoBehaviour
{

    private float selfDestoyTime;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        selfDestoyTime = 3f;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the coin bag after 3 seconds
        selfDestoyTime -= Time.deltaTime;
        if (selfDestoyTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        // Play the coin sound, add 200 to player's coin, then destroy the coin bag GameObject
        gameController.GetComponent<AudioSource>().Play();
        gameController.coins += 200;
        Destroy(gameObject);
    }
}
