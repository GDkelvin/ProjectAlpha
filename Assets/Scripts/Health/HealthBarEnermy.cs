using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarEnermy : MonoBehaviour
{
    [SerializeField] private EnermyHealth enermyHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    private void Start()
    {
        totalHealthBar.fillAmount = enermyHealth.currentHealth / enermyHealth.startingHealth;
        
    }

    private void Update()
    {
        currentHealthBar.fillAmount = enermyHealth.currentHealth / enermyHealth.startingHealth;
        
    }
}
