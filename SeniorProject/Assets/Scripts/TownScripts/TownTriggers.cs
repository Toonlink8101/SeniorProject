using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "HouseADoor" || collision.name == "HouseBDoor" || collision.name == "HouseCDoor" || collision.name == "HouseDDoor")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
        }
    }
}
