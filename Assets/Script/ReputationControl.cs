using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationControl : MonoBehaviour
{
    public Text repText;


    void Update()
    {
        if(GameManager.totalCustomers != 0)
        {
            repText.text = Mathf.Round(GameManager.reputationPerDay / GameManager.totalCustomers * 100).ToString() + "%";
        }
        else
        {
            repText.text = "0%";
        }
    }
}
