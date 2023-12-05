using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float randEnc = 1f;
    private Animator anim;
    /* private float minX = -5.5f;
    private float maxX = 5.5f;
    private float minY = -4.5f;     // disabled to remove artifical boundaries (1)
    private float maxY = 4.5f; */

    public Text npcTalk;
    public Text bossTalk;

    Boolean canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        npcTalk.enabled = false;
        bossTalk.enabled = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        if (canMove)
        {
            
            Vector2 currentPosition = transform.position;
            currentPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            /* if (currentPosition.x < minX)    // (1)
                currentPosition.x = minX;
            if (currentPosition.x > maxX)
                currentPosition.x = maxX; */

            currentPosition.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

            /* if (currentPosition.y < minY)    // (1)
                currentPosition.y = minY;
            if (currentPosition.y > maxY)
                currentPosition.y = maxY; */

            transform.position = currentPosition;
            if (Input.GetAxis("Horizontal") > 0) { anim.Play("WalkRight"); }
            else if(Input.GetAxis("Horizontal") < 0) { anim.Play("WalkLeft"); }
            else if(Input.GetAxis("Vertical") > 0) { anim.Play("WalkingUp"); }
            else if(Input.GetAxis("Vertical") < 0) { anim.Play("WalkDown"); }
            else { anim.Play("Idle"); }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Grass")
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)     // only roll while player is moving
            {
                if (randEnc >= UnityEngine.Random.Range(0, 100))
                    UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Npc1")
        {
            npcTalk.enabled = true;
        }

        if (collision.name == "Boss1")
        {
            bossTalk.enabled = true;
            canMove = false;
        }
    }

    private void OnMouseDown()
    {
        if (npcTalk.enabled)
        {
            npcTalk.enabled = false;
        }

        if (bossTalk.enabled)
        {
            bossTalk.enabled = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
        }
    }
}