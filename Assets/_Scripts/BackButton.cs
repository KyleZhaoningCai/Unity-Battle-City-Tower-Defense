/*
 File Name: BackButton.cs
 Author: Zhaoning Cai, Supreet Kaur, Jiansheng Sun
 Student ID: 300817368, 301093932, 300997240
 Date: Apr 17, 2020
 App Description: Battle City Tower Defense
 Version Information: v2.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class handles the back button click
public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy the DontDestroy GameObject then go the the Menu scene
    private void OnMouseDown()
    {
        Destroy(GameObject.FindGameObjectWithTag("DontDestroy"));
        SceneManager.LoadScene("Menu");
    }
}
