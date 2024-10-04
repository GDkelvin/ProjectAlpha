using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeleeEnermy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistant;
    [SerializeField] private int damage;
    [SerializeField] private float speed; //movement speed
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Health playerHealth;
    private Animator anim;
    private bool isAttacking = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight()){
            if(cooldownTimer >= attackCooldown){
                isAttacking = true;
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
                anim.SetBool("moving",false);
            }
            return;
        }else{
            isAttacking = false;
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.SetBool("moving",true);
        }
        
    }

    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistant, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null){
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistant,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(playerHealth != null){
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnAttackAnimationStart()
    {
        DamagePlayer();
    }

    
    private void OnAttackAnimationEnd()
    {
        isAttacking = false; 
        
    }
}
 