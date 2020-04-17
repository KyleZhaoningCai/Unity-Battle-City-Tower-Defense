/*
 File Name: Explosion.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the explosion effect
public class Explosion : MonoBehaviour
{
    private float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        destroyTimer = 0.5f;

        // Makes sure the explosion appears on top of almost all other GameObjects
        transform.position = new Vector3(transform.position.x, transform.position.y, -2);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy this explosion effect after 0.5 seconds
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
