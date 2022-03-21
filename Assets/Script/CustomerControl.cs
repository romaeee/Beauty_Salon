using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerControl : MonoBehaviour
{
    public float speed = 10f;
    public Text num = null;
    public static int myNumber = 0;

    public GameObject good;
    public GameObject bad;


    //private SpriteRenderer sprite1;

    Vector2 finalPosition = new Vector2(0.72f, -3f);
    Vector2 exitPosition = new Vector2(2.2f, 1);


    void Start()
    {
        //sprite1 = GetComponent<SpriteRenderer>();
        myNumber = Random.Range(1, 4);
        GameManager.task = true;
        GameManager.customerNumber = myNumber;
        GameManager.rate = false;
    }

    void Update()
    {
        if (!GameManager.workingDay)
        {
            Destroy(gameObject);
        }

        if (!GameManager.done && GameManager.task && (Vector2)transform.position != finalPosition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, finalPosition, step);
        }
        else if(!GameManager.done && GameManager.task && (Vector2)transform.position == finalPosition)
        {
            speed = 0;
            num.text = myNumber.ToString();
            StartCoroutine(Waiting());
        }

        if (GameManager.rate && GameManager.customerNumber == GameManager.myNumber)
        {
            //Debug.Log("Good");
            good.SetActive(true);
            
        }
        else if (GameManager.rate && GameManager.customerNumber != GameManager.myNumber)
        {
            bad.SetActive(true);
            //Debug.Log("Bad");
            
        }

        if (!GameManager.game && GameManager.done && GameManager.done && (Vector2)transform.position != exitPosition)
        {
            float step = 2 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position = Vector2.MoveTowards(transform.position, exitPosition, step);
            num.text = "";
        }
        else if(!GameManager.game && GameManager.done && (Vector2)transform.position == exitPosition)
        {
            GameManager.done = false;
            Destroy(gameObject);
            
        }
    }
    IEnumerator Waiting()
    {
        GameManager.task = false;
        yield return new WaitForSeconds(2);
        GameManager.game = true;
    }
}
