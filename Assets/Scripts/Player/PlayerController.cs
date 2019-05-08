using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject body;
    
    public float crouchSpeed;
    public bool isCrouching;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    private float _defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _defaultSpeed = speed;
        isCrouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = moveInput.normalized * speed;

        if (Input.GetButton("Crouch"))
        {
            Crouch();
        }
        else
        {
            Stand();
        }
    }


    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

    private void Crouch()
    {
        speed = crouchSpeed;
        isCrouching = true;
        body.GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    private void Stand()
    {
        isCrouching = false;
        speed = _defaultSpeed;
        body.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
