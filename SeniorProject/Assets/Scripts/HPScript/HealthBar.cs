using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void updateHealthBar(float CurrentHP, float MaxHP)
    {
       slider.value = CurrentHP / MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
