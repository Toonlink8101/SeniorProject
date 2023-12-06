using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;
    HealthBar Healthbar;
    public bool shielded = false;
    public GameObject controller;

    public bool isTarget = false;

    public bool isEnemy = false;
    public bool isPlayer = false;

    private void Awake()
    {
        CurrentHP = 100f;
        MaxHP = 100f;
        Healthbar = GetComponentInChildren<HealthBar>();
        Healthbar.updateHealthBar(CurrentHP, MaxHP);
        controller = GameObject.FindGameObjectWithTag("CombatController");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float DMG) {
        if (shielded) {
            shielded = false;
            return;
        }
        if (CurrentHP <= DMG)
        {
            //Die
            this.gameObject.SetActive(false);
            if (isPlayer) { controller.GetComponent<MasterBAttleScript>().addDeadPlayer(); }
            if (isEnemy) { controller.GetComponent<MasterBAttleScript>().addDeadEnemy(); }
        }


        CurrentHP -= DMG;
        Healthbar.updateHealthBar(CurrentHP, MaxHP);

    }

     public void setTarget ()
    {
        isTarget = true;
    }

    public void notTarget() {
        isTarget = false;
    }

    public bool checkTarget() {
        return isTarget;
    }
    public void Shield() { 
        shielded=true;
    }

    public bool Echeck() {
        return isEnemy;
    }

    public bool Pcheck() {
        return isPlayer;
    }

}
