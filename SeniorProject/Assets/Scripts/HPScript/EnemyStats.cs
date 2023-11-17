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
        if (CurrentHP < DMG)
        {
            //Die

        }


        CurrentHP -= DMG;
        Healthbar.updateHealthBar(CurrentHP, MaxHP);

    }

    private void OnMouseUpAsButton()
    {
        //controller.GetComponent<MasterBAttleScript>.setTarget(this.GameObject);
    }


    public void Shield() { 
        shielded=true;
    }
}
