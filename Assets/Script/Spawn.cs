using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public List<GameObject> customers = new List<GameObject>();
    public static bool done = false;

    private int lastCustID;


    private void Update()
    {
        if (GameObject.FindWithTag("Customer") == null && GameManager.workingDay)
        {
            var i = Random.Range(0, customers.Count);

            if (lastCustID != i)
            {
                Instantiate(customers[i], gameObject.transform.position, gameObject.transform.rotation);
                lastCustID = i;
            }
        }
    }
}
