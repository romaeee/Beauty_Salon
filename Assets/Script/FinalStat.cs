using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalStat : MonoBehaviour
{
    public Text custPerDay;
    public Text monPerDay;
    public Text repPerDay;
    public Text renPerDay;


    void Update()
    {
        custPerDay.text = "Customers: " + GameManager.customersPerDay.ToString();
        monPerDay.text = "Money: +" + GameManager.moneyPerDay.ToString();
        if (GameManager.totalCustomers != 0)
        {
            repPerDay.text = "Reputation: " + Mathf.Round(GameManager.reputationPerDay / GameManager.totalCustomers * 100).ToString() + "%";
            
        }
        else
        {
            repPerDay.text = "Reputation: 0%";
        }
        renPerDay.text = "Rent: " + (-GameManager.rent).ToString();
    }

    public void NextDay()
    {
        GameManager.money -= GameManager.rent;
        
        PlayerPrefs.SetInt("money", GameManager.money);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("respect", GameManager.reputationPerDay);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("customers", GameManager.totalCustomers);
        PlayerPrefs.Save();

        GameManager.customersPerDay = 0;
        GameManager.moneyPerDay = 0;
        //GameManager.reputationPerDay = 0;

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        GameManager.day += 1;
        PlayerPrefs.SetInt("day", GameManager.day);
        PlayerPrefs.Save();
    }

}
