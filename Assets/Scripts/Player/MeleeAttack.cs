using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistant;
    [SerializeField] private int damage;
    [SerializeField] private int anomolyDamage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask enermyLayer;
    public GameObject obstacleRayObject;
    [SerializeField] private float obstacleRayDistance;
    private float characterDirection;

    private float cooldownTimer = Mathf.Infinity;
    private EnermyHealth enermyHealth;
    private Anomoly enemyAnomoly;
    private Animator anim;
    private bool isAttacking;    
    private int attackCount = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        characterDirection = 0f;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if(EnermyInSight()){
            if(cooldownTimer >= attackCooldown && !isAttacking){
                /*
                if(Input.GetKey(KeyCode.Alpha1)){
                    isAttacking = true;
                    anim.SetBool("isAttacking", true);
                    anim.SetTrigger("attack_1");
                    cooldownTimer = 0;
                }
                if(Input.GetKey(KeyCode.Alpha2)){
                    isAttacking = true;
                    anim.SetBool("isAttacking", true);
                    anim.SetTrigger("attack_2");
                    cooldownTimer = 0;
                }
                if(Input.GetKey(KeyCode.Alpha3)){
                    isAttacking = true;
                    anim.SetBool("isAttacking", true);
                    anim.SetTrigger("attack_3");
                    cooldownTimer = 0;
                }
                */
                isAttacking = true;
                anim.SetBool("isAttacking", true);
                cooldownTimer = 0;

                anim.SetTrigger($"attack_{attackCount}");
                attackCount++;
                if(attackCount > 3){
                    attackCount = 1;
                }
            }
            
        }else if(Input.GetKey(KeyCode.E)){
            
        }
        else{
            isAttacking = false;
            anim.SetBool("isAttacking", false);
        }
        
    }

    public bool EnermyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistant, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, enermyLayer);

        if(hit.collider != null){
            enermyHealth = hit.transform.GetComponent<EnermyHealth>();
            enemyAnomoly = hit.transform.GetComponent<Anomoly>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistant,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamageEnermy()
    {
        if(EnermyInSight()){
            enermyHealth.TakeDamage(damage);
            enemyAnomoly.TakeAnomolyDamage(anomolyDamage);
        }
    }

    public void OnAttackAnimationEnd()
    {
        isAttacking = false; 
        
    }
}
