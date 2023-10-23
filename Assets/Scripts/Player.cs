using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public float speed = 5f;

    private float input;
    private bool isPlayerLeft;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(CompareTag("PlayerLeft"))
        {
            isPlayerLeft = true;
        }
    }

    private void Update()
    {
        if (isPlayerLeft)
        {
            float input_01;
            if (Input.GetKey(KeyCode.W))
                input_01 = 1;
            else if (Input.GetKey(KeyCode.S))
                input_01 = -1;
        } else
        {
            float input_02;
            if (Input.GetKey(KeyCode.UpArrow))
                input_02 = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                input_02 = -1;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(0, input * speed);
    }
}