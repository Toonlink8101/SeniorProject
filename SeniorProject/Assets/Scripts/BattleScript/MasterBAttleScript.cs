using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class MasterBAttleScript : MonoBehaviour
{
    public GameObject target;
    public GameObject[] all;
    public int deadEnemy = 0;
    public int deadPlayer = 0;
    public int TotalPlayer;
    public int TotalEnemy;
   // public GameObject[] playersarray = new GameObject[20];
  //  public int playersArraySize =0;
    public int playeractions;
    public int enemyActions;

    // Start is called before the first frame update
    void Awake()
    {
        all = GameObject.FindGameObjectsWithTag("Enemy");
        etotal();
        Ptotal();
        //setplayerArray();
        print(TotalPlayer); print(TotalEnemy);
        playeractions = TotalPlayer;
        enemyActions = TotalEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        setTarget();
        checktoend();
       // AutoRetaliate();
    }
    public void AutoRetaliate() {
        GameObject temp = target;
        while (true) { 
            target = all[Random.Range(0, all.Length)];
            bool tester = target.gameObject.GetComponent<EnemyStats>().Pcheck();
            if (tester)
            {
                dealDmg(Random.Range(0f,10f));
                break;
            }
        
        }
        target = temp;

    
    }


    void checktoend() { 
        if(deadPlayer >= TotalPlayer) { endScene(); }
        if(deadEnemy >= TotalEnemy) {  endScene(); }
    
    }

    public void clearTarget() {
        foreach (GameObject target in all) {
            target.GetComponent<EnemyStats>().notTarget();
        }
    }
    
    public void setTarget() {
        
        foreach (GameObject enemy in all) { 
            bool Testtargett = enemy.GetComponent<EnemyStats>().checkTarget();
            if (Testtargett) { 
                target = enemy;
                break;
            }

        }
    
    }

    public void etotal() {

        foreach (GameObject target in all)
        {
            bool tester = target.gameObject.GetComponent<EnemyStats>().Echeck();
            if (tester) { TotalEnemy++; }
        }
    }

    public void Ptotal() {
        foreach (GameObject target in all)
        {
            bool tester = target.gameObject.GetComponent<EnemyStats>().Pcheck();
            if (tester) { TotalPlayer++; }
        }
    }


    public void dealDmg(float dmg) {
        target.gameObject.GetComponent<EnemyStats>().TakeDamage(dmg);
    }

    public void AddShield() {
        target.gameObject.GetComponent<EnemyStats>().Shield();
    }

    public void addDeadEnemy() {
        deadEnemy++;
    }

    public void addDeadPlayer() { 
        deadPlayer++;
    }

    public void endScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OverworldScene");
    }
}
