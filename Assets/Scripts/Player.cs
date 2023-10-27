using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public float speed = 5f;

    private float input;
    private string axis;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(CompareTag("PlayerLeft"))
        {
            axis = "Vertical_P1";
        }
        else
        {
            axis = "Vertical_P2";
        }
    }

    private void Update()
    {
            input = Input.GetAxis(axis);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(0, input * speed);
    }
}