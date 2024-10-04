using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator anim;
    private MeleeEnermy playerInsight;
    private bool isMoving = false;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerInsight = GetComponent<MeleeEnermy>();
    }
    private void Update()
    {
        if(playerInsight.PlayerInSight()){
            return;
        }
        
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}