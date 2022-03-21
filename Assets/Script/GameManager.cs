using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool game;
    public static bool done;
    public static bool task;

    public static int day = 1;
    public static bool workingDay;
    public GameObject stat;

    public static int money = 0;
    //public static float respect = 0;

    public Text moneyText;

    public static bool rate;

    public GameObject miniGame;

    public static int customerNumber;
    public static int myNumber;

    public static float customersPerDay = 0;
    public static int moneyPerDay = 0;
    public static float reputationPerDay = 0;
    public static int rent = 50;

    public static float totalCustomers = 0;
    public static float totalReputation = 0;

    private int GuessNumber;

    private void Start()
    {
        workingDay = true;
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        if (PlayerPrefs.HasKey("respect"))
        {
            reputationPerDay = PlayerPrefs.GetFloat("respect");
        }
        if (PlayerPrefs.HasKey("day"))
        {
            day = PlayerPrefs.GetInt("day");
        }
        if (PlayerPrefs.HasKey("customers"))
        {
            totalCustomers = PlayerPrefs.GetFloat("customers");
        }
    }

    private void Update()
    {
        if (game)
        {
            miniGame.SetActive(true);
        }

        moneyText.text = money.ToString();

        if (!workingDay)
        {
            stat.SetActive(true);
        }
    }
    
}
