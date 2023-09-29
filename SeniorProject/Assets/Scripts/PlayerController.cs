using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    private float minX = -5.5f;
    private float maxX = 5.5f;
    private float minY = -4.5f;
    private float maxY = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (currentPosition.x < minX)
            currentPosition.x = minX;
        if (currentPosition.x > maxX)
            currentPosition.x = maxX;

        currentPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (currentPosition.y < minY)
            currentPosition.y = minY;
        if (currentPosition.y > maxY)
            currentPosition.y = maxY;

        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grass")
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}