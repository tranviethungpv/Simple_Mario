using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 100.0f;
    private float distance = 100.0f;

    private float startingPosition;
    private bool movingRight = true;

    private float lastHorizontalInput;
    private void Start()
    {
        startingPosition = transform.position.x;
    }

    private void Update()
    {
        float currentPosition = transform.position.x;
        float newPosition = currentPosition + (movingRight ? speed * Time.deltaTime : -speed * Time.deltaTime);
        float distanceTravelled = Mathf.Abs(newPosition - startingPosition);

        if (distanceTravelled >= distance)
        {
            movingRight = !movingRight;
        }

        transform.position = new Vector2(newPosition, transform.position.y);

    }
}
