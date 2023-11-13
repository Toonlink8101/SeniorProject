using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBAttleScript : MonoBehaviour
{
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       






    }

    private void OnMouseDown()
    {
        target = gameObject;
    }
    public void dealDmg(float dmg) {
        target.gameObject.GetComponent<EnemyStats>().TakeDamage(dmg);
    }

    public void AddShield() {
        target.gameObject.GetComponent<EnemyStats>().Shield();
    }
}
