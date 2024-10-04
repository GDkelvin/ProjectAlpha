using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeploymentBar : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float fillSpeed = 0f;
    private float timer;
    private float resetBarTimer = 1f;
    private float targetProgress = 0;

    
    
    private void Start()
    {
        IncrementProgress(1f);
    }

    private void Update() 
    {
        timer += Time.deltaTime;

        if (image.fillAmount < targetProgress)
        {
            image.fillAmount += fillSpeed * Time.deltaTime;
        }

        if (timer >= resetBarTimer)
        {
            ResetProgressBar();
            timer = 0f; 
        }
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = Mathf.Clamp(image.fillAmount + newProgress, 0, 1);
    }

     private void ResetProgressBar()
    {
        image.fillAmount = 0; // Reset to the beginning
        IncrementProgress(1f); // Start filling again
    }
}
