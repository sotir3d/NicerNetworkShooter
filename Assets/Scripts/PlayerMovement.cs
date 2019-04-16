using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed;

    private Rigidbody2D _rigidBody2D;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(horizontal, vertical, 0f);

            //transform.position += movement * Time.deltaTime * moveSpeed;

            _rigidBody2D.velocity = new Vector3(horizontal, vertical, 0f) * Time.fixedDeltaTime * moveSpeed;
        }
    }
}
