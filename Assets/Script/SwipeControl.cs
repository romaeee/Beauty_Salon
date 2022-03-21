using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour
{
    //public Text outputText;

    public float swipeRange;
    public float tapRange;

    public static bool moveLeft = false;
    public static bool moveRight = false;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;


    void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            moveLeft = false;
            moveRight = false;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch && GameManager.game)
            {
                if (Distance.x < -swipeRange)
                {
                    //outputText.text = "Left";
                    moveLeft = true;
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    //outputText.text = "Right";
                    moveRight = true;
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
        }
    }
}

