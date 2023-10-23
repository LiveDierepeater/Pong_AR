using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public Vector2 initialVelocity;
    private float multipliedBounceSpeed;

    private Vector3 initialPosition;
    private float minimumBallSpeed = 7.5f;
    private float countBallCollisions;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        rigidbody2D.velocity = initialVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndRound();
        NextRound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //add speed to ball after each collision
        AddBounceSpeed();

        //set x velocity to minimum ball speed on x
        if (rigidbody2D.velocity.x <= minimumBallSpeed && rigidbody2D.velocity.x >= 0)
        {
            rigidbody2D.velocity = new Vector2(minimumBallSpeed * multipliedBounceSpeed, rigidbody2D.velocity.y);
            print("velocity.x: " + rigidbody2D.velocity.x);
        }
        else if(rigidbody2D.velocity.x >= -minimumBallSpeed && rigidbody2D.velocity.x <= 0)
        {
            rigidbody2D.velocity = new Vector2(-minimumBallSpeed * multipliedBounceSpeed, rigidbody2D.velocity.y);
            print("velocity.x: " + rigidbody2D.velocity.x);
        }
    }

    private void AddBounceSpeed()
    {
        //add speed to ball after each collision
        countBallCollisions++;
        multipliedBounceSpeed = (countBallCollisions/120) + 1f;
        rigidbody2D.velocity *= multipliedBounceSpeed;
    }

    private void EndRound()
    {
        countBallCollisions = 0;
    }

    private void NextRound()
    {
        transform.position = initialPosition;
        rigidbody2D.velocity = new Vector2(-Mathf.Sign(rigidbody2D.velocity.x) * minimumBallSpeed, rigidbody2D.velocity.y);
    }
}