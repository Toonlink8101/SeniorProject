using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    //Copy of EnemyController

    public float speed = 3f;
    public int moveRate = 20;   // manages chances of moving: lower value means more frequent movement
    private int AImove = 10;
    private int frameCount = 0;
    public int frameMax = 20;   // manages length of movements: lower value means shorter movements

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        frameCount++;
    }

    void MoveEnemy()
    {
        Vector2 currentPosition = transform.position;

        if (frameCount >= frameMax)
        {
            AImove = Random.Range(1, moveRate);
            frameCount = 0;
        }

        if (AImove == 1)
            currentPosition.x += speed * Time.deltaTime;
        else if (AImove == 2)
            currentPosition.x += -1 * speed * Time.deltaTime;

        if (AImove == 3)
            currentPosition.y += speed * Time.deltaTime;
        else if (AImove == 4)
            currentPosition.y += -1 * speed * Time.deltaTime;

        transform.position = currentPosition;
    }
}