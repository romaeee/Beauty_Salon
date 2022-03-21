using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailBarControl : MonoBehaviour
{
    public int sortingOrder = 0;
    public GameObject player = null;
    private SpriteRenderer sprite1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > -4f)
        {
            sprite1.sortingOrder = 7;
        }
        else
        {
            sprite1.sortingOrder = 1;
        }
    }
}
