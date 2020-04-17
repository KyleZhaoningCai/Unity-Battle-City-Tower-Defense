/*
 File Name: DontDestroyObject.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles the GameObject that don't get destroyed when changing scene
public class DontDestroyObject : MonoBehaviour
{
    public string gameState;
    public int coins;

    void Awake()
    {
        // Prevent this GameObject from getting destroyed
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
