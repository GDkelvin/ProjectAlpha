using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pantheon;

    private void SpawnPantheon()
    {
        Instantiate(pantheon, transform.position, Quaternion.identity);
    }
    

    
}
