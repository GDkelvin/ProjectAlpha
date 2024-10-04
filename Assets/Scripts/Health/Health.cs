using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] public float startingHealth;
    public float currentHealth {get; private set;}

    [Header ("Shield")]
    [SerializeField] public float startingShield;
    public float currentShield {get; private set;}
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth; //i swapped and spent 30mins fixing this
        currentShield = startingShield;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        //Deal damage to the shield first if there is any
        if(currentShield > 0){
            float damageToShield = Mathf.Min(_damage, currentShield);
            currentShield -= damageToShield;
            _damage -= damageToShield;
        }
        
        if(_damage > 0 && currentHealth > 0){
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        }

        //if(currentHealth > 0 && currentShield <= 0){
        //    currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);    
        //}
        
        if(currentHealth <= 0 && !dead){
            anim.SetTrigger("death");
            GetComponent<MeleeAttack>().enabled = false; 
            dead = true;
        }
                    
    }

    private void Deactivate()
    {
            gameObject.SetActive(false);
    }

    public void ResetHealth()
    {
            currentHealth = startingHealth;
            dead = false;
            Debug.Log("Health reset to: " + currentHealth);
    }
}
