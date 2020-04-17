/*
 File Name: MoveLogo.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the movement of the Logo on the Menu scene
public class MoveLogo : MonoBehaviour
{

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move it down from outside the scene to the center of the scene
        if (Vector2.Distance(transform.position, target.transform.position) > 0.1)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime);
        }
    }
}
