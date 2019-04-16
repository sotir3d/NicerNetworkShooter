using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    public float speed;

    public GameObject bulletPrefab;
    public Transform spawnPointW;
    public Transform spawnPointD;
    public Transform spawnPointA;
    public Transform spawnPointS;

    private Rigidbody2D rb2d;       

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Instantiate(bulletPrefab, spawnPointW.position, Quaternion.identity);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                Instantiate(bulletPrefab, spawnPointD.position, Quaternion.identity);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                Instantiate(bulletPrefab, spawnPointA.position, Quaternion.identity);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                Instantiate(bulletPrefab, spawnPointS.position, Quaternion.identity);
            }
        }
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb2d.AddForce(movement * speed);
        }
    }
}
