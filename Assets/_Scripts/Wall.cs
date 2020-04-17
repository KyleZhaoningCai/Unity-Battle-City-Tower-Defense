/*
 File Name: Wall.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the behaviour of the wall GameObject
public class Wall : MonoBehaviour
{
    public GameObject explosion;
    public int hp;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    // Set the HP of this wall 
    public void SetHp(int wallHp)
    {
        hp = wallHp;
    }

    // Reduce the HP of this wall, and if HP drops to 0, set the wall existence to false,
    // Destroy this wall, and then spawn an explosion
    public void DamageWall(int bulletDamamge)
    {
        hp -= bulletDamamge;
        if (hp <= 0)
        {
            for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
            {
                if (transform.position.x == gameController.wallPlaceholders[i].transform.position.x && transform.position.y == gameController.wallPlaceholders[i].transform.position.y)
                {
                    gameController.hasWall[i] = false;
                    break;
                }
            }
            Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
