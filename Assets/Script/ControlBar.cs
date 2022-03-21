using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBar : MonoBehaviour
{
    public int sortingOrder = 0;
    public GameObject player = null;
    private SpriteRenderer sprite;


    private const float doubleClickTime = .2f;
    private float lastClickTime;


    Touch touch;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime && touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        player.transform.position = new Vector2(-0.52f, -0.74f);
                        Debug.Log("Lets work");
                    }
                }
            }

            lastClickTime = Time.time;
        }

        if (player.transform.position.y > -1.2f)
        {
            sprite.sortingOrder = 6;
        }
        else
        {
            sprite.sortingOrder = 4;
        }

        
            
    }
}
