using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] Sprite[] characterSprites;
    [SerializeField] SpriteRenderer characterSilhouette;

    GameObject[] characterToSpawn;

    private void Start()
    {
        characterSilhouette.sprite = null;
    }

    private void Update()
    {
        CharacterSilhouettePos();
        AddCharacter();
    }

    void CharacterSilhouettePos()
    {
        Vector2 cursorloc = Input.mousePosition;
        Vector2 cursorworldpos = Camera.main.ScreenToWorldPoint(cursorloc);
        characterSilhouette.transform.position = cursorworldpos;
    }

    public void PickCharacter(int characterNum)
    {
        characterSilhouette.sprite = characterSprites[characterNum];
        if(characterNum == 0){
            characterToSpawn = ObjectPooling.instance.GetPantheonToPool();
            Debug.Log("picked");
        }
    }

    void AddCharacter()
    {
        if(characterSilhouette.sprite != null){
            if(Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space)){
                Debug.Log("space");
                for(int i = 0; i < characterToSpawn.Length; i++){
                    if(!characterToSpawn[i].activeInHierarchy){
                        characterToSpawn[i].SetActive(true);
                        characterToSpawn[i].transform.position = (Vector2)characterSilhouette.transform.position;
                        characterSilhouette.sprite = null;
                        break;
                    }
                }
            }
        }
    }


}
