using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    [SerializeField] int amountToPool;
    [SerializeField] GameObject[] characterToPool;

    List<GameObject> characterPooled;

    private void Awake()
    {
        instance = this; //Assign object pooling script to variable instance
    }

    private void Start()
    {
        characterPooled = new List<GameObject>();

        for(int i = 0; i <  characterToPool.Length; i++){
            for(int j = 0; j < amountToPool; j++){
                GameObject temp = Instantiate(characterToPool[i]);
                temp.SetActive(false);
                characterPooled.Add(temp);
            }
        }
    }

    public GameObject[] GetPantheonToPool()
    {
        GameObject[] pantheon = new GameObject[amountToPool];
        for(int i = 0; i < amountToPool; i++){
            pantheon[i] = characterPooled[i];
        }

        return pantheon;
    }
}