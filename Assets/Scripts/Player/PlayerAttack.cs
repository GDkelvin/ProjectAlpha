using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private PlayerMovement playerMovement;
    private MeleeAttack meleeAttack;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        meleeAttack = GetComponent<MeleeAttack>();
    }

    private void Update()
    {
        //left click to attack
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack()){
            if(meleeAttack.EnermyInSight()){
                anim.SetTrigger("meleeAttack");
            }
        }
        
        cooldownTimer += Time.deltaTime;
    }

    

    private void Attack()
    {
        anim.SetTrigger("rangeAttack");
        cooldownTimer = 0;

        //Object pooling
        //Everytime attack, reset the position back to firePoint
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length; i++){
            if(!fireballs[i].activeInHierarchy){
                return i;
            }
            
        }
        return 0;
    }
}
