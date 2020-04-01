using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public GameObject wall;

    private string task;
    private Vector2 target;
    private GameController gameController;
    private WallButton wallButton;
    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        wallButton = FindObjectOfType<WallButton>();
        task = "Idle";
        startingPosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (task == "Idle")
        {
            MoveToPosition(startingPosition);
        }
        if (task == "PlaceWall")
        {
            MoveToPosition(target);
            if (Vector2.Distance(transform.position, target) < 0.01)
            {
                for (int i = 0; i < gameController.wallPlaceholders.Length; i++)
                {
                    if (target.x == gameController.wallPlaceholders[i].transform.position.x && target.y == gameController.wallPlaceholders[i].transform.position.y)
                    {
                        gameController.hasWall[i] = true;
                        gameController.wallPlaceholders[i].SetActive(false);
                        Instantiate(wall, new Vector2(gameController.wallPlaceholders[i].transform.position.x, gameController.wallPlaceholders[i].transform.position.y), Quaternion.identity);
                        wallButton.ShowWallPlaceholders();
                        task = "Idle";
                        RotateTowards(startingPosition);
                        break;
                    }
                }
            }
        }
    }

    public void SetTask(string taskName, Vector2 destination)
    {
        task = taskName;
        target = destination;
        if (taskName != "Idle")
        {
            RotateTowards(target);
        }
        else
        {
            RotateTowards(startingPosition);
        }
        
    }

    public string GetTask()
    {
        return task;
    }

    private void MoveToPosition(Vector2 position)
    {
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -5), new Vector3(position.x, position.y, -5), speed * Time.deltaTime);
    }

    // Code from Unity Forum
    private void RotateTowards(Vector2 target)
    {
        var offset = 270f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
