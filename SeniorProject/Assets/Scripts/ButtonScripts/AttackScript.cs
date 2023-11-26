using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public int maxEnemyHealth = 100;
    public int enemyHealth = 100;
    public int dmg;

    public GameObject Target;

    private void Awake()
    {
        //Target = GameObject.FindGameObjectWithTag("Enemy");
        Target = GameObject.FindGameObjectWithTag("CombatController");
    }

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
        //enemyHealth = enemyHealth - dmg;
        //controller.GetComponent<NewBehaviourScript>().TakeDamage(dmg);
        //Target.GetComponent<EnemyStats>().TakeDamage(dmg);
        Target.GetComponent<MasterBAttleScript>().dealDmg(dmg);
    }
    public float getMaxHealth() {
        return maxEnemyHealth;
    }
    public float getEnemyHealth()
    {
        return enemyHealth;
    }
}
