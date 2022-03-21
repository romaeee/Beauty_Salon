using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoubleClick : MonoBehaviour
{

	[SerializeField]
	float moveSpeed = 5f;


	Rigidbody2D rb;

	Touch touch;
	Vector3 touchPosition, whereToMove;
	bool isMoving = false;

	float previousDistanceToTouchPos, currentDistanceToTouchPos;


	private const float doubleClickTime = .2f;
	private float lastClickTime;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (isMoving)
        {
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
		}
		

		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);



			float timeSinceLastClick = Time.time - lastClickTime;

			if (timeSinceLastClick <= doubleClickTime && touch.phase == TouchPhase.Began && touch.position.y < 900)
            {
				previousDistanceToTouchPos = 0;
				currentDistanceToTouchPos = 0;
				isMoving = true;
				touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
				touchPosition.z = 0;
				whereToMove = (touchPosition - transform.position).normalized;
				rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);
			}

			lastClickTime = Time.time;
		}

		if (currentDistanceToTouchPos > previousDistanceToTouchPos)
		{
			isMoving = false;
			rb.velocity = Vector2.zero;
		}

		if (isMoving)
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;

		
		if(touchPosition.x < transform.position.x)
        {
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
        else
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		
	}
}
