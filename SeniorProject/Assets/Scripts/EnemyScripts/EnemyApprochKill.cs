using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyApprochKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( killthis());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator killthis()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
