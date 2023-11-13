using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 3f;
    public int moveRate = 20;   // manages chances of moving: lower value means more frequent movement
    private int AImove = 10;
    private float minX = -5.5f;
    private float maxX = 5.5f;
    private float minY = -4.5f;
    private float maxY = 4.5f;
    private int frameCount = 0;
    public int frameMax = 20;   // manages length of movements: lower value means shorter movements
    /* NOTE: 'frameMax' also has impact on real-time frequency of movements.
    Considering keeping it like this, good potential for
    jittery enemies or big, lumbering foes */

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

        if (currentPosition.x < minX)
            currentPosition.x = minX;
        if (currentPosition.x > maxX)
            currentPosition.x = maxX;

        if (AImove == 3)
            currentPosition.y += speed * Time.deltaTime;
        else if (AImove == 4)
            currentPosition.y += -1 * speed * Time.deltaTime;
        
        if (currentPosition.y < minY)
            currentPosition.y = minY;
        if (currentPosition.y > maxY)
            currentPosition.y = maxY;

        transform.position = currentPosition;
    }
}
/* Side Note: in testing, editor would sometimes show the following error:
"ArgumentNullException: Value cannot be Null."
However, this did not seem to have any impact on gameplay tests.
Documenting error, but ignoring for now. */
