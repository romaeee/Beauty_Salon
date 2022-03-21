using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameControl : MonoBehaviour
{
    public GameObject card1, card2, card3;
    public GameObject buttons;
    private int GuessNum;

    public List<GameObject> cards;

    void Start()
    {
    }

    void Update()
    {
        if (SwipeControl.moveLeft)
        {
            SwipeControl.moveLeft = false;
            NoBtn();
        }
        if (SwipeControl.moveRight)
        {
            SwipeControl.moveRight = false;
            YesBtn();
        }

        if (!GameManager.workingDay)
        {
            GameManager.rate = true;
            GameManager.done = true;
            GameManager.game = false;
            gameObject.SetActive(false);
            card1.SetActive(true);
            card2.SetActive(false);
            card3.SetActive(false);
        }
    }
    public void NoBtn()
    {
        
        if (card1.activeInHierarchy)
        {
            card1.SetActive(false);
            card2.SetActive(true);
            card3.SetActive(false);
        }
        else if (card2.activeInHierarchy)
        {
            card1.SetActive(false);
            card2.SetActive(false);
            card3.SetActive(true);
        }
        else if (card3.activeInHierarchy)
        {
            card1.SetActive(true);
            card2.SetActive(false);
            card3.SetActive(false);
        }
    }
    public void YesBtn()
    {
        if (card1.activeInHierarchy)
        {
            GuessNum = 1;
        }
        else if (card2.activeInHierarchy)
        {
            GuessNum = 2;
        }
        else if (card3.activeInHierarchy)
        {
            GuessNum = 3;
        }
        GameManager.myNumber = GuessNum;

        if (GameManager.customerNumber == GameManager.myNumber)
        {
            GameManager.reputationPerDay += 1;
            GameManager.money += 25;
            GameManager.moneyPerDay += 25;
        }
        else if (GameManager.customerNumber != GameManager.myNumber)
        {
        }

        GameManager.customersPerDay += 1;
        GameManager.totalCustomers += 1;


        GameManager.rate = true;
        GameManager.done = true;
        GameManager.game = false;
        gameObject.SetActive(false);
        card1.SetActive(true);
        card2.SetActive(false);
        card3.SetActive(false);
    }
}
