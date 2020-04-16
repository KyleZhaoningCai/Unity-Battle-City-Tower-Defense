using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankCollider : MonoBehaviour
{
    private GameController gameController;
    private PlayerTankBasic parentObject;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        parentObject = transform.parent.gameObject.GetComponent<PlayerTankBasic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
