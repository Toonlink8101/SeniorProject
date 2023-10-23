using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public int maxEnemyHealth = 100;
    public int enemyHealth = 100;

    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("OverworldScene");
        }
    }

    public void attack()
    {
            enemyHealth = enemyHealth - (maxEnemyHealth / 10);
            controller.GetComponent<NewBehaviourScript>().TakeDamage(10f);
    }
    public float getMaxHealth() {
        return maxEnemyHealth;
    }
    public float getEnemyHealth()
    {
        return enemyHealth;
    }
}
