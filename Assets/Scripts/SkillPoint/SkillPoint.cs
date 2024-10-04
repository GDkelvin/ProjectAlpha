using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoint : MonoBehaviour
{
    int maxSkillPoint = 5;
    int currentSkillPoint = 0;
    float coolDownTimer = 20f;
    float timer = 0f;

    private void Update()
    {
        if(currentSkillPoint < maxSkillPoint ){
            timer += Time.deltaTime;

            if(timer >= coolDownTimer){
                GainSkillPoint();
                timer = 0f;
            }
        }
    }

    private void GainSkillPoint()
    {
        if(currentSkillPoint < maxSkillPoint){
            currentSkillPoint++;
            Debug.Log("Skill Point Gained! Total Skill Points: " + currentSkillPoint);
        }
    }
    
}
