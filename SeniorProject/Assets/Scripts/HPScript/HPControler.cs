using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Image HealthBar;
    public GameObject button;
    public float HealthAmt;
    public float HealthMax;
   // public Text currentHealth;
   // public Text Maxhealth;



    // Start is called before the first frame update
    void Start()
    {
        // currentHealth.text = HealthAmt.ToString();
        //Maxhealth.text = "/" + HealthMax.ToString();
        HealthMax = button.GetComponent<AttackScript>().getMaxHealth();
        HealthAmt = button.GetComponent<AttackScript>().getEnemyHealth();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(10);
        }
    }
    public void TakeDamage(float damage)
    {
       HealthAmt -= damage;
       HealthBar.fillAmount = HealthAmt / HealthMax;
       // currentHealth.text = HealthAmt.ToString();


    }

    public void Heal(float amount)
    {
       // HealthAmt += amount;
       // HealthAmt = Mathf.Clamp(HealthAmt, 0, HealthMax);
       // HealthBar.fillAmount = HealthAmt / HealthMax;
       // currentHealth.text = HealthAmt.ToString();
    }

}
