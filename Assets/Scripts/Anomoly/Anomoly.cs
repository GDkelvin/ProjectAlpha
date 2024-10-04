using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anomoly : MonoBehaviour
{
    [Header ("Anomoly")]
    [SerializeField] public float startingAnomoly;
    public float currentAnomoly {get; private set;}

    private Animator anim;

    private void Awake()
    {
        currentAnomoly = startingAnomoly; 
        anim = GetComponent<Animator>();
    }

    

    public void TakeAnomolyDamage(float _anomoly)
    {
        currentAnomoly = Mathf.Clamp(currentAnomoly - _anomoly, 0, startingAnomoly);
    }
}
