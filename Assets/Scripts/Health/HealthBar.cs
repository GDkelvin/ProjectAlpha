using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private Image shield;
    [SerializeField] private Gradient colorGradient;

    
    
    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
        shield.fillAmount = playerHealth.currentShield / playerHealth.startingShield;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;
        //Change color for healthbar
        currentHealthBar.color = colorGradient.Evaluate(currentHealthBar.fillAmount); 

        shield.fillAmount = playerHealth.currentShield / playerHealth.startingShield;
    }
}
