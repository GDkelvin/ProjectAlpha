using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomolyBar : MonoBehaviour
{
    [SerializeField] private Anomoly enermyAnomoly;
    [SerializeField] private Image totalAnomolyBar;
    [SerializeField] private Image currentAnomolyBar;
    // Start is called before the first frame update
    void Start()
    {
        totalAnomolyBar.fillAmount = enermyAnomoly.currentAnomoly / enermyAnomoly.startingAnomoly;
    }

    // Update is called once per frame
    void Update()
    {
        currentAnomolyBar.fillAmount = enermyAnomoly.currentAnomoly / enermyAnomoly.startingAnomoly;
    }
}
