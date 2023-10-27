using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public TextMeshProUGUI Count_L;
    public TextMeshProUGUI Count_R;

    public Vector2 initialVelocity;
    private float multipliedBounceSpeed;

    private Vector3 initialPosition;
    private float minimumBallSpeed = 7.5f;
    private float countBallCollisions;

    private float points_L = 0;
    private float points_R = 0;

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
        GivePoints(collision);
        NextRound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //add speed to ball after each collision
        AddBounceSpeed();

        //add random y velocity, when y = 0
        AddRandomVelocity();

        //set x velocity to minimum ball speed on x
        if (rigidbody2D.velocity.x <= minimumBallSpeed && rigidbody2D.velocity.x >= 0)
        {
            rigidbody2D.velocity = new Vector2(minimumBallSpeed * multipliedBounceSpeed, rigidbody2D.velocity.y);
        }
        else if(rigidbody2D.velocity.x >= -minimumBallSpeed && rigidbody2D.velocity.x <= 0)
        {
            rigidbody2D.velocity = new Vector2(-minimumBallSpeed * multipliedBounceSpeed, rigidbody2D.velocity.y);
        }
    }

    private void AddBounceSpeed()
    {
        countBallCollisions++;

        if (rigidbody2D.velocity.x <= 10f)
        {
            //add speed to ball after each collision
            multipliedBounceSpeed = (countBallCollisions / 120) + 1f;
            rigidbody2D.velocity *= multipliedBounceSpeed;
        }
    }

    private void AddRandomVelocity()
    {
        if (rigidbody2D.velocity.y <= 0.5)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Random.Range(-1.75f, 1.75f));
        }
    }

    private void EndRound()
    {
        countBallCollisions = 0;
    }

    private void GivePoints(Collider2D collision2D)
    {
        if(collision2D.CompareTag("PlayerLeft"))
        {
            points_R++;
            Count_R.text = "" + points_R;
        }
        if(collision2D.CompareTag("PlayerRight"))
        {
            points_L++;
            Count_L.text = "" + points_L;
        }
    }

    private void NextRound()
    {
        transform.position = initialPosition;
        rigidbody2D.velocity = new Vector2(-Mathf.Sign(rigidbody2D.velocity.x) * minimumBallSpeed, rigidbody2D.velocity.y);
    }
}